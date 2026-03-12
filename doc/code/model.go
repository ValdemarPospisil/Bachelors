package setup

import (
	"ga-cli/internal/ipc"
	"ga-cli/internal/model"
	"ga-cli/internal/tui/login"
	"ga-cli/internal/tui/style"

	"github.com/charmbracelet/bubbles/spinner"
	tea "github.com/charmbracelet/bubbletea"
)

type Step int

type CheckLoginMsg struct {
	IsLoggedIn             bool
	IsConnected            bool
	UserName               string
	IsAnotherUserConnected bool
}

type AppStateMsg struct {
	IsLoggedIn  bool
	IsConnected bool
	Err         error
}

type DisconnectSuccessMsg string

const (
	StepCheckLogin Step = iota
	StepConfirmDisconnect
	StepDisconnecting
	StepLogin
	StepProtocol
	StepFetchGateways
	StepGateway
	StepPersistent
	StepSaving
	StepConnect
	StepConnecting
	StepSuccess
)

type Model struct {
	client      ipc.Client
	CurrentStep Step

	LoginModel *login.Model
	Spinner    spinner.Model

	Protocols        []string
	SelectedProtocol string

	AvailableGateways []model.GatewayResponse
	SelectedGateway   model.GatewayResponse

	PersistentOptions []string
	IsPersistent      bool

	DisconnectOptions []string
	ConnectOptions    []string

	cursor int
	err    error

	UserName     string
	WasConnected bool
	GatewayOnly  bool
}

func New(client ipc.Client, gatewayOnly bool) Model {
	s := spinner.New()
	s.Spinner = spinner.Dot
	s.Style = style.TitleStyle

	lm := login.New(client)

	return Model{
		client:      client,
		CurrentStep: StepCheckLogin,

		LoginModel: &lm,
		Spinner:    s,

		Protocols:         []string{"WireGuard", "OpenVPN"},
		PersistentOptions: []string{"Yes (Connect automatically after system restart)", "No (Manual connection)"},
		DisconnectOptions: []string{"Yes, disconnect and continue", "No, cancel"},
		ConnectOptions:    []string{"Yes, connect now", "No, save and exit"},

		GatewayOnly: gatewayOnly,
	}
}

func (m Model) Init() tea.Cmd {
	return tea.Batch(
		checkLoginStatusCmd(m.client),
		m.Spinner.Tick,
	)
}

func disconnectCmd(client ipc.Client) tea.Cmd {
	return func() tea.Msg {
		_, err := client.Send("disconnect", nil)
		if err != nil {
			return errorMsg{err: err}
		}
		return DisconnectSuccessMsg("Disconnected")
	}
}
