using AdvancedTaskSpecFlow.PageObjectComponents;
using AdvancedTaskSpecFlow.Utilities;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace AdvancedTaskSpecFlow.StepDefinitions
{
    [Binding]
    public class NotificationFeatureStepDefinitions
    {
        private readonly CommonDriver commonDriver;
        public NotificationFeatureStepDefinitions(CommonDriver commonDriver)
        {
            this.commonDriver = commonDriver;
        }

        [Given(@"I logged in successfully and navigate to Notifications Page")]
        public void GivenILoggedInSuccessfullyAndNavigateToNotificationsPage()
        {
            bool loggedInSuccessfully = commonDriver.Login("jessica@hotmail.com", "123123");
            if (loggedInSuccessfully)
            {
                commonDriver.navigationMenu.goToNotificationsPage();
            }
        }

        [When(@"I select a Service Request checkbox and click on the delete button")]
        public void WhenIClickOnAServiceRequestCheckboxAndClickOnTheDeleteButton()
        {
            commonDriver.notificationsPage.deleteNotification();
        }

        [Then(@"The notification should be deleted and I should see the '([^']*)'")]
        public void ThenTheNotificationShouldBeDeletedAndIShouldSeeThe(string message)
        {
            string popUpMessage = commonDriver.popUpComponent.getMessage();
            Assert.AreEqual(message, popUpMessage, "Actual and expected popup message do not match.");
        }
    }
}
