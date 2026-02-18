# Specification: Track thesis_xp_theory_20260218

## Overview
This track involves writing the final theoretical subchapter (1.7) for the bachelor thesis. The section will explain the principles and values of Extreme Programming (XP), specifically focusing on its applicability to a solo developer. It will cite Kent Beck's foundational book.

## Functional Requirements
- Create subchapter **1.7 Agilní metodiky a Extreme Programming** in `thesis/chapters/01_teorie.tex`.
- Explain the **Core Values** of XP: Simplicity, Communication, Feedback, Courage, and Respect.
- Describe the **Key Practices** of XP: Test-Driven Development (TDD), Continuous Integration (CI), Refactoring, Simple Design, and Pair Programming.
- Include a specific clarification (in the intro or conclusion) that while XP is team-oriented (Pair Programming), its technical practices (TDD, CI, Refactoring) were foundational for this solo project:
    > "Zatímco metodika XP je primárně navržena pro týmovou spolupráci (zejména párové programování), její technické praktiky jako TDD, CI a Refaktoring jsou plně aplikovatelné i pro samostatně pracujícího vývojáře a byly pro tuto bakalářskou práci klíčové."
- Cite the source: `beck_xp` (Kent Beck - Extreme Programming Explained, 2nd Ed).
- Content must remain theoretical and academic.
- Length: Approximately 1.5 - 2 pages.
- Update `README.md` to mark this section as completed.

## Non-Functional Requirements
- Language: Czech (matching the thesis).
- Tone: Academic/Formal.
- Formatting: LaTeX (compatible with `kitheses.cls`).

## Acceptance Criteria
- [ ] Subchapter 1.7 is added to `01_teorie.tex`.
- [ ] The text covers XP values and practices accurately.
- [ ] The citation to Kent Beck (2nd Ed) is correctly implemented.
- [ ] The "solo developer" clarification is included.
- [ ] `README.md` is updated.
- [ ] The user confirms the text meets their expectations.

## Out of Scope
- Detailed project implementation details (this is a theory section).
- In-depth comparison with other agile methodologies like Scrum or Kanban (keep focus on XP).
