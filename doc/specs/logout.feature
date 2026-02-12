Feature: Logout
  As a user
  I want to log out
  So that I can end my session securely

  Background:
    Given the GoodAccess service is running

  Scenario: Successful logout when not connected
    Given I am logged in
    And I am not connected to any gateway
    When I run "ga-cli logout"
    Then the system should perform a logout
    And I should see a success message
    And the exit code should be 0

  Scenario: Logout while connected
    Given I am logged in
    And I am connected to a gateway
    When I run "ga-cli logout"
    Then I should be prompted to disconnect first
    When I confirm disconnection
    Then the system should disconnect from the gateway
    And the system should perform a logout
    And I should see a success message

  Scenario: Logout cancellation while connected
    Given I am logged in
    And I am connected to a gateway
    When I run "ga-cli logout"
    And I decline to disconnect
    Then the logout process should be cancelled
    And I should remain logged in
    And I should remain connected

  Scenario: Not logged in
    Given I am not logged in
    When I run "ga-cli logout"
    Then I should see an error message "not_logged_in"
    And the exit code should be 1

  Scenario: Ctrl+C Interruption (During Logout)
    Given the logout process has started
    When I press Ctrl+C
    Then the application should exit
    But the logout request should continue in the background

  Scenario: No Internet
    Given there is no internet connection
    When I run "ga-cli logout"
    Then I should see an error message "Network error: check your connection"
    And I should remain logged in

  Scenario: Block connection attempt when another user is persistently connected
    Given a persistent VPN connection is active by another linux user "user_a"
    And I am logged in as "user_b"
    When I run "ga-cli connect"
    Then I should see an error message "Another user is already connected"
    And I should see a hint "Run 'sudo ga-cli disconnect' first"
    And the exit code should be 1

