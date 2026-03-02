# Implementation Plan - Refactor Theory Chapter

## Phase 1: Research & Preparation
- [x] Task: Analyze `thesis/chapters/01_teorie.tex` to identify all sections/subsections and their current citation status. [checkpoint: 0b929e1]
- [x] Task: Analyze `thesis/thesis.bib` and identify entries to be cleaned or removed. [checkpoint: 0b929e1]
- [x] Task: Read `sources-theory.txt` (if it exists) and verify images in `thesis/images/`. [checkpoint: 0b929e1]
- [x] Task: Conductor - User Manual Verification 'Phase 1: Research & Preparation' (Protocol in workflow.md) [checkpoint: 0b929e1]

## Phase 2: Source Acquisition & Bibliography Setup
- [x] Task: Conduct web searches using `web_search_exa` to find 15-20 additional sources for theoretical sections (XP, .NET, Go, VPN protocols, etc.). [checkpoint: 09ca047]
- [x] Task: Update `thesis/thesis.bib` with new sources and apply cleanup (remove locations, specific goodaccess sources). [checkpoint: 09ca047]
- [x] Task: Conductor - User Manual Verification 'Phase 2: Source Acquisition & Bibliography Setup' (Protocol in workflow.md) [checkpoint: 09ca047]

## Phase 3: Content Refactoring & Citations
- [x] Task: Increase citation frequency in `thesis/chapters/01_teorie.tex` for existing sections (e.g., XP). [checkpoint: 09ca047]
- [x] Task: Add citations to all sections/subsections currently lacking them. [checkpoint: 09ca047]
- [x] Task: Refactor DAC section (`Model oprávnění DAC`) to reduce its length by ~50%. [checkpoint: 09ca047]
- [x] Task: Merge the "Umístění aplikace" section into the most relevant broader section. [checkpoint: 09ca047]
- [x] Task: Conductor - User Manual Verification 'Phase 3: Content Refactoring & Citations' (Protocol in workflow.md) [checkpoint: 09ca047]

## Phase 4: Visuals & Structural Changes
- [x] Task: Add comparison tables for JSON vs gRPC and Castle-and-Moat vs Zero Trust in `thesis/chapters/01_teorie.tex`. [checkpoint: 09ca047]
- [x] Task: Integrate images from `thesis/images/` into `thesis/chapters/01_teorie.tex` and add citations from `sources-theory.txt`. [checkpoint: 09ca047]
- [x] Task: Move "seznam zkratek" to follow "obsah" in `thesis/thesis.tex`. [checkpoint: 09ca047]
- [x] Task: Conductor - User Manual Verification 'Phase 4: Visuals & Structural Changes' (Protocol in workflow.md) [checkpoint: 09ca047]

## Phase 5: Verification & Final Build
- [x] Task: Verify the total citation count is between 20-30 and every subsection is cited. [checkpoint: 09ca047]
- [x] Task: Run a complete LaTeX build and resolve any errors or warnings. [checkpoint: 09ca047]
- [x] Task: Conductor - User Manual Verification 'Phase 5: Verification & Final Build' (Protocol in workflow.md) [checkpoint: 09ca047]

## Phase: Review Fixes
- [x] Task: Apply review suggestions 8497327
