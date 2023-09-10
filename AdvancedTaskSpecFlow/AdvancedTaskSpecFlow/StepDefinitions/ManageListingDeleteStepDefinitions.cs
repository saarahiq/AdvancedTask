using AdvancedTaskSpecFlow.Utilities;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace AdvancedTaskSpecFlow.StepDefinitions
{
    [Binding]
    public class ManageListingDeleteStepDefinitions
    {
        private readonly CommonDriver commonDriver;
        public ManageListingDeleteStepDefinitions(CommonDriver commonDriver)
        {
            this.commonDriver = commonDriver;
        }

        public void GivenLaunchMarsPortal()
        {
            //Open chrome browser
            commonDriver.driver.Manage().Window.Maximize();
            //Launch Mars portal
            commonDriver.driver.Navigate().GoToUrl("http://localhost:5000");
        }

        public void LoginAndGoToManageListingTab()
        {
            var loggedInSuccessfully = commonDriver.signInPage.SignIn("mars.advanced@example.com", "123456");
            if (loggedInSuccessfully)
            {
                commonDriver.profilePage.gotoManageListingTab();
            }
        }

        [Given(@"Launch Mars portal and login with valid user credentials and go to managelisting page")]
        public void GivenLaunchMarsPortalAndLoginWithValidUserCredentialsAndGoToManagelistingPage()
        {
            GivenLaunchMarsPortal();
            LoginAndGoToManageListingTab();
        }


        [When(@"I click on delete option on first listing of managelisting page")]
        public void WhenIClickOnDeleteOptionOnFirstListingOfManagelistingPage()
        {
            commonDriver.deleteListingPage.DeleteFirstlisting();
        }

        [Then(@"listing should be deleted successfully")]
        public void ThenListingShouldBeDeletedSuccessfully()
        {
            string[] deletedListing = commonDriver.deleteListingPage.GetFirstListing();
            string checkPopUpMessage = commonDriver.deleteListingPage.GetPopUpmessage();
            Assert.AreEqual(checkPopUpMessage, deletedListing[0] + " has been deleted", "Listing is not deleted");
        }

        [When(@"I click on delete option on first listing of managelisting page and select no on confirmation popup")]
        public void WhenIClickOnDeleteOptionOnFirstListingOfManagelistingPageAndSelectNoOnConfirmationPopup()
        {
            commonDriver.deleteListingPage.DeletelistingCancel();
        }

        [Then(@"Listing should not be deleted")]
        public void ThenListingShouldNotBeDeleted()
        {
            string[] deletedListing = commonDriver.deleteListingPage.GetFirstListing();
            string checkPopUpMessage = commonDriver.deleteListingPage.GetPopUpmessage();
            Assert.AreEqual(checkPopUpMessage, deletedListing[0] + " has been deleted", "Listing is not deleted");
        }


    }
}
