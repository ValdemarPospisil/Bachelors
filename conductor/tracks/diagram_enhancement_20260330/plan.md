# Implementation Plan - Diagram Enhancement

## Phase 1: Preparation & Asset Verification [checkpoint: 80e017c]
- [x] Task: Verify existence of external assets. [bcdcf60]
    - [ ] Check `doc/diagrams/Sequence - Login.svg`
    - [ ] Check `thesis/images/command-tree.png`
- [x] Task: Conductor - User Manual Verification 'Phase 1' (Protocol in workflow.md)

## Phase 2: Create Mermaid Diagrams [checkpoint: b358bfe]
- [x] Task: Draft Mermaid Class Diagram. [4032e5e]
    - [ ] Define components for Go CLI side.
    - [ ] Define components for .NET Service side.
    - [ ] Define IPC/UDS relationship.
    - [ ] Verify diagram syntax using a Mermaid live editor.
- [x] Task: Draft Mermaid State Diagram. [30acf8e]
    - [ ] Define connection states (Disconnected, Connecting, Connected, etc.).
    - [ ] Define transitions based on `VpnService` logic.
    - [ ] Verify diagram syntax.
- [x] Task: Conductor - User Manual Verification 'Phase 2' (Protocol in workflow.md)

## Phase 3: README.md Updates
- [x] Task: Replace high-level architecture diagram. [d88268a]
    - [ ] Locate "Celkové schéma" in `README.md`.
    - [ ] Replace with the new Mermaid Class Diagram.
- [~] Task: Replace IPC sequence diagram.
    - [ ] Locate "IPC Komunikace" in `README.md`.
    - [ ] Replace with reference to `doc/diagrams/Sequence - Login.svg`.
- [ ] Task: Replace command hierarchy diagram.
    - [ ] Locate "Hierarchie příkazů" in `README.md`.
    - [ ] Replace with reference to `thesis/images/command-tree.png`.
- [ ] Task: Add connection state diagram.
    - [ ] Create a new section "Stavový diagram" in `README.md`.
    - [ ] Embed the new Mermaid State Diagram.
- [ ] Task: Final README layout polish.
    - [ ] Check all links and image paths.
    - [ ] Ensure consistent formatting and spacing.
- [ ] Task: Conductor - User Manual Verification 'Phase 3' (Protocol in workflow.md)

## Phase 4: Final Verification
- [ ] Task: Manual rendering check.
    - [ ] Confirm all Mermaid diagrams render as expected.
    - [ ] Confirm all images and SVGs display correctly.
- [ ] Task: Conductor - User Manual Verification 'Phase 4' (Protocol in workflow.md)
