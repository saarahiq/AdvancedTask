Feature: ReceivedRequests

Aa a skillswap user I want to be able to accept, decline and complete a skill trade request, 
so that I can exchange and gain skills from other users

@order(1)
Scenario: Accept a Skill Trade request
	Given I logged in successfully and naviagte to Receieved Requests page to accept
	When I click on the Accept button of a Skill trade request by '<Sender>' with '<Title>' 
	Then I verify that the request by '<Sender>' with '<Title>' has been accepted and I should see the '<Message>'

	Examples: 
	| Sender | Title                  | Message                  |
	| Mars   | Make up and Hair Style | Service has been updated |

	@order(2)
	Scenario Outline: Decline a Skill Trade request
	Given I logged in successfully and naviagte to Receieved Requests page to decline
	When I click on the Decline button of a Skill trade request by '<Sender>' with '<Title>' 
	Then I verify that the request by '<Sender>' with '<Title>' has been declined and I should see the '<Message>'

	Examples: 
	| Sender | Title    | Message                  |
	| Mars   | Swimming | Service has been updated |

	@order(3)
	Scenario Outline: Complete a Skill Trade request
	Given I logged in successfully and naviagte to Receieved Requests page to complete
	When I click on the Complete button of a Skill trade request by '<Sender>' with '<Title>' 
	Then I verify that the request by '<Sender>' with '<Title>' has been completed and I should see the '<Message>'

	Examples: 
	| Sender | Title        | Message                  |
	| Mars   | Data Analyst | Request has been updated |