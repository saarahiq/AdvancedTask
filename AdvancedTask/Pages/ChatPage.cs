using AdvancedTask.JSON_Objects;
using AdvancedTask.Pages.ProfilePage;
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
    public class ChatPage
    {
        readonly IWebDriver driver;
        public ChatPage(IWebDriver driver) { this.driver = driver; }

        private IWebElement chatButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/div[1]/div[2]/div/a[1]"));
        private IWebElement searchTextBox => driver.FindElement(By.XPath("//*[@id=\"chatRoomContainer\"]/div/div[1]/div/div[1]/input"));
        private IWebElement searchedUser => driver.FindElement(By.XPath("//*[@id=\"chatList\"]/div/div[2]"));
        private IWebElement chatBox => driver.FindElement(By.XPath("//*[@id=\"chatTextBox\"]"));
        private IWebElement sendButton => driver.FindElement(By.XPath("//*[@id=\"btnSend\"]"));
        private IWebElement matchUser => driver.FindElement(By.XPath("//*[@id=\"chatList\"]/div/div[2]/div[1]"));
        
        public void Chatwithfirstuser(ChatObject chat)
        {
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/div[1]/div[2]/div/a[1]", 10);
            chatButton.Click();
            chatBox.SendKeys(chat.ChatTextBox);
            sendButton.Click();
        }

        public void ChatwithSearchedUser(ChatObject chat)
        {
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/div[1]/div[2]/div/a[1]", 10);
            chatButton.Click();
            searchTextBox.Click();
            Thread.Sleep(2000);
            searchTextBox.SendKeys(chat.SearchUser);
            searchedUser.Click();
            chatBox.SendKeys(chat.ChatTextBox);
            sendButton.Click();

        }

        public void SearchUserLowerCase(ChatObject chat)
        {
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/div[1]/div[2]/div/a[1]", 10);
            chatButton.Click();
            searchTextBox.Click();
            Thread.Sleep(2000);
            searchTextBox.SendKeys(chat.SearchUser);
        }
        public string UserMatch()
        {
            return matchUser.Text;
        }
        public  string EnteredUser()
        {
            return searchTextBox.Text;
        }
    }

}
