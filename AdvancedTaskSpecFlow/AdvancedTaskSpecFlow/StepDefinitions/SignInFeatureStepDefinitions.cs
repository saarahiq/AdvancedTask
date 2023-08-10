using AdvancedTaskSpecFlow.Pages;
using System;
using TechTalk.SpecFlow;
using AdvancedTaskSpecFlow.Utilities;
using NUnit.Framework;


namespace AdvancedTaskSpecFlow.StepDefinitions
{
    [Binding]
    public class SignInFeatureStepDefinitions:CommonDriver
    {
        private bool loginSuccess = false; 
        public SignInFeatureStepDefinitions() : base(false) { }
        [When(@"Input valid '([^']*)' and '([^']*)'")]
        public void WhenInputValidAnd(string email, string password)
        {
            //Sign in Mars portal with valid details
            this.loginSuccess = signInPage.SignIn(email, password);
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
            this.loginSuccess = signInPage.SignIn(email, password);
        }

        [Then(@"I signed in  Mars portal failed")]
        public void ThenISignedInMarsPortalFailed()
        {
            //Check an existing user has signed successfully
            Assert.IsFalse(this.loginSuccess);
        }


    }
}


