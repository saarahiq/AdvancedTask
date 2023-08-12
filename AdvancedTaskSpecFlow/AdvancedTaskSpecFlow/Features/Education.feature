Feature: Education

As a Mars website user, I want to add, edit and delete Education in my profile
so that I can manage my profile details successfully

@order(1)
Scenario: Add Education record in Profile details
	Given I logged in successfully and navigate to Education Tab
	When I click on Add New button and add '<University Name>','<Country>', '<Title>', '<Degree>', '<Graduation Year>'
	Then The new Education record with '<University Name>','<Country>', '<Title>', '<Degree>', '<Graduation Year>' should be added and I should see the '<Message>'

	Examples: 
		| University Name     | Country                       | Title | Degree           | Graduation Year    | Message                            |
		| Harvard University  | United States                 | B.Sc  | Computer Science | 2018               | Education has been added           |
		| Oxford University   | United Kingdom                | PHD   | Psychology       | 2015               | Education has been added           |
		|                     | New Zealand                   | B.A   | Business         | 2010               | Please enter all the fields        |
		| Auckland University | Country of College/University | M.B.A | Master           | 2013               | Please enter all the fields        |
		|                     | Country of College/University | Title |                  | Year of graduation | Please enter all the fields        |
		| Harvard University  | United States                 | B.Sc  | Computer Science | 2018               | This information is already exist. |

	@order(2)
	Scenario Outline: Edit an existing Education record with valid details
		Given I logged in successfully and navigate to Education Tab to edit
		When I edit '<University Name>','<Country>', '<Title>', '<Degree>', '<Graduation Year>' in Education Tab
		Then The Education details should be updated with '<University Name>','<Country>', '<Title>', '<Degree>', '<Graduation Year>' and I should see the '<Message>'
	
		Examples: 
		| University Name      | Country     | Title | Degree       | Graduation Year    | Message                            |
		| Massey               | New Zealand | PHD   | Microbiology | 2021               | Education as been updated          |
		|                      | Australia   | BFA   | Food Science | 2023               | Please enter all the fields        |
		| Melbourne University | Australia   | Title | Food Science | Year of graduation | Please enter all the fields        |
		| Massey               | New Zealand | PHD   | Microbiology | 2021               | This information is already exist. |

	@order(3)
	Scenario Outline: Delete an existing Education record in Profile details
		Given  I logged in successfully and navigate to Education Tab to delete
		When I click on the Delete button for '<University Name>','<Country>', '<Title>', '<Degree>', '<Graduation Year>'
		Then The Education details should be deleted and I should see the '<Message>'

		Examples: 
		| University Name | Country     | Title | Degree       | Graduation Year | Message                              |
		| Massey          | New Zealand | PHD   | Microbiology | 2021            | Education entry successfully removed |
