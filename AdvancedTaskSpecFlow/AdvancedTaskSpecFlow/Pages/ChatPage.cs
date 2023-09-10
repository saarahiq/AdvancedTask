using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTaskSpecFlow.Pages
{
    public class ChatPage
    {
        readonly IWebDriver driver;
        public ChatPage(IWebDriver driver) { this.driver = driver; }

        private IWebElement chatButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/div[1]/div[2]/div/a[1]"));
        private IWebElement searchTextBox => driver.FindElement(By.XPath("//*[@id=\"chatRoomContainer\"]/div/div[1]/div/div[1]/input"));
        private IWebElement searchedUser => driver.FindElement(By.XPath("//*[@id=\"chatList\"]/div/div[2]/div[1]"));
        private IWebElement chatBox => driver.FindElement(By.XPath("//*[@id=\"chatTextBox\"]"));
        private IWebElement sendButton => driver.FindElement(By.XPath("//*[@id=\"btnSend\"]"));
        private IWebElement matchUser => driver.FindElement(By.XPath("//*[@id=\"chatList\"]/div/div[2]/div[1]"));

        public void Chatwithfirstuser(string message)
        {
            chatBox.SendKeys(message);
            sendButton.Click();
        }

        public void ChatwithSearchedUser(string username)
        {

            searchTextBox.Click();
            Thread.Sleep(2000);
            searchTextBox.SendKeys(username);
            Thread.Sleep(2000);
            searchedUser.Click();
            chatBox.SendKeys("Hi there");
            sendButton.Click();

        }

        public void SearchUserLowerCase(string username)
        {

            searchTextBox.Click();
            Thread.Sleep(2000);
           searchTextBox.SendKeys(username);
        }
        public string UserMatch()
        {
            return matchUser.Text;
        }
        public string EnteredUser()
        {
            return searchTextBox.Text;
        }


    }
}
