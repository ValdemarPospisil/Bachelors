# Specification: Refine Go Client Implementation Subchapter

## Overview
Refine the third subchapter of the Implementation chapter in the bachelor thesis, specifically focusing on the Go client application. This includes adding missing references to design and theory chapters, embedding concrete code examples, and including screenshots of the CLI tool.

## Functional Requirements
- **Go Client Chapter Refinement (`thesis/chapters/04_implementace.tex`):**
    - **Section "Parsování příkazů (Cobra)":**
        - Reference the "strom příkazů" (Command Tree) figure from the Design chapter (3.3).
        - Insert a code snippet from `doc/code/connect.go` demonstrating a Cobra command structure.
        - Provide a Czech explanation of the Cobra attributes: `Use`, `Short`, `Long`, and `RunE`.
        - Add a figure for `thesis/images/implementation/screenshots/help-command.png` illustrating the `ga-cli help` output.
    - **Section "Interaktivní terminálové rozhraní (Bubble Tea)":**
        - Reference the "Architektura Elm a framework Bubble tea" section from the Theory chapter (1).
        - Insert a code snippet from `doc/code/view.go` (lines 154-169) focusing on the "connect" step implementation.
        - Add a figure for `thesis/images/implementation/screenshots/setup-step-connect.png` and explain the visual components shown.
    - **Section "Komunikace se službou (IPC Klient)":**
        - Describe the implementation of the "request envelope" used for UDS communication.
        - Explain how the client prepares and sends these envelopes to the background service.

## Non-Functional Requirements
- Maintain consistency with the existing thesis tone (23-year-old IT student perspective).
- Use standard LaTeX environments (`figure`, `lstinputlisting`, etc.).
- Ensure all references use standard LaTeX labels (`\ref{}`, `\nameref{}`).

## Out of Scope
- Editing other implementation subchapters (e.g., .NET service or advanced features).
- Modifying source code or creating new diagrams.
