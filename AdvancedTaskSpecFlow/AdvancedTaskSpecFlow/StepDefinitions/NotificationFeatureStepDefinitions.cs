using AdvancedTaskSpecFlow.Pages;
using AdvancedTaskSpecFlow.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace AdvancedTaskSpecFlow.StepDefinitions
{
    [Binding]
    public class NotificationFeatureStepDefinitions
    {
        private ICollection<IWebElement> beforeLoadMore = null;
        private readonly CommonDriver commonDriver;
        public NotificationFeatureStepDefinitions(CommonDriver commonDriver)
        {
            this.commonDriver = commonDriver;
        }

        [When(@"Navigate to notification page")]
        public void WhenNavigateToNotificationPage()
        {
            //Naviaget to notifications page
            commonDriver.navigationMenu.goToNotificationsPage();
        }

        [When(@"Unselect the first notification")]
        public void WhenUnselectTheFirstNotification()
        {
            commonDriver.notificationsPage.UnSelectOneNotification();
        }

        [Then(@"The first notification should be unselected successfully")]
        public void ThenTheFirstNotificationShouldBeUnselectedSuccessfully()
        {
            //Check if the selected list is unselected
            var success = commonDriver.notificationsPage.IsUnselectOneHidden();
            Assert.IsTrue(success);
        }

        [When(@"Mark the first notification as read")]
        public void WhenMarkTheFirstNotificationAsRead()
        {
            commonDriver.notificationsPage.MarkOneSelectionAsRead();
        }

        [Then(@"The first notification should be marked as read successfully")]
        public void ThenTheFirstNotificationShouldBeMarkedAsReadSuccessfully()
        {
            //Check if the selected notification has been marked as read
            string checkPopUpMessage = commonDriver.notificationsPage.GetPopUpMessage();
            Assert.AreEqual(checkPopUpMessage, "Notification updated", "Actual and expected skill record do not match.");
        }

        [When(@"Select all the notifications")]
        public void WhenSelectAllTheNotifications()
        {
            commonDriver.notificationsPage.SelectAllNotifications();
        }

        [Then(@"All the notifications should be selected successfully")]
        public void ThenAllTheNotificationsShouldBeSelectedSuccessfully()
        {
            //Check all notifications are selected
            var success = commonDriver.notificationsPage.IsSelectAllNotifications();
            Assert.IsTrue(success);
        }

        [When(@"Unselect all the notifications")]
        public void WhenUnselectAllTheNotifications()
        {
            commonDriver.notificationsPage.UnSelectAllNotifications();
        }

        [Then(@"All the notifications should be unselected successfully")]
        public void ThenAllTheNotificationsShouldBeUnselectedSuccessfully()
        {
            //Check all notifications are selected
            var success = commonDriver.notificationsPage.IsUnselectAllHidden();
            Assert.IsTrue(success);
            
        }

        [When(@"Mark all notifications as read")]
        public void WhenMarkAllNotificationsAsRead()
        {
            commonDriver.notificationsPage.MarkAllSelectionsAsRead();
        }

        [Then(@"All notifications should be marked as read successfully")]
        public void ThenAllNotificationsShouldBeMarkedAsReadSuccessfully()
        {
            //Check if all notifications have been marked as read
            string checkPopUpMessage = commonDriver.notificationsPage.GetPopUpMessage();
            Assert.AreEqual(checkPopUpMessage, "Notification updated", "Actual and expected skill record do not match.");
        }

        [When(@"Load more and show less notifications")]
        public void WhenLoadMoreAndShowLessNotifications()
        {
            this.beforeLoadMore = commonDriver.notificationsPage.GetAllNotificationMessages();
            commonDriver.notificationsPage.LoadMoreNotifications();
        }

        [Then(@"More notifications and less notifications should be loaded successfully")]
        public void ThenMoreNotificationsAndLessNotificationsShouldBeLoadedSuccessfully()
        {
            
            var testSuccess = false;
            //Check more notifications can be load
            for (int i = 0; i < 10; i++)
            {
                var afterLoadMore = commonDriver.notificationsPage.GetAllNotificationMessages();
                if (afterLoadMore.Count > this.beforeLoadMore.Count)
                {
                    testSuccess = true;
                    break;
                }

                else
                    Thread.Sleep(1000);

            }
            if (!testSuccess)
                Assert.Fail("The number of notifications hasn't increased after 10 seconds.");

            var beforeShowLess = commonDriver.notificationsPage.GetAllNotificationMessages();
            commonDriver.notificationsPage.ShowLessNotifications();
            testSuccess = false;
            //Check less notifications can be load
            for (int i = 0; i < 10; i++)
            {
                var afterShowLess = commonDriver.notificationsPage.GetAllNotificationMessages();
                if (afterShowLess.Count < beforeShowLess.Count)
                {
                    testSuccess = true;
                    break;
                }
                else
                    Thread.Sleep(1000);
            }
            if (!testSuccess)
                Assert.Fail("The number of notifications hasn't decreased after 10 seconds.");
        }

    }
}
