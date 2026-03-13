# Implementation Plan: Refine Implementation Chapter - Advanced Features & UX

## Phase 1: Context Verification
- [ ] Task: Locate LaTeX labels for "funkční požadavky" in `02_analyza.tex` and "Vizuální styl a UX" in `03_navrh.tex`. If they don't exist, create them.
- [ ] Task: Read the target sections in `thesis/chapters/04_implementace.tex` to understand the current text.
- [ ] Task: Verify the existence of the four required screenshots in `thesis/images/implementation/screenshots/`.
- [ ] Task: Conductor - User Manual Verification 'Context Verification' (Protocol in workflow.md)

## Phase 2: Draft Refined Content
- [ ] Task: Refine "Persistentní relace a vícero uživatelů" section: Add the reference, remove "např.", and format the `another-user-connected.png` screenshot.
- [ ] Task: Refine "Vylepšení uživatelské přívětivosti (UX)" section: Add the reference to chapter 3, draft the text explaining hints and spinners, and format the `status-disconnected.png`, `connecting-spinner.png`, and `status-json.png` screenshots (using side-by-side formatting where appropriate).
- [ ] Task: Draft the new subsection "Rozdíly ve správě stavu: GUI vs. CLI" explaining the architectural differences in state handling.
- [ ] Task: Design and draft the `tabularx` or `longtable` comparing CLI command behavior across different application states.
- [ ] Task: Conductor - User Manual Verification 'Draft Refined Content' (Protocol in workflow.md)

## Phase 3: Integration into LaTeX
- [ ] Task: Apply the drafted text and table updates to `thesis/chapters/04_implementace.tex`.
- [ ] Task: Compile the LaTeX document to ensure there are no compilation errors (e.g., using `latexmk` or `pdflatex`).
- [ ] Task: Conductor - User Manual Verification 'Integration into LaTeX' (Protocol in workflow.md)
