using AdvancedTaskSpecFlow.Pages;
using System;
using TechTalk.SpecFlow;
using AdvancedTaskSpecFlow.Utilities;
using NUnit.Framework;


namespace AdvancedTaskSpecFlow.StepDefinitions
{
    [Binding]
    public class SignInFeatureStepDefinitions
    {
        private readonly CommonDriver commonDriver;
        private bool loginSuccess = false;
        public SignInFeatureStepDefinitions(CommonDriver commonDriver) 
        { 
            this.commonDriver = commonDriver;
        }

        [Given(@"Launch Mars portal")]
        public void GivenLaunchMarsPortal()
        {
            //Open chrome browser
            commonDriver.driver.Manage().Window.Maximize();
            //Launch Mars portal
            commonDriver.driver.Navigate().GoToUrl("http://localhost:5000");
        }

        [Given(@"Launch Mars portal and login with default user")]
        public void GivenLaunchMarsPortalAndLoginWithDefaultUser()
        {
            GivenLaunchMarsPortal();
            this.loginSuccess = commonDriver.signInPage.SignIn("ada@example.com", "123456");
        }

        [When(@"Input valid '([^']*)' and '([^']*)'")]
        public void WhenInputValidAnd(string email, string password)
        {
            //Sign in Mars portal with valid details
            this.loginSuccess = commonDriver.signInPage.SignIn(email, password);
        }

        [Then(@"I signed in  Mars portal successfully")]
        public void ThenISignedInMarsPortalSuccessfully()
        {
            //Check an existing user has signed successfully
            Assert.IsTrue(this.loginSuccess);

        }
        [When(@"Input invalid '([^']*)' and '([^']*)'")]
        public void WhenInputInvalidAnd(string email, string password)
        {
            //Sign in Mars portal with invalid details
            this.loginSuccess = commonDriver.signInPage.SignIn(email, password);
        }

        [Then(@"I signed in  Mars portal failed")]
        public void ThenISignedInMarsPortalFailed()
        {
            //Check an existing user has signed successfully
            Assert.IsFalse(this.loginSuccess);
        }


    }
}


