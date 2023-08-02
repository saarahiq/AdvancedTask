using AdvancedTask.PageObjectComponents;
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
        [SetUp]
        public void notificationsTestsSetUp()
        {
            NavigationMenu navigationMenu = new NavigationMenu(driver);
            navigationMenu.goToNotificationsPage();
        }

        [Test, Order(1), Description("Delete Notification successfully")]
        public void deleteNotification()
        {
            Notifications notificationsPage = new Notifications(driver);
            notificationsPage.deleteNotification();
            PopUpComponent popUpComponent = new PopUpComponent(driver);
            string popUpMessage = popUpComponent.getMessage();
            Assert.AreEqual("Notification updated", popUpMessage, "Actual and expected popup message do not match.");
            //logging to extent reports
            test.Log(Status.Pass, "Successfully verified Deleting a Notification");
        }

    }
}
