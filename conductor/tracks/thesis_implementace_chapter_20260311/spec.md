# Specification: Thesis Chapter 4 - Implementace

## Overview
This track covers writing Chapter 4 (Implementace) of the bachelor thesis (`thesis/chapters/04_implementace.tex`), replacing the existing draft. The text will focus on describing the implementation of the GoodAccess CLI client and its .NET backend service. It will omit generic introductions and conclusions, diving directly into the technical implementation. The chapter will be structured logically by domain (Project Structure -> Backend -> Frontend -> Specific Features).

## Functional Requirements
The chapter must include the following subchapters/topics in a logical order:
1. **Struktura projektu a vývojové prostředí:**
   - Explanation of the repository layout based on `doc/notes/project-structure.txt`.
   - Separation of the .NET backend (logic) and the Go frontend (UI).
2. **Backend Services (.NET):**
   - **IPC Communication:** Creation of the `CLIService` module for inter-process communication.
   - **Secure Storage:** Implementation of secure token/key storage.
   - **CliMessenger:** Handling commands received from the CLI (including the initial phase of returning hardcoded data for testing).
3. **Frontend Application (Go):**
   - **Command Structure:** Initialization of the Cobra framework and command tree definition.
   - **Commands Implementation:** Iterative implementation of commands (`login`, `logout`, `setup`, `connect`, `disconnect`, `status`). The `status` command should be highlighted as a continuous proof-of-work/storage reader throughout development.
4. **Core Features & Challenges:**
   - **OpenVPN Connection:** Integration with the existing `ProtoService` for `connect`/`disconnect`.
   - **Persistent Connection:** Handling device-wide connections and the challenge of multiple Linux users. Explanation of passing user context from CLI to Service, and requiring `sudo ga-cli disconnect` to resolve user conflicts.
   - **WireGuard Implementation:** Focus on the architecture and limitations (static config only, tunnel implementation on Linux) and note that full lifecycle management is out of scope for this thesis but being developed by others.
   - **UX Enhancements:** Mentioning additions like CLI flags and other user experience improvements.

## Non-Functional Requirements
- **Language:** Czech, written from the perspective of a student developer.
- **Format:** LaTeX, adhering to the `kitheses.cls` template.
- **Content:** Emphasize code snippets and diagrams related to "Architecture/Setup" (e.g., IPC setup, Storage init) and "CLI Commands" (e.g., Cobra definitions).
- **Tone:** Technical and analytical, avoiding generic filler text (no "Úvod"/"Závěr").

## Acceptance Criteria
- [ ] `thesis/chapters/04_implementace.tex` contains the newly written content replacing the old plan.
- [ ] The text successfully integrates the provided project structure notes.
- [ ] All required topics (IPC, Storage, CliMessenger, Cobra, Commands, Persistent flag logic, WG architecture) are covered.
- [ ] The text logically flows by domain rather than strictly chronologically.
- [ ] GUI conflict resolution is completely omitted.

## Out of Scope
- Writing other chapters.
- Actual source code modifications in Go or .NET repositories.
- "GUI Conflict resolution" topic.
- Generic introductory and concluding paragraphs for the chapter.