@Post
@Pet
@Regression
Feature: Post Pet
	
Scenario: 1. Validate Pet creation with empty model
	Given I have free API with swagger
	When I send the pet creation request with empty model
	Then I see created pet in the get response
	
Scenario: 2. Validate Pet creation with null model
	Given I have free API with swagger
	When I send the pet creation request with null model
	Then I see 'UnsupportedMediaType' status code request

Scenario: 3. Validate that new pet can be create with correct data 
	Given I have free API with swagger
	When I create pet with 'New' data 
	Then I see that new pet has been created successfully 
