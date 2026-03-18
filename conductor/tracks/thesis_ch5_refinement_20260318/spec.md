# Specification: Thesis Refinement (Chapters 1, 2, 5)

## Overview
Refine and update thesis chapters 1, 2, and 5 to improve accuracy and detail in the testing, theory, and analysis sections.

## Functional Requirements
- **Chapter 1 (Theory)**:
    - Uncross the BDD section (remove `\sout{}`).
    - Remove the detailed explanation of Gherkin steps (Given, When, Then).
    - Add a brief transition sentence linking to Chapter 5.
- **Chapter 5 (Testing)**:
    - Update section 5.3 "Akceptační testování" to reference the BDD section in Chapter 1.
    - Restrict the display of `login.feature` to the first two scenarios using LaTeX `linerange` (e.g., `firstline=1, lastline=18`).
    - In section 5.4, reference section 2.4 "Nefunkční požadavky" from Chapter 2.
    - Update section 5.4 to include Arch Linux as a verified platform and specify that testing was conducted by a professional QA tester.
- **Chapter 2 (Analysis)**:
    - Ensure cross-referencing to Chapter 5 is consistent.

## Non-Functional Requirements
- Maintain LaTeX syntax integrity.
- Ensure document compiles successfully.
- Adhere to the student's tone and style (Czech language).

## Acceptance Criteria
- BDD section is visible and updated in Chapter 1.
- Chapter 5 correctly references Chapter 1 and Chapter 2.
- `login.feature` snippet is correctly limited to 2 scenarios.
- Arch Linux and QA validation are clearly documented.

## Out of Scope
- Modifying actual `.feature` files or application code.
- General refactoring of other chapters.
