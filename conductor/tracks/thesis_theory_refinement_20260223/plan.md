# Implementation Plan: Theory Chapter Refinement

This plan outlines the steps to refactor `thesis/chapters/01_teorie.tex` to meet the approved specification.

## Phase 1: Analysis & Terminology Alignment
This phase focuses on gathering data and making decisions on terminology to ensure consistency before editing the text.

- [ ] Task: Scan `01_teorie.tex` and extract all abbreviations and potential English/Czech technical term conflicts.
- [ ] Task: Present the extracted terms to the user and obtain final decisions for each (Case-by-Case).
- [ ] Task: Propose specific locations and titles for new `\subsubsection` (subsubchapters) based on content analysis.
- [ ] Task: Conductor - User Manual Verification 'Analysis & Terminology Alignment' (Protocol in workflow.md)

## Phase 2: Content Refactoring & Generalization
The "Full Clean-up" phase where application-specific details are removed and the text is generalized.

- [ ] Task: Remove or generalize all sentences describing the GoodAccess CLI implementation details (focus on DAC and Process Management sections).
- [ ] Task: Re-verify that the text maintains a professional, theoretical tone (autorský plurál).
- [ ] Task: Conductor - User Manual Verification 'Content Refactoring & Generalization' (Protocol in workflow.md)

## Phase 3: Structural & Technical Updates
Implementing the formal changes to the LaTeX document structure.

- [ ] Task: Implement the formal Abbreviation List/Table at the beginning of the chapter.
- [ ] Task: Deduplicate abbreviation explanations: Ensure first-instance only explanation and remove others.
- [ ] Task: Insert the approved `\subsubsection` tags into the text.
- [ ] Task: Apply terminology corrections based on decisions from Phase 1.
- [ ] Task: Conductor - User Manual Verification 'Structural & Technical Updates' (Protocol in workflow.md)

## Phase 4: Final Polish & Verification
Ensuring the document builds correctly and meets quality standards.

- [ ] Task: Run a LaTeX build to ensure no syntax errors were introduced.
- [ ] Task: Final read-through to verify all Acceptance Criteria are met.
- [ ] Task: Conductor - User Manual Verification 'Final Polish & Verification' (Protocol in workflow.md)

## Quality Gates
- [ ] All abbreviations listed and explained correctly.
- [ ] No "in my app" or implementation-specific sentences remain.
- [ ] LaTeX document compiles without errors.
- [ ] Tone is academic and consistent.
