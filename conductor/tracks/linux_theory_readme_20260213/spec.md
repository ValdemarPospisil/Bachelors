# Track Specification: Expand Linux Architecture Theory & Project README

## Overview
This track involves two main components:
1.  **Theoretical Expansion:** Expanding and restructuring the "Architektura operačního systému Linux" section in the thesis. It will be converted from a standalone chapter to a detailed section within the "Teoretická východiska" chapter (01_teorie.tex). The content will be expanded to 2-3 pages, focusing on the Linux kernel, process management, security models (sudo/privileges), and `systemd`, while citing key literature.
2.  **Project Documentation:** Creating a root `README.md` that provides a high-level overview of the project and tracks the completion status of the thesis chapters/sub-chapters.

## Functional Requirements
- **Thesis Modification (`thesis/chapters/01_teorie.tex`):**
    - Convert `\chapter{Architektura operačního systému Linux}` (or its current placeholder) into a `\section` within Chapter 1.
    - Expand the content to 2-3 pages.
    - Include theoretical explanations of:
        - **Linux Kernel & Process Management:** How the OS manages background daemons.
        - **Security & Privileges:** Explanation of `sudo`, root permissions, and why the .NET backend requires them for network operations.
        - **Systemd:** Theory of service management and the evolution from `sysvinit`.
    - Cite `@literature/How-Linux-Works-What-Every-Superuser-Should-Know.pdf`.
    - Cite `@literature/wireguard.pdf` where appropriate (e.g., kernel-space vs user-space implementations).
    - Maintain a theoretical tone (avoiding implementation-specific details of the .NET service).
- **Root Documentation (`README.md`):**
    - Create a `README.md` in the project root.
    - Include links to `thesis/thesis.pdf` and `presentations/SKKI1/build/prezentace.pdf` (ignoring gitignore status).
    - Implement a "Progress Tracker" for the Bachelor Thesis (e.g., a checklist of chapters/sections).
    - Mark the first three sub-chapters of the Theory section as "Done".

## Non-Functional Requirements
- **Formatting:** Adhere to the `kitheses.cls` LaTeX style and existing Czech language conventions used in the thesis.
- **Academic Integrity:** Ensure all technical claims are supported by the cited literature.

## Acceptance Criteria
- [ ] `01_teorie.tex` contains the expanded "Architektura operačního systému Linux" as a section.
- [ ] The expansion is approximately 2-3 pages in length.
- [ ] Proper LaTeX citations for "How Linux Works" and "WireGuard" are present.
- [ ] A root `README.md` exists with project info and PDF links.
- [ ] The `README.md` includes a progress checklist with the first three Theory sections checked.

## Out of Scope
- Detailed code snippets of the .NET backend implementation.
- Modification of other thesis chapters (except where necessary for structural integrity).
