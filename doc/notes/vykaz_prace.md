VÝKAZ PRÁCE Z ODBORNÉ PRAXE STUDENTA/STUDENTKY
Přírodovědecké fakulty Univerzity Jana Evangelisty Purkyně v Ústí nad Labem
v bakalářském studijním programu Aplikovaná informatika

Organizace (poskytovatel odborné praxe): <Název dle smlouvy> (IČO: <IČO>)
Jméno, příjmení a pozice zaměstnance/zaměstnankyně organizace pověřené/ho potvrzením tohoto výkazu: <Jméno> <PŘÍJMENÍ>, <pozice v organizaci>
Jméno a příjmení studenta/studentky: <Jméno> <PŘÍJMENÍ>
Datum a místo narození studenta/studentky: <D>. <M>. <RRRR> v <Obec>
Datum zahájení odborné praxe: 11. 11. 2025
Datum ukončení odborné praxe: 15. 3. 2026

---

### Nástin výkazu práce v podobě strukturovaného seznamu

A. Souhrnné označení náplně pracovních činností (20 hodin v období od 11. 11. 2025 do 14. 11. 2025)
Předmětem/cílem tohoto bloku úkolů je analýza požadavků a studium stávající infrastruktury GoodAccess.
1. Studium dokumentace k VPN infrastruktuře a principům ZTNA (Zero Trust Network Access) (8 hodin)
2. Analýza požadavků na CLI klienta a definice základních uživatelských scénářů (Gherkin) (8 hodin)
3. Návrh vysokoúrovňové architektury aplikace (Go frontend a .NET backend) (4 hodiny)

B. Souhrnné označení náplně pracovních činností (20 hodin v období od 18. 11. 2025 do 21. 11. 2025)
Předmětem/cílem tohoto bloku úkolů je návrh architektury IPC a příprava vývojového prostředí.
1. Návrh komunikačního protokolu mezi CLI a backendem přes Unix Domain Sockets (10 hodin)
2. Nastavení vývojového prostředí pro .NET 8 a Go (Golang) (6 hodin)
3. Inicializace projektu CLIService v C# a definice základních rozhraní (4 hodiny)

C. Souhrnné označení náplně pracovních činností (30 hodin v období od 24. 11. 2025 do 28. 11. 2025)
Předmětem/cílem tohoto bloku úkolů je implementace základního backend modulu.
1. Vývoj logiky pro správu stavu VPN připojení v .NET backendu (15 hodin)
2. Implementace asynchronního zpracování příkazů v CLIService (10 hodin)
3. Příprava mechanismů pro logging a monitoring stavu backendu (5 hodin)

D. Souhrnné označení náplně pracovních činností (30 hodin v období od 01. 12. 2025 do 05. 12. 2025)
Předmětem/cílem tohoto bloku úkolů je vývoj Go frontendové části aplikace.
1. Implementace struktury CLI příkazů pomocí standardních knihoven Go (15 hodin)
2. Vývoj parseru argumentů a přepínačů pro interakci s uživatelem (10 hodin)
3. Návrh uživatelského rozhraní CLI (formátování výstupu, nápověda) (5 hodin)

E. Souhrnné označení náplně pracovních činností (30 hodin v období od 08. 12. 2025 do 12. 12. 2025)
Předmětem/cílem tohoto bloku úkolů je implementace IPC komunikace na straně backendu.
1. Vývoj socket serveru využívajícího Unix Domain Sockets v .NET (15 hodin)
2. Definice a implementace JSON serializace pro zprávy protokolu (10 hodin)
3. Řešení souběžného přístupu více klientů k backend službě (5 hodin)

F. Souhrnné označení náplně pracovních činností (30 hodin v období od 15. 12. 2025 do 19. 12. 2025)
Předmětem/cílem tohoto bloku úkolů je implementace IPC komunikace na straně CLI.
1. Vývoj IPC klienta v Go pro připojení k Unix Domain Socketu (15 hodin)
2. Implementace asynchronního čtení a zápisu zpráv do socketu (10 hodin)
3. Mapování JSON odpovědí z backendu na vnitřní datové struktury Go (5 hodin)

G. Souhrnné označení náplně pracovních činností (30 hodin v období od 22. 12. 2025 do 31. 12. 2025)
Předmětem/cílem tohoto bloku úkolů je zabezpečení citlivých údajů a správa credentials.
1. Implementace bezpečného uložení přihlašovacích údajů pomocí DPAPI v .NET (15 hodin)
2. Návrh a vývoj modulu pro správu uživatelských relací a tokenů (10 hodin)
3. Ošetření chybových stavů při neplatných credentials nebo expiraci tokenu (5 hodin)

