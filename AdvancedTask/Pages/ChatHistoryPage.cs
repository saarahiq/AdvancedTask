using AdvancedTask.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTask.Pages
{
    public class ChatHistoryPage
    {
        readonly IWebDriver driver;
        public ChatHistoryPage(IWebDriver driver)
        {
            this.driver = driver;

        }
        private IWebElement searchBar => driver.FindElement(By.XPath("//*[@id=\"chatRoomContainer\"]/div/div[1]/div/div[1]/input"));
        private IWebElement listOfChats => driver.FindElement(By.XPath("//*[@id=\"chatList\"]"));
        public void searchChatHistory(string name)
        {
            Thread.Sleep(2000);
            searchBar.SendKeys(name);
        }

        public void verifyNumberOfChats(string expectedNumber)
        {
            ReadOnlyCollection<IWebElement> children = listOfChats.FindElements(By.XPath("./*"));
            Assert.AreEqual(expectedNumber, children.Count().ToString(), "Actual and expected number of chats didn't match");

        }
    }
    
}
