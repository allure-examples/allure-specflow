@allure.label.layer:rest
Feature: Labels API

  @smoke
  Scenario: Create new label via api
    When I create label with title "hello" via api
    Then I should see label with title "hello" via api

  @regress
  Scenario: Delete existing label via api
    When I create label with title "hello" via api
    And I delete label with title "hello" via api
    Then I should not see label with title "hello" via api
