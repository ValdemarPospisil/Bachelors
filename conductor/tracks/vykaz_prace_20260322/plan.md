# Implementation Plan: Internship Log (Výkaz práce) Generation

## Phase 1: Preparation and Data Generation
- [x] Task: Calculate exact working days between 11.11.2025 and 15.3.2026
    - [x] Identify all weekends within the period.
    - [x] Identify all Czech public holidays within the period (e.g., Nov 17, Dec 24, Dec 25, Dec 26, Jan 1).
    - [x] Verify the total number of working days to distribute 480 hours (approx. 60 days if 8h/day, we need exactly 480 hours).
- [x] Task: Design the content structure and narratives
    - [x] Create logical blocks covering 2-3 day chunks (approx. 16-24 hours each).
    - [x] Distribute the specific topics (Go CLI, .NET backend, UDS, WireGuard/OpenVPN, Testing) progressively across the timeline.
- [x] Task: Conductor - User Manual Verification 'Phase 1: Preparation and Data Generation' (Protocol in workflow.md)

## Phase 2: Document Generation
- [x] Task: Generate the markdown document
    - [x] Write the document header with the exact required text and placeholders (`<Jméno>`, etc.).
    - [x] Generate the "strukturovaný seznam" entries (A, B, C...) containing the calculated hours, dates, and Czech task descriptions.
    - [x] Ensure the total sum of hours across all blocks equals exactly 480.
    - [x] Save the generated content to `doc/notes/vykaz_prace.md`.
- [x] Task: Conductor - User Manual Verification 'Phase 2: Document Generation' (Protocol in workflow.md)