# Specification: Thesis content update - Section 1.1 (CLI)

## Overview
This track involves updating the theoretical section "Rozhraní příkazové řádky" (Section 1.1) in the first chapter of the bachelor thesis. The goal is to incorporate insights from a specific blog post from Contentful while maintaining the established tone and approximate length of the section.

## Functional Requirements
- **Content Update**: Update `thesis/chapters/01_teorie.tex`. 
    - Translate the provided English text from Contentful into academic Czech.
    - Integrate/merge the translated text into the existing section content.
    - Focus on defining what a CLI is, its historical context (Steve Bourne), its relationship with GUIs (abstraction/Swiss Army knife), and its advantages for developers (automation, efficiency).
- **Bibliography**: Update `thesis/thesis.bib`.
    - Add a BibTeX entry for the source: 
        - Key: `fateh_cli_explained`
        - Title: "Command line interfaces explained"
        - Author: David Fateh
        - Date: April 16, 2025
        - URL: `https://www.contentful.com/blog/command-line-interfaces-explained/`
- **Citation**: Ensure the updated section includes a proper `\cite{fateh_cli_explained}`.

## Non-Functional Requirements
- **Consistency**: Maintain the established professional and academic tone of the thesis.
- **Language**: All changes in the LaTeX chapter must be in Czech.
- **Formatting**: Adhere to the existing LaTeX structure and formatting conventions.

## Acceptance Criteria
- Section 1.1 content reflects the new insights and references the new source.
- `thesis.bib` contains the new entry.
- The document compiles successfully with LaTeX (no new errors).
- The length of the section remains comparable to the original.

## Out of Scope
- Major restructuring of Chapter 1.
- Updating other sections in Chapter 1.
- Changes to the bibliography style.