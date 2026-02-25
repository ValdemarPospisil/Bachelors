# Implementation Plan: Finish 2nd Chapter

## Phase 1: Update Non-Functional Requirements [checkpoint: 5c9c091]
- [x] Task: In `thesis/chapters/02_analyza.tex`, update "N1 -- Výkon" to focus on fast startup and low resource consumption without mentioning Go.
- [x] Task: In `thesis/chapters/02_analyza.tex`, add a new section for "N4 -- Distribuce a nasazení" explicitly mentioning `.deb` and `.rpm` formats.
- [x] Task: Compile the LaTeX document to verify compilation.
- [x] Task: Conductor - User Manual Verification 'Update Non-Functional Requirements' (Protocol in workflow.md) [5c9c091]

## Phase 2: Restructure Architecture Analysis
- [ ] Task: In `thesis/chapters/02_analyza.tex`, locate the "Analýza architektury" section. Delete the current contents (Návrh A, Návrh B, Zvolené řešení).
- [ ] Task: In `thesis/chapters/02_analyza.tex`, write a new subsection "Analýza stávajícího řešení GoodAccess" describing the Daemon (root privileges, systemd, WireGuard) and the Graphical Client (user space, Electron, IPC/UDS).
- [ ] Task: In `thesis/chapters/02_analyza.tex`, write a new subsection "Zhodnocení problému" explaining that Electron requires X11/Wayland, making it unusable on headless servers/Docker, hence the need for a CLI.
- [ ] Task: In `thesis/chapters/03_navrh.tex`, insert the previously removed "Zvolené řešení" (Návrh A: Tenký klient) as the architectural foundation of the new design.
- [ ] Task: Compile the LaTeX document to ensure cross-chapter references and structure are intact.
- [ ] Task: Conductor - User Manual Verification 'Restructure Architecture Analysis' (Protocol in workflow.md)