using AdvancedTask.JSON_Objects;
using AdvancedTask.Utilities;
using AventStack.ExtentReports;
using DnsClient.Protocol;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTask.Test
{
    [TestFixture]
    [Parallelizable]
    public class ManageRequests_Tests : CommonDriver
    {
        [Test, Order(1), Description("Check if user is able to sort by category"),]
        public void TestSortByCategory()
        {
            manageRequestPage.GoToSentRequestPage();
            manageRequestPage.SortByCategory();
            //Check if the requests are sorted by category
            var categories = manageRequestPage.GetCategories();
            for (int i = 1; i < categories.Length; i++)
            {
                test.Log(Status.Info, categories[i - 1]);
                test.Log(Status.Info, categories[i]);
                Assert.IsTrue(categories[i - 1].CompareTo(categories[i]) <= 0);
            }
            manageRequestPage.SortByCategory();
            //Check if the requests are sorted by category
            categories = manageRequestPage.GetCategories();
            for (int i = 1; i < categories.Length; i++)
            {
                test.Log(Status.Info, categories[i - 1]);
                test.Log(Status.Info, categories[i]);
                Assert.IsTrue(categories[i - 1].CompareTo(categories[i]) >= 0);
            }
        }
        [Test, Order(2), Description("Check if user is able to sort by title"),]
        public void TestSortByTitle()
        {
            manageRequestPage.GoToSentRequestPage();
            manageRequestPage.SortByTitle();
            //Check if the requests are sorted by category
            var titles = manageRequestPage.GetTitles();
            for (int i = 1; i < titles.Length; i++)
            {
                test.Log(Status.Info, titles[i - 1]);
                test.Log(Status.Info, titles[i]);
                Assert.IsTrue(titles[i - 1].ToLower().CompareTo(titles[i].ToLower()) <= 0);
            }
            manageRequestPage.SortByTitle();
            //Check if the requests are sorted by category
            titles = manageRequestPage.GetTitles();
            for (int i = 1; i < titles.Length; i++)
            {
                test.Log(Status.Info, titles[i - 1]);
                test.Log(Status.Info, titles[i]);
                Assert.IsTrue(titles[i - 1].ToLower().CompareTo(titles[i].ToLower()) >= 0);
            }
        }
        [Test, Order(3), Description("Check if user is able to sort by message"),]
        public void TestSortByMessage()
        {
            manageRequestPage.GoToSentRequestPage();
            manageRequestPage.SortByMessage();
            //Check if the requests are sorted by category
            var messages = manageRequestPage.GetMessages();
            for (int i = 1; i < messages.Length; i++)
            {
                test.Log(Status.Info, messages[i - 1]);
                test.Log(Status.Info, messages[i]);
                Assert.IsTrue(messages[i - 1].ToLower().CompareTo(messages[i].ToLower()) <= 0);
            }
            manageRequestPage.SortByMessage();
            //Check if the requests are sorted by category
            messages = manageRequestPage.GetMessages();
            for (int i = 1; i < messages.Length; i++)
            {
                test.Log(Status.Info, messages[i - 1]);
                test.Log(Status.Info, messages[i]);
                Assert.IsTrue(messages[i - 1].ToLower().CompareTo(messages[i].ToLower()) >= 0);
            }
        }
        [Test, Order(4), Description("Check if user is able to sort by recipient"),]
        public void TestSortByRecipient()
        {
            manageRequestPage.GoToSentRequestPage();
            manageRequestPage.SortByRecipient();
            //Check if the requests are sorted by category
            var recipients = manageRequestPage.GetRecipients();
            for (int i = 1; i < recipients.Length; i++)
            {
                test.Log(Status.Info, recipients[i - 1]);
                test.Log(Status.Info, recipients[i]);
                Assert.IsTrue(recipients[i - 1].ToLower().CompareTo(recipients[i].ToLower()) <= 0);
            }
            manageRequestPage.SortByRecipient();
            //Check if the requests are sorted by category
            recipients = manageRequestPage.GetRecipients();
            for (int i = 1; i < recipients.Length; i++)
            {
                test.Log(Status.Info, recipients[i - 1]);
                test.Log(Status.Info, recipients[i]);
                Assert.IsTrue(recipients[i - 1].ToLower().CompareTo(recipients[i].ToLower()) >= 0);
            }
        }
        private int StatusOrder(string status)
        {
            if (status == "Pending")
                return 0;
            else if (status == "Accepted")
                return 1;
            else if (status == "Declined")
                return 2;
            else if (status == "Withdrawn")
                return 3;
            else if (status == "Completed")
                return 4;
                return -1;
        }

        [Test, Order(5), Description("Check if user is able to sort by status"),]
        public void TestSortByStatus()
        {
            manageRequestPage.GoToSentRequestPage();
            manageRequestPage.SortByStatus();
            //Check if the requests are sorted by category
            var statuses = manageRequestPage.GetStatuses();
            for (int i = 1; i < statuses.Length; i++)
            {
                test.Log(Status.Info, statuses[i - 1]);
                test.Log(Status.Info, statuses[i]);
                Assert.IsTrue(StatusOrder(statuses[i - 1]) <= StatusOrder(statuses[i]));
            }
            manageRequestPage.SortByStatus();
            //Check if the requests are sorted by category
            statuses = manageRequestPage.GetStatuses();
            for (int i = 1; i < statuses.Length; i++)
            {
                test.Log(Status.Info, statuses[i - 1]);
                test.Log(Status.Info, statuses[i]);
                Assert.IsTrue(StatusOrder(statuses[i - 1]) >= StatusOrder(statuses[i]));
            }
        }

        private DateTime ParseDate(string date)
        {
            string dateString = date.Replace("st", "")
                            .Replace("nd", "")
                            .Replace("rd", "")
                            .Replace("th", "");

            return DateTime.ParseExact(dateString, "d MMM, yyyy", CultureInfo.InvariantCulture);
        }

        [Test, Order(6), Description("Check if user is able to sort by status"),]
        public void TestSortByDates()
        {
            manageRequestPage.GoToSentRequestPage();
            manageRequestPage.SortByDate();
            //Check if the requests are sorted by category
            var dates = manageRequestPage.GetDates();
            for (int i = 1; i < dates.Length; i++)
            {
                test.Log(Status.Info, dates[i - 1]);
                test.Log(Status.Info, dates[i]);
                Assert.IsTrue(ParseDate(dates[i - 1]) <= ParseDate(dates[i]));
            }
            manageRequestPage.SortByDate();
            //Check if the requests are sorted by category
            dates = manageRequestPage.GetDates();
            for (int i = 1; i < dates.Length; i++)
            {
                test.Log(Status.Info, dates[i - 1]);
                test.Log(Status.Info, dates[i]);
                Assert.IsTrue(ParseDate(dates[i - 1]) >= ParseDate(dates[i]));
            }
        }


        [Test, Order(7), Description("Check if user is able to withdraw the sent request"),]
        public void TestWithdrawSuccessfully()
        {
            manageRequestPage.GoToSentRequestPage();
            manageRequestPage.WithdrawSentRequests();
            //Check if the sent request has been withdrawn successfully
            
            string checkPopUpMessage = manageRequestPage.GetPopUpMessage();
            Assert.AreEqual(checkPopUpMessage, "Request has been withdrawn", "Actual and expected skill record do not match.");

        }
    }
}
