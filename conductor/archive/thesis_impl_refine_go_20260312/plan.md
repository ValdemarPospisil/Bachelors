# Implementation Plan: Refine Go Client Subchapter

## Phase 1: Context and Label Discovery
- [x] Task: Locate LaTeX labels for "Architektura Elm a framework Bubble tea" in `01_teorie.tex` and "Návrh uživatleské rozhraní" (Command Tree figure) in `03_navrh.tex`.
- [x] Task: Identify exact insertion points in `04_implementace.tex` for the three sections (Cobra, Bubble Tea, IPC).
- [x] Task: Verify the line ranges in `doc/code/view.go` (154-169) match the "connect" step implementation.
- [x] Task: Conductor - User Manual Verification 'Discovery' (Protocol in workflow.md)

## Phase 2: Content Refinement
- [x] Task: Refine "Parsování příkazů (Cobra)": Add Design reference, `connect.go` snippet, keyword explanations, and `help-command.png` figure.
- [x] Task: Refine "Interaktivní terminálové rozhraní (Bubble Tea)": Add Theory reference, `view.go` snippet, and `setup-step-connect.png` figure with description.
- [x] Task: Refine "Komunikace se službou (IPC Klient)": Draft description of the request envelope and Go client preparation logic.
- [x] Task: Conductor - User Manual Verification 'Refinement' (Protocol in workflow.md)

## Phase 3: Final Verification
- [x] Task: Compile the thesis using `pdflatex` or `latexmk` to ensure references and figures are rendered correctly.
- [x] Task: Conductor - User Manual Verification 'Final Review' (Protocol in workflow.md)
