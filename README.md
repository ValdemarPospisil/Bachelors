# GoodAccess CLI Klient pro Linux

Tento projekt je zaměřen na vývoj nativního CLI (Command Line Interface) klienta pro službu **GoodAccess** v prostředí operačního systému Linux. Součástí projektu je také bakalářská práce dokumentující celý proces vývoje od analýzy až po distribuci.

> [!IMPORTANT]
> **Poznámka k repozitáři:** Vzhledem k tomu, že vývoj probíhal v rámci firemního prostředí, je samotný zdrojový kód aplikace **soukromý**. Tento veřejný repozitář ([ValdemarPospisil/Bachelors](https://github.com/ValdemarPospisil/Bachelors)) slouží jako doprovodný materiál k bakalářské práci a obsahuje dokumentaci, ukázky kódu, schémata a specifikace testů.

---

## 🏗️ Architektura Systému

Aplikace je navržena jako distribuovaný systém skládající se ze dvou hlavních komponent komunikujících přes **Unix Domain Sockets (UDS)**.

### Celkové schéma
```mermaid
classDiagram
    class GoCLI {
        +main()
    }
    class UnixClient {
        -socketPath: string
        +Send(command, payload)
    }
    class SenderReader {
        -pipeName: string
        +CreatePipe()
        +ReadMessageAsync()
        +SendMessageAsync()
    }
    class CliMessenger {
        -senderReader: SenderReader
        +Start()
        +HandleCommand()
    }
    class AuthService {
        +Login()
        +IsUserLoggedIn()
    }
    class VpnService {
        +Connect()
        +Disconnect()
    }
    class GatewayService {
        +GetGateways()
    }
    class UserProfileService {
        +SaveConfiguration()
    }
    class VpnManager {
        -agents: IAgent[]
    }
    class IAgent {
        <<interface>>
        +Connect()
    }
    class OpenVPN {
    }
    class WireGuard {
    }

    GoCLI --> UnixClient : používá
    UnixClient ..> SenderReader : IPC (UDS/JSON)
    CliMessenger --> SenderReader : používá
    CliMessenger --> AuthService : spravuje
    CliMessenger --> VpnService : spravuje
    CliMessenger --> GatewayService : spravuje
    CliMessenger --> UserProfileService : spravuje
    VpnService --> VpnManager : orchestruje
    VpnManager --> IAgent : používá
    IAgent <|.. OpenVPN : implementuje
    IAgent <|.. WireGuard : implementuje
```

### Komponentový model (User vs System Space)
Vizualizace rozdělení aplikace na klientskou část (User Space) a systémového démona (System Space).

![Architecture Component Model](./thesis/images/navrh-architecture.png)

### Bezpečnostní model (Data Protection)
Schéma zajištění bezpečnosti uložených dat a ověřování identity uživatele (LinuxId validation).

![Security Component](./thesis/images/security-component.png)

### IPC Komunikace (Sekvenční diagram přihlášení)
Komunikace mezi klientem a službou probíhá asynchronně pomocí JSON zpráv. Níže je vizualizace procesu přihlášení.

![Login Sequence](./doc/diagrams/Sequence%20-%20Login.png)

### Hierarchie příkazů
Přehled dostupných příkazů a jejich struktury v rámci CLI aplikace.

![Command Hierarchy](./thesis/images/command-tree.png)

### Distribuce a Aktualizace
Diagram zobrazující proces detekce nové verze a následnou aktualizaci balíčků přes systémového správce balíčků.

![Distribution Diagram](./thesis/images/distribution-diagram.png)

## 📸 Ukázky z Implementace (Screenshots)

Zde jsou snímky obrazovky zachycující různé stavy aplikace v logickém pořadí.

| Stav | Náhled |
| :--- | :--- |
| **Průvodce: Přihlášení (Setup)** | ![Setup Login](./thesis/images/implementation/screenshots/setup-step-login.png) |
| **Průvodce: Výběr brány (Gateway)** | ![Gateway](./thesis/images/implementation/screenshots/setup-step-gateway.png) |
| **Průvodce: Protokol** | ![Setup Protocol](./doc/screenshots/setup-protocol.png) |
| **Průvodce: Persistence** | ![Setup Persistence](./doc/screenshots/setup-persistent.png) |
| **Úspěšné přihlášení (Login)** | ![Login](./doc/screenshots/login-successfull.png) |
| **Připojování (Spinner)** | ![Connecting](./thesis/images/implementation/screenshots/connecting-spinner.png) |
| **Stav připojení (Status)** | ![Status](./thesis/images/implementation/screenshots/status-connected.png) |
| **Úspěšné připojení** | ![Connected](./doc/screenshots/connect-successfull.png) |
| **Odpojeno (Disconnected)** | ![Disconnected](./doc/screenshots/disconnect-successfull.png) |
| **Nápověda (Help)** | ![Help](./doc/screenshots/connect-help.png) |
| **Chyba sítě (Error)** | ![Error](./doc/screenshots/connect-network-error.png) |
| **JSON výstup (Status JSON)** | ![Status JSON](./thesis/images/implementation/screenshots/status-json.png) |
| **Konflikt: Jiný uživatel** | ![Another User](./thesis/images/implementation/screenshots/another-user-connected.png) |
| **Odhlášení (Vynucené odpojení)** | ![Logout Connected](./doc/screenshots/logout-connected.png) |
| **Úspěšné odhlášení (Logout)** | ![Logout Success](./doc/screenshots/logout-successfull.png) |

---

## 💻 Technické Detaily

### Implementační technologie
- **Frontend (UI/CLI):** [Go (Golang)](./doc/code/main.go) – Zaměřeno na rychlost, jednoduchost a statickou binárku.
- **Backend (Daemon):** [.NET 8 (C#)](./doc/code/Program.cs) – Systémová služba spravovaná přes `systemd`, využívající silné typování a moderní asynchronní API.
- **IPC:** Unix Domain Sockets s JSON serializací (viz [protocol.go](./doc/code/protocol.go)).

### Ukázka kódu (Go Frontend)
```go
// Inicializace klienta a spuštění root příkazu
func main() {
    socketPath := "/tmp/CoreFxPipe_ga-cli.sock"
    client := adapter.NewUnixClient(socketPath)
    rootCmd := cmd.NewRootCmd(client)

    if err := rootCmd.Execute(); err != nil {
        fmt.Fprintln(os.Stderr, err)
        os.Exit(1)
    }
}
```

### Ukázka kódu (C# Backend)
```csharp
// Konfigurace hostitele pro systémovou službu
IHost host = Host.CreateDefaultBuilder(args)
    .UseSystemd()
    .ConfigureServices(services =>
    {
        services.AddDataProtection()
            .PersistKeysToFileSystem(new DirectoryInfo(keysPath))
            .SetApplicationName("CLIService");

        services.AddSingleton(logger);
        services.AddHostedService<Worker>();
    })
    .Build();

await host.RunAsync();
```

---

## 🧪 Zajištění Kvality (QA)

Projekt využívá metodiku **BDD (Behavior-Driven Development)** pro definici uživatelských požadavků a jejich následné testování.

### Gherkin Specifikace
Testovací scénáře jsou psány v jazyce Gherkin, což umožňuje snadnou komunikaci mezi vývojáři a zadavatelem.

**Ukázka scénáře ([connect.feature](./doc/specs/connect.feature)):**
```gherkin
Scenario: Connect using saved preferences (Default behavior)
    Given I have a saved configuration:
      | Gateway  | CZ Prague |
      | Protocol | WireGuard |
    When I run "ga-cli connect"
    Then the system should initiate connection to "CZ Prague" using "WireGuard"
    And I should see "Connected" in the output
    And the exit code should be 0
```

**Odkazy na specifikace:**
- [Login](./doc/specs/login.feature)
- [Logout](./doc/specs/logout.feature)
- [Setup](./doc/specs/setup.feature)
- [Connect](./doc/specs/connect.feature)
- [Disconnect](./doc/specs/disconnect.feature)
- [Status](./doc/specs/status.feature)
- [Version](./doc/specs/version.feature)

---

## 📅 Roadmapa Projektu (Ganttův diagram)

Vývoj probíhal iterativně od počátečního návrhu IPC až po finální balíčkování.

```mermaid
gantt
    title GoodAccess CLI - Vývojová Roadmapa (2025-2026)
    dateFormat  YYYY-MM-DD
    axisFormat  %m/%y
    
    section Foundation & IPC
    Analýza a návrh IPC struktury :done, init, 2025-12-01, 14d
    TUI Framework (Bubble Tea)    :done, tui, after init, 8d
    
    section Auth & UI logic
    Login / Logout mechanismus    :done, login, after tui, 10d
    Interaktivní Setup Wizard     :done, setup, after login, 10d
    Status & View modely          :done, stat, after setup, 8d

    section Core Implementation
    Connect / Disconnect logika   :done, conn, after stat, 12d
    Persistence & Systemd integrace:done, pers, after conn, 12d
    WireGuard & OpenVPN podpora   :done, vpn, after pers, 18d

    section Polish & QA
    Rozšíření (-p, -g přepínače)  :done, enh, after vpn, 8d
    Řešení konfliktů (Multi-user) :done, conf, after enh, 10d
    QA & Balíčkování (.deb, .rpm) :active, rel, after conf, 10d
```

---

## 🎥 Video Ukázka (Walkthrough)

Zde je kompletní video ukázka základního workflow aplikace od prvního nastavení až po odhlášení.

![Walkthrough](./doc/videos/full-walktrough.mp4)

---

## 📄 Dokumentace a Výstupy

Kompletní dokumentaci k projektu naleznete v následujících souborech:

- **Bakalářská práce:** [thesis.pdf](./thesis/build/thesis.pdf)
- **Zdrojové texty (LaTeX):** [thesis/](./thesis/)
- **Prezentace:** [prezentace.pdf](./presentations/SKKI1/build/prezentace.pdf)

---

© 2026 Valdemar Pospíšil
