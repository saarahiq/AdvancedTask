using AdvancedTask.Utilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTask.Test
{
    [TestFixture]
    [Parallelizable]
    public class Notifications_Tests : CommonDriver
    {
        [Test, Order(1), Description("Check if user is able to unselect one notification"),]
        public void TestUnselectNotification()
        {
            notificationsPage.GoToNotificationsPage();
            notificationsPage.UnSelectOneNotification();
            //Check if the selected list is unselected
            var success = notificationsPage.IsUnselectOneHidden();
            Assert.IsTrue(success);

        }
        [Test, Order(2), Description("Check if user is able to mark one selected notification as read"),]
        public void TestMarkSelectedNotificationAsRead()
        {
            notificationsPage.GoToNotificationsPage();
            notificationsPage.MarkOneSelectionAsRead();
            //Check if the selected notification has been marked as read
            string checkPopUpMessage = notificationsPage.GetPopUpMessage();
            Assert.AreEqual(checkPopUpMessage, "Notification updated", "Actual and expected skill record do not match.");
        }

        [Test, Order(3), Description("Check if user is able to delete the selected notification"),]
        public void TestDeleteSelectedNotification()
        {
            notificationsPage.GoToNotificationsPage();
            notificationsPage.DeleteOneSelection();
            //Check if the selected notification has been marked as read
            string checkPopUpMessage = notificationsPage.GetPopUpMessage();
            Assert.AreEqual(checkPopUpMessage, "Notification updated", "Actual and expected skill record do not match.");
        }

        [Test, Order(4), Description("Check if user is able to select all notifications"),]
        public void TestSelectAllNotifications()
        {
            notificationsPage.GoToNotificationsPage();
            notificationsPage.SelectAllNotifications();
            //Check all notifications are selected
            var success = notificationsPage.IsSelectAllNotifications();
            Assert.IsTrue(success);
        }

        [Test, Order(5), Description("Check if user is able to unselect all notifications"),]
        public void TestUnselectAllNotifications()
        {
            notificationsPage.GoToNotificationsPage();
            notificationsPage.UnSelectAllNotifications();
            //Check all notifications are selected
            var success = notificationsPage.IsUnselectAllHidden();
            Assert.IsTrue(success);
        }

        [Test, Order(6), Description("Check if user is able to mark all notifications as read"),]
        public void TestMarkAllNotificationsAsRead()
        {
            notificationsPage.GoToNotificationsPage();
            notificationsPage.MarkAllSelectionsAsRead();
            //Check if all notifications have been marked as read
            string checkPopUpMessage = notificationsPage.GetPopUpMessage();
            Assert.AreEqual(checkPopUpMessage, "Notification updated", "Actual and expected skill record do not match.");
        }

        [Test, Order(7), Description("Check if user is able to load more and show less notifications"),]
        public void TestLoadMoreAndShowLessNotifications()
        {
            notificationsPage.GoToNotificationsPage();
            var beforeLoadMore = notificationsPage.GetAllNotificationMessages();
            notificationsPage.LoadMoreNotifications();
            var testSuccess = false;
            //Check more notifications can be load
            for (int i = 0; i < 10; i++)
            {
                var afterLoadMore = notificationsPage.GetAllNotificationMessages();
                if (afterLoadMore.Count > beforeLoadMore.Count) 
                {
                    testSuccess = true;
                    break;
                }
                   
                else 
                    Thread.Sleep(1000);

            }
            if (!testSuccess) 
                Assert.Fail("The number of notifications hasn't increased after 10 seconds."); 

            var beforeShowLess = notificationsPage.GetAllNotificationMessages();
            notificationsPage.ShowLessNotifications();
            testSuccess = false;
            //Check less notifications can be load
            for (int i = 0; i < 10; i++)
            {
                var afterShowLess = notificationsPage.GetAllNotificationMessages();
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