H. Souhrnné označení náplně pracovních činností (40 hodin v období od 02. 01. 2026 do 09. 01. 2026)
Předmětem/cílem tohoto bloku úkolů je integrace OpenVPN protokolu.
1. Integrace knihoven pro řízení OpenVPN procesů v rámci .NET backendu (20 hodin)
2. Implementace monitoringu stavu tunelu a automatického znovupřipojení (15 hodin)
3. Zpracování logů z OpenVPN a jejich prezentace uživateli v CLI (5 hodin)

I. Souhrnné označení náplně pracovních činností (30 hodin v období od 12. 01. 2026 do 16. 01. 2026)
Předmětem/cílem tohoto bloku úkolů je implementace podpory pro WireGuard.
1. Vývoj modulu pro konfiguraci a řízení WireGuard interface na Linuxu (15 hodin)
2. Implementace mechanismu pro přepínání mezi protokoly OpenVPN a WireGuard (10 hodin)
3. Optimalizace parametrů tunelu pro zvýšení propustnosti dat (5 hodin)

J. Souhrnné označení náplně pracovních činností (30 hodin v období od 19. 01. 2026 do 23. 01. 2026)
Předmětem/cílem tohoto bloku úkolů je unit testování Go frontendu.
1. Vytvoření testovací sady pro CLI komponenty pomocí package `testing` (15 hodin)
2. Mockování IPC komunikace pro izolované testování logiky CLI (10 hodin)
3. Implementace automatizovaných testů pro validaci uživatelských vstupů (5 hodin)

K. Souhrnné označení náplně pracovních činností (30 hodin v období od 26. 01. 2026 do 30. 01. 2026)
Předmětem/cílem tohoto bloku úkolů je unit testování .NET backendu.
1. Implementace unit testů pro CLIService moduly pomocí frameworku xUnit (15 hodin)
2. Použití knihovny Moq pro izolaci externích závislostí v .NET (10 hodin)
3. Verifikace správného chování při handlingu IPC socketů (5 hodin)

L. Souhrnné označení náplně pracovních činností (30 hodin v období od 02. 02. 2026 do 06. 02. 2026)
Předmětem/cílem tohoto bloku úkolů je refaktorování a optimalizace kódu.
1. Refaktorování meziprocesní komunikace pro snížení latence (15 hodin)
2. Odstraňování duplicit v kódu a implementace design patternů (10 hodin)
3. Optimalizace správy paměti a prostředků (socket closure, task disposal) (5 hodin)

M. Souhrnné označení náplně pracovních činností (30 hodin v období od 09. 02. 2026 do 13. 02. 2026)
Předmětem/cílem tohoto bloku úkolů je verifikace chování pomocí BDD scénářů.
1. Definice akceptačních testů v jazyce Gherkin pro klíčové funkce (15 hodin)
2. Implementace integračních testů ověřujících součinnost CLI a backendu (10 hodin)
3. Validace chování aplikace v nestandardních síťových podmínkách (5 hodin)

N. Souhrnné označení náplně pracovních činností (30 hodin v období od 16. 02. 2026 do 20. 02. 2026)
Předmětem/cílem tohoto bloku úkolů je ladění chyb a handling výjimek.
1. Analýza a oprava chyb hlášených během interního testování (15 hodin)
2. Implementace robustního error handlingu v .NET backendu (10 hodin)
3. Zlepšení informativnosti chybových zpráv pro koncového uživatele (5 hodin)

O. Souhrnné označení náplně pracovních činností (30 hodin v období od 23. 02. 2026 do 27. 02. 2026)
Předmětem/cílem tohoto bloku úkolů je dokumentace a příprava k odevzdání.
1. Dokumentace IPC protokolu a API pro budoucí rozšíření (15 hodin)
2. Příprava instalačních skriptů a dokumentace k nasazení na Linux (10 hodin)
3. Sběr dat a screenshotů pro praktickou část bakalářské práce (5 hodin)

P. Souhrnné označení náplně pracovních činností (25 hodin v období od 02. 03. 2026 do 06. 03. 2026)
Předmětem/cílem tohoto bloku úkolů je finalizace funkčností a opravy.
1. Finalizace příkazů pro zobrazení stavu (status) a verzování (15 hodin)
2. Implementace mechanismu pro automatické aktualizace klienta (5 hodin)
3. Opravy drobných chyb v uživatelském rozhraní (5 hodin)

Q. Souhrnné označení náplně pracovních činností (15 hodin v období od 09. 03. 2026 do 13. 03. 2026)
Předmětem/cílem tohoto bloku úkolů je závěrečné testování a odevzdání výstupů.
1. Provedení závěrečných akceptačních testů celého systému (10 hodin)
2. Export a archivace zdrojových kódů a dokumentace (5 hodin)

---

Celkový počet odpracovaných hodin je: 480

Datum: 22. 3. 2026
Podpis pověřeného zaměstnance/zaměstnankyně organizace:
