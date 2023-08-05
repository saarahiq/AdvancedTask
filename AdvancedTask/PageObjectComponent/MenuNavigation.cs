using AdvancedTask.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using RazorEngine.Compilation.ImpromptuInterface.Dynamic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTask.PageObjectComponent
{
    public class MenuNavigation
    {
        readonly IWebDriver driver;
        public MenuNavigation(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void GoToProfilePage()
        {
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[1]/div/a[2]", 15);
            IWebElement profileButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[1]/div/a[2]"));
            profileButton.Click();
        }
        public void GoToManageListingsPage()
        {
            Wait.WaitToBeClickable(driver, "LinkText", "Manage Listings", 10);
            IWebElement manageListings = driver.FindElement(By.LinkText("Manage Listings"));
            manageListings.Click();

        }
        public void GoToChatPage()
        {
            IWebElement chatButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/div[1]/div[2]/div/a[1]"));
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/div[1]/div[2]/div/a[1]", 10);
            chatButton.Click();
        }
        public void GoToNotificationsPage()
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

        public void GoToSearchPage() 
        {
            
           IWebElement searchButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/div[1]/div[1]/i"));
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/div[1]/div[1]/i", 10);
            searchButton.Click();

        }
    }
}
