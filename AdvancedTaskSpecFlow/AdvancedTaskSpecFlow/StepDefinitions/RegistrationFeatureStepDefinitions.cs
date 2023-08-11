using AdvancedTaskSpecFlow.Pages;
using AdvancedTaskSpecFlow.Utilities;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using TechTalk.SpecFlow;

namespace AdvancedTaskSpecFlow.StepDefinitions
{
    [Binding]
    public class RegistrationFeatureStepDefinitions:CommonDriver
    {

        private readonly CommonDriver commonDriver;
        public RegistrationFeatureStepDefinitions(CommonDriver commonDriver)
        {
            this.commonDriver = commonDriver;
        }

        [When(@"Input valid '([^']*)','([^']*)','([^']*)','([^']*)','([^']*)','([^']*)'")]
        public void WhenInputValid(string firstName, string lastName, string emailAddress, string password, string confirmPassword, string agreeToTC)
        {
            //join Mars portal with valid details
            this.joinSuccess = registrationPage.Registration(firstName, lastName, RandomEmail(emailAddress), password, confirmPassword, agreeToTC);
        }

        [Then(@"I registered Mars portal successfully")]
        public void ThenIRegisteredMarsPortalSuccessfully()
        {
            //Check a new user has joined successfully
            Assert.IsTrue(this.joinSuccess);
        }

        [When(@"Input invalid '([^']*)','([^']*)','([^']*)','([^']*)','([^']*)','([^']*)'")]
        public void WhenInputInvalid(string firstName, string lastName, string emailAddress, string password, string confirmPassword, string agreeToTC)
        {
            //join Mars portal with invalid details
            this.joinSuccess = registrationPage.Registration(firstName, lastName, emailAddress, password, confirmPassword, agreeToTC);
        }
        [Then(@"I registered Mars portal failed")]
        public void ThenIRegisteredMarsPortalFailed()
        {
            //Check a new user failed to join Mars portal
            Assert.IsFalse(this.joinSuccess);
        }


    }
}
