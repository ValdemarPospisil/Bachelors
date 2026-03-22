# Specification: Internship Log (Výkaz práce) Generation

## Overview
This track focuses on generating a comprehensive internship work log (Výkaz práce) documenting the development of the GoodAccess CLI client application. The log will span from November 11, 2025, to March 15, 2026, totaling exactly 480 hours. The output will be a single markdown file formatted as a structured list (strukturovaný seznam) in Czech.

## Functional Requirements
- **Output File:** A single markdown file located at `doc/notes/vykaz_prace.md`.
- **Duration:** The work log must cover the period from 11.11.2025 to 15.3.2026.
- **Working Days:** The log must exclude weekends and Czech public holidays during the specified period.
- **Total Hours:** The total accumulated hours must sum up exactly to 480.
- **Entry Frequency:** Entries should be grouped into blocks covering multiple days.
- **Content:** The descriptions of work must be in Czech and reflect the actual tasks involved in developing the GoodAccess CLI, specifically highlighting:
  - Core CLI & Backend (Go, C#, .NET 8)
  - Inter-process Communication (Unix Domain Sockets)
  - Networking/VPN protocols (OpenVPN, WireGuard)
  - Testing & BDD methodologies (xUnit, Moq, Go testing, Gherkin)
- **Format:** The document must follow the "strukturovaný seznam" (structured list) format provided in the reference template, containing blocks (A, B, C...) with specific timeframes and bullet points of tasks with associated hours.

## Non-Functional Requirements
- The generated text should be believable and represent a logical progression of a software engineering project (e.g., analysis -> design -> backend -> CLI -> IPC -> testing -> documentation).
- The document must include the provided header template with placeholders for student and organization details.

## Out of Scope
- Actual modification of the application codebase.
- Filling out the specific personal details (student name, organization details) - these will be left as placeholders (`<Jméno>`, etc.) for the user to fill in later.