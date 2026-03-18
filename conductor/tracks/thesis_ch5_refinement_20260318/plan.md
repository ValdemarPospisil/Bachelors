# Implementation Plan: Thesis Refinement (Chapters 1, 2, 5)

## Phase 1: Chapter 1 - Theory Refinement (BDD)
- [x] Task: Uncross BDD section in `thesis/chapters/01_teorie.tex`. d7c615c
    - [x] Remove `\sout{}` from the BDD section (lines ~272).
    - [x] Remove the detailed explanation of Gherkin steps (Given, When, Then).
    - [x] Add a brief transition sentence linking to Chapter 5.
- [~] Task: Conductor - User Manual Verification 'Phase 1: Theory Refinement' (Protocol in workflow.md)

## Phase 2: Chapter 5 - Testing Refinement (Acceptance Testing)
- [x] Task: Reference Chapter 1's BDD section in section 5.3 of `thesis/chapters/05_testovani.tex`. e6123e4
    - [x] Add a cross-reference to the updated BDD section in Chapter 1.
    - [x] Remove the detailed explanation of Gherkin steps (Given, When, Then) from Chapter 5.
- [x] Task: Update `login.feature` inclusion to show only the first 2 scenarios. e6123e4
    - [x] Modify `\lstinputlisting` to use `firstline=1, lastline=18` (or correct range for first 2 scenarios).
- [~] Task: Conductor - User Manual Verification 'Phase 2: Acceptance Testing' (Protocol in workflow.md)

## Phase 3: Chapter 5 - Testing Refinement (System Testing & QA) [checkpoint: e8b7ab4]
- [x] Task: Reference section 2.4 "Nefunkční požadavky" from `thesis/chapters/02_analyza.tex` in section 5.4. 2d33230
    - [x] Add a cross-reference to section 2.4 in section 5.4 of `thesis/chapters/05_testovani.tex`.
- [x] Task: Update section 5.4 to include Arch Linux as a verified platform. 2d33230
    - [x] Modify the list of distributions to include Arch Linux.
- [x] Task: Specify that testing in section 5.4 was done by a QA tester. 2d33230
    - [x] Update the text to state that system testing was verified by a professional QA tester.
- [x] Task: Conductor - User Manual Verification 'Phase 3: System Testing & QA' (Protocol in workflow.md)

## Phase 4: Final Verification & Compilation
- [x] Task: Compile the LaTeX document and verify PDF output. e965e41
    - [x] Run `pdflatex` or `latexmk` to ensure the document compiles.
    - [x] Check for broken references or formatting issues.
- [x] Task: Review all references and content accuracy. e965e41
    - [x] Confirm all requested changes are present and stylistically consistent.
- [~] Task: Conductor - User Manual Verification 'Phase 4: Final Verification' (Protocol in workflow.md)
