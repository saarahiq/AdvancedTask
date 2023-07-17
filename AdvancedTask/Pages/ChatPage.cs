using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTask.Pages
{
    public class ChatPage
    {
        readonly IWebDriver driver;
        public ChatPage(IWebDriver driver) { this.driver = driver; }
        public void GoToChatPage()
        {
            //Identify chat button and click
            IWebElement chatButton = driver.FindElement(By.XPath("//*[@id=\"message-section\"]/div[1]/div[2]/div/a[1]"));
            chatButton.Click();
        }

    }
}
