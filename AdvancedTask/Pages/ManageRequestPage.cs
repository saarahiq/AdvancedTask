using AdvancedTask.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTask.Pages
{
    public class ManageRequests
    {
        readonly IWebDriver driver;
        public ManageRequests(IWebDriver driver)
        {
            this.driver = driver;
        }
        private IWebElement manageRequestsHoverButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[1]/div/div[1]"));
        private IWebElement starRatingSection => driver.FindElement(By.XPath("//*[@id=\"received-request-section\"]/div[2]/div[1]/table/tbody/tr[5]/td[3]/div"));
        private IWebElement pageNavigation => driver.FindElement(By.XPath("//*[@id=\"received-request-section\"]/div[2]/div[1]/div"));
        private IWebElement popUpMessage => driver.FindElement(By.CssSelector(".ns-box-inner"));

        public void goToReceivedRequestPage()
        {
            //Navigate to Received Requests page
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[1]/div/div[1]", 15);
            Actions actions = new Actions(driver);
            actions.MoveToElement(manageRequestsHoverButton).Perform();
            manageRequestsHoverButton.FindElement(By.LinkText("Received Requests")).Click();
        }
        public void acceptServiceRequest(string title, string sender)
        {
            goToReceivedRequestPage();
            //Navigate to skill trade request row you want to accept and Click on Accept button
            var xPathToFindRow = "//tr[td[a[contains(text(), '" + title + "')]] and td[a[contains(text(), '" + sender +"')]]]";
            Wait.WaitToBeClickable(driver, "XPath", xPathToFindRow, 15);
            var skillTradeRequestRow = driver.FindElement(By.XPath(xPathToFindRow));
            var acceptButton = skillTradeRequestRow.FindElement(By.CssSelector(".ui.primary.basic.button"));
            acceptButton.Click();   
            Thread.Sleep(3000);
        }
        public void selectStarRating(string title, string sender, string starNumber)
        {
            goToReceivedRequestPage();
            var xPathToFindRow = "//tr[td[a[contains(text(), '" + title + "')]] and td[a[contains(text(), '" + sender + "')]]]";
            Wait.WaitToBeClickable(driver, "XPath", xPathToFindRow, 15);
            var skillTradeRequestRow = driver.FindElement(By.XPath(xPathToFindRow));
            skillTradeRequestRow.Click();
            starRatingSection.FindElement(By.XPath($"//i[@aria-posinset='{starNumber}']")).Click();
        }
        public void declineServiceRequest(string title, string sender)
        {
            goToReceivedRequestPage();
            //Navigate to skill trade request row you want to accept and Click on Decline button
            var xPathToFindRow = "//tr[td[a[contains(text(), '" + title + "')]] and td[a[contains(text(), '" + sender + "')]]]";
            Wait.WaitToBeClickable(driver, "XPath", xPathToFindRow, 15);
            var skillTradeRequestRow = driver.FindElement(By.XPath(xPathToFindRow));
            var declineButton = skillTradeRequestRow.FindElement(By.CssSelector(".ui.negative.basic.button"));
            declineButton.Click();
            Thread.Sleep(3000);
        }
        public void verifyServiceRequestHasBeenAccepted(string title, string sender)
        {
            Wait.WaitToBeVisible(driver, "CssSelector", ".ns-box-inner", 10);
            Assert.AreEqual("Service has been updated", popUpMessage.Text, "Actual and expected accepted service request message do not match");
            var xPathToFindRow = "//tr[td[a[contains(text(), '" + title + "')]] and td[a[contains(text(), '" + sender + "')]]]";
            var skillTradeRequestRow = driver.FindElement(By.XPath(xPathToFindRow));
            Thread.Sleep(2000);
            var statusColumn = skillTradeRequestRow.FindElement(By.XPath("//td[text() = 'Accepted']"));
            Assert.AreEqual("Accepted", statusColumn.Text, "Actual and expected accepted status do not match");
        }
        public void verifyServiceRequestHasBeenDeclined(string title, string sender)
        {
            Wait.WaitToBeVisible(driver, "CssSelector", ".ns-box-inner", 10);
            Assert.AreEqual("Service has been updated", popUpMessage.Text, "Actual and expected declined service request message do not match");
            var xPathToFindRow = "//tr[td[a[contains(text(), '" + title + "')]] and td[a[contains(text(), '" + sender + "')]]]";
            var skillTradeRequestRow = driver.FindElement(By.XPath(xPathToFindRow));
            Thread.Sleep(2000);
            var statusColumn = skillTradeRequestRow.FindElement(By.XPath("//td[text() = 'Declined']"));
            Assert.AreEqual("Declined", statusColumn.Text, "Actual and expected declined status do not match");
        }
        public void navigateToPages(string pageNumber)
        {
            try
            {
                goToReceivedRequestPage();
                Wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"received-request-section\"]/div[2]/div[1]/div", 10);
                pageNavigation.FindElement(By.XPath($"//button[text()='{pageNumber}']")).Click();
            }
            catch (Exception ex)
            {
                Assert.Fail($"Page number {pageNumber} not availabe");
            }

        }
    }
}
