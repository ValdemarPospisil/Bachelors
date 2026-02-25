# Specification: Update Thesis Chapter 2 (Analysis and Requirements)

## Overview
This track involves rewriting sections of `thesis/chapters/02_analyza.tex` to accurately reflect the updated architecture and functionality of the GoodAccess CLI. The focus is on expanding the stakeholders, adding a Use Case diagram, and redefining the functional requirements.

## Stakeholders (Identifikace zúčastněných stran)
Keep the existing stakeholders and add a new group:
- **Běžní zaměstnanci (Normal Employees):** Users who prefer the Terminal User Interface (TUI) over the graphical client (GUI) for daily tasks.

## Use Case Diagram
Include the Use Case diagram referencing `images/use-case.png` and add the provided PlantUML source code to the thesis text.

## Functional Requirements (Funkční požadavky)
Rewrite the functional requirements section to include the following commands and behaviors:

- **Login**: Remove mentions of Device Code Flow. Standard terminal input for team, username, and password. Password input is masked (visualized as `*`). Explicitly mention that web-based SSO is not supported directly in the terminal.
- **Logout**: Standard session termination.
- **Connect**: Connects using the preferred protocol and gateway.
- **Disconnect**: Standard session termination.
- **Persistent Connect**: Device-wide connection that automatically reconnects after a PC restart.
- **Gateway Selection**: Ability to select a specific VPN gateway.
- **Protocol Selection**: Ability to choose the VPN protocol (WireGuard or OpenVPN).
- **Status**: Display current status, with an option to output in JSON format.
- **Řešení konfliktů (Conflict Resolution)**: The system must detect conflicts. If an active session is in the GUI or another user is connected on the same machine, the CLI client must warn the user and **strictly prevent** overwriting the network state.
- **Setup**: A strictly interactive onboarding wizard. Allows the user to log in, select protocol, select gateway, set persistence, and connect in a single flow.
- **Connect Flags**: Users can connect using `-g` (gateway) or `-p` (protocol) flags to override their preferred settings temporarily (without saving them). `--protocol` expects a string name, while `--gateway` triggers interactive selection.
- **Version**: Displays the application version.
- **Help**: Displays standard help text.