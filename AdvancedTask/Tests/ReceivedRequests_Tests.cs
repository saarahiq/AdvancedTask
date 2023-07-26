using AdvancedTask.Models;
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
    public class ReceivedRequests_Tests : CommonDriver
    {
        public static List<List<string>> listOfAcceptRequests()
        {
            var skillTradeRequests = new List<List<string>> 
            {
                new List<string> { "Make up and Hair style", "Mars"}
            };
            return skillTradeRequests;
        }
        public static List<List<string>> listOfDeclineRequests()
        {
            var skillTradeRequests = new List<List<string>>
            {
                new List<string> { "Swimming", "Mars" }
            };
            return skillTradeRequests;
        }
        public static List<List<string>> listOfCompletedRequests()
        {
            var skillTradeRequests = new List<List<string>>
            {
                new List<string> { "Data Analyst", "Mars" }
            };
            return skillTradeRequests;
        }
        public static List<string> listOfPages()
        {
            var pageNumbers = new List<string>()
            {
                "4",
                "2",
                "8"
            };
            return pageNumbers;
        }

        [Test, Order(1), Description("Accept a Service Request"), TestCaseSource(nameof(listOfAcceptRequests))]
        public void manageRequestAcceptTest(List<string> skillTradeRequest)
        {
            ManageRequests manageRequestsPage = new ManageRequests(driver);
            manageRequestsPage.acceptServiceRequest(skillTradeRequest[0], skillTradeRequest[1]);
            manageRequestsPage.verifyServiceRequestHasBeenAccepted(skillTradeRequest[0], skillTradeRequest[1]);
            //logging to extent reports
            test.Log(Status.Pass, "Successfully verified Accept button for a Service Request");
        }
        [Test, Order(2), Description("Decline a Service Request"), TestCaseSource(nameof(listOfDeclineRequests))]
        public void manageRequestDeclineTest(List<string> skillTradeRequest)
        {
            ManageRequests manageRequestsPage = new ManageRequests(driver);
            manageRequestsPage.declineServiceRequest(skillTradeRequest[0], skillTradeRequest[1]);
            manageRequestsPage.verifyServiceRequestHasBeenDeclined(skillTradeRequest[0], skillTradeRequest[1]);
            //logging to extent reports
            test.Log(Status.Pass, "Successfully verified Decline button for a Service Request");
        }
        [Test, Order(3), Description("Complete a Service Request"), TestCaseSource(nameof(listOfCompletedRequests))]
        public void manageRequestCompleteTest(List<string> skillTradeRequest)
        {
            ManageRequests manageRequestsPage = new ManageRequests(driver);
            manageRequestsPage.completeServiceRequest(skillTradeRequest[0], skillTradeRequest[1]);
            manageRequestsPage.verifyServiceRequestHasBeenCompleted();
            //logging to extent reports
            test.Log(Status.Pass, "Successfully verified Complete button for a Service Request");
        }
        [Test, Order(4), Description("Rate a Service"), TestCaseSource(nameof(listOfAcceptRequests))]
        public void starRateService(List<string> skillTradeRequest)
        {
            ManageRequests manageRequestsPage = new ManageRequests(driver);
            manageRequestsPage.selectStarRating(skillTradeRequest[0], skillTradeRequest[1], "3");
            //logging to extent reports
            test.Log(Status.Pass, "Successfully verified Star rating for a Service Request");

        }
       [Test, Order(5), Description("Navigate to Pages"), TestCaseSource(nameof(listOfPages))]
        public void pageNavigation(string pageNumber)
        {
            ManageRequests manageRequestsPage = new ManageRequests(driver);
            manageRequestsPage.navigateToPages(pageNumber);
            //logging to extent reports
            test.Log(Status.Pass, "Successfully verified navigating to pages of Received Requests");
        }
    }
}
