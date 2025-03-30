Feature: Login Functionality
    
  Rule: User opened the Login page
  Background:  
    Given I opened the Login page

  Scenario: UC-1 - Login with empty credentials    
    Given I entered "standard_user" as username
    And I entered "secret_sauce" as password
    And I cleared both inputs
    When I click the Login button with invalid input
    Then I should see the error message "Username is required"

  Scenario: UC-2 - Login with missing password
    Given I entered "standard_user" as username
    And I entered "secret_sauce" as password
    And I cleared the Password input
    When I click the Login button with invalid input
    Then I should see the error message "Password is required"

  Scenario: UC-3 - Login with valid credentials
    Given I entered "standard_user" as username
    And I entered "secret_sauce" as password
    When I click the Login button with valid input
    Then I should see the dashboard title "Swag Labs"
