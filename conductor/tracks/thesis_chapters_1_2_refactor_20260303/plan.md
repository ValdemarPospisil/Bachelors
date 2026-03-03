# Implementation Plan

## Phase 1: Update Chapter 1 (Theory) [checkpoint: c78cd99]
- [x] Task: Fix image placements in Chapter 1 3981759
    - [x] Locate all figures in `thesis/chapters/01_teorie.tex`.
    - [x] Update float specifiers to `[!htbp]`.
- [x] Task: Add Zero Trust concept and restructure text 3981759
    - [x] Add paragraph explaining the concept of Zero Trust.
    - [x] Ensure the "Castle and Moat vs Zero Trust" comparison table follows the new text.
    - [x] Ensure the ZTNA text follows the table and clarifies it as an implementation of Zero Trust.
- [x] Task: Conductor - User Manual Verification 'Update Chapter 1 (Theory)' (Protocol in workflow.md)

## Phase 2: Update Chapter 2 (Analysis) [checkpoint: 0f24adf]
- [x] Task: Add agile methodology details e5f99dc
    - [x] Locate the analysis process section in `thesis/chapters/02_analyza.tex`.
    - [x] Insert details about iterative meetings, brainstorms, agile environment, sprints, standups, experienced devs, and the CTO.
- [x] Task: Update user description in section 2.1 e5f99dc
    - [x] Find "zdatní profesionálové" in section 2.1.
    - [x] Replace it with a broader description of the users.
- [x] Task: Add Architecture Analysis e5f99dc
    - [x] Insert the provided LaTeX snippet containing "Návrh A" and "Návrh B".
    - [x] Embed the `architecture.png` directly under the "Zvolené řešení" subsection.
- [x] Task: Conductor - User Manual Verification 'Update Chapter 2 (Analysis)' (Protocol in workflow.md)

## Phase 3: Update Chapter 3 and Abbreviations
- [ ] Task: Refine transition in Chapter 3
    - [ ] Locate the architecture section in `thesis/chapters/03_navrh.tex`.
    - [ ] Add continuity text referencing the analysis from Chapter 2 (e.g., Option B would be only Go).
- [ ] Task: Clean up abbreviations
    - [ ] Locate "Seznam zkratek" in `thesis/thesis.tex`.
    - [ ] Remove "GNU" and "DNF" entries.
- [ ] Task: Compile and review
    - [ ] Build the LaTeX document.
    - [ ] Verify visually that the output matches the acceptance criteria.
- [ ] Task: Conductor - User Manual Verification 'Update Chapter 3 and Abbreviations' (Protocol in workflow.md)