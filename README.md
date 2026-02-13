# GoodAccess CLI klient pro Linux

Tento projekt je zaměřen na vývoj nativního CLI klienta pro službu GoodAccess v prostředí operačního systému Linux. Součástí projektu je také bakalářská práce dokumentující celý proces vývoje od analýzy až po distribuci.

## Klíčové technologie
- **Backend:** .NET 8 (C#) – systémová služba (daemon) spravující VPN tunely.
- **Frontend:** Go (Golang) – uživatelské rozhraní příkazové řádky.
- **IPC:** Unix Domain Sockets – bezpečná komunikace mezi komponentami.
- **VPN Protokoly:** WireGuard a OpenVPN.

## Dokumentace a Výstupy
- 📄 [Bakalářská práce (PDF)](./thesis/thesis.pdf)
- 📊 [Prezentace (PDF)](./presentations/SKKI1/build/prezentace.pdf)

---

## Stav bakalářské práce

### 1. Teoretická východiska
- [x] 1.1 Rozhraní příkazové řádky
- [x] 1.2 Architektura VPN a principy Zero Trust
- [x] 1.3 Architektura operačního systému Linux
- [ ] 1.4 Implementační technologie
- [ ] 1.5 Distribuce softwaru
- [ ] 1.6 Metodika vývoje

### 2. Analýza a specifikace požadavků
- [ ] 2.1 Analýza současného stavu
- [ ] 2.2 Specifikace funkčních požadavků
- [ ] 2.3 Specifikace nefunkčních požadavků

### 3. Návrh řešení
- [ ] 3.1 Architektura systému
- [ ] 3.2 Návrh komunikačního protokolu
- [ ] 3.3 Návrh uživatelského rozhraní

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
