# Implementation Plan: Thesis Refinement (Chapters 1, 2, 5)

## Phase 1: Chapter 1 - Theory Refinement (BDD)
- [ ] Task: Uncross BDD section in `thesis/chapters/01_teorie.tex`.
    - [ ] Remove `\sout{}` from the BDD section (lines ~272).
    - [ ] Remove the detailed explanation of Gherkin steps (Given, When, Then).
    - [ ] Add a brief transition sentence linking to Chapter 5.
- [ ] Task: Conductor - User Manual Verification 'Phase 1: Theory Refinement' (Protocol in workflow.md)

## Phase 2: Chapter 5 - Testing Refinement (Acceptance Testing)
- [ ] Task: Reference Chapter 1's BDD section in section 5.3 of `thesis/chapters/05_testovani.tex`.
    - [ ] Add a cross-reference to the updated BDD section in Chapter 1.
- [ ] Task: Update `login.feature` inclusion to show only the first 2 scenarios.
    - [ ] Modify `\lstinputlisting` to use `firstline=1, lastline=18` (or correct range for first 2 scenarios).
- [ ] Task: Conductor - User Manual Verification 'Phase 2: Acceptance Testing' (Protocol in workflow.md)

## Phase 3: Chapter 5 - Testing Refinement (System Testing & QA)
- [ ] Task: Reference section 2.4 "Nefunkční požadavky" from `thesis/chapters/02_analyza.tex` in section 5.4.
    - [ ] Add a cross-reference to section 2.4 in section 5.4 of `thesis/chapters/05_testovani.tex`.
- [ ] Task: Update section 5.4 to include Arch Linux as a verified platform.
    - [ ] Modify the list of distributions to include Arch Linux.
- [ ] Task: Specify that testing in section 5.4 was done by a QA tester.
    - [ ] Update the text to state that system testing was verified by a professional QA tester.
- [ ] Task: Conductor - User Manual Verification 'Phase 3: System Testing & QA' (Protocol in workflow.md)

## Phase 4: Final Verification & Compilation
- [ ] Task: Compile the LaTeX document and verify PDF output.
    - [ ] Run `pdflatex` or `latexmk` to ensure the document compiles.
    - [ ] Check for broken references or formatting issues.
- [ ] Task: Review all references and content accuracy.
    - [ ] Confirm all requested changes are present and stylistically consistent.
- [ ] Task: Conductor - User Manual Verification 'Phase 4: Final Verification' (Protocol in workflow.md)
