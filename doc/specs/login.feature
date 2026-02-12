Feature: Login
  As a user
  I want to log in to the GoodAccess CLI
  So that I can access the VPN network

  Background:
    Given the GoodAccess service is running

  Scenario: Successful login
    Given I am not logged in
    When I run "ga-cli login"
    And I enter a valid Team name
    And I enter a valid Username
    And I enter a valid Password
    And I submit the form
    Then the system should authenticate the user
    And the application should exit with success

  Scenario: Login failure with invalid credentials
    Given I am not logged in
    When I run "ga-cli login"
    And I enter invalid credentials
    And I submit the form
    Then I should see an error message "Invalid Team, Username, or Password."
    And the password field should be cleared
    And the focus should return to the password field

  Scenario: Validation error for empty fields
    Given I am not logged in
    When I run "ga-cli login"
    And I leave the "Team" field empty
    And I submit the form
    Then I should see a validation error "Team name cannot be empty"

  Scenario: Already logged in
    Given I am already logged in as "user@example.com"
    When I run "ga-cli login"
    Then I should see "Already logged in" state
    And the application should exit

  Scenario: No Internet during Login
    Given I am not logged in
    And there is no internet connection
    When I run "ga-cli login"
    And I enter valid credentials
    And I submit the form
    Then I should see an error message "Network error: check your connection"
    And I should remain on the login screen

  Scenario: Ctrl+C Interruption (Before Submit)
    Given I am on the login screen
    When I press Ctrl+C
    Then the application should exit
    And NO login request should be sent

  Scenario: Ctrl+C Interruption (After Submit)
    Given I have submitted the login form
    And the authentication request is processing
    When I press Ctrl+C
    Then the application should exit
    But the login process should continue in the background

  Scenario: Block connection attempt when another user is persistently connected
    Given a persistent VPN connection is active by another linux user "user_a"
    And I am logged in as "user_b"
    When I run "ga-cli connect"
    Then I should see an error message "Another user is already connected"
    And I should see a hint "Run 'sudo ga-cli disconnect' first"
    And the exit code should be 1

