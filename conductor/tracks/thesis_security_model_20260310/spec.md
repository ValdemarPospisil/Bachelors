# Specification: Správa dat a bezpečnostní model

## 1. Overview
The goal of this track is to rewrite and expand the security section within the architectural design chapter (`thesis/chapters/03_navrh.tex`) of the thesis. The existing section "Bezpečnostní model" will be renamed to "Správa dat a bezpečnostní model" and its contents will be completely replaced. The new text will cover data persistence, secure storage via ASP.NET Core Data Protection API, and secure Inter-Process Communication (IPC) using Unix Domain Sockets.

## 2. Functional Requirements
- **Section Renaming:** Change the heading from "Bezpečnostní model" to "Správa dat a bezpečnostní model" with the label `\label{sec:data_a_bezpecnost}`.
- **Content Replacement:** Completely replace the existing text under this section.
- **Content Expansion:** Enhance and expand the provided draft text, ensuring a smooth flow, academic vocabulary, and logical integration with the rest of the chapter.
- **Subsections:**
  - `\subsection{Perzistence a struktura dat}`: Describe the stateless CLI client and the daemon managing persistent state (GlobalConfig, ActiveSessions, KnownGateways) serialized to JSON and cryptographically protected before disk write.
  - `\subsection{Implementace zabezpečeného úložiště (Secure Storage)}`: Detail the use of ASP.NET Core Data Protection API (`Protect`/`Unprotect`), key management in `/opt/GoodAccess/configs/DataProtection-Keys`, and restrictive file permissions (`chmod 700` for root access only).
  - `\subsection{Bezpečnost meziprocesové komunikace (IPC)}`: Explain the use of Named Pipes (Unix Domain Sockets at `/tmp/CoreFxPipe_ga-cli.sock`) and application-level security verifying the `LinuxId` in the payload context.
- **Cross-References:**
  - Reference the `security-component.png` diagram (located in `thesis/images/`).
  - Reference the theoretical explanation of ASP.NET Core Data Protection API from Chapter 1 (`thesis/chapters/01_teorie.tex`).
- **Style:** Adhere to the principles and style of previous chapters, avoiding repetition of already explained architectural concepts in Chapter 3.

## 3. Non-Functional Requirements
- **Language:** Czech (academic style).
- **Format:** LaTeX (`.tex`).

## 4. Acceptance Criteria
- [ ] The `03_navrh.tex` file has the new section title and sub-sections.
- [ ] The old "Bezpečnostní model" content is removed.
- [ ] The new text accurately reflects the required technical details and references the diagram and Chapter 1.
- [ ] The LaTeX syntax is correct and valid.

## 5. Out of Scope
- Rebuilding or compiling the LaTeX document (explicitly requested to not build the latex).
- Modifying other chapters besides the specified cross-references.