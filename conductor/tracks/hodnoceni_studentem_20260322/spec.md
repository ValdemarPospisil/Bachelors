# Specification: Student Internship Evaluation (Hodnocení studentem) Generation

## Overview
This track focuses on generating a student evaluation document (Hodnocení průběhu odborné praxe studentem) documenting the internship experience during the development of the GoodAccess CLI client application. The evaluation will cover the period from November 11, 2025, to March 15, 2026, totaling 480 hours. The output will be a single markdown file in Czech.

## Functional Requirements
- **Output File:** A single markdown file located at `doc/notes/hodnoceni_studentem.md`.
- **Content Structure:** Must follow the provided template sections:
  1. Hodnocení přínosu (Benefit for the student)
  2. Kvalita zajištění (Quality of the provider)
  3. Celkový dojem (Overall impression)
  4. Sebehodnocení (Self-evaluation)
  5. Připomínky a návrhy (Comments and suggestions)
- **Internship Details:**
  - Start: 11.11.2025, End: 15.3.2026, Hours: 480.
  - Program: B0613P140005 / Aplikovaná informatika.
  - Course: KI/BOP Odborná praxe.
- **Tone:** Constructive, professional, and positive.
- **Narrative Focus:** Technical growth (Go, .NET, IPC, VPN), positive company culture (GoodAccess), and problem-solving skills development.
- **Language:** Czech, using bullet points or short, concise paragraphs.

## Non-Functional Requirements
- The generated responses should be realistic and reflect the actual technical scope of the project (e.g., challenges with UDS, protocols, or extreme programming).
- Personal details (student name, organization details) will be left as placeholders (`<Jméno>`, etc.) for the user to fill in.

## Out of Scope
- Filling out personal or organizational placeholders.
- Modifying the application codebase.
- Generating other documents.