# Implementation Plan: Refine Implementation Chapter - .NET Service Subchapters

## Phase 1: Context Verification
- [ ] Task: Read `thesis/chapters/04_implementace.tex` to understand the current state of the .NET subchapters.
- [ ] Task: Read `thesis/chapters/03_navrh.tex` to identify the exact LaTeX labels for sections 3.4 and 3.2 to use in references.
- [ ] Task: Read `doc/code/CliStorage.cs` and `doc/code/Program.cs` to verify the secure storage implementation details.
- [ ] Task: Read `doc/code/CliMessenger.cs` (lines 194-226) and `doc/code/Program.cs` (lines 33-46) to understand the code snippets to be added.
- [ ] Task: Conductor - User Manual Verification 'Context Verification' (Protocol in workflow.md)

## Phase 2: Draft Refined Content
- [ ] Task: Draft the updated text for "Bezpečné úložiště (Secure Storage)", incorporating the reference to the design chapter and ensuring it aligns with the source code.
- [ ] Task: Draft the updated text for "IPC Server (Unix Domain Sockets)", including the reference and the LaTeX code for inserting `ipc-diagram.png`.
- [ ] Task: Draft the updated text for "Zpracování příkazů (CliMessenger)", linking to the JSON message examples in the design chapter, and add the explanation for the `CliMessenger.cs` code snippet.
- [ ] Task: Draft the updated text for "Životní cyklus a integrace se systemd", adding the explanation for the `Program.cs` code snippet.
- [ ] Task: Conductor - User Manual Verification 'Draft Refined Content' (Protocol in workflow.md)

## Phase 3: Integration into LaTeX
- [ ] Task: Apply the drafted text updates to `thesis/chapters/04_implementace.tex`.
- [ ] Task: Insert the standard LaTeX figure environment for `ipc-diagram.png` in the IPC section.
- [ ] Task: Insert the `lstinputlisting` environments for `CliMessenger.cs` and `Program.cs` in their respective sections.
- [ ] Task: Compile the LaTeX document to ensure there are no compilation errors (e.g., using `latexmk` or `pdflatex`).
- [ ] Task: Conductor - User Manual Verification 'Integration into LaTeX' (Protocol in workflow.md)
