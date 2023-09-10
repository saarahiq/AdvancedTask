using AdvancedTaskSpecFlow.Pages;
using AdvancedTaskSpecFlow.Utilities;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace AdvancedTaskSpecFlow.StepDefinitions
{
    [Binding]
    public class DescriptionStepDefinitions
    {
        private readonly CommonDriver commonDriver;
        public DescriptionStepDefinitions(CommonDriver commonDriver)
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
        public void LoginAndGoToDescriptionTab()
        {
            var loggedInSuccessfully = commonDriver.signInPage.SignIn("mars.advanced@example.com", "123456");
            if (loggedInSuccessfully)
            {
                commonDriver.profilePage.goToDescriptionTab();
            }
        }

        [Given(@"Launch Mars portal and login with valid user credentials")]
        public void GivenLaunchMarsPortalAndLoginWithValidUserCredentials()
        {
            GivenLaunchMarsPortal();
            LoginAndGoToDescriptionTab();
        }

        //Add Function

        [Given(@"I logged in successfully and navigate to Description tab")]
        public void GivenILoggedInSuccessfullyAndNavigateToDescriptionTab()
        {
            LoginAndGoToDescriptionTab();
        }

        [When(@"I input valid '([^']*)','([^']*)','([^']*)','([^']*)'")]
        public void WhenIInputValid(string Availability, string Hours, string EarnTarget, string Description)
        {
            commonDriver.descriptionPage.AddDescription(Availability, Hours, EarnTarget, Description);
        }

        [Then(@"The description should be added successfully")]
        public void ThenTheDescriptionShouldBeAddedSuccessfully()
        {
          
           string checkPopUpMessage = commonDriver.descriptionPage.GetPopUpmessage();
           Assert.AreEqual(checkPopUpMessage, "Description has been saved successfully", "Description is not added.");
          
        }

        // Edit function


        [When(@"Edit '([^']*)','([^']*)','([^']*)','([^']*)'")]
        public void WhenEdit(string Availability, string Hours, string EarnTarget, string Description)
        {
            commonDriver.descriptionPage.EditDescription(Availability, Hours, EarnTarget, Description);
        }

        [Then(@"The description should be edited successfully")]
        public void ThenTheDescriptionShouldBeEditedSuccessfully()
        {
            string checkPopUpMessage = commonDriver.descriptionPage.GetPopUpmessage();
            Assert.AreEqual(checkPopUpMessage, "Description has been saved successfully", "Description is not added.");
            
        }

        

        [When(@"Input valid '([^']*)','([^']*)','([^']*)','([^']*)'")]
        public void WhenInputValid(string Availability, string Hours, string EarnTarget, string Description)
        {
            commonDriver.descriptionPage.AddDescription(Availability, Hours, EarnTarget, Description);
        }


        //Invalid description
        [When(@"Input valid '([^']*)','([^']*)','([^']*)' and invalid '([^']*)'")]
        public void WhenInputValidAndInvalid(string Availability, string Hours, string EarnTarget, string Description)
        {
            commonDriver.descriptionPage.SpecialCharAddDescription(Availability, Hours, EarnTarget, Description);
        }


        [Then(@"The description should not be added successfully")]
        public void ThenTheDescriptionShouldNotBeAddedSuccessfully()
        {
            string checkPopUpMessage = commonDriver.descriptionPage.GetPopUpmessage();
            Assert.AreEqual("First character can only be digit or letters", checkPopUpMessage, "Description added.");

        }

        //Empty Description

        [When(@"Input valid'([^']*)','([^']*)','([^']*)' and empty '([^']*)'")]
        public void WhenInputValidAndEmpty(string Availability, string Hours, string EarnTarget, string Description)
        {
            commonDriver.descriptionPage.FailtoAddDescription(Availability, Hours, EarnTarget, Description);
        }





        [Given(@"launch Mars portal and login with default user")]
        public void GivenLaunchMarsPortalAndLoginWithDefaultUser()
        {
            GivenLaunchMarsPortal();
            

            //this.loginSuccess = commonDriver.signInPage.SignIn("mars.advanced@example.com", "123456");
        }

        [When(@"Click on add description option")]
        public void WhenClickOnAddDescriptionOption()
        {
            throw new PendingStepException();
        }

        [When(@"I add description")]
        public void WhenIAddDescription()
        {
            throw new PendingStepException();
        }
        

        



        [When(@"Input valid My Profile describes all about begineer Test Analyst,Part Time,Less than (.*)hours a week and Less than \$(.*) per month")]
        public void WhenInputValidMyProfileDescribesAllAboutBegineerTestAnalystPartTimeLessThanHoursAWeekAndLessThanPerMonth(int p0, int p1)
        {
            throw new PendingStepException();
        }

        [When(@"Input invalid @My Profile describes all about begineer Test Analyst and validPart Time,Less than (.*)hours a week and Less than \$(.*) per month")]
        public void WhenInputInvalidMyProfileDescribesAllAboutBegineerTestAnalystAndValidPartTimeLessThanHoursAWeekAndLessThanPerMonth(int p0, int p1)
        {
            throw new PendingStepException();
        }

        [When(@"Input empty <Description> and valid<Availability>,<Hours> and <Earn Target>")]
        public void WhenInputEmptyDescriptionAndValidAvailabilityHoursAndEarnTarget()
        {
            throw new PendingStepException();
        }

        

        


    }
}
