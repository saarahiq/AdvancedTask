Feature: Description

As a user,I'd like to add description on profile page successfully
As a user I'd like to edit description successfully

@tag1
Scenario: Add description on the profile page
	Given Launch Mars portal and login with valid user credentials
	When Input valid '<Availability>','<Hours>','<EarnTarget>','<Description>'
	Then The description should be added successfully

Examples: 
| Availability | Hours                    | EarnTarget                       | Description                                          |
| Part Time    | Less than 30hours a week | Less than $500 per month         | My Profile describes all about begineer Test Analyst |
| Full Time    | More than 30hours a week | Between $500 and $1000 per month | Software Tester Begineer                             |

Scenario Outline: Edit description on profile page
Given Launch Mars portal and login with valid user credentials
When Edit '<Availability>','<Hours>','<EarnTarget>','<Description>'
Then The description should be edited successfully

Examples: 
| Availability | Hours                    | EarnTarget                | Description |
| Full Time    | More than 30hours a week | More than $1000 per month | Test Intern |
 

Scenario Outline: Add invalid description on profile page starting with special character
Given Launch Mars portal and login with valid user credentials
When Input valid '<Availability>','<Hours>','<Earn Target>' and invalid '<Description>'
Then The description should not be added successfully

Examples: 
| Availability | Hours                    | EarnTarget                       | Description                                           |
| Part Time    | Less than 30hours a week | Less than $500 per month         | @My Profile describes all about begineer Test Analyst |
| Full Time    | More than 30hours a week | Between $500 and $1000 per month | @Software Tester                                      |




Scenario Outline: Add empty description
Given Launch Mars portal and login with valid user credentials
When Input valid'<Availability>','<Hours>','<Earn Target>' and empty '<Description>'
Then The description should not be added successfully


Examples: 
 | Availability | Hours                    | EarnTarget               | Description |
 | Full time    | Less than 30hours a week | Less than $500 per month |             |
