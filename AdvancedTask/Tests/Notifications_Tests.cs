using AdvancedTask.Pages;
using AdvancedTask.Utilities;
using AventStack.ExtentReports;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTask.Test
{
    [TestFixture]
    [Parallelizable]
    public class Notifications_Tests: CommonDriver
    {
        [Test, Order(1), Description("Delete Notification successfully")]
        public void deleteNotification()
        {
            Notifications notificationsPage = new Notifications(driver);
            notificationsPage.deleteNotification();
            notificationsPage.verifyNotificationDeleted();
            //logging to extent reports
            test.Log(Status.Pass, "Successfully verified Deleting a Notification");
        }

    }
}
