# Specification: Thesis IPC & Architecture Refinement

## Overview
This track refines the transition between Chapter 2 (Analysis) and Chapter 3 (Design) of the thesis. It simplifies the Chapter 3 introduction to focus on the technical implementation, adds a detailed IPC communication section, and fixes image positioning and cross-references.

## Functional Requirements
- **Chapter 2 (`02_analyza.tex`):**
    - Preserve sections "Možné architektonické přístupy" and "Zvolené řešení".
    - Add `\label{sec:analyza_architektury}` to Section 2.5 "Analýza architektury".
- **Chapter 3 (`03_navrh.tex`):**
    - Rewrite the introduction to connect briefly to Chapter 2 and jump straight to component descriptions.
    - Delete the redundant `enumerate` list (reasons for architecture choice) from Section 1.1.
    - Update the .NET Service reference in Chapter 3 to point to Section 2.5 (`\ref{sec:analyza_architektury}`).
    - **Add Section 3.2: "Návrh komunikace IPC"**
        - Reference Theory 1.4 (JSON vs gRPC).
        - Justify the choice of JSON for the implementation.
        - Add reference to image `ipc-sequence.png` (using `\begin{figure}[H]`).
        - Add JSON code blocks for Login Request and Response (Success/Error).
- **Global Figure Float Fix:**
    - Update all `\begin{figure}` environments in Chapter 2 and 3 to use `[H]` or `[!htbp]` to ensure they appear exactly where defined in the LaTeX source.

## Non-Functional Requirements
- **Language:** Maintain the existing Czech academic style.
- **Verification:** Manual source review (no LaTeX build required for this track).

## Acceptance Criteria
- [ ] Section 2.5 has `\label{sec:analyza_architektury}`.
- [ ] Chapter 3 introduction is simplified and connects directly to the technical solution.
- [ ] Redundant choice list in Chapter 3 is removed.
- [ ] All references to the .NET service analysis point to Section 2.5.
- [ ] Section 3.2 "Návrh komunikace IPC" is present and contains:
    - Theory reference (1.4).
    - JSON justification.
    - IPC sequence figure reference.
    - JSON example snippets for request/response.
- [ ] Figures in Chapter 2 and 3 do not float away from their definitions.
