using AdvancedTask.JSON_Objects;
using AdvancedTask.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V109.Tracing;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTask.Pages
{
    
    public class ManageRequestPage
    {
        readonly IWebDriver driver;
        public ManageRequestPage(IWebDriver driver) { this.driver = driver; }
        public void GoToSentRequestPage()
        {
            
            //Creating object of an Actions class
            Actions action = new Actions(driver);
            //Performing the mouse hover action on the target element
            action.MoveToElement(manageRequest).Perform();
            Wait.WaitToBeClickable(driver,"XPath", "//*[@id=\"account-profile-section\"]/div/section[1]/div/div[1]/div/a[2]", 10);
            sentRequest.Click();
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"sent-request-section\"]/div[2]/div[1]/table/thead/tr/th[1]", 10);
        }
        public void SortByCategory()
        {
            //Identify category and click
            category.Click();
            Thread.Sleep(1500);
        }

        public string[] GetCategories()
        {
            var categoryElements = driver.FindElements(By.XPath("//*[@id=\"sent-request-section\"]/div[2]/div[1]/table/tbody/tr/td[1]"));
            var categories = new List<string>();
            foreach (var element in categoryElements)
            {
                categories.Add(element.Text);

            }
            return categories.ToArray();
        }

        public void SortByTitle()
        {
            //Identify category and click
            title.Click();
            Thread.Sleep(500);
        }

        public string[] GetTitles()
        {
            var titleElements = driver.FindElements(By.XPath("//*[@id=\"sent-request-section\"]/div[2]/div[1]/table/tbody/tr/td[2]/a"));

            var titles = new List<string>();
            foreach (var element in titleElements)
            {
                titles.Add(element.Text);

            }
            return titles.ToArray();
        }
        public void SortByMessage()
        {
            //Identify category and click
            message.Click();
            Thread.Sleep(500);
        }

        public string[] GetMessages()
        {
            var messageElements = driver.FindElements(By.XPath("//*[@id=\"sent-request-section\"]/div[2]/div[1]/table/tbody/tr/td[3]"));

            var messages = new List<string>();
            foreach (var element in messageElements)
            {
                messages.Add(element.Text);

            }
            return messages.ToArray();
        }
        public void SortByRecipient()
        {
            //Identify category and click
            recipient.Click();
            Thread.Sleep(500);
        }

        public string[] GetRecipients()
        {
            var recipientElements = driver.FindElements(By.XPath("//*[@id=\"sent-request-section\"]/div[2]/div[1]/table/tbody/tr/td[4]"));

            var recipients = new List<string>();
            foreach (var element in recipientElements)
            {
                recipients.Add(element.Text);

            }
            return recipients.ToArray();
        }
        public void SortByStatus()
        {
            //Identify category and click
            IWebElement status = driver.FindElement(By.XPath("//*[@id=\"sent-request-section\"]/div[2]/div[1]/table/thead/tr/th[5]"));
            status.Click();
            Thread.Sleep(500);
        }

        public string[] GetStatuses()
        {
            var statusElements = driver.FindElements(By.XPath("//*[@id=\"sent-request-section\"]/div[2]/div[1]/table/tbody/tr/td[5]"));

            var statuses = new List<string>();
            foreach (var element in statusElements)
            {
                statuses.Add(element.Text);

            }
            return statuses.ToArray();
        }
        public void SortByDate()
        {
            //Identify category and click
            IWebElement dates = driver.FindElement(By.XPath("//*[@id=\"sent-request-section\"]/div[2]/div[1]/table/thead/tr/th[7]"));
            dates.Click();
            Thread.Sleep(500);
        }

        public string[] GetDates()
        {
            var datesElements = driver.FindElements(By.XPath("//*[@id=\"sent-request-section\"]/div[2]/div[1]/table/tbody/tr/td[7]"));
            var dates = new List<string>();
            foreach (var element in datesElements)
            {
                dates.Add(element.Text);

            }
            return dates.ToArray();
        }

        public void WithdrawSentRequests()
        {
            //Identify withdraw button and click
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"sent-request-section\"]/div[2]/div[1]/table/tbody/tr[1]/td[8]/button", 15);
            withdrawActionButton.Click();
           
        }

        public string GetPopUpMessage()
        {
            Wait.WaitToBeVisible(driver, "CssSelector", ".ns-box-inner", 15);
            return popUpmMessage.Text;
        }
        private IWebElement manageRequest => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[1]/div/div[1]"));
        private IWebElement sentRequest => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[1]/div/div[1]/div/a[2]"));
        private IWebElement category => driver.FindElement(By.XPath("//*[@id=\"sent-request-section\"]/div[2]/div[1]/table/thead/tr/th[1]"));
        private IWebElement title => driver.FindElement(By.XPath("//*[@id=\"sent-request-section\"]/div[2]/div[1]/table/thead/tr/th[2]"));
        private IWebElement message => driver.FindElement(By.XPath("//*[@id=\"sent-request-section\"]/div[2]/div[1]/table/thead/tr/th[3]"));
        private IWebElement recipient => driver.FindElement(By.XPath("//*[@id=\"sent-request-section\"]/div[2]/div[1]/table/thead/tr/th[4]"));
        private IWebElement withdrawActionButton => driver.FindElement(By.XPath("//*[@id=\"sent-request-section\"]/div[2]/div[1]/table/tbody/tr[1]/td[8]/button"));
        private IWebElement popUpmMessage => driver.FindElement(By.CssSelector(".ns-box-inner"));

    }
}
