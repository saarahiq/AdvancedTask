Feature: LanguageFeature

As a user, I'd like to add new language record.
As a user, I'd like to edit an existing language record.
As a user, I'd like to delete an existing language record.


@tag1
Scenario Outline: 01) I can add new language record
	Given Launch Mars portal
	When Input valid '<languageLevel>','<languageName>'
	Then I added new language record successfully

	Examples:
	| languageLevel    | languageName |
	| Basic            |German        |
	| Conversational   | Maori        |
	| Fluent           | English      |
	| Native/Bilingual | Chinese      |