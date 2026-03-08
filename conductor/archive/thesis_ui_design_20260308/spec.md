# Specification: UI Design Section (3.3)

## Overview
This track involves writing Section 3.3 "Návrh uživatelského rozhraní (CLI)" in Chapter 3 of the bachelor thesis. The section will describe how the user interacts with the application, focusing on command hierarchy, display modes, and the logic behind arguments and flags.

## Functional Requirements
- **Section 3.3 Drafting:**
    - **Intro:** Interaction philosophy (human vs. script).
    - **3.3.1 Strom příkazů:** Hierarchy using Cobra, reference `command-tree.png` (bigger size). Correct `connect` behavior: default uses preferences, `--gateway` flag for interactive selection.
    - **3.3.2 Režimy zobrazení:** Interactive (Bubble Tea) vs. Headless (JSON/Pipes).
    - **3.3.3 Vizuální styl a UX:** 
        - Color palette using `lipgloss` (Primary: Purple #7D56F4, Secondary: Green #04B575, Error: Red #FF0000, Warning: Orange #FFA500, Subtle: Gray #626262).
        - UX principles: Instant feedback (spinners), hint messages for navigation.
    - **3.3.4 Průvodce nastavením (Setup):** Description of the all-in-one onboarding flow.
- **Cross-References:**
    - Link to Section 1.5 (Cobra, Bubble Tea).
    - Link to Section 2.3 (Functional Requirements).
- **Technical Accuracy:** Ensure consistency with actual app behavior (no positional args for gateway).

## Non-Functional Requirements
- **Language:** Academic Czech.
- **Style:** Conceptual/Architectural.
- **Figures:** Standard LaTeX figure with `[H]` specifier.

## Acceptance Criteria
- [ ] Section 3.3 is complete and coherent.
- [ ] Command hierarchy accurately reflects the application behavior.
- [ ] `command-tree.png` is correctly referenced.
- [ ] Theory and analysis references are present and correct.
