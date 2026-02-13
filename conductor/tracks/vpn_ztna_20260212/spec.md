# Specification: Sub-chapter 1.2 - Architektura VPN a principy Zero Trust

## Overview
This track involves writing the second sub-chapter of the theoretical part of the thesis (`thesis/chapters/01_teorie.tex`). It focuses on the evolution of network security from traditional VPNs to Zero Trust Network Access (ZTNA), with specific details on GoodAccess's implementation and a comparison of the WireGuard and OpenVPN protocols.

## Functional Requirements
- **Target File**: `thesis/chapters/01_teorie.tex`
- **Sub-chapter Title**: "Architektura VPN a principy Zero Trust"
- **Section 1: Traditional VPN and Perimeter Security**:
    - Explain the concept of a VPN and the principle of tunneling.
    - Describe the "Castle-and-Moat" model and its limitations (lateral movement).
- **Section 2: Zero Trust Network Access (ZTNA)**:
    - Define ZTNA principles: "Never trust, always verify".
    - Contrast identity-based trust vs. IP-based trust.
    - Explain the Software Defined Perimeter (SDP) and how it hides resources.
    - Describe the GoodAccess implementation (low-code, ZTNA platform).
- **Section 3: VPN Protocols**:
    - Describe WireGuard and OpenVPN.
    - Compare them with a focus on configuration, ease of use, and dynamic management.
- **Citations**:
    - Cite GoodAccess documentation using the content from `doc/goodaccess/`.
    - Cite WireGuard using `literature/wireguard.pdf`.
- **Language**: Czech.
- **Length**: Approximately 2-3 pages.

## Acceptance Criteria
- [ ] Sub-chapter is added to `thesis/chapters/01_teorie.tex`.
- [ ] Content accurately reflects the differences between "Castle-and-Moat" and Zero Trust.
- [ ] GoodAccess architecture (SDP, Identity-based access) is correctly described.
- [ ] Comparison of WireGuard vs. OpenVPN is included.
- [ ] Citations for GoodAccess and WireGuard are correctly implemented.
- [ ] The text maintains an academic tone in Czech.

## Out of Scope
- Detailed code implementation of the protocols (belongs in the implementation chapter).
- Comparative performance benchmarks (unless briefly mentioned as a general characteristic).
