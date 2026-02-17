# Track: thesis_qa_theory_20260217

## Overview
This track involves writing a new subchapter titled "Zajištění kvality a testování softwaru" for the theoretical part of the bachelor's thesis (`thesis/chapters/01_teorie.tex`). The subchapter will be inserted as the 5th section of Chapter 1. It will cover software quality, the test pyramid (Unit, Integration, E2E), and BDD/Gherkin, with appropriate citations and an image.

## Functional Requirements
- **Title:** Zajištění kvality a testování softwaru.
- **Location:** `thesis/chapters/01_teorie.tex`, inserted between current Section 4 ("Technologie a nástroje") and Section 5 ("Distribuce softwaru").
- **Content:**
    - Introduction to software quality and its importance in the SDLC.
    - Detailed explanation of the Test Pyramid levels: Unit, Integration, and End-to-End (E2E) tests.
    - Explanation of Behavior-Driven Development (BDD) and Gherkin syntax.
- **Citations:** 
    - Cite *Succeeding with Agile: Software Development Using Scrum* (Mike Cohn) for the Test Pyramid concept.
    - Citation should be placed in the figure caption for the pyramid image.
- **Visuals:** 
    - Include the image `doc/images/tests.jpg` representing the test pyramid.
- **Formatting:** 
    - Written in Czech, consistent with the rest of the thesis.
    - Target length: approximately 2 pages.
- **Completion Actions:** 
    - Update `README.md` to mark this subchapter as done.

## Non-Functional Requirements
- Maintain consistent LaTeX styling and terminology used in existing chapters.
- Ensure proper cross-referencing if applicable.

## Acceptance Criteria
- [ ] Subchapter "Zajištění kvality a testování softwaru" exists in `thesis/chapters/01_teorie.tex` at the correct position.
- [ ] Content covers Software Quality, Test Pyramid (Unit, Integration, E2E), and Gherkin/BDD.
- [ ] The Test Pyramid image (`doc/images/tests.jpg`) is included with a caption citing the author.
- [ ] Bibliography contains the entry for *Succeeding with Agile*.
- [ ] `README.md` reflects the completion of this subchapter.
- [ ] LaTeX document builds without errors.

## Out of Scope
- Implementation of actual tests in the Go or .NET codebase (this is theory only).
- Detailed analysis of specific testing frameworks (e.g., xUnit, Go test) beyond general theory.