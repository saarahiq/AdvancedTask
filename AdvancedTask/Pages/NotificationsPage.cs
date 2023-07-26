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
    }
}
