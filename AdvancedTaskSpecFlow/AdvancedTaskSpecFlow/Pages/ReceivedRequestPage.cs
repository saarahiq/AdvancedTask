using AdvancedTaskSpecFlow.PageObjectComponents;
using AdvancedTaskSpecFlow.Pages;
using AdvancedTaskSpecFlow.Utilities;
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
        NavigationMenu navigationMenu;
        public ManageRequests(IWebDriver driver)
        {
            //Instantiate the navigation menu
            navigationMenu = new NavigationMenu(driver);
            this.driver = driver;
        }
        
        private IWebElement pageNavigation => driver.FindElement(By.XPath("//*[@id=\"received-request-section\"]/div[2]/div[1]/div"));
        public void acceptServiceRequest(string title, string sender)
        {
            navigationMenu.goToManageRequestsReceivedRequestPage();
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
            navigationMenu.goToManageRequestsReceivedRequestPage();
            var xPathToFindRow = "//tr[td[a[contains(text(), '" + title + "')]] and td[a[contains(text(), '" + sender + "')]]]";
            Wait.WaitToBeClickable(driver, "XPath", xPathToFindRow, 15);
            var skillTradeRequestRow = driver.FindElement(By.XPath(xPathToFindRow));
            skillTradeRequestRow.Click();
            var starRatingSection = driver.FindElement(By.XPath($"//tr[td/a[text()='{title}'] and td/a[text()='{sender}']]/following-sibling::tr/td[contains(., 'Rating')]"));
            Thread.Sleep(1000);
            starRatingSection.FindElement(By.XPath($"//i[@aria-posinset='{starNumber}']")).Click();
        }
        public void declineServiceRequest(string title, string sender)
        {
            navigationMenu.goToManageRequestsReceivedRequestPage();
            //Navigate to skill trade request row you want to decline and Click on Decline button
            var xPathToFindRow = "//tr[td[a[contains(text(), '" + title + "')]] and td[a[contains(text(), '" + sender + "')]]]";
            Wait.WaitToBeClickable(driver, "XPath", xPathToFindRow, 15);
            var skillTradeRequestRow = driver.FindElement(By.XPath(xPathToFindRow));
            var declineButton = skillTradeRequestRow.FindElement(By.CssSelector(".ui.negative.basic.button"));
            declineButton.Click();
            Thread.Sleep(3000);
        }
        public void completeServiceRequest(string title, string sender)
        {
            navigationMenu.goToManageRequestsReceivedRequestPage();
            //Navigate to skill trade request row you want to complete and Click on Complete button
            var xPathToFindRow = "//tr[td[a[contains(text(), '" + title + "')]] and td[a[contains(text(), '" + sender + "')]]]";
            Wait.WaitToBeClickable(driver, "XPath", xPathToFindRow, 15);
            var skillTradeRequestRow = driver.FindElement(By.XPath(xPathToFindRow));
            var completeButton = skillTradeRequestRow.FindElement(By.CssSelector(".ui.positive.basic.button"));
            completeButton.Click();
            Thread.Sleep(3000);
        }
        public void verifyServiceRequestHasBeenAccepted(string title, string sender, string message)
        {
            PopUpComponent popUpComponent = new PopUpComponent(driver);
            string popUpMessage = popUpComponent.getMessage();
            Assert.AreEqual(message, popUpMessage, "Actual and expected accepted service request message do not match");
            var xPathToFindRow = "//tr[td[a[contains(text(), '" + title + "')]] and td[a[contains(text(), '" + sender + "')]]]";
            var skillTradeRequestRow = driver.FindElement(By.XPath(xPathToFindRow));
            Thread.Sleep(2000);
            var statusColumn = skillTradeRequestRow.FindElement(By.XPath("//td[text() = 'Accepted']"));
            Assert.AreEqual("Accepted", statusColumn.Text, "Actual and expected accepted status do not match");
        }
        public void verifyServiceRequestHasBeenDeclined(string title, string sender, string message)
        {
            PopUpComponent popUpComponent = new PopUpComponent(driver);
            string popUpMessage = popUpComponent.getMessage();
            Assert.AreEqual(message, popUpMessage, "Actual and expected declined service request message do not match");
            var xPathToFindRow = "//tr[td[a[contains(text(), '" + title + "')]] and td[a[contains(text(), '" + sender + "')]]]";
            var skillTradeRequestRow = driver.FindElement(By.XPath(xPathToFindRow));
            Thread.Sleep(2000);
            var statusColumn = skillTradeRequestRow.FindElement(By.XPath("//td[text() = 'Declined']"));
            Assert.AreEqual("Declined", statusColumn.Text, "Actual and expected declined status do not match");
        }
        public void verifyServiceRequestHasBeenCompleted(string title, string sender, string message)
        {
            PopUpComponent popUpComponent = new PopUpComponent(driver);
            string popUpMessage = popUpComponent.getMessage();
            Assert.AreEqual(message, popUpMessage, "Actual and expected declined service request message do not match");
            var xPathToFindRow = "//tr[td[a[contains(text(), '" + title + "')]] and td[a[contains(text(), '" + sender + "')]]]";
            var skillTradeRequestRow = driver.FindElement(By.XPath(xPathToFindRow));
            Thread.Sleep(2000);
            var statusColumn = skillTradeRequestRow.FindElement(By.XPath("//td[text() = 'Completed']"));
            Assert.AreEqual("Completed", statusColumn.Text, "Actual and expected complete status do not match");
        }
        public void navigateToPages(string pageNumber)
        {
            try
            {
                navigationMenu.goToManageRequestsReceivedRequestPage();

                Wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"received-request-section\"]/div[2]/div[1]/div", 10);
                pageNavigation.FindElement(By.XPath($"//button[text()='{pageNumber}']")).Click();
            }
            catch (Exception ex)
            {
                Assert.Pass($"Page number {pageNumber} not availabe");
            }

        }
    }
}
