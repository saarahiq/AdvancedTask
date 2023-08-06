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
        private IWebElement notification => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/div[1]/div[2]/div/div"));
        private IWebElement seeAllButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/div[1]/div[2]/div/div/div[2]/span/div/div[2]/div/center/a"));
        private IWebElement theFirstNotificationCheckbox => driver.FindElement(By.XPath("//*[@id=\"notification-section\"]/div[2]/div/div/div[3]/div[2]/span/span/div/div[1]/div/div/div[3]/input"));
        private IWebElement unselectButton => driver.FindElement(By.XPath("//*[@id=\"notification-section\"]/div[2]/div/div/div[3]/div[1]/div[2]"));
        private IWebElement markFirstAsRead => driver.FindElement(By.XPath("//*[@id=\"notification-section\"]/div[2]/div/div/div[3]/div[1]/div[4]"));
        private IWebElement deleteSelection => driver.FindElement(By.XPath("//*[@id=\"notification-section\"]/div[2]/div/div/div[3]/div[1]/div[3]"));
        private IWebElement selectAllButton => driver.FindElement(By.XPath("//*[@id=\"notification-section\"]/div[2]/div/div/div[3]/div[1]/div[1]"));
        private IWebElement unselectAllButton => driver.FindElement(By.XPath("//*[@id=\"notification-section\"]/div[2]/div/div/div[3]/div[1]/div[2]"));
        private IWebElement markAsRead => driver.FindElement(By.XPath("//*[@id=\"notification-section\"]/div[2]/div/div/div[3]/div[1]/div[4]"));
        private IWebElement popUpMessage => driver.FindElement(By.CssSelector(".ns-box-inner"));
        private IWebElement loadMoreButton => driver.FindElement(By.XPath("//*[@id=\"notification-section\"]/div[2]/div/div/div[3]/div[2]/span/span/div/div[6]/div/center/a"));                                                                  
        private IWebElement showLessButton => driver.FindElement(By.XPath("//*[@id=\"notification-section\"]/div[2]/div/div/div[3]/div[2]/span/span/div/div[11]/div[1]/center/a"));

        public void GoToNotificationsPage()
        {
            //Creating object of an actions class
            Actions action = new Actions(driver);
            //Performing the mouse  hover action on the target element
            action.MoveToElement(notification).Perform();
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/div[1]/div[2]/div/div/div[2]/span/div/div[2]/div/center/a", 10);
            seeAllButton.Click();
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"notification-section\"]/div[2]/div/div/div[3]/div[2]/span/span/div/div[1]/div/div/div[2]/div[1]/a/span/h4", 10);
        }

        public void UnSelectOneNotification()
        {
            //Identify the first notification and select
            theFirstNotificationCheckbox.Click();
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
            theFirstNotificationCheckbox.Click();
            markFirstAsRead.Click();
        }
        public void DeleteOneSelection()
        {
            //Identify the first notification and select
            theFirstNotificationCheckbox.Click();
            deleteSelection.Click();
        }

        public void SelectAllNotifications()
        {
            //Identify select all button and click
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
            selectAllButton.Click();
            //Identify unselect all button and click
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
            selectAllButton.Click();
            //Identify the mark as read button and click
            markAsRead.Click();
        }
       
        public string GetPopUpMessage()
        {
            Wait.WaitToBeVisible(driver, "CssSelector", ".ns-box-inner", 15);
            return popUpMessage.Text;
        }

        public void LoadMoreNotifications()
        {
            //Identify load more button and click
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"notification-section\"]/div[2]/div/div/div[3]/div[2]/span/span/div/div[6]/div/center/a", 10);
            loadMoreButton.Click();
        }

        public void ShowLessNotifications()
        {
            //Identify show less button and click
            showLessButton.Click();
        }
        public  ICollection<IWebElement> GetAllNotificationMessages()
        {
           return driver.FindElements(By.XPath("//*[@id=\"notification-section\"]/div[2]/div/div/div[3]/div[2]/span/span/div/div/div/div/div[2]/div[1]/a/div[1]"));
        }
       

    }
}
