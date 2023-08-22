Feature: SentRequestsFeature

As a Mars user, I'd like to sort my SentRequests by Category, Title, Recipient, Status, Type, Date and Actions.
As a Mars user, I can Withraw, Complete and Review my SentRequests.


@tag1
Scenario: 01) I can sort sent requests by Category.
	Given Launch Mars portal and login with default user
	When Navigate to Sent Requests tab 
	And Click on the Category
	Then The Sent Requests should be sort by Category successfully

Scenario: 02) I can sort sent requests by Title.
	Given Launch Mars portal and login with default user
	When Navigate to Sent Requests tab 
	And Click on the Title
	Then The Sent Requests should be sort by Title successfully

Scenario: 03) I can sort sent requests by Message.
	Given Launch Mars portal and login with default user
	When Navigate to Sent Requests tab 
	And Click on the Message
	Then The Sent Requests should be sort by Message successfully

Scenario: 04) I can sort sent requests by Recipient.
	Given Launch Mars portal and login with default user
	When Navigate to Sent Requests tab 
	And Click on the Recipient
	Then The Sent Requests should be sort by Recipient successfully

Scenario: 05) I can sort sent requests by Status.
	Given Launch Mars portal and login with default user
	When Navigate to Sent Requests tab 
	And Click on the Status
	Then The Sent Requests should be sort by Status successfully

Scenario: 05) I can sort sent requests by Type.
	Given Launch Mars portal and login with default user
	When Navigate to Sent Requests tab 
	And Click on the Type
	Then The Sent Requests should be sort by Type successfully

Scenario: 06) I can sort sent requests by Date.
	Given Launch Mars portal and login with default user
	When Navigate to Sent Requests tab 
	And Click on the Date
	Then The Sent Requests should be sort by Date successfully

Scenario: 07) I can withdraw an existing sent request.
	Given Launch Mars portal and login with default user
	When Navigate to Sent Requests tab 
	And Click on the withdraw button of the first sent request  
	Then The first Sent Requests should be withdrawn successfully

	
