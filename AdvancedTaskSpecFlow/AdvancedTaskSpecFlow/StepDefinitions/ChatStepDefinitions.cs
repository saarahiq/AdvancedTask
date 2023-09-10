using AdvancedTaskSpecFlow.Pages;
using AdvancedTaskSpecFlow.Utilities;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace AdvancedTaskSpecFlow.StepDefinitions
{
    [Binding]
    public class ChatStepDefinitions
    {
        private readonly CommonDriver commonDriver;
        public ChatStepDefinitions(CommonDriver commonDriver)
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
        public void LoginAndGoToChatPage()
        {
            var loggedInSuccessfully = commonDriver.signInPage.SignIn("mars.advanced@example.com", "123456");
            if (loggedInSuccessfully)
            {
                commonDriver.profilePage.gotoChatPage();
            }
        }
        [Given(@"Launch Mars portal and login with valid user credentials and go to chat page")]
        public void GivenLaunchMarsPortalAndLoginWithValidUserCredentialsAndGoToChatPage()
        {
            GivenLaunchMarsPortal();
            LoginAndGoToChatPage();
        }

        [When(@"I enter message in type your '([^']*)' here textbox and click send")]
        public void WhenIEnterMessageInTypeYourHereTextboxAndClickSend(string message)
        {
            commonDriver.chatPage.Chatwithfirstuser(message);
        }

        [Then(@"the message should be send successfully")]
        public void ThenTheMessageShouldBeSendSuccessfully()
        {
            throw new PendingStepException();
        }

        // chat with searched user
        [When(@"I enter '([^']*)' in the searctextbox")]
        public void WhenIEnterInTheSearctextbox(string username)
        {
            commonDriver.chatPage.ChatwithSearchedUser(username);
        }
        [Then(@"searched user should be presented to chat")]
        public void ThenSearchedUserShouldBePresentedToChat(string username)
        {
           commonDriver.chatPage.ChatwithSearchedUser(username);
            string MatchedUser = commonDriver.chatPage.UserMatch();
            Assert.That(MatchedUser == "Nik", "User does not match");
        }

        // Enter invalid name of user

        [When(@"I enter '([^']*)' in lower case or invalid")]
        public void WhenIEnterInLowerCaseOrInvalid(string username)
        {
            commonDriver.chatPage.SearchUserLowerCase(username);
        }

        [Then(@"user should not appear in the selection list presented")]
        public void ThenUserShouldNotAppearInTheSelectionListPresented()
        {
            throw new PendingStepException();
        }



    }
}
