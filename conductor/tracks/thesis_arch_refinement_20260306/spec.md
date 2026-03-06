# Specification: Thesis Architecture Refinement (Chapter 3)

## Overview
This track involves updating Chapter 3 (`03_navrh.tex`) of the thesis to provide a detailed technical description of the "Thin Client (Wrapper)" architecture. It will specifically address the separation of concerns between the .NET Service and the Go Client, the rationale for technology choices, and the application of Clean Architecture principles.

## Functional Requirements
- **Separation of Concerns (SoC):**
    - **Service (.NET):** Describe its role as a `systemd` daemon running with `root` privileges. Responsibility for network state, WireGuard interface management, and secure storage.
    - **Client (Go):** Describe its role in user space (no root). Responsibility for CLI parsing (`Cobra`), interactive TUI (`Bubble Tea`), and output formatting.
- **Architectural Principles:**
    - Explain how the Go client's design adheres to "Clean Architecture" (separation of UI, logic, and IPC layers).
- **Technology Rationale & References:**
    - **Go for CLI:** Reference Chapter 1 (`\ref{sec:technologie}` or `\ref{sec:cli_teorie}`) for its benefits (static binary, performance).
    - **.NET for Service:** 
        - Reference Chapter 1 (`\ref{sec:technologie}`) for multiplatform support and `systemd` integration.
        - Reference Chapter 2 (`\ref{sec:analyza}`) for reuse of existing GUI backend logic.
- **Visuals:**
    - Add a description/placeholder for an **Architecture Diagram** showing the Service/Client boundary via IPC (Unix Domain Sockets).
    - Add a description/placeholder for a **Clean Architecture Diagram** for the Go client.

## Non-Functional Requirements
- **Language:** Czech (consistent with the rest of the thesis).
- **Format:** LaTeX (`.tex` file) with proper labels and citations.
- **Clarity:** Ensure clear technical justification for architectural decisions.

## Acceptance Criteria
- [ ] Section 3.1 in `thesis/chapters/03_navrh.tex` is updated with the specified SoC details.
- [ ] Technical choices for Go and .NET are justified with references to previous chapters.
- [ ] Clean Architecture principles are explained in the context of the Go client.
- [ ] Placeholders for the Architecture and Clean Architecture diagrams are included.
- [ ] The document compiles without LaTeX errors related to these changes.
- [ ] All text is in Czech.

## Out of Scope
- Implementing the actual diagrams (only placeholders/descriptions).
- Modifying other chapters or functional code.
