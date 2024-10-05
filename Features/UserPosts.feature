Feature: User Posts API

  Scenario: Get all posts
    Given I have a valid API endpoint
    When I send a GET request to "/posts"
    Then the response status code should be 200
    And the response should contain a list of posts

  Scenario: Get a single post by ID
    Given I have a valid API endpoint
    And the post ID is 1
    When I send a GET request to "/posts/1"
    Then the response status code should be 200
    And the response should contain the post with ID 1
