# Specification

## Overview
This track involves refining the theoretical and analytical chapters of the thesis (Chapters 1 and 2), with minor updates to the abbreviations list and Chapter 3. The primary goals are to fix image placements, clarify the relationship between Zero Trust and ZTNA, elaborate on the agile analysis process, and insert a new architecture analysis section with a supporting image.

## Functional Requirements
- **Chapter 1 (`01_teorie.tex`):**
  - Fix image placement issues by utilizing the `[!htbp]` float specifier to prevent images from skipping text context.
  - Add text explaining the concept of Zero Trust.
  - Ensure the comparison table (Castle and Moat vs Zero Trust) directly follows the Zero Trust concept text.
  - Follow the table with the existing ZTNA text, clarifying that ZTNA is the implementation of the Zero Trust concept.
- **Chapter 2 (`02_analyza.tex`):**
  - Add content detailing the analysis process: mention the use of an agile environment, sprints, standups, iterative meetings, and brainstorms.
  - Mention the presence of experienced developers and the CTO during these meetings to understand customer requests.
  - Add the provided "Analýza architektury" section comparing Option A (Thin Client/Wrapper) and Option B (Standalone Logic).
  - Place the newly added `architecture.png` directly under the "Zvolené řešení" (Chosen Solution) subsection.
  - Update section 2.1 to remove the phrase "zdatní profesionálové" and rephrase to refer more broadly to the users.
- **Chapter 3 (`03_navrh.tex`):**
  - Ensure continuity from the architectural analysis in Chapter 2, potentially mentioning that Option B would have been implemented solely in Go.
- **Abbreviations (`thesis.tex`):**
  - Remove non-abbreviations from the "Seznam zkratek" (List of Abbreviations), specifically "GNU" and "DNF".

## Non-Functional Requirements
- Maintain existing LaTeX formatting and project conventions.
- The tone should remain academic and consistent with a bachelor's thesis.

## Acceptance Criteria
- [ ] Images in Chapter 1 appear close to their relevant text without breaking the logical flow.
- [ ] The flow in Chapter 1 goes: Castle and Moat -> Zero Trust concept -> Comparison Table -> ZTNA implementation.
- [ ] Chapter 2 includes the new agile workflow description and the provided architectural analysis text.
- [ ] `architecture.png` is displayed under "Zvolené řešení" in Chapter 2.
- [ ] "zdatní profesionálové" is removed from section 2.1.
- [ ] The transition between Chapter 2 and Chapter 3 regarding the architecture options makes logical sense.
- [ ] "GNU" and "DNF" are no longer present in the abbreviations list.

## Out of Scope
- Major restructuring of the thesis outside of the requested additions/changes.
- Implementation of new features in the CLI or Backend codebase.