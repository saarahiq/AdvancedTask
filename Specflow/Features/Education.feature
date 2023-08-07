Feature: EducationFeature

As a Mars website user, I want to add, edit and delete Education in my profile
so that I can manage my profile details successfully

@tag1
Scenario: 01) Add Education record in Profile details
	Given I logged in successfully and navigate to Education Tab
	When I click on Add New button and add Education details
	Then The new Education record with <University Name>, <Country>, <Title>, <Degree>, <Graduation Year> should be added and I should see the <Message>

	Examples: 
		| University Name    | Country       | Title | Degree           | Graduation Year | Notification |
		| Harvard University | United States | BSc   | Computer Science | 2018            |              |
		| Oxford University  | England       |       | Food Science     | 2015            |              |

	Scenario Outline: 02) Edit an existing Education record with valid details
		Given I logged in successfully and navigate to Education Tab to edit
		When I edit <University Name>, <Country>, <Title>, <Degree>, <Graduation Year> in Education Tab
		Then The Education details should be updated with <University Name>, <Country>, <Title>, <Degree>, <Graduation Year> and I should see the <Message>
	
		Examples: 
		| University Name | Country     | Title | Degree       | Graduation Year | Notification                       |
		| Massey          | New Zealand | PHD   | Food Science | 2021            | This information is already exist. |
		| Massey          | Australia   | PHD   | Food Science | 2023            | Education as been updated          |
		

	Scenario Outline: 03) Delete an existing Education record in Profile details
		Given  I logged in successfully and navigate to Education Tab to delete
		When I click on the Delete button for <University Name>, <Country>, <Title>, <Degree>, <Graduation Year>
		Then The Education details should be deleted and I should see the <Message>

		Examples: 
		| University Name | Country     | Title | Degree       | Graduation Year | Notification                         |
		| Massey          | Australia   | PHD   | Food Science | 2023            | Education entry successfully removed |
		