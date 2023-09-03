Feature: SideBarsFeature

As a Mars user, I can edit Availability, Hours and EarnTarget.

@tag1
Scenario Outline: 01) I can edit availability
	Given Launch Mars portal and login with default user
	When select '<Availability>'
	Then The availability should be edited successfully

	Examples:
	| Availability |
	| Part Time    | 
	| Full Time    | 
	    
Scenario Outline: 02) I can edit hours
	Given Launch Mars portal and login with default user
	When I can select '<Hours>'
	Then The hours should be edited successfully

	Examples:
	| Hours                    |
	| As needed                |
	| Less than 30hours a week |
	| More than 30hours a week |

Scenario Outline: 03) I can edit earn target
	Given Launch Mars portal and login with default user
	When I can edit '<earnTarget>'
	Then The earn target should be edited successfully

	Examples:
	| earnTarget                       |
	| Less than $500 per month         |
	| Between $500 and $1000 per month |
	| More than $1000 per month        |
