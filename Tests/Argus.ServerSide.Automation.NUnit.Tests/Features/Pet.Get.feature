@Get
@Pet
@Regression
Feature: Get Pet by Id
	Story:

@Smoke
Scenario: 1. Validate Get Pet by id with valid data
	Given I have free API with swagger
	When I receive get pet by id response
	Then I see returned pet details

Scenario Outline: 2. Validate Get Pet by id with invalid data
	Given I have free API with swagger
	When I receive get pet by id response with <WrongId> wrong id
	Then I see NotFound response status code
	And I see <ErrorResponse> response

	Examples:
		| TestId   | WrongId              | ErrorResponse                                                                                                         |
		| string   | string               | {"code":404,"type":"unknown","message":"java.lang.NumberFormatException: For input string: \"string\""}               |
		| specChar | &we@#$%              | {"code":404,"type":"unknown","message":"java.lang.NumberFormatException: For input string: \"&we@\""}                 |
		| maxValue | 99999999999999999999 | {"code":404,"type":"unknown","message":"java.lang.NumberFormatException: For input string: \"99999999999999999999\""} |
		| minValue | -9999                | {"code":1,"type":"error","message":"Pet not found"}                                                                   |
		| zero     | 0                    | {"code":1,"type":"error","message":"Pet not found"}                                                                   |