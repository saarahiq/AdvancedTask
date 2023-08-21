Feature: AddNewShareSkillFeature

As a user, I'd like to add new share skill with valid details.
As a user, I can't add new share skill with invalid details.

@tag1
Scenario Outline: 01) I can add new share skill with valid details.
	Given Launch Mars portal and login with default user
	When I click on add button and input valid '<Title>', '<Description>', '<Category>', '<SubCategory>', '<Tags>', '<ServiceType>', '<LocationType>', '<StartDate>', '<EndDate>', '<SkillTrade>', '<SkillExchange>', '<Credit>', '<Active>','<MonTime>', '<TueTime>', '<WedTime>', '<ThurTime>', '<FriTime>', '<SatTime>'
	Then The new share skill with '<Title>', '<Category>'should be added successfully

	Examples: 
	| Title                    | Description                                                     | Category              | SubCategory      | Tags              | ServiceType          | LocationType | StartDate  | EndDate    | SkillTrade    | SkillExchange    | Credit | Active | MonTime    | TueTime | WedTime    | ThurTime | FriTime    | SatTime     | 
	| Interview skill exchange | I like to exchange my interview skill traing with other skills. | Business              | Presentations    | Selling,Interview | Hourly basis service | On-site      | 12/12/2023 |            | Credit        |                  | 9      | Hidden |            |         |            |          |            |             |             
	| Web design               | I work as a dancing teacher for ten years.                      | Programming & Tech    | Web & Mobile App | Design            | One-off service      | Online       | 01/01/2024 | 31/01/2024 | Skill-exchange| software testing |        | Active |            |         |            |          |            |             |             
	| Singing Teaching         | I am a singing teacher.                                         | Music & Audio         | Voice Over       | Teaching          |                      |              | 12/08/2024 |            | Credit        |                  | 5      |        | 9:00-17:00 |         | 9:00-17:00 |          | 9:00-17:00 |             |             
	| Game Playing             | I like to play games.                                           | Fun & Lifestyle       | Gaming           | Gaming,Fun        |                      |              | 12/12/2024 |            |               | dancing          |        |        | 12:00      |         | 12:00      | 12:00    | 12:00      | 12:00       |              
	| Essay Writing            | I can help you in writing essay.                                | Writing & Translation | Creative Writing | Writing           |                      |              | 12/09/2025 |31/01/2026  | Credit        |                  | 8      |        | 12:00      | 12:00   | 12:00      | 12:00    | 12:00      | 12:00-17:00 | 



Scenario Outline: 02) I can not add new share skill with invalid details.
	Given Launch Mars portal and login with default user
	When I click on add button and input invalid '<Title>', '<Description>','<Category>', '<SubCategory>', '<Tags>', '<ServiceType>','<LocationType>', '<StartDate>', '<EndDate>', '<SkillTrade>', '<SkillExchange>', '<Credit>', '<Active>','<MonTime>', '<TueTime>', '<WedTime>', '<ThurTime>', '<FriTime>', '<SatTime>'
	Then The new share skill with invalid'<Title>', '<Category>'should be added failed

	Examples: 
	| Title  | Description   | Category          | SubCategory      | Tags    | ServiceType          | LocationType | StartDate  | EndDate    | SkillTrade     | SkillExchange | Credit | Active | MonTime | TueTime | WedTime | ThurTime | FriTime | SatTime |
	|        | programming  | Business           | Presentations    | Selling | Hourly basis service | On-site      | 12/12/2023 |            | Credit         |               | 9      | Hidden |         |         |         |          |         |         |
	| !QA    | programming  | Programming & Tech | Web & Mobile App | Design  | One-off service      | Online       | 01/01/2024 | 31/01/2024 | Skill-exchange | testing       |        | Active |         |         |         |          |         |         |
	| IT     |              | Programming & Tech | Web & Mobile App | Design  | One-off service      | Online       | 01/01/2024 | 31/01/2024 | Skill-exchange | testing       |        | Active |         |         |         |          |         |         |
	| PHD    | progr*aming  | Business           | Presentations    | Selling | Hourly basis service | On-site      | 12/12/2023 |            | Credit         |               | 9      | Hidden |         |         |         |          |         |         |
	| BA     | !programming | Business           | Presentations    | Selling | Hourly basis service | On-site      | 12/12/2023 |            | Credit         |               | 9      | Hidden |         |         |         |          |         |         |
	| DA     | programming  | Programming        | Web & Mobile App | Design  | One-off service      | Online       | 01/01/2024 | 31/01/2024 | Skill-exchange | testing       |        | Active |         |         |         |          |         |         |
	| MA     | programming  | Programming & Tech | Mobile           | Design  | One-off service      | Online       | 01/01/2024 | 31/01/2024 | Credit         |               | 5      | Active |         |         |         |          |         |         |
	| GD     | programming  | Programming & Tech | Web & Mobile App |         | One-off service      | Online       | 01/01/2024 | 31/01/2024 | Credit         |               | 5      | Hidden |         |         |         |          |         |         |
	| PGD    | programming  | Programming & Tech | Web & Mobile App | Design  | One-off service      | Online       | 01/01/2023 | 31/01/2024 | Credit         |               | 6      | Active |         |         |         |          |         |         |
	| Dev    | programming  | Business           | Presentations    | Selling | Hourly basis service | On-site      | 12/12/2023 |            | Skill-exchange |               |        | Hidden |         |         |         |          |         |         |



