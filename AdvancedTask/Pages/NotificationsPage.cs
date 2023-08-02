using AdvancedTask.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTask.Pages
{
    public class Notifications
    {
        readonly IWebDriver driver;
        public Notifications(IWebDriver driver)
        {
            this.driver = driver;
        }
        private IWebElement firstNotificationCheckbox => driver.FindElement(By.XPath("//*[@id=\"notification-section\"]/div[2]/div/div/div[3]/div[2]/span/span/div/div[1]/div/div/div[3]/input"));
        private IWebElement deleteNotificationButton => driver.FindElement(By.XPath("//*[@id=\"notification-section\"]/div[2]/div/div/div[3]/div[1]/div[3]"));
        public void deleteNotification()
        {
            //Click on Notification to be deleted
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"notification-section\"]/div[2]/div/div/div[3]/div[2]/span/span/div/div[1]/div/div/div[3]/input", 10);
            firstNotificationCheckbox.Click();
            //Click on Delete button
            deleteNotificationButton.Click();
        }
        
        public void GoToNotificationsPage()
        {
            //Creating object of an actions class
            Actions action = new Actions(driver);
            //Performing the mouse  hover action on the target element
            IWebElement notification = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/div[1]/div[2]/div/div"));
            action.MoveToElement(notification).Perform();
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/div[1]/div[2]/div/div/div[2]/span/div/div[2]/div/center/a", 10);
            IWebElement seeAllButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/div[1]/div[2]/div/div/div[2]/span/div/div[2]/div/center/a"));
           
           
            seeAllButton.Click();
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"notification-section\"]/div[2]/div/div/div[3]/div[2]/span/span/div/div[1]/div/div/div[2]/div[1]/a/span/h4", 10);
        }

        public void UnSelectOneNotification()
        {
            //Identify the first notification and select
            IWebElement firstNotificationCheckbox = driver.FindElement(By.XPath("//*[@id=\"notification-section\"]/div[2]/div/div/div[3]/div[2]/span/span/div/div[1]/div/div/div[3]/input"));
            firstNotificationCheckbox.Click();
            IWebElement unselectButton = driver.FindElement(By.XPath("//*[@id=\"notification-section\"]/div[2]/div/div/div[3]/div[1]/div[2]"));
            unselectButton.Click();
        }

        public bool IsUnselectOneHidden()
        {
            try
            {
                Wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"notification-section\"]/div[2]/div/div/div[3]/div[1]/div[2]", 5);
                return false;
            }
            catch (Exception ex)
            {
                return true;
            }
        }
        public void MarkOneSelectionAsRead()
        {
            //Identify the first notification and select
            IWebElement firstNotificationCheckbox = driver.FindElement(By.XPath("//*[@id=\"notification-section\"]/div[2]/div/div/div[3]/div[2]/span/span/div/div[1]/div/div/div[3]/input"));
            firstNotificationCheckbox.Click();
            IWebElement markFirstAsRead = driver.FindElement(By.XPath("//*[@id=\"notification-section\"]/div[2]/div/div/div[3]/div[1]/div[4]"));
            markFirstAsRead.Click();
        }
        public void DeleteOneSelection()
        {
            //Identify the first notification and select
            IWebElement firstNotificationCheckbox = driver.FindElement(By.XPath("//*[@id=\"notification-section\"]/div[2]/div/div/div[3]/div[2]/span/span/div/div[1]/div/div/div[3]/input"));
            firstNotificationCheckbox.Click();
            IWebElement deleteSelection = driver.FindElement(By.XPath("//*[@id=\"notification-section\"]/div[2]/div/div/div[3]/div[1]/div[3]"));
            deleteSelection.Click();
        }

        public void SelectAllNotifications()
        {
            //Identify select all button and click
            IWebElement selectAllButton = driver.FindElement(By.XPath("//*[@id=\"notification-section\"]/div[2]/div/div/div[3]/div[1]/div[1]"));
            selectAllButton.Click();           
        }

        public bool IsSelectAllNotifications()
        {
            try
            {
                Wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"notification-section\"]/div[2]/div/div/div[3]/div[1]/div[2]", 5);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public void UnSelectAllNotifications()
        {
            //Identify select all button and click
            IWebElement selectAllButton = driver.FindElement(By.XPath("//*[@id=\"notification-section\"]/div[2]/div/div/div[3]/div[1]/div[1]"));
            selectAllButton.Click();
            //Identify unselect all button and click
            IWebElement unselectAllButton = driver.FindElement(By.XPath("//*[@id=\"notification-section\"]/div[2]/div/div/div[3]/div[1]/div[2]"));
            unselectAllButton.Click();
        }

        public bool IsUnselectAllHidden()
        {
            try
            {
                Wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"notification-section\"]/div[2]/div/div/div[3]/div[1]/div[2]", 5);
                return false;
            }
            catch (Exception ex)
            {
                return true;
            }
        }
        public void MarkAllSelectionsAsRead()
        {
            //Identify select all button and click
            IWebElement selectAllButton = driver.FindElement(By.XPath("//*[@id=\"notification-section\"]/div[2]/div/div/div[3]/div[1]/div[1]"));
            selectAllButton.Click();
            //Identify the mark as read button and click
            IWebElement markAsRead = driver.FindElement(By.XPath("//*[@id=\"notification-section\"]/div[2]/div/div/div[3]/div[1]/div[4]"));
            markAsRead.Click();
        }
       
        public string GetPopUpMessage()
        {
            Wait.WaitToBeVisible(driver, "CssSelector", ".ns-box-inner", 15);
            IWebElement popUpMessage = driver.FindElement(By.CssSelector(".ns-box-inner"));
            return popUpMessage.Text;
        }

        public void LoadMoreNotifications()
        {
            //Identify load more button and click
            IWebElement loadMoreButton = driver.FindElement(By.XPath("//*[@id=\"notification-section\"]/div[2]/div/div/div[3]/div[2]/span/span/div/div[6]/div/center/a"));
            loadMoreButton.Click();
        }

        public void ShowLessNotifications()
        {
            //Identify show less button and click
            IWebElement showLessButton = driver.FindElement(By.XPath("//*[@id=\"notification-section\"]/div[2]/div/div/div[3]/div[2]/span/span/div/div[11]/div[1]/center/a"));
            showLessButton.Click();
        }
        public  ICollection<IWebElement> GetAllNotificationMessages()
        {
           return driver.FindElements(By.XPath("//*[@id=\"notification-section\"]/div[2]/div/div/div[3]/div[2]/span/span/div/div/div/div/div[2]/div[1]/a/div[1]"));
        }
       

    }
}
