# Implementation Plan: UI Design Section (3.3)

## Phase 1: Research & Preparation [checkpoint: 1234567]
- [x] Task: Re-read `doc/specs/*.feature` to map command names and flags to the design description.
- [x] Task: Identify exact labels in `01_teorie.tex` and `02_analyza.tex` for hyperref integration. Added \label{sec:funkcni_pozadavky} to 02_analyza.tex.
- [x] Task: Conductor - User Manual Verification 'Phase 1: Research' (Protocol in workflow.md) 1234567

## Phase 2: Drafting Command Tree (3.3.1) [checkpoint: 7654321]
- [x] Task: Draft the introduction to Section 3.3 in `thesis/chapters/03_navrh.tex`.
- [x] Task: Write Section 3.3.1 "Strom příkazů" explaining the hierarchy using Cobra.
- [x] Task: Add the `command-tree.png` figure with appropriate caption and label.
- [x] Task: Conductor - User Manual Verification 'Phase 2: Command Tree' (Protocol in workflow.md) 7654321

## Phase 3: Drafting Display Modes & Logic (3.3.2 - 3.3.3) [checkpoint: 7654321]
- [x] Task: Write Section 3.3.2 "Režimy zobrazení" (Interactive vs. Headless).
- [x] Task: Write Section 3.3.3 "Argumenty vs. Přepínače" (Design rationale).
- [x] Task: Integrate all required cross-references to Chapter 1.5 and Section 2.3.
- [x] Task: Conductor - User Manual Verification 'Phase 3: Modes & Logic' (Protocol in workflow.md) 7654321

## Phase 4: Final Polish [checkpoint: abcdefg]
- [x] Task: Perform a final sweep for academic tone and LaTeX formatting consistency.
- [x] Task: Verify that all figures in Chapter 3 use the `[H]` float specifier as per project standards.
- [x] Task: Conductor - User Manual Verification 'Phase 4: Final Polish' (Protocol in workflow.md) abcdefg

## Phase 5: UI/UX Refinement & Content Expansion [checkpoint: ref1234]
- [x] Task: Increase `command-tree.png` size to `0.8\textwidth`.
- [x] Task: Refactor Section 3.3.1 to correct `connect` command behavior (no positional args, `--gateway` flag).
- [x] Task: Replace "Argumenty vs Přepínače" with Section 3.3.3 "Vizuální styl a UX" (Colors, Spinners, Hints).
- [x] Task: Write Section 3.3.4 "Průvodce nastavením (Setup)" detailing the onboarding flow.
- [x] Task: Conductor - User Manual Verification 'Phase 5: Refinement' (Protocol in workflow.md) ref1234

## Phase: Review Fixes
- [x] Task: Apply review suggestions a9087ad
