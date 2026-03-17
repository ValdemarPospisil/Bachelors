# Specification: Refactor Chapter 5 and Update Chapter 1 Testing Tools

## Overview
This track aims to refine Chapter 5 (`05_testovani.tex`) of the thesis by improving references to theoretical concepts and updating the unit testing section. Additionally, Chapter 1 (`01_teorie.tex`) will be expanded to include a new unified section on testing tools ("Testovací knihovny"). The bibliography (`thesis.bib`) will be updated with new `@online` entries for the testing frameworks. The goal is to ensure consistency, remove statements about missing tests, and provide a dummy xUnit code snippet for the .NET backend.

## Functional Requirements
- **Chapter 5 (`05_testovani.tex`) Section 5.1 Refactor**:
    - Remove book citations for the "Testovací pyramida" and instead cross-reference the theory chapter (`01_teorie.tex`) where it was previously explained.
    - Briefly explain TDD and reference the Extreme Programming (XP) book.
- **Chapter 1 (`01_teorie.tex`) Updates**:
    - Add a new unified sub-section "Testovací knihovny" to the "Technologie a Nástroje" section (after "Architektura Elm a bubble tea").
    - Introduce Go testing libraries (`testing` and `testify`) and the .NET testing framework (`xUnit`).
    - Cite the new bibliography sources in this new section.
- **Chapter 5 (`05_testovani.tex`) Section 5.2 Refactor**:
    - Reference the newly created "Testovací knihovny" section from Chapter 1.
    - Remove text stating that unit tests for the .NET backend were not implemented.
    - Add a dummy xUnit code snippet for the .NET backend, specifically a generic test for `CliStorage` (use a generic test code block and include it directly in the text or via file).
    - Ensure the writing style follows the principles used in Chapter 4 (`04_implementace.tex`).
- **Bibliography (`thesis.bib`) Updates**:
    - Add new `@online` entries for:
        - `testify`: `https://github.com/stretchr/testify`
        - Go `testing`: `https://pkg.go.dev/testing`
        - `xUnit`: `https://xunit.net`
- **Validation**:
    - Verify compilation of the thesis using `pdflatex` or `make` in the `thesis` directory.

## Non-Functional Requirements
- Maintain the academic tone and style consistent with previous chapters, particularly Chapter 4.
- Use correct LaTeX formatting (`\lstinputlisting`, cross-references, citations).

## Out of Scope
- Actually implementing real unit tests for the .NET backend (only a dummy snippet will be added to the text).
- Re-writing the entire theory chapter (only the new sub-section will be added).
