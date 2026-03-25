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
- [x] 3.4 Správa dat a bezpečnostní model
- [x] 3.5 Návrh distribuce a aktualizací

### 4. Implementace
- [x] 4.1 Struktura projektu a vývojové prostředí
- [x] 4.2 Implementace systémové služby (.NET)
- [x] 4.3 Implementace klientské aplikace (Go)
- [x] 4.4 Pokročilé funkce a technické výzvy

### 5. Testování a nasazení
- [x] 5.1 Metodika testování
- [x] 5.2 Jednotkové testy a mockování
- [x] 5.3 Akceptační testování
- [x] 5.4 Systémové a integrační testování v prostředí Linux

### 6. Závěr
- [x] Shrnutí výsledků a budoucí rozvoj
