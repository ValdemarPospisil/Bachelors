# Specification - Refactor Theory Chapter

## Overview
Refactor the theory chapter (`thesis/chapters/01_teorie.tex`) to improve its academic rigor, structure, and visual presentation. This includes significantly increasing the number of sources/citations, cleaning up the bibliography, adding comparison tables, and adjusting section balance.

## Functional Requirements

### 1. Source and Citation Management
- **Target Count:** Increase the total number of sources to 20-30.
- **Source Types:** Mix of Academic/Formal (papers, books), Technical/Official (docs, specs), and Industry/Practical (blogs, articles).
- **Web Search:** Use `web_search_exa` to find relevant sources for currently uncited or under-cited sections (e.g., XP, .NET, Go, VPN protocols).
- **Citation Frequency:** Ensure every section/subsection has at least one citation (e.g., in the XP section, cite the source more frequently).
- **Bibliography Cleanup (`thesis/thesis.bib`):**
    - Remove location fields (e.g., "Boston").
    - Keep `goodaccess` documentation.
    - Remove `goodaccess` "whatis" source.

### 2. Image and Visual Content
- **New Images:** Add images from `thesis/images/` to the chapter.
- **Image Placement:** Follow strict placement based on references in `sources-theory.txt`.
- **Image Citations:** Cite the origin of each image as specified in `sources-theory.txt`.

### 3. Comparison Tables
- Add comparison tables for key theoretical concepts:
    - **JSON vs gRPC**
    - **Castle-and-Moat vs Zero Trust**
- Use logical criteria for comparison (e.g., Performance, Security, Complexity).

### 4. Structural Adjustments
- **Section Balancing:**
    - **DAC (Model oprávnění DAC):** Reduce content by approximately 50% (less priority).
    - **App Location (Umístění aplikace):** Merge into a related broader section (e.g., Network Infrastructure) due to its short length.
- **Thesis Structure (`thesis/thesis.tex`):**
    - Move "seznam zkratek" (List of Abbreviations) to follow immediately after "obsah" (Table of Contents).

## Non-Functional Requirements
- **Academic Rigor:** All added sources must be relevant to the text they are citing.
- **Consistency:** Maintain consistent LaTeX formatting throughout.

## Acceptance Criteria
- [ ] Chapter 1 contains 20-30 citations in total.
- [ ] Every section/subsection has at least one citation.
- [ ] `thesis.bib` is cleaned up (no locations, specific goodaccess sources kept/removed).
- [ ] All images from `sources-theory.txt` are included and correctly cited.
- [ ] Two comparison tables (JSON/gRPC and Castle-and-Moat/Zero Trust) are added.
- [ ] DAC section is reduced in length.
- [ ] "Umístění aplikace" is merged.
- [ ] "Seznam zkratek" is correctly moved in `thesis.tex`.
- [ ] LaTeX builds successfully without errors.

## Out of Scope
- Rewriting the entire chapter (only targeted refactoring and additions).
- Adding new theoretical sections beyond what is mentioned.
