# Specification: Návrh distribuce a aktualizací

## 1. Overview
The goal of this track is to create a new subchapter in `thesis/chapters/03_navrh.tex` titled "Návrh distribuce a aktualizací", replacing the existing empty section "Datový model a konfigurace". This section will detail the distribution of the GoodAccess CLI client via standard Linux packages (.deb, .rpm) and describe the client's mechanism for detecting new versions without performing self-updates, adhering to Linux security and administrative standards.

## 2. Functional Requirements
- **Section Replacement:** Locate and completely remove the empty section "Datový model a konfigurace" (and its comments) in `thesis/chapters/03_navrh.tex`.
- **New Section:** Add `\section{Návrh distribuce a aktualizací} \label{sec:distribuce_aktualizace}`.
- **Content Expansion:** Enhance and expand the provided draft text to ensure a smooth flow, academic vocabulary, and logical integration with the rest of the chapter, avoiding repetitions of previously explained concepts.
- **Subsections:**
  - `\subsection{Distribuční balíčky a instalace}`: Describe the use of .deb and .rpm packages, detailing how the Go binary is placed in `/usr/bin/ga-cli` and the .NET service in `/opt/GoodAccess/`, followed by systemd registration and auto-start.
  - `\subsection{Detekce a provedení aktualizace}`: Explain the mechanism where `ga version` (and `ga status`) asynchronously queries the GoodAccess API for updates (`UpdateAvailable` flag). Discuss the architectural and security benefits of this approach (separating information from file-system write privileges, leaving upgrades to the package manager and `root`).
- **Cross-References:**
  - Explicitly reference subchapter "Distribuce softwaru a balíčkové systémy" (e.g., `\ref{sec:distribuce_balickovaci_systemy}` or similar, checking chapter 1).
  - Explicitly reference UNIX philosophy (`\ref{sec:unix_filozofie}` or similar).
- **Visuals:** Add a placeholder figure `images/distribution-diagram.png` within the text to illustrate the distribution and update process.
- **Style:** Adhere to the academic style defined in `product-guidelines.md` (Czech language, first person plural or passive voice, appropriate terminology).

## 3. Non-Functional Requirements
- **Format:** Valid LaTeX (`.tex`).

## 4. Acceptance Criteria
- [ ] The `03_navrh.tex` file contains the new section and its subsections.
- [ ] The old "Datový model a konfigurace" section is removed.
- [ ] The text is academically polished, flowing smoothly.
- [ ] Cross-references to relevant sections from Chapter 1 are included.
- [ ] A placeholder for `images/distribution-diagram.png` is included.
- [ ] The LaTeX document is not explicitly built/compiled during this task as requested.

## 5. Out of Scope
- Building the PDF.
- Modifying other chapters besides inserting references if necessary.