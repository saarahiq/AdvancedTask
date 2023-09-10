Feature: Chat

As a user I'd like to chat with different users

@tag1
Scenario: Chat with first user
	Given Launch Mars portal and login with valid user credentials and go to chat page
	When I enter message in type your '<message>' here textbox and click send
	Then the message should be send successfully

	Examples: 
	| message                           |
	| Hi how are you                    |
	| I am interested in trading skills |

	Scenario Outline: Chat by searching user using invalid name
	Given Launch Mars portal and login with valid user credentials and go to chat page
	When I enter '<username>' in lower case or invalid
	Then user should not appear in the selection list presented

	Examples: 
	| username |
	| nik      |
	| jessica  |

	Scenario Outline: Chat with the user by searching through searchbar
	Given Launch Mars portal and login with valid user credentials and go to chat page
	When I enter '<username>' in the searctextbox
	Then searched user should be presented to chat

	Examples: 
	| username |
	| Nik      |
	| Mars     |