# Implementation Plan: Thesis Architecture Refinement (Chapter 3)

## Phase 1: Preparation & Drafting
- [x] **Task: Verify Reference Labels** 57c1983
    - [ ] Check `thesis/chapters/01_teorie.tex` and `thesis/chapters/02_analyza.tex` for the exact labels (e.g., `sec:technologie`, `sec:linux_arch`).
- [x] **Task: Draft Czech Content** a19c989
    - [x] Draft text for Separation of Concerns (Service vs. Client).
    - [x] Draft text for Clean Architecture in Go Client.
    - [x] Draft technology choice justifications with references.

## Phase 2: Implementation (LaTeX Update)
- [x] **Task: Update 03_navrh.tex** a5695b0
    - [x] Integrate the drafted SoC details into subsection 3.1.1.
    - [x] Add paragraphs justifying Go (CLI) and .NET (Service) with Chapter 1/2 references.
    - [x] Add the explanation for Clean Architecture in the Go client.
- [x] **Task: Add Diagram Placeholders** a5695b0
    - [x] Insert `figure` environments with placeholders for the Architecture and Clean Arch diagrams.
    - [x] Write detailed captions and descriptions for each.

## Phase 3: Verification & Quality Gates [checkpoint: cb5c1ac]
- [x] **Task: Verify LaTeX Compilation**
    - [x] Run `pdflatex` (or equivalent) to ensure `thesis/thesis.tex` compiles correctly.
    - [x] Check for broken references (`??`) and formatting issues.
- [x] **Task: Content Self-Review**
    - [x] Review for technical accuracy, clarity, and Czech grammar.
    - [x] Ensure the "Thin Client (Wrapper)" argument is consistent with the rest of the chapter.
- [x] **Task: Conductor - User Manual Verification 'Thesis Refinement' (Protocol in workflow.md)**

## Phase: Review Fixes
- [x] Task: Apply review suggestions 0e4e398
