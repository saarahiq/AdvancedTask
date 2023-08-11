Feature:RegistrationFeature

As a new user, I'd like to join Mars portal successfully with valid details.
As a new user, I can't join Mars portal with invalid details.
@mytag
Scenario Outline:01) A new user register mars portal with valid details
	Given Launch Mars portal
	When Input valid '<firstName>','<lastName>','<emailAddress>','<password>','<confirmPassword>','<agreeToTC>'
	Then I registered Mars portal successfully

	Examples:
	| firstName  | lastName | emailAddress            | password | confirmPassword | agreeToTC |
	| ada520     | Zhang    | ada520.task@example.com | 123456   | 123456          | yes       |
	| ada520     | Zhang    | ada520.task@example.com | abcdefg  | abcdefg         | yes       |
	| ada520     | Zhang    | ada520.task@example.com | abc@def  | abc@def         | yes       |
	| ada520     | Zhang    | ada520.task@example.com | abc@123  | abc@123         | yes       |
	
	
Scenario Outline: 02) A new user failed to register mars portal with invalid details
	Given Launch Mars portal
	When Input invalid '<firstName>','<lastName>','<emailAddress>','<password>','<confirmPassword>','<agreeToTC>'
	Then I registered Mars portal failed

	Examples:
	| firstName | lastName | emailAddress           | password | confirmPassword | agreeToTC |
	|           | Zhang    | poppy.task@example.com | 123456   | 123456          | yes       |
	|Poppy      |          | poppy.task@example.com | 123456   | 123456          | yes       |
	|Poppy      | Zhang    | poppy.taskexample.com  | 123456   | 123456          | yes       |
	|Poppy      | Zhang    | ada.task@example.com   | 123456   | 123456          | yes       |
	|Poppy      | Zhang    | poppy.task@example.com |          | 123456          | yes       |
	|Poppy      | Zhang    | poppy.task@example.com | 12345    | 123456          | yes       |
	|Poppy      | Zhang    | poppy.task@example.com | 123456   |                 | yes       |
	|Poppy      | Zhang    | poppy.task@example.com | 123456   | 1234567         | yes       |
	|Poppy      | Zhang    | poppy.task@example.com | 123456   | 123456          | no        |

