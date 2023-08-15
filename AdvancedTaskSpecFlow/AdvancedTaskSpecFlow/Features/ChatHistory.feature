Feature: ChatHistory

As a skill swap user I want to be able to search for users in the 
chat history page and view the chats so I can communicate well with other users.

@order(1)
Scenario: Viewing Chat History
	Given I logged in successfully and navigate to the Chat Page
	When I search up '<User>' on the chat history page
	Then I should see all the chats and verify the '<NumberOfChats>' displayed

	Examples: 
		| User    | NumberOfChats |
		| Jessica | 2             |
		| Saarah  | 1             |
		| Saa     | 1             |
		| saa     | 0             |
		| Jessica | 2             |
		| Mars    | 1             |
		| MA      | 0             |
		| Ma      | 1             |
		| Jake    | 0             |
		| saarah  | 0             |