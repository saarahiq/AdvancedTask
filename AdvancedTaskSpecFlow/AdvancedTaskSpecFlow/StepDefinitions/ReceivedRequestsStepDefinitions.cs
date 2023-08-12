using AdvancedTaskSpecFlow.Utilities;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using System;
using TechTalk.SpecFlow;

namespace AdvancedTaskSpecFlow.StepDefinitions
{
    [Binding]
    public class ReceivedRequestsStepDefinitions
    {
        private readonly CommonDriver commonDriver;
        public ReceivedRequestsStepDefinitions(CommonDriver commonDriver)
        {
            this.commonDriver = commonDriver;
        }

        public void LoginAndGoToReceivedRequestsPage()
        {
            //Open chrome browser
            commonDriver.driver.Manage().Window.Maximize();
            //Launch Mars portal
            commonDriver.driver.Navigate().GoToUrl("http://localhost:5000");
            var loggedInSuccessfully = commonDriver.signInPage.SignIn("jessica@hotmail.com", "123123");
            if (loggedInSuccessfully)
            {
                commonDriver.navigationMenu.goToManageRequestsReceivedRequestPage();
            }
        }
        
        [Given(@"I logged in successfully and naviagte to Receieved Requests page to accept")]
        public void GivenILoggedInSuccessfullyAndNaviagteToReceievedRequestsPageToAccept()
        {
            LoginAndGoToReceivedRequestsPage();
        }

        [When(@"I click on the Accept button of a Skill trade request by '([^']*)' with '([^']*)'")]
        public void WhenIClickOnTheAcceptButtonOfASkillTradeRequestByWith(string sender, string title)
        {
            commonDriver.manageRequestsPage.acceptServiceRequest(sender, title);
        }

        [Then(@"I verify that the request by '([^']*)' with '([^']*)' has been accepted and I should see the '([^']*)'")]
        public void ThenIVerifyThatTheRequestHasBeenAcceptedAndIShouldSeeThe(string sender, string title, string message)
        {
            commonDriver.manageRequestsPage.verifyServiceRequestHasBeenAccepted(sender, title, message);
        }

        [Given(@"I logged in successfully and naviagte to Receieved Requests page to decline")]
        public void GivenILoggedInSuccessfullyAndNaviagteToReceievedRequestsPageToDecline()
        {
            LoginAndGoToReceivedRequestsPage();
        }

        [When(@"I click on the Decline button of a Skill trade request by '([^']*)' with '([^']*)'")]
        public void WhenIClickOnTheDeclineButtonOfASkillTradeRequestByWith(string sender, string title)
        {
            commonDriver.manageRequestsPage.declineServiceRequest(sender, title);
        }

        [Then(@"I verify that the request by '([^']*)' with '([^']*)' has been declined and I should see the '([^']*)'")]
        public void ThenIVerifyThatTheRequestHasBeenDeclinedAndIShouldSeeThe(string sender, string title, string message)
        {
            commonDriver.manageRequestsPage.verifyServiceRequestHasBeenDeclined(sender, title, message);
        }

        [Given(@"I logged in successfully and naviagte to Receieved Requests page to complete")]
        public void GivenILoggedInSuccessfullyAndNaviagteToReceievedRequestsPageToComplete()
        {
            LoginAndGoToReceivedRequestsPage();
        }

        [When(@"I click on the Complete button of a Skill trade request by '([^']*)' with '([^']*)'")]
        public void WhenIClickOnTheCompleteButtonOfASkillTradeRequestByWith(string sender, string title)
        {
            commonDriver.manageRequestsPage.completeServiceRequest(sender, title);
        }

        [Then(@"I verify that the request by '([^']*)' with '([^']*)' has been completed and I should see the '([^']*)'")]
        public void ThenIVerifyThatTheRequestHasBeenCompletedAndIShouldSeeThe(string sender, string title, string message)
        {
            commonDriver.manageRequestsPage.verifyServiceRequestHasBeenCompleted(sender, title, message);
        }
    }
}
