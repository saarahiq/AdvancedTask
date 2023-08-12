using AdvancedTaskSpecFlow.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTaskSpecFlow.Pages
{
    public class NotificationsPage
    {
        readonly IWebDriver driver;
        public NotificationsPage(IWebDriver driver)
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
