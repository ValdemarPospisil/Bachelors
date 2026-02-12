Feature: Status
  As a user
  I want to check the status of my VPN connection
  So that I know if I am secured and what gateway I am using

  Background:
    Given the GoodAccess service is running

  Scenario: Not Logged In
    Given I am not logged in
    When I run "ga-cli status"
    Then the output should contain "Status: Not Logged In"
    And the output should contain "You are not currently authenticated"
    And the exit code should be 0

  Scenario: Disconnected (No Preferences)
    Given I am logged in
    And I am not connected
    And I have no saved preferences
    When I run "ga-cli status"
    Then the output should contain "Status: Disconnected"
    And the output should NOT contain "Preferred Gateway"
    And the output should contain "To connect, run:"

  Scenario: Disconnected (With Recommended Preference)
    Given I am logged in
    And I am not connected
    And I have a saved configuration:
      | Gateway  | Recommended |
      | Protocol | WireGuard   |
    When I run "ga-cli status"
    Then the output should contain "Status: Disconnected"
    And the output should contain "Preferred Gateway: Recommended Gateway"

  Scenario: Disconnected (With Specific Preference)
    Given I am logged in
    And I am not connected
    And I have a saved configuration:
      | Gateway  | CZ Prague |
    When I run "ga-cli status"
    Then the output should contain "Status: Disconnected"
    And the output should contain "Preferred Gateway: [CZ] Prague"

  Scenario: Connected (Standard)
    Given I am connected to "CZ Prague"
    When I run "ga-cli status"
    Then the output should contain "Status: Connected"
    And the output should contain "Connected Gateway: [CZ] Prague"
    And the output should contain "Duration:"

  Scenario: Connected (Recommended)
    Given I connected using the "Recommended" gateway
    And the system assigned "DE Berlin" as the recommended gateway
    When I run "ga-cli status"
    Then the output should contain "Status: Connected"
    And the output should contain "Connected Gateway: [DE] Berlin (Recommended)"

  Scenario: No Internet (Disconnected)
    Given I am not connected
    And there is no internet connection
    When I run "ga-cli status"
    Then the output should contain "Status: Disconnected"

  Scenario: No Internet (Connected)
    Given I am connected
    And I lose internet connection
    When I run "ga-cli status"
    Then the output should contain "Status: Reconnecting"

  Scenario: JSON Output
    Given I am connected to "CZ Prague"
    When I run "ga-cli status --json"
    Then the output should be valid JSON
    And the JSON should contain "IsConnected": true
    And the JSON should contain "ConnectedGatewayName": "Prague"

  Scenario: Block connection attempt when another user is persistently connected
    Given a persistent VPN connection is active by another user "user_a"
    And I am logged in as "user_b"
    When I run "ga-cli connect"
    Then I should see an error message "Another user is already connected"
    And I should see a hint "Run 'sudo ga-cli disconnect' first"
    And the exit code should be 1
