Feature: Searchskill

As a user I should be able to search skill through category,skills and user

@tag1
Scenario: Search skill through category on Searchskill page
	Given Launch Mars portal and login with valid user credentials and go to searchskill page
	When I click on category and sub category
	Then appropriate category should be displayed in result 

	Scenario Outline: Search skill through skills on Searchskill page
	Given Launch Mars portal and login with valid user credentials and go to searchskill page
	When I click search skill textbox and enter '<skill>'
	Then result should be displayed as per searched skill 

	Examples: 
	| skill           |
	| Software tester |
	| Test Analyst    |

	Scenario Outline: Search skill through user on Searchskill page
	Given Launch Mars portal and login with valid user credentials and go to searchskill page
	When I click search user textbox and enter '<user>'
	Then result should be displayed as per searched user

	Examples: 
	| user          |
	| Nikita Jindal |
	| xxx yyy       |