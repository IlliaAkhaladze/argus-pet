@Delete
@Pet
@Regression
Feature: Delete Pet

A short summary of the feature

@Smoke
Scenario: 1. Validate that we can delete created pet
	Given I have free API with swagger
	And I have created pet entity
	When I delete the created pet entity
	Then I see 'OK' response status of delete request
	And I don't see newly created pet

Scenario: 2. Validate response when delete by not exists id
	Given I have free API with swagger
	When I delete not exists pet by 'GUID' id value
	Then I see 'NotFound' response status of delete request

Scenario: 2. Validate response when delete by null id
	Given I have free API with swagger
	When I delete not exists pet by null id value
	Then I see 'MethodNotAllowed' response status of delete request
