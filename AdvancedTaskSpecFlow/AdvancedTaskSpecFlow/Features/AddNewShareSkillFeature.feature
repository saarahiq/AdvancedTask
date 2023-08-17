Feature: AddNewShareSkillFeature

As a user, I'd like to add new share skill with valid details.
As a user, I can't add new share skill with invalid details.

@tag1
Scenario Outline: 01) I can add new share skill with valid details except avaiable days.
	Given Launch Mars portal and login with default user
	When I click on add button and input valid '<Title>', '<Description>', '<Category>', '<SubCategory>', '<Tags>', '<ServiceType>', '<LocationType>', '<StartDate>', '<EndDate>', '<SkillTrade>', '<SkillExchange>', '<Credit>', '<Active>'
	Then The new share skill with '<Title>', '<Description>', '<Category>', '<SubCategory>', '<Tags>', '<ServiceType>', '<LocationType>', '<StartDate>', '<EndDate>', '<SkillTrade>', '<SkillExchange>', '<Credit>', '<Active>'should be added successfully

	Examples: 
	| Title                    | Description                                                       | Category         | SubCategory    | Tags    | ServiceType          | LocationType | StartDate  | EndDate   | SkillTrade   | SkillExchange    | Credit | Active |
	| Interview skill exchange | I'd like to exchange my interview skill traing with other skills. | Business         | Presentations  | Selling | Hourly basis service | On-site      | 12/12/2023 |           | Credit       |                  | 9      | Hidden |             
	| Web design               | I've been working as a dancing teacher for ten years.             | Programming&Tech | Web&Mobile App | Design  | One-off service      | Online       | 1/1/2024   | 31/1/2024 | SkillExchange| software testing |        | Active | 

Scenario Outline: 02) I can add new share skill with valid details and avaiable days.
	Given Launch Mars portal and login with default user
	When I click on add button and input valid '<MonTime>', '<TueTime>', '<WedTime>', '<ThurTime>', '<FriTime>', '<SatTime>', '<SunTime>'
	Then The new share skill with '<MonTime>', '<TueTime>', '<WedTime>', '<ThurTime>', '<FriTime>', '<SatTime>', '<SunTime>' should be added successfully

	Examples: 
	| MonTime     | TueTime     | WedTime     | ThurTime    | FriTime     | SatTime     | SunTime     |
	| 9:00-17:00  |		        | 9:00-17:00  |             | 9:00-17:00  |             |             |
	| 12:00       |	12:00    	| 12:00       | 12:00       | 12:00       |             |             |
	| 12:00       |	12:00    	| 12:00       | 12:00       | 12:00       | 12:00-17:00 | 12:00-17:00 |

Scenario Outline: 03) I can not add new share skill with invalid details.
	Given Launch Mars portal and login with default user
	When I click on add button and input invalid '<Title>', '<Description>','<Category>', '<SubCategory>', '<Tags>', '<ServiceType>','<LocationType>', '<StartDate>', '<EndDate>', '<SkillTrade>', '<SkillExchange>', '<Credit>', '<Active>'
	Then The new share skill with invalid'<Title>', '<Description>', '<Category>', '<SubCategory>', '<Tags>', '<ServiceType>', '<LocationType>', '<StartDate>', '<EndDate>', '<SkillTrade>', '<SkillExchange>', '<Credit>', '<Active>'should be added failed

	Examples: 
	| Title  | Description  | Category         | SubCategory    | Tags    | ServiceType          | LocationType | StartDate  | EndDate   | SkillTrade    | SkillExchange | Credit | Active |
	|        | programming  | Business         | Presentations  | Selling | Hourly basis service | On-site      | 12/12/2023 |           | Credit        |               | 9      | Hidden | 
	| !QA    | programming  | Programming&Tech | Web&Mobile App | Design  | One-off service      | Online       | 1/1/2024   | 31/1/2024 | SkillExchange | testing       |        | Active |
	| QA     |              | Programming&Tech | Web&Mobile App | Design  | One-off service      | Online       | 1/1/2024   | 31/1/2024 | SkillExchange | testing       |        | Active |
	| QA     | !programming | Business         | Presentations  | Selling | Hourly basis service | On-site      | 12/12/2023 |           | Credit        |               | 9      | Hidden |             
	| QA     | programming  | Programming      | Web&Mobile App | Design  | One-off service      | Online       | 1/1/2024   | 31/1/2024 | SkillExchange | testing       |        | Active |
	| QA     | programming  | Programming&Tech | Mobile         | Design  | One-off service      | Online       | 1/1/2024   | 31/1/2024 | Credit        |               | 5      | Active |
	| QA     | programming  | Programming      | Web&Mobile App |         | One-off service      | Online       | 1/1/2024   | 31/1/2024 | Credit        |               | 5      | Hidden |
	| QA     | programming  | Programming&Tech | Web&Mobile App | Design  | One-off service      | Online       | 1/1/2023   | 31/1/2024 | Credit        |               | 6      | Active | 
    | QA     | programming  | Business         | Presentations  | Selling | Hourly basis service | On-site      | 12/12/2023 |           | SkillExchange |               |        | Hidden |             
	| QA     | programming  | Business         | Presentations  | Selling | Hourly basis service | On-site      | 12/12/2023 |           | Credit        |               | 9      | Hidden |             



