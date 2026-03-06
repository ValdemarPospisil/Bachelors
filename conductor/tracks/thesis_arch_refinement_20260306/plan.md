# Implementation Plan: Thesis Architecture Refinement (Chapter 3)

## Phase 1: Preparation & Drafting
- [ ] **Task: Verify Reference Labels**
    - [ ] Check `thesis/chapters/01_teorie.tex` and `thesis/chapters/02_analyza.tex` for the exact labels (e.g., `sec:technologie`, `sec:linux_arch`).
- [ ] **Task: Draft Czech Content**
    - [ ] Draft text for Separation of Concerns (Service vs. Client).
    - [ ] Draft text for Clean Architecture in Go Client.
    - [ ] Draft technology choice justifications with references.

## Phase 2: Implementation (LaTeX Update)
- [ ] **Task: Update 03_navrh.tex**
    - [ ] Integrate the drafted SoC details into subsection 3.1.1.
    - [ ] Add paragraphs justifying Go (CLI) and .NET (Service) with Chapter 1/2 references.
    - [ ] Add the explanation for Clean Architecture in the Go client.
- [ ] **Task: Add Diagram Placeholders**
    - [ ] Insert `figure` environments with placeholders for the Architecture and Clean Arch diagrams.
    - [ ] Write detailed captions and descriptions for each.

## Phase 3: Verification & Quality Gates
- [ ] **Task: Verify LaTeX Compilation**
    - [ ] Run `pdflatex` (or equivalent) to ensure `thesis/thesis.tex` compiles correctly.
    - [ ] Check for broken references (`??`) and formatting issues.
- [ ] **Task: Content Self-Review**
    - [ ] Review for technical accuracy, clarity, and Czech grammar.
    - [ ] Ensure the "Thin Client (Wrapper)" argument is consistent with the rest of the chapter.
- [ ] **Task: Conductor - User Manual Verification 'Thesis Refinement' (Protocol in workflow.md)**
