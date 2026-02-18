# Specification: Track thesis_distribuce_softwaru_20260218

## Overview
This track involves writing a new theoretical subchapter (1.6) for the bachelor thesis. The section will cover the theory of software distribution in Linux, specifically focusing on the two major packaging ecosystems: Debian (.deb) and Red Hat/Fedora (.rpm). It will explain the hierarchical nature of distributions and the relationship between upstream developers and downstream maintainers.

## Functional Requirements
- Create subchapter **1.6 Distribuce softwaru a balíčkovací systémy** in `thesis/chapters/01_teorie.tex`.
- Content must be purely theoretical, avoiding mentions of the specific project implementation.
- Explain the **Upstream vs. Downstream** relationship.
- Describe the **Distribution Hierarchy** (e.g., Debian family, Red Hat family).
- Discuss the concepts of package management: metadata, dependencies, and repository systems.
- Contrast `.deb` and `.rpm` concepts at a high level (control files, spec files, pre/post-install scripts).
- Target length: Approximately 2 pages.
- Update `thesis/thesis.bib` with the following citations:
    - Debian Policy Manual: `https://www.debian.org/doc/debian-policy/`
    - Fedora Packaging Guidelines: `https://docs.fedoraproject.org/en-US/packaging-guidelines/`

## Non-Functional Requirements
- Language: Czech (matching the thesis).
- Tone: Academic/Formal.
- Formatting: LaTeX (compatible with `kitheses.cls`).

## Acceptance Criteria
- [ ] Subchapter 1.6 is added to `01_teorie.tex`.
- [ ] Bibliography contains the two new sources.
- [ ] The text covers distribution hierarchy and upstream/downstream concepts.
- [ ] The text explains .deb and .rpm theoretical foundations.
- [ ] The user confirms the document compiles and renders correctly.

## Out of Scope
- Practical implementation details of the GoodAccess CLI packaging.
- Deep dives into specific package manager syntax (e.g., specific `dnf` or `apt` flags).
- Non-Linux packaging systems (MSI, DMG).