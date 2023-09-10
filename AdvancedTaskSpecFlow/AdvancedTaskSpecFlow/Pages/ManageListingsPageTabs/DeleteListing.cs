using AdvancedTaskSpecFlow.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTaskSpecFlow.Pages.ManageListingsPageTabs
{
    public class DeleteListing
    {
        readonly IWebDriver driver;
        public DeleteListing(IWebDriver driver) { this.driver = driver; }

        private IWebElement deleteButton => driver.FindElement(By.XPath("//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[8]/div/button[3]/i"));
        private IWebElement manageListingtab => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[1]/div/a[3]"));
        private IWebElement deletionConfirm => driver.FindElement(By.XPath("/html/body/div[2]/div/div[3]/button[2]"));

        private IWebElement popUpMessage => driver.FindElement(By.CssSelector(".ns-box-inner"));
        private IWebElement cancelDelete => driver.FindElement(By.XPath("/html/body/div[2]/div/div[3]/button[1]"));
        private IWebElement firstListing => driver.FindElement(By.XPath("//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[3]"));


        public void DeleteFirstlisting()
        {

            //Identify delete button and click
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[8]/div/button[3]/i", 10);
            deleteButton.Click();
            deletionConfirm.Click();
        }

        public void DeletelistingCancel()
        {

            //Identify delete button and click
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[8]/div/button[3]/i", 10);
            deleteButton.Click();
            cancelDelete.Click();
        }
        public string GetPopUpmessage()
        {
            Wait.WaitToBeVisible(driver, "CssSelector", ".ns-box-inner", 15);
            return popUpMessage.Text;
        }
        public string[] GetFirstListing()
        {
            return new[] { firstListing.Text };
        }
    }
}
