Feature: Version
  As a user
  I want to know the version of the CLI and Service
  So that I can report issues or know if I need to update

  Background:
    Given the GoodAccess service is running

  Scenario: Display Version Info
    When I run "ga-cli version"
    Then the output should contain "CLI Version:"
    And the output should contain "Service Version:"
    And the exit code should be 0

  Scenario: Display Version in JSON Format
    When I run "ga-cli version --json"
    Then the output should be valid JSON
    And the JSON should contain "cliVersion"
    And the JSON should contain "ServiceVersion"

  Scenario: Service Unreachable
    Given the GoodAccess service is NOT running
    When I run "ga-cli version"
    Then the output should contain "CLI Version:"
    But the output should contain "Error: failed to communicate with service"
    And the exit code should be 1

