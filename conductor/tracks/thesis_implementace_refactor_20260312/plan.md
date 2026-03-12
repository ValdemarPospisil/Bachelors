# Implementation Plan: Refactor Chapter 4 (Implementation)

## Phase 1: Structure and Content Refactoring
- [ ] Task: Analyze existing `04_implementace.tex` and map content to the new structure defined in `doc/notes/implementace_plan.md`.
- [ ] Task: Restructure the file to explicitly focus on the 2 main sections: System Service (.NET) and Client Application (Go), explicitly omitting introduction and conclusion sections.
- [ ] Task: Rewrite and adjust the tone of the text in `04_implementace.tex` to align with the stylistic principles of previous chapters (formal, analytical Czech).
- [ ] Task: Conductor - User Manual Verification 'Structure and Content Refactoring' (Protocol in workflow.md)

## Phase 2: Code Snippets and Compilation Fixes
- [ ] Task: Identify specific line ranges in `doc/code/` for .NET Secure Storage and IPC Server implementations.
- [ ] Task: Identify specific line ranges in `doc/code/` for Go Cobra CLI, Bubble Tea UI, and Go IPC Client implementations.
- [ ] Task: Replace broken or hardcoded `\begin{lstlisting}` blocks in `04_implementace.tex` with `\lstinputlisting` directives referencing the selected lines from `doc/code/`.
- [ ] Task: Verify that `thesis.tex` compiles successfully without errors using `latexmk` or `pdflatex` locally.
- [ ] Task: Conductor - User Manual Verification 'Code Snippets and Compilation Fixes' (Protocol in workflow.md)

## Phase 3: Image Placeholders Integration
- [ ] Task: Identify all locations requiring visual aids based on `implementace_plan.md` (e.g., IPC Flow diagram, Command Tree, Setup Wizard UI).
- [ ] Task: Insert commented placeholders (e.g., `% TODO: [DIAGRAM: Flow parsování požadavku ze socketu...]`) into `04_implementace.tex` ensuring they do not affect compilation.
- [ ] Task: Conductor - User Manual Verification 'Image Placeholders Integration' (Protocol in workflow.md)