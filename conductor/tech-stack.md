# Tech Stack - GoodAccess CLI & Thesis

## Vývojové technologie
- **Backend (Logika):** .NET 8 / C# 12 – implementace `CLIService` modulu pro autentizaci a řízení tunelů.
- **Frontend (CLI):** Go (Golang) – nativní binární aplikace pro Linux, slouží jako rozhraní pro uživatele.
- **IPC (Inter-process Communication):** Unix Domain Sockets (UDS) – meziprocesní komunikace mezi Go CLI a .NET backendem.

## VPN a síťové technologie
- **Protokoly:** 
    - **OpenVPN:** Stávající a ověřený protokol integrovaný v GoodAccess infrastruktuře.
    - **WireGuard:** Moderní, vysoce výkonný protokol; v rámci práce implementován tunel pro Linux.
- **Platforma:** Linux (primární podpora pro distribuce založené na rodinách Debian a Fedora/RHEL).

## Dokumentace a psaní práce
- **Sazba textu:** LaTeX (využití šablony `kitheses.cls`).
- **Analýza požadavků:** Gherkin (Cucumber) scénáře pro definici chování aplikace a testování.
- **Verzování a správa:** Git.

## Metodika vývoje
- **Extreme Programming (XP):** Aplikace agilních praktik (TDD, CI, Refactoring) v kontextu samostatného vývojáře.
