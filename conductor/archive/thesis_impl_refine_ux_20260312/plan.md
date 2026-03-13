# Implementation Plan: Refine Implementation Chapter - Advanced Features & UX

## Phase 1: Context Verification
- [x] Task: Locate LaTeX labels for "funkční požadavky" in `02_analyza.tex` and "Vizuální styl a UX" in `03_navrh.tex`. If they don't exist, create them.
- [x] Task: Read the target sections in `thesis/chapters/04_implementace.tex` to understand the current text.
- [x] Task: Verify the existence of the four required screenshots in `thesis/images/implementation/screenshots/`.
- [x] Task: Conductor - User Manual Verification 'Context Verification' (Protocol in workflow.md)

## Phase 2: Draft Refined Content
- [x] Task: Refine "Persistentní relace a vícero uživatelů" section: Add the reference, remove "např.", and format the `another-user-connected.png` screenshot.
- [x] Task: Refine "Vylepšení uživatelské přívětivosti (UX)" section: Add the reference to chapter 3, draft the text explaining hints and spinners, and format the `status-disconnected.png`, `connecting-spinner.png`, and `status-json.png` screenshots (using side-by-side formatting where appropriate).
- [x] Task: Draft the new subsection "Rozdíly ve správě stavu: GUI vs. CLI" explaining the architectural differences in state handling.
- [x] Task: Design and draft the `tabularx` or `longtable` comparing CLI command behavior across different application states.
- [x] Task: Conductor - User Manual Verification 'Draft Refined Content' (Protocol in workflow.md)

## Phase 3: Integration into LaTeX
- [x] Task: Apply the drafted text and table updates to `thesis/chapters/04_implementace.tex`.
- [x] Task: Compile the LaTeX document to ensure there are no compilation errors (e.g., using `latexmk` or `pdflatex`).
- [x] Task: Conductor - User Manual Verification 'Integration into LaTeX' (Protocol in workflow.md)

## Phase: Review Fixes
- [x] Task: Apply review suggestions f39094d
