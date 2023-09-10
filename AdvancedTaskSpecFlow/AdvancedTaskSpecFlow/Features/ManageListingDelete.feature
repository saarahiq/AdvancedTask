Feature: ManageListingDelete

As a user I'd like to delete listing on ManageListing page successfully

@tag1
Scenario: Delete Listing on ManageListing page 
	Given Launch Mars portal and login with valid user credentials and go to managelisting page
	When I click on delete option on first listing of managelisting page
	Then listing should be deleted successfully

	Scenario:Do not Delete Listing on ManageListing page
	Given Launch Mars portal and login with valid user credentials and go to managelisting page
	When I click on delete option on first listing of managelisting page and select no on confirmation popup
	Then Listing should not be deleted

