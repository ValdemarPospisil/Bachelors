# Implementation Plan: Refine Go Client Subchapter

## Phase 1: Context and Label Discovery
- [ ] Task: Locate LaTeX labels for "Architektura Elm a framework Bubble tea" in `01_teorie.tex` and "Návrh uživatleské rozhraní" (Command Tree figure) in `03_navrh.tex`.
- [ ] Task: Identify exact insertion points in `04_implementace.tex` for the three sections (Cobra, Bubble Tea, IPC).
- [ ] Task: Verify the line ranges in `doc/code/view.go` (154-169) match the "connect" step implementation.
- [ ] Task: Conductor - User Manual Verification 'Discovery' (Protocol in workflow.md)

## Phase 2: Content Refinement
- [ ] Task: Refine "Parsování příkazů (Cobra)": Add Design reference, `connect.go` snippet, keyword explanations, and `help-command.png` figure.
- [ ] Task: Refine "Interaktivní terminálové rozhraní (Bubble Tea)": Add Theory reference, `view.go` snippet, and `setup-step-connect.png` figure with description.
- [ ] Task: Refine "Komunikace se službou (IPC Klient)": Draft description of the request envelope and Go client preparation logic.
- [ ] Task: Conductor - User Manual Verification 'Refinement' (Protocol in workflow.md)

## Phase 3: Final Verification
- [ ] Task: Compile the thesis using `pdflatex` or `latexmk` to ensure references and figures are rendered correctly.
- [ ] Task: Conductor - User Manual Verification 'Final Review' (Protocol in workflow.md)
