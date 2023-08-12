Feature:RegistrationFeature

As a new user, I'd like to join Mars portal with valid details.
@mytag
Scenario: register mars portal with valid details
	Given Launch Mars portal
	When Input valid First name, Last name, Email address, Password, Confirm Password
	Then I registered Mars portal successfully