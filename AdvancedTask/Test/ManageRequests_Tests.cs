using AdvancedTask.Models;
using AdvancedTask.Pages;
using AdvancedTask.Utilities;
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
    public class ManageRequests_Tests : CommonDriver
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
        }
        [Test, Order(2), Description("Decline a Service Request"), TestCaseSource(nameof(listOfDeclineRequests))]
        public void manageRequestDeclineTest(List<string> skillTradeRequest)
        {
            ManageRequests manageRequestsPage = new ManageRequests(driver);
            manageRequestsPage.declineServiceRequest(skillTradeRequest[0], skillTradeRequest[1]);
            manageRequestsPage.verifyServiceRequestHasBeenDeclined(skillTradeRequest[0], skillTradeRequest[1]);
        }
        [Test, Order(3), Description("Complete a Service Request"), TestCaseSource(nameof(listOfCompletedRequests))]
        public void manageRequestCompleteTest(List<string> skillTradeRequest)
        {
            ManageRequests manageRequestsPage = new ManageRequests(driver);
            manageRequestsPage.completeServiceRequest(skillTradeRequest[0], skillTradeRequest[1]);
            manageRequestsPage.verifyServiceRequestHasBeenCompleted();
        }
        [Test, Order(4), Description("Rate a Service"), TestCaseSource(nameof(listOfAcceptRequests))]
        public void starRateService(List<string> skillTradeRequest)
        {
            ManageRequests manageRequestsPage = new ManageRequests(driver);
            manageRequestsPage.selectStarRating(skillTradeRequest[0], skillTradeRequest[1], "3");

        }
       [Test, Order(5), Description("Navigate to Pages"), TestCaseSource(nameof(listOfPages))]
        public void pageNavigation(string pageNumber)
        {
            ManageRequests manageRequestsPage = new ManageRequests(driver);
            manageRequestsPage.navigateToPages(pageNumber);
        }
    }
}
