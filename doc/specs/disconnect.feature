Feature: Disconnect from VPN
  As a user
  I want to disconnect from the VPN
  So that I can stop routing traffic through the corporate gateway

  Background:
    Given the GoodAccess service is running
    And I am logged in

  Scenario: Successful disconnect
    Given I am currently connected to "CZ Prague"
    When I run "ga-cli disconnect"
    Then the system should terminate the VPN connection
    And I should see a success message "Disconnected successfully"
    And the exit code should be 0

  Scenario: Try to disconnect when NOT connected
    Given I am already disconnected
    When I run "ga-cli disconnect"
    Then I should see an error message "You are not connected to any VPN"
    And the exit code should be 1

  Scenario: Ctrl+C Interruption (During Disconnect)
    Given I am currently connected
    When I run "ga-cli disconnect"
    And the disconnection is processing
    And I press Ctrl+C
    Then the application should exit
    But the disconnection attempt should continue in the background
    # (Fire-and-forget)

  Scenario: No Internet
    Given there is no internet connection
    When I run "ga-cli disconnect"
    Then the system should still attempt to stop the VPN interface
    And I should see a success message "Disconnected successfully"

  Scenario: Try to disconnect another user WITHOUT sudo
    Given a persistent VPN connection is active by another user "user_a"
    And I am logged in as "user_b"
    And I am NOT running with sudo privileges
    When I run "ga-cli disconnect"
    Then I should see an error message "Permission denied: Another user is connected"
    And I should see a hint "Run 'sudo ga-cli disconnect' to force disconnection"
    And the exit code should be 1

  Scenario: Force disconnect another user WITH sudo
    Given a persistent VPN connection is active by another user "user_a"
    And I am running with sudo privileges
    When I run "ga-cli disconnect"
    Then the system should terminate the VPN connection
    And the persistent lock for "user_a" should be released
    And I should see a success message "Disconnected successfully"
    And the exit code should be 0
