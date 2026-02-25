# Specification: Finish 2nd Chapter (Analysis and Requirements)

## Overview
This track involves completing the second chapter (`02_analyza.tex`) by finalizing the Non-Functional Requirements and rewriting the Architecture Analysis section. The existing architectural solution proposal will be moved to Chapter 3, and the Chapter 2 architecture section will focus on the analysis of the *existing* GoodAccess solution and the motivation for creating a CLI.

## Non-Functional Requirements (Nefunkční požadavky)
Update the existing non-functional requirements and add a new one:

1.  **N1 -- Výkon (Performance):** Rewrite this to focus generally on the necessity of fast startup times, low resource consumption, and quick responsiveness in a CLI environment. *Do not explicitly mention Go here; leave that for the design chapter.*
2.  **N2 -- Kompatibilita:** Keep as is (Linux distributions: Debian/Ubuntu, Fedora/RHEL, Arch Linux).
3.  **N3 -- Bezpečnost:** Keep as is.
4.  **N4 -- Distribuce a nasazení (NEW):** Add a new requirement stating that the application must be packageable into standard distribution formats (.deb for Debian-based, .rpm for Red Hat-based) to facilitate easy installation and management by system administrators.

## Architecture Analysis (Analýza architektury)
Restructure this section entirely within `02_analyza.tex`:

1.  **Remove existing proposals:** Remove the current "Návrh A", "Návrh B", and "Zvolené řešení". (Note: The content of "Zvolené řešení" will be moved to `03_navrh.tex` in a subsequent task).
2.  **Analyze Existing Solution (Analýza stávajícího řešení GoodAccess):** Describe the current split-architecture system on Linux:
    *   **GoodAccessService (Daemon):** Runs in the background with root privileges (via systemd), manages network interfaces (WireGuard), handles routing, and holds cryptographic keys.
    *   **Grafický klient (Electron/GUI):** Runs in user space (without root privileges) as a "dumb" presentation controller that communicates with the daemon, typically via local IPC (Unix Domain Sockets).
3.  **Problem Statement / Motivation (Zhodnocení problému / Motivace pro CLI):** Explain that the current Electron-based application requires a display server (X11/Wayland). It cannot be run on headless server distributions or within Docker containers. This limitation creates the explicit need for a native CLI tool.

## Chapter 3 Updates
1. **Move "Zvolené řešení":** Take the previously removed "Zvolené řešení" from Chapter 2 and insert it into a relevant section in `03_navrh.tex`.