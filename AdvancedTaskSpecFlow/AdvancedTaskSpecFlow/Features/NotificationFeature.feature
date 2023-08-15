Feature: NotificationFeature

I should be able to manage my Notifications in the Notifications Page.

@order(1)
Scenario: Delete a Notification
	Given I logged in successfully and navigate to Notifications Page
	When I select a Service Request checkbox and click on the delete button
	Then The notification should be deleted and I should see the '<Message>'

	Examples: 
	| Message              |
	| Notification updated |
