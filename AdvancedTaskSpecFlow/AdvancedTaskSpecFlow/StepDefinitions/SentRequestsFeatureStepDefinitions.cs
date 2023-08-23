using AdvancedTaskSpecFlow.Utilities;
using AventStack.ExtentReports;
using NUnit.Framework;
using System;
using System.Globalization;
using TechTalk.SpecFlow;

namespace AdvancedTaskSpecFlow.StepDefinitions
{
    [Binding]
    public class SentRequestsFeatureStepDefinitions
    {

         private readonly CommonDriver commonDriver;
         public SentRequestsFeatureStepDefinitions(CommonDriver commonDriver)
         {
                this.commonDriver = commonDriver;
         }

        [When(@"Navigate to Sent Requests tab")]
        public void WhenNavigateToSentRequestsTab()
        {
            //Naviaget to Sent Requests page
            commonDriver.navigationMenu.GoToSentRequestPage();
        }

        [When(@"Click on the Category")]
        public void WhenClickOnTheCategory()
        {
            commonDriver.sentRequests.SortByCategory();
        }

        [Then(@"The Sent Requests should be sort by Category successfully")]
        public void ThenTheSentRequestsShouldBeSortByCategorySuccessfully()
        {
            //Check if the requests are sorted by category
            var categories = commonDriver.sentRequests.GetCategories();
            for (int i = 1; i < categories.Length; i++)
            {

                CommonDriver.test.Log(Status.Info, categories[i - 1]);
                CommonDriver.test.Log(Status.Info, categories[i]);
                Assert.IsTrue(categories[i - 1].CompareTo(categories[i]) <= 0);
            }
            commonDriver.sentRequests.SortByCategory();
            //Check if the requests are sorted by category
            categories = commonDriver.sentRequests.GetCategories();
            for (int i = 1; i < categories.Length; i++)
            {

                CommonDriver.test.Log(Status.Info, categories[i - 1]);
                CommonDriver.test.Log(Status.Info, categories[i]);
                Assert.IsTrue(categories[i - 1].CompareTo(categories[i]) >= 0);
            }
        }

        [When(@"Click on the Title")]
        public void WhenClickOnTheTitle()
        {
            commonDriver.sentRequests.SortByTitle();
        }

        [Then(@"The Sent Requests should be sort by Title successfully")]
        public void ThenTheSentRequestsShouldBeSortByTitleSuccessfully()
        {
            //Check if the requests are sorted by category
            var titles = commonDriver.sentRequests.GetTitles();
            for (int i = 1; i < titles.Length; i++)
            {
                CommonDriver.test.Log(Status.Info, titles[i - 1]);
                CommonDriver.test.Log(Status.Info, titles[i]);
                Assert.IsTrue(titles[i - 1].ToLower().CompareTo(titles[i].ToLower()) <= 0);
            }
            commonDriver.sentRequests.SortByTitle();
            //Check if the requests are sorted by category
            titles = commonDriver.sentRequests.GetTitles();
            for (int i = 1; i < titles.Length; i++)
            {
                CommonDriver.test.Log(Status.Info, titles[i - 1]);
                CommonDriver.test.Log(Status.Info, titles[i]);
                Assert.IsTrue(titles[i - 1].ToLower().CompareTo(titles[i].ToLower()) >= 0);
            }
        }

        [When(@"Click on the Message")]
        public void WhenClickOnTheMessage()
        {
            commonDriver.sentRequests.SortByMessage();
        }

        [Then(@"The Sent Requests should be sort by Message successfully")]
        public void ThenTheSentRequestsShouldBeSortByMessageSuccessfully()
        {
            //Check if the requests are sorted by category
            var messages = commonDriver.sentRequests.GetMessages();
            for (int i = 1; i < messages.Length; i++)
            {
                CommonDriver.test.Log(Status.Info, messages[i - 1]);
                CommonDriver.   test.Log(Status.Info, messages[i]);
                Assert.IsTrue(messages[i - 1].ToLower().CompareTo(messages[i].ToLower()) <= 0);
            }
            commonDriver.sentRequests.SortByMessage();
            //Check if the requests are sorted by category
            messages = commonDriver.sentRequests.GetMessages();
            for (int i = 1; i < messages.Length; i++)
            {
                CommonDriver.test.Log(Status.Info, messages[i - 1]);
                CommonDriver.test.Log(Status.Info, messages[i]);
                Assert.IsTrue(messages[i - 1].ToLower().CompareTo(messages[i].ToLower()) >= 0);
            }
        }

        [When(@"Click on the Recipient")]
        public void WhenClickOnTheRecipient()
        {
            commonDriver.sentRequests.SortByRecipient();
        }

