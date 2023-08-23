Feature: NotificationFeature

As a Mars user, I can select ,unselect one notification.
As a Mars user, I can mark one selected notification as read.
As a Mars user, I can select ,unselect all notification.
As a Mars user, I can mark all selected notification as read.
As a Mars user, I can load more and show less notifications


@tag1
Scenario: 01) I can unselect the first notification
	Given Launch Mars portal and login with default user
	When Navigate to notification page 
	And Unselect the first notification
	Then The first notification should be unselected successfully

Scenario: 02) I can mark one selected notification as read
	Given Launch Mars portal and login with default user
	When Navigate to notification page 
	And Mark the first notification as read
	Then The first notification should be marked as read successfully

Scenario: 03) I can select all the notifications
	Given Launch Mars portal and login with default user
	When Navigate to notification page 
	And Select all the notifications
	Then All the notifications should be selected successfully

Scenario: 04) I can unselect all the notifications
	Given Launch Mars portal and login with default user
	When Navigate to notification page 
	And Unselect all the notifications
	Then All the notifications should be unselected successfully

Scenario: 05) I can mark all notifications as read
	Given Launch Mars portal and login with default user
	When Navigate to notification page 
	And Mark all notifications as read
	Then All notifications should be marked as read successfully

Scenario: 06) I can load more and shlow less notifications
	Given Launch Mars portal and login with default user
	When Navigate to notification page 
	And Load more and show less notifications
	Then More notifications and less notifications should be loaded successfully
