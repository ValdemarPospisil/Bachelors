# Plán kapitoly 4: Implementace (04_implementace.tex)

## 1. Úvod
- Krátké představení cíle kapitoly: ukázat, jak byl návrh přetaven do kódu.
- Zdůraznění zaměření na konkrétní technické problémy a architekturu.

## 2. Implementace systémové služby (.NET)
- Úvod do .NET backendu. Jak je služba strukturovaná (Generic Host, Dependency Injection).

### 2.1 Bezpečné úložiště (Secure Storage)
- **Téma:** Ukládání citlivých dat (tokeny, klíče).
- **Propojení s teorií:** Odkaz na sekci 1.5.1 (ASP.NET Core Data Protection).
- **Obsah:** Popis implementace šifrování `DataProtection API`. Izolace klíčů pomocí práv `chmod 700` pro systémového uživatele `root`.
- **Ukázka kódu (Placeholder):** 
  ```csharp
  // [KÓD: Inicializace Data Protection s cestou ke klíčům a nastavením práv]
  ```

### 2.2 IPC Server (Unix Domain Sockets)
- **Téma:** Komunikace mezi službou a klientem.
- **Propojení s teorií:** Odkaz na sekci 1.4.1 (Unix Domain Sockets) a 1.5.3 (JSON IPC).
- **Obsah:** Vytvoření Named Pipe (Unix Domain Socket) v .NET. Přijímání a parsování zpráv ve formátu JSON z klienta (Request-Response model).
- **Ukázka kódu (Placeholder):** 
  ```csharp
  // [KÓD: Vytvoření NamedPipeServerStream s Unix Domain Socket pro Linux]
  ```
- **Diagram (Placeholder):** `[DIAGRAM: Flow parsování požadavku ze socketu, validace a odeslání JSON odpovědi]`

### 2.3 Životní cyklus a integrace se systemd
- **Téma:** Běh služby na pozadí, instalace.
- **Propojení s teorií:** Odkaz na sekci 1.3.3 (systemd).
- **Obsah:** Využití modulu `Microsoft.Extensions.Hosting.Systemd`. Definice `goodaccess-cli.service` a gracefully shutdown proces pro bezpečné odpojení VPN před vypnutím.
- **Ukázka kódu (Placeholder):**
  ```ini
  # [KÓD: Příklad systemd unit file (goodaccess-cli.service)]
  ```

## 3. Implementace klientské aplikace (Go)
- Úvod do Go klienta.
- **3.1 Parsování příkazů (Cobra)**
- **3.2 Interaktivní terminálové rozhraní (Bubble Tea)**
- **3.3 Komunikace se službou (IPC Klient)**

## 4. Závěr kapitoly
- Shrnutí implementace.
- Odkaz na další kapitolu (testování).