        [Then(@"The Sent Requests should be sort by Recipient successfully")]
        public void ThenTheSentRequestsShouldBeSortByRecipientSuccessfully()
        {
            //Check if the requests are sorted by category
            var recipients = commonDriver.sentRequests.GetRecipients();
            for (int i = 1; i < recipients.Length; i++)
            {
                CommonDriver.test.Log(Status.Info, recipients[i - 1]);
                CommonDriver.test.Log(Status.Info, recipients[i]);
                Assert.IsTrue(recipients[i - 1].ToLower().CompareTo(recipients[i].ToLower()) <= 0);
            }
            commonDriver.sentRequests.SortByRecipient();
            //Check if the requests are sorted by category
            recipients = commonDriver.sentRequests.GetRecipients();
            for (int i = 1; i < recipients.Length; i++)
            {
                CommonDriver.test.Log(Status.Info, recipients[i - 1]);
                CommonDriver.test.Log(Status.Info, recipients[i]);
                Assert.IsTrue(recipients[i - 1].ToLower().CompareTo(recipients[i].ToLower()) >= 0);
            }
        }

        [When(@"Click on the Status")]
        public void WhenClickOnTheStatus()
        {
            commonDriver.sentRequests.SortByStatus();
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
        [Then(@"The Sent Requests should be sort by Status successfully")]
        public void ThenTheSentRequestsShouldBeSortByStatusSuccessfully()
        {
            //Check if the requests are sorted by category
            var statuses = commonDriver.sentRequests.GetStatuses();
            for (int i = 1; i < statuses.Length; i++)
            {
                CommonDriver.test.Log(Status.Info, statuses[i - 1]);
                CommonDriver.test.Log(Status.Info, statuses[i]);
                Assert.IsTrue(StatusOrder(statuses[i - 1]) <= StatusOrder(statuses[i]));
            }
            commonDriver.sentRequests.SortByStatus();
            //Check if the requests are sorted by category
            statuses = commonDriver.sentRequests.GetStatuses();
            for (int i = 1; i < statuses.Length; i++)
            {
                CommonDriver.test.Log(Status.Info, statuses[i - 1]);
                CommonDriver.test.Log(Status.Info, statuses[i]);
                Assert.IsTrue(StatusOrder(statuses[i - 1]) >= StatusOrder(statuses[i]));
            }
        }

        [When(@"Click on the Type")]
        public void WhenClickOnTheType()
        {
            commonDriver.sentRequests.SortByType();
        }
        private int typeOrder(string type)
        {
            if (type == "Paid")
                return 0;
            else if (type == "Exchange")
                return 1;
            return -1;
        }
        [Then(@"The Sent Requests should be sort by Type successfully")]
        public void ThenTheSentRequestsShouldBeSortByTypeSuccessfully()
        {
            //Check if the requests are sorted by category
            var types = commonDriver.sentRequests.GetTypes();
            for (int i = 1; i < types.Length; i++)
            {
                CommonDriver.test.Log(Status.Info, types[i - 1]);
                CommonDriver.test.Log(Status.Info, types[i]);
                Assert.IsTrue(StatusOrder(types[i - 1]) >= StatusOrder(types[i]));
            }
            commonDriver.sentRequests.SortByStatus();
            //Check if the requests are sorted by category
            types = commonDriver.sentRequests.GetStatuses();
            for (int i = 1; i < types.Length; i++)
            {
                CommonDriver.test.Log(Status.Info, types[i - 1]);
                CommonDriver.test.Log(Status.Info, types[i]);
                Assert.IsTrue(StatusOrder(types[i - 1]) <= StatusOrder(types[i]));
            }
        }

        [When(@"Click on the Date")]
        public void WhenClickOnTheDate()
        {
            commonDriver.sentRequests.SortByDate();
        }
        private DateTime ParseDate(string date)
        {
            string dateString = date.Replace("st", "")
                            .Replace("nd", "")
                            .Replace("rd", "")
                            .Replace("th", "");

            return DateTime.ParseExact(dateString, "d MMM, yyyy", CultureInfo.InvariantCulture);
        }
        [Then(@"The Sent Requests should be sort by Date successfully")]
        public void ThenTheSentRequestsShouldBeSortByDateSuccessfully()
        {
            //Check if the requests are sorted by category
            var dates = commonDriver.sentRequests.GetDates();
            for (int i = 1; i < dates.Length; i++)
            {
                CommonDriver.test.Log(Status.Info, dates[i - 1]);
                CommonDriver.test.Log(Status.Info, dates[i]);
                Assert.IsTrue(ParseDate(dates[i - 1]) <= ParseDate(dates[i]));
            }
            commonDriver.sentRequests.SortByDate();
            //Check if the requests are sorted by category
            dates = commonDriver.sentRequests.GetDates();
            for (int i = 1; i < dates.Length; i++)
            {
                CommonDriver.test.Log(Status.Info, dates[i - 1]);
                CommonDriver.test.Log(Status.Info, dates[i]);
                Assert.IsTrue(ParseDate(dates[i - 1]) >= ParseDate(dates[i]));
            }
        }

        [When(@"Click on the withdraw button of the first sent request")]
        public void WhenClickOnTheWithdrawButtonOfTheFirstSentRequest()
        {
            commonDriver.sentRequests.WithdrawSentRequests();
        }

        [Then(@"The first Sent Requests should be withdrawn successfully")]
        public void ThenTheFirstSentRequestsShouldBeWithdrawnSuccessfully()
        {
            //Check if the sent request has been withdrawn successfully
            string checkPopUpMessage = commonDriver.sentRequests.GetPopUpMessage();
            Assert.AreEqual(checkPopUpMessage, "Request has been withdrawn", "Actual and expected skill record do not match.");
        }

    }
}
