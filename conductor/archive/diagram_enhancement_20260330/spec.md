# Specification - Diagram Enhancement

## Overview
This track aims to modernize and enhance the visual documentation in the project's root `README.md`. It involves replacing outdated Mermaid diagrams with updated ones and incorporating external assets to provide a clearer understanding of the system's architecture, command structure, and runtime state transitions.

## Objectives
- Update the high-level system architecture visualization.
- Replace the IPC sequence diagram with a specialized SVG asset.
- Update the command hierarchy visualization using a high-quality image.
- Add a new Class Diagram to visualize the internal structure of the Go CLI and .NET Service.
- Add a new State Diagram to visualize the VPN connection lifecycle.

## Functional Requirements

### 1. README.md Updates
- **Replace "Celkové schéma"**: Swap the current high-level Mermaid diagram with a new **Mermaid Class Diagram** focused on the high-level architecture of the Go and .NET components.
- **Replace "IPC Komunikace"**: Replace the current Mermaid sequence diagram with the external asset `doc/diagrams/Sequence - Login.svg`.
- **Replace "Hierarchie příkazů"**: Replace the current Mermaid graph with the external asset `thesis/images/command-tree.png`.
- **Add "Stavový diagram"**: Add a new section for the VPN connection lifecycle using a **Mermaid State Diagram**.

### 2. Diagram Definitions (Mermaid)

#### Class Diagram (High-Level Architecture)
Should show:
- `Go CLI (Main)` -> `UnixClient` (Go side)
- `UnixClient` --(IPC/UDS)--> `SenderReader` (.NET side)
- `CliMessenger` -> `SenderReader`
- `CliMessenger` -> `AuthService`, `VpnService`, `GatewayService`, `UserProfileService`
- `VpnService` -> `VpnManager` -> `IAgent` (OpenVPN/WireGuard)
- `UserProfileService` -> `CliRepository` -> `CliStorage`

#### State Diagram (Connection Lifecycle)
Should show states:
- `Disconnected`
- `Connecting` (triggered by `connect` command)
- `Connected` (on success)
- `Disconnecting` (triggered by `disconnect` command)
- `Error` (on connection failure)
- Transitions between these states based on `VpnService` logic.

## Non-Functional Requirements
- **Maintainability**: New diagrams (Class and State) must use Mermaid text format for easy future edits.
- **Consistency**: The SVG and PNG assets should be correctly referenced and rendered in the GitHub README.

## Acceptance Criteria
- [ ] `README.md` is updated with the new diagrams and assets.
- [ ] "Celkové schéma" is replaced by the Mermaid Class Diagram.
- [ ] "IPC Komunikace" is replaced by `doc/diagrams/Sequence - Login.svg`.
- [ ] "Hierarchie příkazů" is replaced by `thesis/images/command-tree.png`.
- [ ] A new "Stavový diagram" is added.
- [ ] All Mermaid diagrams render correctly on GitHub.
- [ ] All image/SVG references are valid.

## Out of Scope
- Modifying actual application code.
- Updating other documentation files (e.g., in `doc/`) unless directly relevant to the README.
