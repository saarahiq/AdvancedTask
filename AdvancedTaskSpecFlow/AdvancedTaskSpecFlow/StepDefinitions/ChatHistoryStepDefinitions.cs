using AdvancedTask.Pages;
using AdvancedTaskSpecFlow.Utilities;
using System;
using TechTalk.SpecFlow;

namespace AdvancedTaskSpecFlow.StepDefinitions
{
    [Binding]
    public class ChatHistoryStepDefinitions
    {
        private readonly CommonDriver commonDriver;
        public ChatHistoryStepDefinitions(CommonDriver commonDriver)
        {
            this.commonDriver = commonDriver;
        }
        [Given(@"I logged in successfully and navigate to the Chat Page")]
        public void GivenILoggedInSuccessfullyAndNavigateToTheChatPage()
        {
            //Open chrome browser
            commonDriver.driver.Manage().Window.Maximize();
            //Launch Mars portal
            commonDriver.driver.Navigate().GoToUrl("http://localhost:5000");
            var loggedInSuccessfully = commonDriver.signInPage.SignIn("jessica@hotmail.com", "123123");
            if (loggedInSuccessfully)
            {
                commonDriver.navigationMenu.goToChatPage();
            }
        }

        [When(@"I search up '([^']*)' on the chat history page")]
        public void WhenISearchUpOnTheChatHistoryPage(string user)
        {
            commonDriver.chatHistoryPage.searchChatHistory(user);
        }

        [Then(@"I should see all the chats and verify the '([^']*)' displayed")]
        public void ThenIShouldSeeAllChatsForThatParticualrAndVerifyTheDisplayed(string numberOfChats)
        {
            commonDriver.chatHistoryPage.verifyNumberOfChats(numberOfChats);
        }
    }
}
