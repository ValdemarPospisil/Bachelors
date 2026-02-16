# Specification: Kapitola 1.4: Technologie a nástroje (thesis_tech_tools_20260216)

## Overview
This track involves writing a new section (1.4) for the theoretical part of the Bachelor's thesis (`thesis/chapters/01_teorie.tex`). The section, titled "Použité technologie a nástroje" (Used Technologies and Tools), will serve as a theoretical justification for the implementational choices made in the practical part of the project. It will cover the .NET 8 platform for the backend, the Go language for the CLI frontend, and the data serialization formats used for IPC.

## Functional Requirements
- **Content Coverage:**
    - **.NET 8 Platform:** Cross-platform capabilities, Generic Host pattern, Systemd integration (`Microsoft.Extensions.Hosting.Systemd`), and ASP.NET Core Data Protection (high-level encryption at rest).
    - **Go Language:** Suitability for CLI tools, Cobra (routing/documentation), and Bubble Tea (TUI framework based on Elm Architecture).
    - **Data Serialization:** Argumentative comparison between JSON and gRPC, concluding with the selection of JSON for local IPC inspectability.
- **Language & Style:**
    - Czech language (Academic, formal, passive voice).
    - Descriptive and argumentative style (focus on "why" as well as "what").
    - Length: Approximately 3 standard pages (in LaTeX output).
- **Formatting:**
    - Valid LaTeX syntax.
    - Integration into `thesis/chapters/01_teorie.tex` as `\section{Použité technologie a nástroje}`.
    - Proper use of `\cite{price_csharp}` and `\cite{donovan_go}`.

## Non-Functional Requirements
- **Consistency:** Ensure terminology aligns with previous sections of the thesis.
- **Objectivity:** Maintain a documentarian standard, especially in the technology comparisons.

## Acceptance Criteria
1. The new section is added to `thesis/chapters/01_teorie.tex`.
2. The text covers all required technical points (.NET, Go, IPC).
3. The style is strictly academic (no first-person).
4. Citations are correctly placed and formatted.
5. The document compiles successfully in LaTeX (verified via PDF check if possible).

## Out of Scope
- Detailed implementation code (this is theoretical).
- Deep technical dive into ASP.NET Data Protection key rotation (high-level only).
- Other technologies not mentioned in the prompt.