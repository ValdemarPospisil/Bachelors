package setup

import (
	"fmt"
	"ga-cli/internal/tui/style"
	"strings"
)

func (m Model) View() string {
	if m.CurrentStep == StepLogin {
		return m.LoginModel.View()
	}

	s := "\n"

	if m.err != nil {
		errorMsg := m.err.Error()
		if strings.Contains(errorMsg, "connected_by_other_user") {
			s += style.ErrorStyle.Render("✖") + " " + style.ErrorStyle.Render("Another user is already connected.") + "\n"
			s += style.SubtleStyle.Render("  Run 'sudo ga-cli disconnect' first.") + "\n"
			return s
		}
		s += style.TitleStyle.Render("GoodAccess Setup Wizard") + "\n\n"
		return s + style.ErrorStyle.Render(fmt.Sprintf("Error: %v", m.err)) + "\n"
	}

	s += style.TitleStyle.Render("GoodAccess Setup Wizard") + "\n\n"

	// --- Summary Header ---
	if m.UserName != "" {
		user := m.UserName
		if user == "" {
			user = "Logged In"
		}
		s += fmt.Sprintf("✔ User:         %s\n", style.SuccessStyle.Render(user))
	}

	if m.CurrentStep > StepProtocol {
		s += fmt.Sprintf("✔ Protocol:     %s\n", style.SuccessStyle.Render(m.SelectedProtocol))
	}

	if m.CurrentStep > StepGateway {
		s += fmt.Sprintf("✔ Gateway:      %s\n", style.SuccessStyle.Render(m.SelectedGateway.Label()))
	}

	if m.CurrentStep > StepPersistent {
		status := "No"
		if m.IsPersistent {
			status = "Yes"
		}
		s += fmt.Sprintf("✔ Auto-connect: %s\n", style.SuccessStyle.Render(status))
	}

	if m.CurrentStep == StepSuccess {
		status := "Not Connected"
		st := style.SubtleStyle
		if m.WasConnected {
			status = "Connected"
			st = style.SuccessStyle
		}
		s += fmt.Sprintf("✔ Status:       %s\n", st.Render(status))
	}

	s += "\n"

	// --- Step Content ---
	switch m.CurrentStep {

	case StepCheckLogin:
		s += m.Spinner.View() + " Checking login status...\n"

	case StepConfirmDisconnect:
		s += style.SubtleStyle.Render("Step 1: Disconnect") + "\n"
		s += "You are currently connected. You cannot change preferences while connected.\n"
		s += "Do you want to disconnect and continue setup?\n\n"

		for i, opt := range m.DisconnectOptions {
			cursor := "  "
			st := style.SubtleStyle
			if i == m.cursor {
				cursor = "> "
				st = style.ValueStyle
			}
			s += fmt.Sprintf("%s%s\n", cursor, st.Render(opt))
		}

		s += "\n" + style.SubtleStyle.Render("[up/down] Select - [Enter] Confirm")

	case StepDisconnecting:
		s += m.Spinner.View() + " Disconnecting...\n"

	case StepProtocol:
		s += style.SubtleStyle.Render("Step 2: VPN Protocol") + "\n"
		s += "Select connection protocol:\n\n"

		for i, p := range m.Protocols {
			cursor := "  "
			st := style.SubtleStyle
			if i == m.cursor {
				cursor = "> "
				st = style.ValueStyle
			}
			s += fmt.Sprintf("%s%s\n", cursor, st.Render(p))
		}

		s += "\n" + style.SubtleStyle.Render("[up/down] Select - [Enter] Confirm")

	case StepFetchGateways:
		s += m.Spinner.View() + " Fetching available gateways...\n"

	case StepGateway:
		s += style.SubtleStyle.Render("Step 3: Default Gateway") + "\n"
		s += "Select your default location:\n\n"

		if len(m.AvailableGateways) == 0 {
			s += style.ErrorStyle.Render("No gateways found.") + "\n"
		} else {
			start, end := m.getPaginatorBounds()

			for i := start; i < end; i++ {
				gw := m.AvailableGateways[i]
				cursor := "  "
				st := style.SubtleStyle

				if i == m.cursor {
					cursor = "> "
					st = style.ValueStyle
				}

				s += fmt.Sprintf("%s%s\n", cursor, st.Render(gw.Label()))
			}
			s += "\n" + style.SubtleStyle.Render("[up/down] Select - [Enter] Confirm")
		}

	case StepPersistent:
		s += style.SubtleStyle.Render("Step 4: Persistence") + "\n"
		s += "Connect automatically after system restart?\n\n"

		for i, opt := range m.PersistentOptions {
			cursor := "  "
			st := style.SubtleStyle
			if i == m.cursor {
				cursor = "> "
				st = style.ValueStyle
			}
			s += fmt.Sprintf("%s%s\n", cursor, st.Render(opt))
		}

		s += "\n" + style.SubtleStyle.Render("[up/down] Select - [Enter] Confirm")

	case StepSaving:
		s += m.Spinner.View() + " Saving configuration...\n"

	case StepConnect:
		s += style.SubtleStyle.Render("Step 5: Connect") + "\n"
		s += "Do you want to connect to the VPN now?\n\n"

		for i, opt := range m.ConnectOptions {
			cursor := "  "
			st := style.SubtleStyle
			if i == m.cursor {
				cursor = "> "
				st = style.ValueStyle
			}
			s += fmt.Sprintf("%s%s\n", cursor, st.Render(opt))
		}

		s += "\n" + style.SubtleStyle.Render("[up/down] Select - [Enter] Confirm")

	case StepConnecting:
		s += m.Spinner.View() + " Connecting...\n"

	case StepSuccess:
		s += style.SuccessStyle.Render("✔ Setup Completed Successfully!") + "\n\n"
		s += style.SubtleStyle.Render("You can now run ") + style.ValueStyle.Render("ga-cli connect") + style.SubtleStyle.Render(" to start VPN.") + "\n"
	}

	return s
}

func (m Model) getPaginatorBounds() (int, int) {
	return 0, len(m.AvailableGateways)
}
