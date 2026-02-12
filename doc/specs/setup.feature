Feature: Setup Configuration
  As a user
  I want to configure my default connection preferences
  So that future connections are fast and automatic

  Background:
    Given the GoodAccess service is running
    And I am logged in

  Scenario: Initial Setup (Fresh Install)
    Given no configuration exists
    When I run "ga-cli setup"
    Then I should be prompted to select a Protocol
    When I select "WireGuard"
    Then I should see a list of available gateways
    When I select a gateway "CZ Prague"
    Then I should be asked about persistence
    When I enable persistence
    Then the configuration should be saved with:
      | Protocol   | WireGuard |
      | Gateway    | CZ Prague |
      | Persistent | true      |
    And I should be asked to connect immediately

  Scenario: Setup while Connected (User accepts disconnect)
    Given I am currently connected to VPN
    When I run "ga-cli setup"
    Then I should see a warning "You are currently connected"
    And I should be asked "Do you want to disconnect and continue?"
    When I choose "Yes"
    Then the VPN should disconnect
    And the setup wizard should proceed to Protocol selection

  Scenario: Setup while Connected (User declines disconnect)
    Given I am currently connected to VPN
    When I run "ga-cli setup"
    And I should be asked "Do you want to disconnect and continue?"
    When I choose "No"
    Then the setup process should exit
    And the VPN connection should remain active

  Scenario: Setup with Gateway Flag (Update Gateway Preference Only)
    Given I have an existing configuration:
      | Protocol   | OpenVPN |
      | Persistent | true    |
    When I run "ga-cli setup --gateway"
    Then I should NOT be prompted for Protocol selection
    And I should NOT be prompted for Persistence
    But I should see a list of available gateways
    When I select a new gateway "DE Berlin"
    Then the configuration should be updated to:
      | Protocol   | OpenVPN   |
      | Gateway    | DE Berlin |
      | Persistent | true      |

  Scenario: Ctrl+C Before Save (Transaction Boundary)
    Given I am on step 3 (Gateway Selection)
    When I press Ctrl+C
    Then the application should exit
    And NO configuration changes should be saved

  Scenario: Ctrl+C After Save (Transaction Boundary)
    Given I have completed step 4 (Persistence)
    And the configuration has been saved
    When I press Ctrl+C during the "Connect Now?" prompt
    Then the application should exit
    But the configuration changes SHOULD be preserved

  Scenario: Parallel Setup Conflict (Last Write Wins & Connection Block)
    Given I start "ga-cli setup" in Terminal 1
    And I start "ga-cli setup" in Terminal 2
    When I save preferences in Terminal 2
    And I connect to VPN in Terminal 2
    And I return to Terminal 1 to finish setup
    Then Terminal 1 should display "Error: Already connected"
    And the process in Terminal 1 should exit
    But the preferences saved in Terminal 1 (if any) should overwrite Terminal 2's preferences

  Scenario: No Internet
    Given there is no internet connection
    When I run "ga-cli setup"
    Then I should see an error message "Network error: check your connection"
    And the setup wizard should exit

  Scenario: Block connection attempt when another user is persistently connected
    Given a persistent VPN connection is active by another user "user_a"
    And I am logged in as "user_b"
    When I run "ga-cli connect"
    Then I should see an error message "Another user is already connected"
    And I should see a hint "Run 'sudo ga-cli disconnect' first"
    And the exit code should be 1
