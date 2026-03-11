# Implementation Plan: Thesis Chapter 4 - Implementace

## Phase 1: Struktura projektu a backendové služby
- [ ] Task: Analyze `doc/notes/project-structure.txt` and integrate the repository layout into LaTeX format.
- [ ] Task: Draft section "Struktura projektu a vývojové prostředí" focusing on the separation of .NET backend and Go frontend.
- [ ] Task: Draft section "IPC Communication" explaining `CLIService` module creation and setup (include architecture snippet).
- [ ] Task: Draft section "Secure Storage" explaining secure token/key storage implementation.
- [ ] Task: Draft section "CliMessenger" explaining command handling and initial hardcoded data phase.
- [ ] Task: Conductor - User Manual Verification 'Phase 1: Struktura projektu a backendové služby' (Protocol in workflow.md)

## Phase 2: Klientská aplikace a příkazy (Go)
- [ ] Task: Draft section "Command Structure" detailing Cobra initialization and command tree definition (include CLI commands snippet).
- [ ] Task: Draft section "Commands Implementation" covering the iterative process (`login`, `logout`, `setup`, `connect`, `disconnect`).
- [ ] Task: Highlight the `status` command as a proof-of-work/storage reader throughout development.
- [ ] Task: Conductor - User Manual Verification 'Phase 2: Klientská aplikace a příkazy (Go)' (Protocol in workflow.md)

## Phase 3: Pokročilé funkce a omezení
- [ ] Task: Draft section "OpenVPN Connection" covering integration with `ProtoService`.
- [ ] Task: Draft section "Persistent Connection" explaining device-wide connections, multi-user challenges, context passing, and `sudo ga-cli disconnect`.
- [ ] Task: Draft section "WireGuard Implementation" focusing on architecture, static config limitations on Linux, and future scope.
- [ ] Task: Draft section "UX Enhancements" covering CLI flags and UI/UX improvements.
- [ ] Task: Review the entire `thesis/chapters/04_implementace.tex` for flow, logical domain grouping, and formatting. Ensure "Úvod", "Závěr", and "GUI conflict resolution" are omitted.
- [ ] Task: Conductor - User Manual Verification 'Phase 3: Pokročilé funkce a omezení' (Protocol in workflow.md)