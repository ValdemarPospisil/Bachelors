# Specification: Thesis Source Integration - GoodAccess ZTNA

## Overview
This track involves adding a new authoritative source from GoodAccess regarding Zero Trust Network Access (ZTNA) to the thesis and updating the theoretical section (`01_teorie.tex`) to include historical, regulatory, and technical details from this source.

## Functional Requirements
- **Add Citation:** Add a new entry to `thesis/thesis.bib` for the GoodAccess ZTNA explained article (URL: https://www.goodaccess.com/zero-trust-network-access-ztna).
- **Expand Context:**
    - Add the historical origin of Zero Trust (John Kindervag, Forrester Research, 2010) in the "Koncept Zero Trust" section.
    - Mention the NIS2 Directive and its relevance to zero trust adoption in the "Architektura VPN a principy Zero Trust" section.
- **Update Comparison Table:**
    - Enhance the comparison table `tab:castle_zero` (or add a new one) to include observability and scalability metrics based on the ZTNA vs VPN comparison in the new source.
- **Translation:** All new content derived from the English source MUST be translated into Czech to maintain consistency with the thesis.

## Non-Functional Requirements
- **Academic Tone:** Maintain the established professional and academic tone of the thesis.
- **LaTeX Consistency:** Ensure all new content follows existing LaTeX commands and styling (citations, labels, cross-references).

## Acceptance Criteria
- [ ] New citation entry `goodaccess_ztna_explained` exists in `thesis/thesis.bib`.
- [ ] `thesis/chapters/01_teorie.tex` contains translated sections regarding Kindervag (2010) and NIS2.
- [ ] Comparison table `tab:castle_zero` is updated with technical metrics from the new source.
- [ ] Thesis compiles without errors (checked via `pdflatex` or similar).
- [ ] Citations correctly point to the new source.

## Out of Scope
- Detailed technical implementation of ZTNA in Go/.NET (this is covered in later chapters).
- Adding full details of all 7 NIST tenets (unless specifically requested later).
