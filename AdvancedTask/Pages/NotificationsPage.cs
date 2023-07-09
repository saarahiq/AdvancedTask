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
        private IWebElement notificationsHoverButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/div[1]/div[2]/div/div"));
        private IWebElement popUpMessage => driver.FindElement(By.CssSelector(".ns-box-inner"));
        private IWebElement firstNotificationCheckbox => driver.FindElement(By.XPath("//*[@id=\"notification-section\"]/div[2]/div/div/div[3]/div[2]/span/span/div/div[1]/div/div/div[3]/input"));
        private IWebElement deleteNotificationButton => driver.FindElement(By.XPath("//*[@id=\"notification-section\"]/div[2]/div/div/div[3]/div[1]/div[3]"));
        public void deleteNotification()
        {
            //Navigate to Notification page
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/div[1]/div[2]/div/div", 10);
            Actions actions = new Actions(driver);
            actions.MoveToElement(notificationsHoverButton).Perform();
            //Click on See All Option (copy See All XPath)
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/div[1]/div[2]/div/div/div[2]/span/div/div[2]/div/center/a", 10);
            notificationsHoverButton.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/div[1]/div[2]/div/div/div[2]/span/div/div[2]/div/center/a")).Click();

            //Click on Notification to be deleted
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"notification-section\"]/div[2]/div/div/div[3]/div[2]/span/span/div/div[1]/div/div/div[3]/input", 10);
            firstNotificationCheckbox.Click();
            //Click on Delete button
            deleteNotificationButton.Click();
        }
        public void verifyNotificationDeleted()
        {
            Wait.WaitToBeVisible(driver, "CssSelector", ".ns-box-inner", 10);
            Assert.AreEqual("Notification updated", popUpMessage.Text, "Actual and expected delete notification message do not match");
        }
    }
}
