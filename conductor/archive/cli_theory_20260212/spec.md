# Specification: Sub-chapter 1.1 - Command Line Interfaces (CLI)

## Overview
This track involves writing the first sub-chapter of the theoretical part of the thesis (`thesis/chapters/01_teorie.tex`). The chapter provides a theoretical foundation for CLI applications, their design principles, and their role in modern system administration, including a comparison with TUIs.

## Functional Requirements
- **Target File**: `thesis/chapters/01_teorie.tex`
- **Sub-chapter Title**: "Rozhraní příkazové řádky" (or similar professional title).
- **Section 1: Role of CLI**: 
    - Focus on speed, efficiency, and remote management (SSH).
    - Explain why admins prefer terminal over GUI.
- **Section 2: CLI Design**: 
    - Cover POSIX syntax guidelines (flags vs. arguments).
    - Explain standard streams (stdin, stdout, stderr) and composability.
- **Section 3: CLI vs TUI**: 
    - Differentiate based on visual complexity (ASCII art, menus).
    - Explain when each is appropriate.
- **Citation**: Include at least one reference to *The Art of Unix Programming* by Eric S. Raymond.
- **Language**: Czech.
- **Perspective**: Academic IT student (do not mention your specific app implementation here).
- **Length**: Approximately 2-3 pages.

## Acceptance Criteria
- [ ] Sub-chapter is added to `thesis/chapters/01_teorie.tex`.
- [ ] All three designated sections are addressed.
- [ ] Citation from Eric S. Raymond is correctly formatted.
- [ ] Text maintains an academic tone in Czech.
- [ ] Sub-chapter title is clearly defined and updated from the placeholder.

## Out of Scope
- Detailed implementation details of the GoodAccess CLI (belongs in later chapters).
- In-depth history of computing prior to Unix.
