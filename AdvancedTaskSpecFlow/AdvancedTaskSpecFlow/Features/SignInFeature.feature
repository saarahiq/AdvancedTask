Feature: SignInFeature

As a user, I'd like to sign in Mars portal successfully.
As a user, I can't sign in Mars portal with invalid details.

@tag1

Scenario: 01) I sign in Mars portal with default user
	Given Launch Mars portal and login with default user
	Then I signed in  Mars portal successfully

Scenario Outline: I sign in Mars portal successfully with valid details
	Given Launch Mars portal
	When  Input valid '<email>' and '<password>'
	Then I signed in  Mars portal successfully

	Examples: 
	|email                      |password |
	|advanced.task@example.com  |123456   |
	|ada520@example.com         |abcdefg  |


Scenario Outline: 02) I sign in Mars portal failed with invalid details
	Given Launch Mars portal
	When  Input invalid '<email>' and '<password>'
	Then I signed in  Mars portal failed

	Examples: 
	| email                     | password |
	|                           | 123456   |
	| advanced.taskexample.com  | 123456   |
	| advanced.task@example.com |          |
	| advanced.task@example.com | 1234567  |
	