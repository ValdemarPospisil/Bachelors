# Plán kapitoly 4: Implementace (04_implementace.tex)

## 1. Úvod
- Krátké představení cíle kapitoly: ukázat, jak byl návrh přetaven do kódu.
- Zdůraznění zaměření na konkrétní technické problémy a architekturu.

## 2. Implementace systémové služby (.NET)
- Úvod do .NET backendu. Jak je služba strukturovaná (Generic Host, Dependency Injection) a jak to reflektuje zvolenou architekturu "Tenký klient" z návrhu.

### 2.1 Bezpečné úložiště (Secure Storage)
- **Téma:** Ukládání citlivých dat (tokeny, klíče).
- **Propojení:** Odkaz na sekci 1.5.1 (ASP.NET Core Data Protection) a naplnění nefunkčního požadavku N3 z analýzy. Odkaz na kapitolu Návrh (sekce 4.4 - Správa dat a bezpečnostní model).
- **Obsah:** Popis implementace šifrování `DataProtection API`. Izolace klíčů pomocí práv `chmod 700` pro systémového uživatele `root`.
- **Ukázka kódu (Placeholder):** 
  ```csharp
  // [KÓD: Inicializace Data Protection s cestou ke klíčům a nastavením práv]
  ```

### 2.2 IPC Server (Unix Domain Sockets)
- **Téma:** Komunikace mezi službou a klientem.
- **Propojení:** Odkaz na sekci 1.4.1 (Unix Domain Sockets) a 1.5.3 (JSON IPC). Dále odkaz na Návrh IPC komunikace (sekce 4.2).
- **Obsah:** Vytvoření Named Pipe (Unix Domain Socket) v .NET. Přijímání a parsování zpráv ve formátu JSON z klienta (Request-Response model).
- **Ukázka kódu (Placeholder):** 
  ```csharp
  // [KÓD: Vytvoření NamedPipeServerStream s Unix Domain Socket pro Linux]
  ```
- **Diagram (Placeholder):** `[DIAGRAM: Flow parsování požadavku ze socketu, validace a odeslání JSON odpovědi]`

### 2.3 Životní cyklus a integrace se systemd
- **Téma:** Běh služby na pozadí, instalace.
- **Propojení:** Odkaz na sekci 1.3.3 (systemd).
- **Obsah:** Využití modulu `Microsoft.Extensions.Hosting.Systemd`. Definice `goodaccess-cli.service` a gracefully shutdown proces pro bezpečné odpojení VPN před vypnutím.
- **Ukázka kódu (Placeholder):**
  ```ini
  # [KÓD: Příklad systemd unit file (goodaccess-cli.service)]
  ```

## 3. Implementace klientské aplikace (Go)
- Úvod do Go klienta. Architektura vrstev (Clean Architecture) a oddělení UI od logiky popsané v návrhu.

### 3.1 Parsování příkazů (Cobra)
- **Téma:** CLI rozhraní a struktura příkazů.
- **Propojení:** Odkaz na sekci 1.5.2 (Framework Cobra). Odkaz na navržený strom příkazů v sekci 4.3.1.
- **Obsah:** Popis inicializace hlavního příkazu `ga-cli` a podřízených příkazů (`setup`, `connect`, `status`). Způsob předávání flagů (např. `--json`).
- **Ukázka kódu (Placeholder):**
  ```go
  // [KÓD: Inicializace root příkazu pomocí knihovny Cobra]
  ```
- **Diagram (Placeholder):** `[DIAGRAM: Command Tree struktura s vybranými příkazy z návrhu]`

### 3.2 Interaktivní terminálové rozhraní (Bubble Tea)
- **Téma:** Textové uživatelské rozhraní pro průvodce nastavením (Setup wizard).
- **Propojení:** Odkaz na sekci 1.5.2 (Architektura Elm a Bubble Tea). Odkaz na navržený Průvodce nastavením v sekci 4.3.4 a splnění požadavku F10.
- **Obsah:** Ukázka The Elm Architecture v praxi. Implementace `Update` funkce pro reakci na klávesy a `View` pro vykreslování s využitím `Lip Gloss`. Průběh onboarding flow.
- **Ukázka kódu (Placeholder):**
  ```go
  // [KÓD: Update funkce v Bubble Tea (reakce na Msg)]
  ```
- **Screenshot (Placeholder):** `[SCREENSHOT: Setup Wizard UI - výběr brány / zadávání hesla]`

### 3.3 Komunikace se službou (IPC Klient)
- **Téma:** Odesílání a přijímání JSON dat z Unix Domain Socketu.
- **Propojení:** Odkaz na sekci 1.4.1 (Unix Domain Sockets) a 1.5.3 (JSON IPC). Odkaz na Návrh komunikace IPC (sekce 4.2).
- **Obsah:** Kód IPC klienta, který navazuje spojení přes `net.Dial("unix", "/tmp/CoreFxPipe_ga-cli.sock")`. Formátování dat do JSON struktur (Structs v Go) a jejich deserializace zpět.
- **Ukázka kódu (Placeholder):**
  ```go
  // [KÓD: Vytvoření požadavku, jeho JSON marshaling a odeslání přes UDS]
  ```

## 4. Závěr kapitoly
- Shrnutí implementace.
- Odkaz na další kapitolu (testování).