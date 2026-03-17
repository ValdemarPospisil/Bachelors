# Implementation Plan: Refactor Chapter 5 and Update Chapter 1 Testing Tools

## Phase 1: Bibliography and Chapter 1 Updates
- [x] Task: Add new bibliography entries 3e2f783
    - [ ] Add `@online` entries for `testify`, `go testing`, and `xUnit` to `thesis/thesis.bib`.
- [x] Task: Add "Testovací knihovny" section to Chapter 1 18be313
    - [ ] Open `thesis/chapters/01_teorie.tex`.
    - [ ] Locate the "Technologie a Nástroje" section, specifically after "Architektura Elm a bubble tea".
    - [ ] Add a new subsection `\subsection{Testovací knihovny}`.
    - [ ] Write content introducing Go `testing` and `testify`, and .NET `xUnit`, including citations to the newly added bibliography entries.
- [x] Task: Conductor - User Manual Verification 'Phase 1: Bibliography and Chapter 1 Updates' (Protocol in workflow.md) bf6cd96

## Phase 2: Refactor Chapter 5
- [x] Task: Update Section 5.1 (Metodika testování) 3253749
    - [ ] Open `thesis/chapters/05_testovani.tex`.
    - [ ] Locate Section 5.1.
    - [ ] Remove book citations for the "Testovací pyramida".
    - [ ] Add a cross-reference to the theory chapter (`01_teorie.tex`) where "Testovací pyramida" is explained.
    - [ ] Add a brief explanation of TDD and reference the XP book.
- [x] Task: Update Section 5.2 (Jednotkové testování a mockování) 561f4a1
    - [ ] In `thesis/chapters/05_testovani.tex`, locate Section 5.2.
    - [ ] Add a reference to the new "Testovací knihovny" subsection from Chapter 1.
    - [ ] Remove the text stating that unit tests for the .NET backend were not fully implemented.
    - [ ] Create a dummy xUnit code file `doc/code/dummy_xunit_test.cs` containing a basic test for `CliStorage`.
    - [ ] Include the dummy snippet in the text using `\lstinputlisting`.
    - [ ] Ensure the tone matches Chapter 4.
- [~] Task: Conductor - User Manual Verification 'Phase 2: Refactor Chapter 5' (Protocol in workflow.md)

## Phase 3: Final Compilation and Review
- [ ] Task: Verify Thesis Compilation
    - [ ] Run `pdflatex thesis.tex` or `make` in the `thesis/` directory to ensure no LaTeX errors occur.
    - [ ] Run `biber` to resolve citations, then run `pdflatex` again.
    - [ ] Check that references and citations are correctly resolved.
- [ ] Task: Conductor - User Manual Verification 'Phase 3: Final Compilation and Review' (Protocol in workflow.md)
