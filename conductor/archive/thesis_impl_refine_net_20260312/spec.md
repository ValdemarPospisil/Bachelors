# Specification: Refine Implementation Chapter - .NET Service Subchapters

## Overview
The goal of this track is to refine the second subchapter of the Implementation chapter (`thesis/chapters/04_implementace.tex`), focusing on the `.NET` service implementation. The refinement will create stronger linkages to the design chapter (`03_navrh.tex`) and add concrete code snippets and diagrams to better illustrate the implementation.

## Functional Requirements
- **Secure Storage Refinement:**
  - Update the "Bezpečné úložiště (Secure Storage)" section to explicitly reference section "3.4 Správa dat a bezpečnostní model (Implementace zabezpečeného úložiště)".
  - Verify the description against `doc/code/CliStorage.cs` and `doc/code/Program.cs` to ensure accuracy.
- **IPC Server Refinement:**
  - Update the "IPC Server (Unix Domain Sockets)" section to explicitly reference section "3.2 Návrh komunikace IPC".
  - Insert the diagram `thesis/images/implementation/diagrams/ipc-diagram.png` where the TODO marker is currently located, formatted consistently with previous figures.
- **CliMessenger Refinement:**
  - Update the "Zpracování příkazů (CliMessenger)" section to reference section "3.2 Návrh komunikace IPC" (specifically the JSON message examples).
  - Explain that `CliMessenger` handles the commands defined in the referenced design section.
  - Insert a code snippet from `doc/code/CliMessenger.cs` lines 194-226 using `lstinputlisting` and provide an explanatory text for it.
- **Lifecycle and systemd Refinement:**
  - Update the "Životní cyklus a integrace se systemd" section.
  - Insert a code snippet from `doc/code/Program.cs` lines 33-46 using `lstinputlisting` and provide an explanatory text for it.

## Non-Functional Requirements
- Ensure references use standard LaTeX referencing mechanisms (`\ref` or similar) to maintain document integrity.
- Code snippets must use the standard `lstinputlisting` environment with correct line numbers, maintaining the style of existing snippets.
- The tone of the newly added text should remain consistent with the rest of the thesis (written in Czech from the perspective of a 23-year-old IT student).
- The changes must be syntactically correct LaTeX code and compile without errors.

## Acceptance Criteria
- [ ] `thesis/chapters/04_implementace.tex` is updated with the new references, text, diagrams, and code snippets.
- [ ] The descriptions align with the actual code in the provided `doc/code/` files.
- [ ] The document compiles successfully.

## Out of Scope
- Modifying the Go frontend implementation subchapters.
- Modifying other chapters besides `04_implementace.tex` (unless adding a label for referencing is strictly necessary).
