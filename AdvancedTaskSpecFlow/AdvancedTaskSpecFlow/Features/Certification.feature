Feature: Certification

As a Mars user, I want to add, edit and delete Certification records in my profile
so that I can manage my profile details successfully


@order(1)
Scenario: Add a Certification record in Profile details
	Given I logged in successfully and navigate to Certifications Tab to add
	When I click on Add New button and add '<Certificate>', '<Certified From>', '<Year>'
	Then The new Certification record with '<Certificate>', '<Certified From>', '<Year>' should be added successfully and I should see the '<Message>'

	Examples: 
	| Certificate     | Certified From   | Year | Message                                                                    |
	| Test Analyst    | Industry Connect | 2023 | Test Analyst has been added to your certification                          |
	| Applied Science | AUT              | 2015 | Applied Science has been added to your certification                       |
	|                 | iSQI             | 2020 | Please enter Certification Name, Certification From and Certification Year |
	| ISTQB           |                  | Year | Please enter Certification Name, Certification From and Certification Year |
	| Test Analyst    | Industry Connect | 2023 | This information is already exist.                                         |

	@order(2)
	Scenario Outline: Edit an existing Certification record with valid details
		Given I logged in successfully and navigate to Certifications Tab to edit
		When I edit '<Certificate>', '<Certified From>', '<Year>' in Certifications Tab
		Then The  Certification details should be updated with '<Certificate>', '<Certified From>', '<Year>' and I should see the '<Message>'

		Examples: 
		| Certificate | Certified From | Year | Message                                                                    |
		| MySQL       | Udemy          | 2018 | MySQL has been updated to your certification                               |
		|             | AUT            | 2015 | Please enter Certification Name, Certification From and Certification Year |
		|             | Udemy          | 2020 | Please enter Certification Name, Certification From and Certification Year |
		| MySQL       | Udemy          | Year | Please enter Certification Name, Certification From and Certification Year |
		| MySQL       | Udemy          | 2018 | This information is already exist.                                         |
	
	@order(3)
	Scenario Outline: Delete a Certification record in Profile details
		Given  I logged in successfully and navigate to Certifications Tab to delete
		When I click on the Delete button for '<Certificate>', '<Certified From>', '<Year>'
		Then The Certification details should be deleted and I should see the '<Message>'

		Examples: 
		| Certificate | Certified From | Year | Message                                        |
		| MySQL       | Udemy          | 2018 | MySQL has been deleted from your certification |