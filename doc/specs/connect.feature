Feature: Connect to VPN
  As a user
  I want to establish a VPN connection
  So that I can access secured resources

  Background:
    Given the GoodAccess service is running
    And I am logged in

  Scenario: Connect using saved preferences (Default behavior)
    Given I have a saved configuration:
      | Gateway  | CZ Prague |
      | Protocol | WireGuard |
    When I run "ga-cli connect"
    Then the system should initiate connection to "CZ Prague" using "WireGuard"
    And I should see "Connected" in the output
    And the exit code should be 0

  Scenario: Connect with Gateway Flag (One-off connection)
    Given I have a saved configuration for "CZ Prague"
    When I run "ga-cli connect --gateway"
    Then I should see a list of available gateways
    When I select "US New York"
    Then the system should initiate connection to "US New York"
    But the saved configuration should STILL be "CZ Prague"
    # Note: Preference is NOT updated, only current session uses US New York

  Scenario: Display Recommended Gateway label
    Given the current recommended gateway is "CZ Prague"
    When I connect to "CZ Prague"
    Then the output should display the connection details
    And the Gateway line should contain "(Recommended)"
    # Example output: Gateway: [CZ] Prague (123.45.6.7) (Recommended)

  Scenario: Connect when already connected
    Given I am already connected
    When I run "ga-cli connect"
    Then I should see an error message "Already connected"
    And the exit code should be 1

  Scenario: No Internet
    Given there is no internet connection
    When I run "ga-cli connect"
    Then I should see an error message "Network error: check your connection"
    And NO connection attempt should be made
    And the exit code should be 1

  Scenario: Ctrl+C Interruption (During Connection)
    Given the connection process has started
    When I press Ctrl+C
    Then the application should exit
    But the connection attempt should continue in the background
    # (Fire-and-forget: The CLI client exits, but the daemon keeps trying)

  Scenario: Block connection attempt when another user is persistently connected
    Given a persistent VPN connection is active by another linux user "user_a"
    And I am logged in as "user_b"
    When I run "ga-cli connect"
    Then I should see an error message "Another user is already connected"
    And I should see a hint "Run 'sudo ga-cli disconnect' first"
    And the exit code should be 1

