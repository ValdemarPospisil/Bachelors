# Specification: Theory Chapter Refinement & Unification

## 1. Overview
Refactor and unify the theory chapter (`thesis/chapters/01_teorie.tex`) of the Bachelor's thesis. The goal is to improve professionality, consistency, and adherence to "theory-only" standards by removing application-specific implementation details and standardizing abbreviations and terminology.

## 2. Functional Requirements

### 2.1 Abbreviation Management
- **Scan & Standardize:** Identify all abbreviations (e.g., CLI, VPN, ZTNA, IPC, UDS).
- **First-Instance Explanation:** Ensure the first occurrence of each abbreviation is explained (e.g., "Rozhraní příkazové řádky (CLI – Command Line Interface)").
- **Deduplication:** Remove explanations from subsequent occurrences.
- **Formal List:** Create a formal LaTeX list/table of abbreviations at the beginning of the chapter.

### 2.2 Terminology & Translation
- **Term Identification:** Identify technical terms with inconsistent English/Czech usage (e.g., Waterfall vs. Vodopád).
- **Interactive Correction:** Present terms to the user for a case-by-case decision on the preferred version.
- **Consistency:** Ensure the chosen version is used consistently throughout the chapter.

### 2.3 Structural Enhancements
- **Subsubchapters:** Integrate `\subsubsection` tags to break down long sections into more digestible, logically grouped parts.
- **AI-Driven Suggestions:** The implementation plan will include identifying optimal break points for these subsubchapters.

### 2.4 Theory-Only Refinement ("Full Clean-up")
- **Remove Application Context:** Identify and remove sentences that describe the specific implementation of the "GoodAccess CLI" (e.g., "In my app...", "We use...").
- **Generalization:** Rephrase or remove app-specific logic to focus on objective theoretical facts and industry standards.
- **Critical Sections:** Particular focus on "Model oprávnění DAC" and "Správa procesů a životní cyklus služeb" to ensure they describe general OS principles, not the specific backend behavior.

## 3. Non-Functional Requirements
- **LaTeX Compliance:** Maintain the integrity of the `kitheses.cls` template and LaTeX syntax.
- **Tone & Style:** Adhere to the "Product Guidelines" (Academic clarity, autorský plurál/trpný rod, 23yo student perspective).

## 4. Acceptance Criteria
- [ ] Chapter 1 contains ZERO references to the specific application's internal implementation details.
- [ ] Every abbreviation is explained exactly once at its first occurrence.
- [ ] A formal list of abbreviations is present at the start of the chapter.
- [ ] Subsubchapters are implemented, improving the visual and logical structure.
- [ ] Technical terminology is consistent across the entire chapter.

## 5. Out of Scope
- Modifying chapters 2 (Analysis) through 6 (Conclusion).
- Adding new theoretical sections not already present in the draft.
- Fixing bibliography citations (unless specifically related to a term change).
