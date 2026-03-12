package setup

import (
	"fmt"

	"ga-cli/internal/ipc"
	"ga-cli/internal/model"
	"ga-cli/internal/service"
	"ga-cli/internal/tui/connect"
	"ga-cli/internal/tui/login"

	"github.com/charmbracelet/bubbles/spinner"
	tea "github.com/charmbracelet/bubbletea"
)

type gatewaysLoadedMsg []model.GatewayResponse
type configSavedMsg struct{}
type errorMsg struct{ err error }

func (e errorMsg) Error() string { return e.err.Error() }

func checkLoginStatusCmd(client ipc.Client) tea.Cmd {
	return func() tea.Msg {
		state, err := service.GetAppState(client)
		if err != nil {
			return AppStateMsg{Err: err}
		}

		return CheckLoginMsg{
			IsLoggedIn:             state.IsLoggedIn,
			IsConnected:            state.IsConnected,
			UserName:               state.UserName,
			IsAnotherUserConnected: state.IsAnotherUserConnected,
		}
	}
}

func fetchGatewaysCmd(client ipc.Client) tea.Cmd {
	return func() tea.Msg {
		rawResponse, err := client.Send("get_gateways", nil)
		if err != nil {
			return errorMsg{err: fmt.Errorf("network error: %w", err)}
		}
		data, err := ipc.Unpack[[]model.GatewayResponse](rawResponse)
		if err != nil {
			return errorMsg{err: err}
		}
		return gatewaysLoadedMsg(*data)
	}
}

func saveConfigCmd(client ipc.Client, payload model.SaveConfigPayload) tea.Cmd {
	return func() tea.Msg {
		_, err := client.Send("save_config", payload)
		if err != nil {
			return errorMsg{err: err}
		}
		return configSavedMsg{}
	}
}

