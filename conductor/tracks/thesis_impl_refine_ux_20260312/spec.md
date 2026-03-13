# Specification: Refine Implementation Chapter - Advanced Features & UX

## Overview
The goal of this track is to refine the final subchapter of the Implementation chapter (`thesis/chapters/04_implementace.tex`), specifically "4.4 Pokročilé funkce a technické výzvy". The refinement involves adding cross-references to previous chapters, embedding new screenshots to illustrate UX improvements, and creating a new section with a comparative table explaining the state management differences between GUI and CLI.

## Functional Requirements
- **Persistent Session Refinement:**
  - Update the "Persistentní relace a vícero uživatelů" section.
  - Reference the "funkční požadavky" from chapter 2 (`02_analyza.tex`) in the opening sentence.
  - Remove the prefix "např." from the command `sudo ga-cli disconnect` at the end of the section.
  - Add the screenshot `another-user-connected.png` to illustrate the error state.
- **UX Refinement:**
  - Update the "Vylepšení uživatelské přívětivosti (UX)" section.
  - Reference the "Vizuální styl a UX" section from chapter 3 (`03_navrh.tex`).
  - Describe the implementation of hint messages and add the `status-disconnected.png` screenshot.
  - Describe the implementation of immediate feedback (spinners) and add the `connecting-spinner.png` screenshot.
  - Describe the machine-readable output feature and add the `status-json.png` screenshot.
  - Group smaller screenshots side-by-side using the `subfigure` (or `minipage`) environment where appropriate to save space.
- **New Section: GUI vs. CLI State Management:**
  - Create a new subsection (e.g., "Rozdíly ve správě stavu: GUI vs. CLI").
  - Explain the fundamental difference: GUI inherently restricts invalid actions (e.g., disabling a "Connect" button if not logged in), whereas a CLI must accept any command at any time and explicitly handle invalid state transitions.
  - Create an advanced table (using `tabularx` or `longtable`) mapping out how the CLI handles various commands (`login`, `connect`, `status`, etc.) across different application states (not logged in, logged in, connected, another user connected).

## Non-Functional Requirements
- Maintain consistency with the existing thesis tone (23-year-old IT student perspective).
- Use standard LaTeX referencing mechanisms (`\ref`, `\nameref`).
- Ensure all new images are correctly referenced in the text.
- Ensure the document compiles successfully without LaTeX errors.

## Acceptance Criteria
- [ ] `thesis/chapters/04_implementace.tex` is updated with all specified changes.
- [ ] Cross-references to chapters 2 and 3 are present and correctly formatted.
- [ ] All four new screenshots are integrated into the document.
- [ ] The new GUI vs. CLI state management section and table are included.
- [ ] The LaTeX project compiles successfully.
