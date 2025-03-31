Feature: Login Functionality

  Rule: User opened the Login page
  
  Scenario Outline: UC-1 - Login with empty credentials
    Given I use "<browser>" browser
    And I opened the Login page  
    And I entered "standard_user" as username
    And I entered "secret_sauce" as password
    And I cleared both inputs
    When I click the Login button with invalid input
    Then I should see the error message "Username is required"
    
  Examples:
      | browser  |
      | Chrome   |
      | Edge     |
      | Firefox  |

  Scenario Outline: UC-2 - Login with missing password
    Given I use "<browser>" browser
    And I opened the Login page  
    And I entered "standard_user" as username
    And I entered "secret_sauce" as password
    And I cleared the Password input
    When I click the Login button with invalid input
    Then I should see the error message "Password is required"
  
  Examples:
      | browser  |
      | Chrome   |
      | Edge     |
      | Firefox  |

  Scenario Outline: UC-3 - Login with valid credentials
    Given I use "<browser>" browser
    And I opened the Login page  
    And I entered "standard_user" as username
    And I entered "secret_sauce" as password
    When I click the Login button with valid input
    Then I should see the dashboard title "Swag Labs"
    
  Examples:
      | browser  |
      | Chrome   |
      | Edge     |
      | Firefox  |