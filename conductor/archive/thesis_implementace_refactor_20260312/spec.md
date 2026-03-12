# Specification: Refactor Chapter 4 (Implementation)

## Overview
Refactor, refine, and enhance the 4th chapter of the thesis (`04_implementace.tex`). The primary goals are to fix LaTeX compilation issues caused by code snippets, improve the chapter's structural alignment with the pre-defined implementation plan (`doc/notes/implementace_plan.md`), and ensure a consistent style with previous chapters. The updated chapter will include precise code references and placeholder image locations.

## Functional Requirements
- **Compilation Fixes:** Replace inline `\begin{lstlisting}` blocks with `\lstinputlisting` referencing code snippets from `doc/code/` directly. This will resolve compilation errors related to code block parsing.
- **Structural Alignment:** Restructure the chapter strictly following the sections defined in `doc/notes/implementace_plan.md`, omitting the "1. Úvod" and "4. Závěr kapitoly" sections.
- **Expanded Code Integration:** Introduce new, highly relevant code snippets spanning the complete architectural flow:
  - **.NET Backend:** Snippets for Secure Storage and IPC Server setup.
  - **Go CLI & UI:** Snippets showcasing Cobra CLI configuration, commands, and Bubble Tea UI interactions.
  - **Go IPC Client:** Snippets illustrating the communication with the backend service.
- **Image Integration:** Insert commented placeholders (e.g., `% TODO: [SCREENSHOT: ...]`) for missing diagrams and screenshots at appropriate locations described in the implementation plan.

## Non-Functional Requirements
- **Stylistic Consistency:** The text must follow the formal, technical, and analytical tone established in previous chapters. It is written in Czech from the perspective of a student.
- **LaTeX Best Practices:** The code must be clean, use appropriate macros for formatting (e.g., `\texttt{}` for inline code), and ensure successful compilation with `latexmk` or `pdflatex`.

## Acceptance Criteria
- Running `latexmk` or `pdflatex` on `thesis/thesis.tex` successfully produces a PDF without errors in `04_implementace.tex`.
- The `04_implementace.tex` file structure corresponds to the internal sections (excluding Intro/Conclusion) of `implementace_plan.md`.
- Code snippets are integrated using `\lstinputlisting` (or appropriate inline references if needed) targeting files from `doc/code/`.
- All required images/diagrams from the plan have corresponding `% TODO:` comment placeholders.

## Out of Scope
- Creating the actual images (the user will provide them later).
- Modifying the actual codebase in `doc/code/` or other thesis chapters.