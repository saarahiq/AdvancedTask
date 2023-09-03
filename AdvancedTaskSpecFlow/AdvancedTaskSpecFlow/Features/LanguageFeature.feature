Feature: LanguageFeature

As a user, I'd like to add new language record.
As a user, Ican't add new language record with invalid details.
As a user, I'd like to edit an existing language record.
As a user, I can't edit language record with invalid details.
As a user, I'd like to delete an existing language record.


@tag1
Scenario Outline: 01) I can add new language record
	Given Launch Mars portal and login with default user
	When Input valid '<languageName>','<languageLevel>'
	Then I added new language record successfully

	Examples:
	| languageName | languageLevel    |
	| ! 1@ 2       | Basic            |
	| @@@@@        | Conversational   |
	| Chinese      | Native/Bilingual |

Scenario Outline: 02) I add new language record failed with invalid details
	Given Launch Mars portal and login with default user
	When Input invalid '<languageName>','<languageLevel>'
	Then I added new language record failed

	Examples:
	|languageName  |languageLevel    |
	|              |Basic            |
	|Maori         |                 |
	|English       |Fluented         |

Scenario Outline: 03) I add new language record failed with repeat details
	Given Launch Mars portal and login with default user
	When Input repeat '<languageName>','<languageLevel>'
	Then I can't add new language record with repeat details

	Examples:
	|languageName  |languageLevel     |
	| Chinese      | Native/Bilingual |
	| @@@@@        | Conversational   |

Scenario Outline: 04) Edit the first language record successfully with valid details
	Given Launch Mars portal and login with default user
	When Edit first language record with valid '<languageName>','<languageLevel>'
	Then The first language record has been edited successfully

	Examples:
	|languageName  |languageLevel    |
	|1111111       |Basic            |
	|Maori         |Fluent           |

Scenario Outline: 05) Edit the first language record failed with invalid details
	Given Launch Mars portal and login with default user
	When Edit first language record with invalid '<languageName>','<languageLevel>'
	Then The first language record has been edited failed

	Examples:
	|languageName  |languageLevel    |
	|German        |Language Level   |
	
Scenario Outline: 06) I edit the first language record failed with repeat details
	Given Launch Mars portal and login with default user
	When Edit first langiage record with repeat '<languageName>','<languageLevel>'
	Then I edit first language record with repeat details failed

	Examples:
	|languageName  |languageLevel     |
	| Chinese      | Native/Bilingual |
	| @@@@@        | Conversational   |

Scenario Outline: 07) I delete an existing language record
	Given Launch Mars portal and login with default user
	When I delete an existing language record '<languageName>'
	Then The language record '<languageName>'should be deleted successfully

	Examples:
	|languageName  |
	| Chinese      | 
	| @@@@@        | 
	
	