func (m Model) Update(msg tea.Msg) (tea.Model, tea.Cmd) {
	var cmds []tea.Cmd

	switch msg := msg.(type) {

	case tea.KeyMsg:
		if msg.Type == tea.KeyCtrlC {
			return m, tea.Quit
		}

	case errorMsg:
		m.err = msg.err
		return m, nil

	case spinner.TickMsg:
		var sCmd tea.Cmd
		m.Spinner, sCmd = m.Spinner.Update(msg)
		return m, sCmd

	case CheckLoginMsg:
		if msg.IsAnotherUserConnected {
			m.err = fmt.Errorf("connected_by_other_user")
			return m, tea.Quit
		} else if msg.IsConnected {
			m.UserName = msg.UserName
			m.CurrentStep = StepConfirmDisconnect
			m.cursor = 0
		} else if msg.IsLoggedIn {
			m.UserName = msg.UserName
			if m.GatewayOnly {
				m.SelectedProtocol = "WireGuard"
				m.CurrentStep = StepFetchGateways
				cmds = append(cmds, fetchGatewaysCmd(m.client))
			} else {
				m.CurrentStep = StepProtocol
			}
			m.cursor = 0
		} else {
			m.CurrentStep = StepLogin
			cmds = append(cmds, m.LoginModel.Init())
		}

	case login.LoginSuccessMsg:
		if m.GatewayOnly {
			m.SelectedProtocol = "WireGuard"
			m.CurrentStep = StepFetchGateways
			cmds = append(cmds, fetchGatewaysCmd(m.client))
		} else {
			m.CurrentStep = StepProtocol
		}
		m.cursor = 0
		m.cursor = 0
		return m, tea.Batch(cmds...)

	case gatewaysLoadedMsg:
		m.AvailableGateways = msg
		m.CurrentStep = StepGateway
		m.cursor = 0
		return m, nil

	case configSavedMsg:
		m.CurrentStep = StepConnect
		m.cursor = 0
		return m, nil

	case connect.ConnectionSuccessMsg:
		m.CurrentStep = StepSuccess
		m.WasConnected = true
		return m, tea.Quit

	case connect.ErrorMsg:
		m.err = msg
		return m, nil

	case DisconnectSuccessMsg:
		if m.GatewayOnly {
			m.SelectedProtocol = "WireGuard"
			m.CurrentStep = StepFetchGateways
			cmds = append(cmds, fetchGatewaysCmd(m.client))
		} else {
			m.CurrentStep = StepProtocol
		}
		m.cursor = 0
		m.cursor = 0
		return m, tea.Batch(cmds...)
	}

	switch m.CurrentStep {

	case StepLogin:
		newLoginModel, loginCmd := m.LoginModel.Update(msg)
		m.LoginModel = newLoginModel.(*login.Model)
		cmds = append(cmds, loginCmd)

	case StepConfirmDisconnect:
		if msg, ok := msg.(tea.KeyMsg); ok {
			count := len(m.DisconnectOptions)
			switch msg.String() {
			case "up", "k":
				m.cursor = (m.cursor - 1 + count) % count
			case "down", "j":
				m.cursor = (m.cursor + 1) % count
			case "enter":
				if m.cursor == 0 { // Yes
					m.CurrentStep = StepDisconnecting
					cmds = append(cmds, disconnectCmd(m.client))
				} else { // No
					return m, tea.Quit
				}
			}
		}

	case StepProtocol:
		if msg, ok := msg.(tea.KeyMsg); ok {
			count := len(m.Protocols)
			switch msg.String() {
			case "up", "k":
				m.cursor = (m.cursor - 1 + count) % count
			case "down", "j":
				m.cursor = (m.cursor + 1) % count
			case "enter":
				m.SelectedProtocol = m.Protocols[m.cursor]
				m.CurrentStep = StepFetchGateways
				cmds = append(cmds, fetchGatewaysCmd(m.client))
			}
		}

	case StepGateway:
		if msg, ok := msg.(tea.KeyMsg); ok {
			count := len(m.AvailableGateways)
			if count > 0 {
				switch msg.String() {
				case "up", "k":
					m.cursor = (m.cursor - 1 + count) % count
				case "down", "j":
					m.cursor = (m.cursor + 1) % count
				case "enter":
					m.SelectedGateway = m.AvailableGateways[m.cursor]
					if m.GatewayOnly {
						m.IsPersistent = true
						m.CurrentStep = StepSaving
						cmds = append(cmds, m.saveData())
					} else {
						m.CurrentStep = StepPersistent
					}
					m.cursor = 0
				}
			}
		}

	case StepPersistent:
		if msg, ok := msg.(tea.KeyMsg); ok {
			count := len(m.PersistentOptions)
			switch msg.String() {
			case "up", "k":
				m.cursor = (m.cursor - 1 + count) % count
			case "down", "j":
				m.cursor = (m.cursor + 1) % count
			case "enter":
				// 0 = Yes, 1 = No
				m.IsPersistent = (m.cursor == 0)
				m.CurrentStep = StepSaving
				cmds = append(cmds, m.saveData())
			}
		}

	case StepConnect:
		if msg, ok := msg.(tea.KeyMsg); ok {
			count := len(m.ConnectOptions)
			switch msg.String() {
			case "up", "k":
				m.cursor = (m.cursor - 1 + count) % count
			case "down", "j":
				m.cursor = (m.cursor + 1) % count
			case "enter":
				// 0 = Yes, 1 = No
				if m.cursor == 0 {
					m.CurrentStep = StepConnecting
					cmds = append(cmds, connect.ConnectCmd(m.client, m.SelectedProtocol, ""))
				} else {
					m.CurrentStep = StepSuccess
					return m, tea.Quit
				}
			}
		}
	}

	return m, tea.Batch(cmds...)
}

func (m Model) saveData() tea.Cmd {
	payload := model.SaveConfigPayload{
		GatewayID:          m.SelectedGateway.ID,
		GatewayName:        m.SelectedGateway.Name,
		GatewayIP:          m.SelectedGateway.IP,
		GatewayCountryCode: m.SelectedGateway.CountryCode,
		Protocol:           m.SelectedProtocol,
		Persistent:         m.IsPersistent,
	}
	return saveConfigCmd(m.client, payload)
}
