using AdvancedTaskSpecFlow.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTaskSpecFlow.Pages
{
    public class NavigationMenu
    {
        readonly IWebDriver driver;
        public NavigationMenu(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void goToProfileButton()
        {
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[1]/div/a[2]", 15);
            IWebElement profileButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[1]/div/a[2]"));
            profileButton.Click();
        }
        public void goToManageListingsButton()
        {
            Wait.WaitToBeClickable(driver, "LinkText", "Manage Listings", 10);
            IWebElement manageListings = driver.FindElement(By.LinkText("Manage Listings"));
            manageListings.Click();
            // Wait for edit button to be clickable and click it.
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr/td[8]/div/button[2]/i", 10);
            driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr/td[8]/div/button[2]/i")).Click();


    }
    public void goToManageRequestsReceivedRequestPage()
        {
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[1]/div/div[1]", 15);
            //Hover over Manage Requests button
            IWebElement manageRequestsHoverButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[1]/div/div[1]"));
            Actions actions = new Actions(driver);
            actions.MoveToElement(manageRequestsHoverButton).Perform();
            // Click on Received Request button
            manageRequestsHoverButton.FindElement(By.LinkText("Received Requests")).Click();
        }

        public void goToNotificationsPage()
        {
            IWebElement notificationsHoverButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/div[1]/div[2]/div/div"));

            //Navigate to Notification page
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/div[1]/div[2]/div/div", 10);
            Actions actions = new Actions(driver);
            actions.MoveToElement(notificationsHoverButton).Perform();
            //Click on See All Option (copy See All XPath)
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/div[1]/div[2]/div/div/div[2]/span/div/div[2]/div/center/a", 10);
            notificationsHoverButton.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/div[1]/div[2]/div/div/div[2]/span/div/div[2]/div/center/a")).Click();
        }

        public void goToChatPage()
        {
            IWebElement chatButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/div[1]/div[2]/div/a[1]"));
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/div[1]/div[2]/div/a[1]", 10);
            chatButton.Click();
        }
    }
}
