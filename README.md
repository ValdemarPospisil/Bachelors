# GoodAccess CLI klient pro Linux

Tento projekt je zaměřen na vývoj nativního CLI klienta pro službu GoodAccess v prostředí operačního systému Linux. Součástí projektu je také bakalářská práce dokumentující celý proces vývoje od analýzy až po distribuci.

## Klíčové technologie
- **Backend:** .NET 8 (C#) – systémová služba (daemon) spravující VPN tunely.
- **Frontend:** Go (Golang) – uživatelské rozhraní příkazové řádky.
- **IPC:** Unix Domain Sockets – bezpečná komunikace mezi komponentami.
- **VPN Protokoly:** WireGuard a OpenVPN.

## Dokumentace a Výstupy
- 📄 [Bakalářská práce (PDF)](./thesis/build/thesis.pdf)
- 📊 [Prezentace (PDF)](./presentations/SKKI1/build/prezentace.pdf)

---

## Stav bakalářské práce

### 1. Teoretická východiska
- [x] 1.1 Rozhraní příkazové řádky
- [x] 1.2 Architektura VPN a principy Zero Trust
- [x] 1.3 Architektura operačního systému Linux
- [x] 1.4 Implementační technologie
- [x] 1.5 Zajištění kvality a testování softwaru
- [x] 1.6 Distribuce softwaru a balíčkové systémy
- [x] 1.7 Agilní metodiky a Extreme Programming

### 2. Analýza a specifikace požadavků
- [x] 2.1 Identifikace zúčastněných stran
- [x] 2.2 Případy užití
- [x] 2.3 Funkční požadavky
- [x] 2.4 Mimofunkční požadavky
- [x] 2.5 Analýza architektury

### 3. Návrh řešení
- [x] 3.1 Komponenty systému
- [x] 3.2 Návrh komunikace IPC
- [x] 3.3 Návrh uživatelského rozhraní (CLI)
- [ ] 3.4 Bezpečnostní model
- [ ] 3.5 Správa stavu a konfigurace
- [ ] 3.6 Návrh distribuce a aktualizací

### 4. Implementace
- [ ] 4.1 Implementace backendové služby
- [ ] 4.2 Implementace klientské části
- [ ] 4.3 Integrace s WireGuard

### 5. Testování a nasazení
- [ ] 5.1 Jednotkové testování
- [ ] 5.2 Akceptační testování
- [ ] 5.3 Proces balíčkování (.deb, .rpm)

### 6. Závěr
- [ ] Shrnutí výsledků a budoucí rozvoj
