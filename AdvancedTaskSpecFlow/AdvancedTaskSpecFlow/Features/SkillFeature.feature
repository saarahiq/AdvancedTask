Feature: SkillFeature

As a Mars user, I want to add, edit and delete Skill records in my profile
so that I can manage my profile details successfully 


@order(1)
Scenario: Add a Skill record in Profile details
	Given I logged in successfully and navigate to Skills Tab to add
	When I click on Add New button and add '<Skill>' and '<SkillLevel>'
	Then The new Skill record with '<Skill>' and '<SkillLevel>' should be added successfully and I should see the '<Message>'

	Examples:
		| Skill    | SkillLevel         | Message                                         |
		| Specflow | Intermediate       | Specflow has been added to your skills          |
		| Python   | Expert             | Python has been added to your skills            |
		| Python   | Expert             | This skill is already exist in your skill list. |
		|          | Beginner           | Please enter skill and experience level         |
		| Dancing  | Choose Skill Level | Please enter skill and experience level         |
		|          | Choose Skill Level | Please enter skill and experience level         |

	@order(2)
	Scenario Outline: Edit an existing Skill record with valid details
		Given I logged in successfully and navigate to Skills Tab to edit
		When I edit '<Skill>' and '<SkillLevel>'
		Then The new Skill details should be updated with '<Skill>' and '<SkillLevel>' and I should see the '<Message>'

		Examples:
			| Skill    | SkillLevel         | Message                                         |
			| Jira     | Beginner           | Jira has been updated to your skills            |
			| Painting | Intermediate       | Painting has been updated to your skills        |
			| Painting | Intermediate       | This skill is already added to your skill list. |
			|          | Expert             | Please enter skill and experience level         |
			| Jmeter   | Skill Level | Please enter skill and experience level         |
			|          | Skill Level | Please enter skill and experience level         |

	@order(3)
	Scenario Outline: Delete a Skill record in Profile details
		Given I logged in successfully and navigate to Skills Tab to delete
		When I click on the Delete button for '<Skill>' and '<SkillLevel>'
		Then The Skill record should be successfully deleted and I should see the '<Message>'

		Examples:
			| Skill    | SkillLevel   | Message                   |
			| Painting | Intermediate | Painting has been deleted |