Feature: EditShareSkill

As a Mars user, I want to edit a Service Listing record so I can manage my listings


@order(1)
Scenario: Edit a Service Listing record
	Given I logged in successfully and navigate to the Manage Listings page 
	When I click on the Edit button and enter '<Title>', '<Description>', '<Category>','<SubCategory>', '<TagsToRemove>', '<TagsToAdd>','<ServiceType>', '<LocationType>', '<StartDate>', '<EndDate>','<AvailableDays>', '<SkillTrade>', '<Credit>', '<SkillExchangeTagsToRemove>', '<skillExchangeTagsToAdd>', '<Active>'
	Then The new Service Listing record should be successfully updated

	Examples: 
	| Title               | Description                       | Category | SubCategory      | TagsToRemove | TagsToAdd   | ServiceType     | LocationType | StartDate  | EndDate    | AvailableDays                       | SkillTrade     | Credit | SkillExchangeTagsToRemove | skillExchangeTagsToAdd    | Active |
	| Business Analyst 01 | Provide Data driven solutions 2.0 | Business | Legal Consulting |              | Tag01,Tag02 | One-off service | Online       | 07/08/2024 | 08/04/2025 | Mon,0900AM,1000PM;Tue,1230PM,0200PM | Skill-exchange |        |                           | Data-Analysis,Programming | Active |

	@order(2)
	Scenario Outline: Edit a Service Listing record with invalid title
		Given I logged in successfully and navigate to the Manage Listings page to edit the title
		When I click on the Edit button and enter '<Title>', '<Description>', '<Category>','<SubCategory>', '<TagsToRemove>', '<TagsToAdd>','<ServiceType>', '<LocationType>', '<StartDate>', '<EndDate>','<AvailableDays>', '<SkillTrade>', '<Credit>', '<SkillExchangeTagsToRemove>', '<skillExchangeTagsToAdd>', '<Active>' to see if it doesn't save with an invalid title
		Then The new Service Listing record should not be updated successfully and I should see the '<Message>' and '<FieldErrorMessage>' for title

		Examples: 
		| Title                 | Description                   | Category | SubCategory      | TagsToRemove | TagsToAdd   | ServiceType     | LocationType | StartDate  | EndDate    | AvailableDays                       | SkillTrade     | Credit | SkillExchangeTagsToRemove | skillExchangeTagsToAdd    | Active | Message                             | FieldErrorMessage                                          |
		| !!Business Analyst 01 | Provide Data driven solutions | Business | Legal Consulting |              | Tag01,Tag02 | One-off service | Online       | 07/08/2024 | 08/04/2025 | Mon,0900AM,1000PM;Tue,1230PM,0200PM | Skill-exchange |        |                           | Data-Analysis,Programming | Active | Please complete the form correctly. | First character must be an alphabet character or a number. |
		| Business Analyst 01$$ | Provide Data driven solutions | Business | Legal Consulting |              | Tag01,Tag02 | One-off service | Online       | 07/08/2024 | 08/04/2025 | Mon,0900AM,1000PM;Tue,1230PM,0200PM | Skill-exchange |        |                           | Data-Analysis,Programming | Active | Please complete the form correctly. | Special characters are not allowed.                        |

	@order(3)
	Scenario Outline: Edit a Service Listing record with invalid description
		Given I logged in successfully and navigate to the Manage Listings page to edit the description
		When I click on the Edit button and enter '<Title>', '<Description>', '<Category>','<SubCategory>', '<TagsToRemove>', '<TagsToAdd>','<ServiceType>', '<LocationType>', '<StartDate>', '<EndDate>','<AvailableDays>', '<SkillTrade>', '<Credit>', '<SkillExchangeTagsToRemove>', '<skillExchangeTagsToAdd>', '<Active>' to see if it doesn't save with an invalid description
		Then The new Service Listing record should not be updated successfully and I should see the '<Message>' and '<FieldErrorMessage>' for description

		Examples: 
		| Title               | Description                   | Category | SubCategory      | TagsToRemove | TagsToAdd   | ServiceType     | LocationType | StartDate  | EndDate    | AvailableDays                       | SkillTrade     | Credit | SkillExchangeTagsToRemove | skillExchangeTagsToAdd    | Active | Message                             | FieldErrorMessage                                          |
		| Business Analyst 01 | $$Test                        | Business | Legal Consulting |              | Tag01,Tag02 | One-off service | Online       | 07/08/2024 | 08/04/2025 | Mon,0900AM,1000PM;Tue,1230PM,0200PM | Skill-exchange |        |                           | Data-Analysis,Programming | Active | Please complete the form correctly. | First character must be an alphabet character or a number. |
		| Business Analyst 01 | Test$$                        | Business | Legal Consulting |              | Tag01,Tag02 | One-off service | Online       | 07/08/2024 | 08/04/2025 | Mon,0900AM,1000PM;Tue,1230PM,0200PM | Skill-exchange |        |                           | Data-Analysis,Programming | Active | Please complete the form correctly. | Special characters are not allowed.                        |

	@order(4)
	Scenario Outline: Edit a Service Listing record with invalid tags
		Given I logged in successfully and navigate to the Manage Listings page to edit the tags
		When I click on the Edit button and enter '<Title>', '<Description>', '<Category>','<SubCategory>', '<TagsToRemove>', '<TagsToAdd>','<ServiceType>', '<LocationType>', '<StartDate>', '<EndDate>','<AvailableDays>', '<SkillTrade>', '<Credit>', '<SkillExchangeTagsToRemove>', '<skillExchangeTagsToAdd>', '<Active>' to see if it doesn't save with an invalid tags
		Then The new Service Listing record should not be updated successfully and I should see the '<Message>' and '<FieldErrorMessage>' for tags

		Examples: 
		| Title               | Description                   | Category | SubCategory      | TagsToRemove | TagsToAdd | ServiceType     | LocationType | StartDate  | EndDate    | AvailableDays                       | SkillTrade     | Credit | SkillExchangeTagsToRemove | skillExchangeTagsToAdd | Active | Message                             | FieldErrorMessage  |
		| Business Analyst 01 | Provide Data driven solutions | Business | Legal Consulting | Tag01,Tag02  |           | One-off service | Online       | 07/08/2024 | 08/04/2025 | Mon,0900AM,1000PM;Tue,1230PM,0200PM | Skill-exchange |        |                           |                        | Active | Please complete the form correctly. | Please enter a tag |

	@order(5)
	Scenario Outline: Edit a Service Listing record with invalid start and end date
		Given I logged in successfully and navigate to the Manage Listings page to edit the start and end date
		When I click on the Edit button and enter '<Title>', '<Description>', '<Category>','<SubCategory>', '<TagsToRemove>', '<TagsToAdd>','<ServiceType>', '<LocationType>', '<StartDate>', '<EndDate>','<AvailableDays>', '<SkillTrade>', '<Credit>', '<SkillExchangeTagsToRemove>', '<skillExchangeTagsToAdd>', '<Active>' to see if it doesn't save with an invalid start and end date
		Then The new Service Listing record should not be updated and I should see the "<Message>" and "<FieldErrorMessage>" for start and end date

		Examples: 
		| Title               | Description                   | Category | SubCategory      | TagsToRemove | TagsToAdd   | ServiceType     | LocationType | StartDate  | EndDate    | AvailableDays                       | SkillTrade     | Credit | SkillExchangeTagsToRemove | skillExchangeTagsToAdd    | Active | Message                             | FieldErrorMessage                             |
		| Business Analyst 01 | Provide Data driven solutions | Business | Legal Consulting |              | Tag01,Tag02 | One-off service | Online       | 07/08/2023 |            | Mon,0900AM,1000PM;Tue,1230PM,0200PM | Skill-exchange |        |                           | Data-Analysis,Programming | Active | Please complete the form correctly. | Start Date cannot be set to a day in the past |
		| Business Analyst 01 | Provide Data driven solutions | Business | Legal Consulting |              | Tag01,Tag02 | One-off service | Online       | 07/08/2024 | 02/01/2023 | Mon,0900AM,1000PM;Tue,1230PM,0200PM | Skill-exchange |        |                           | Data-Analysis,Programming | Active | Please complete the form correctly. | Start Date shouldn't be greater than End Date |

		