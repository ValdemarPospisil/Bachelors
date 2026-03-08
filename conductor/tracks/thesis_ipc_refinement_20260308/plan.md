# Implementation Plan: Thesis IPC & Architecture Refinement

## Phase 1: Preparation & Cross-References [checkpoint: 8389020]
- [x] Task: Add label `\label{sec:analyza_architektury}` to Section 2.5 in `thesis/chapters/02_analyza.tex`. b07acb1
- [x] Task: Identify and verify all existing `\begin{figure}` blocks in Chapter 2 and 3 for float fix preparation. 4 matches found. 2d0fcbd
- [x] Task: Conductor - User Manual Verification 'Phase 1: Preparation' (Protocol in workflow.md) 8389020

## Phase 2: Chapter 2 Image Float Refinement [checkpoint: b8f0dc9]
- [x] Task: Update all `\begin{figure}` environments in `thesis/chapters/02_analyza.tex` to use `[H]` or `[!htbp]` to ensure fixed positioning. Used `[H]`.
- [x] Task: Verify that "Možné architektonické přístupy" and "Zvolené řešení" remain intact at the end of the chapter. Verified.
- [x] Task: Conductor - User Manual Verification 'Phase 2: Chapter 2 Refinement' (Protocol in workflow.md) b8f0dc9

## Phase 3: Chapter 3 Introduction & Reference Refactor [checkpoint: 8516f38]
- [x] Task: Rewrite the introduction of Chapter 3 in `thesis/chapters/03_navrh.tex`. Remove Section 1.1/1.2 and replace with a direct transition from Analysis.
- [x] Task: Delete the redundant `enumerate` list (reasons 1-3) from Section 1.1.
- [x] Task: Update the .NET Service reference in Chapter 3 to use `\ref{sec:analyza_architektury}` instead of `\ref{chap:analyza}`.
- [x] Task: Conductor - User Manual Verification 'Phase 3: Chapter 3 Intro Refactor' (Protocol in workflow.md) 8516f38

## Phase 4: IPC Communication Design (Section 3.2)
- [ ] Task: Implement Section 3.2 "Návrh komunikace IPC" in `thesis/chapters/03_navrh.tex`.
    - [ ] Add reference to theory section 1.4.
    - [ ] Add justification for JSON.
    - [ ] Add `\begin{figure}[H]` for `ipc-sequence.png`.
    - [ ] Add request/response JSON code snippets using `lstlisting` or `verbatim`.
- [ ] Task: Conductor - User Manual Verification 'Phase 4: IPC Design' (Protocol in workflow.md)

## Phase 5: Global Verification
- [ ] Task: Perform a final sweep of all `.tex` files in `thesis/chapters/` to ensure consistent figure positioning (`[H]`).
- [ ] Task: Conductor - User Manual Verification 'Phase 5: Final Sweep' (Protocol in workflow.md)
