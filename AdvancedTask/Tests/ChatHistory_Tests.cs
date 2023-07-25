using AdvancedTask.Models;
using AdvancedTask.Pages;
using AdvancedTask.Utilities;
using NUnit.Framework;
using AventStack.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTask.Test
{
    public class ChatHistory_Tests : CommonDriver
    {
        public static List<List<string>> listofChats()
        {
            var chatHistoryNames = new List<List<string>>
            {
                new List<string> { "Saarah", "1"},
                new List<string> { "Saa", "1"},
                new List<string> { "saa", "0"},
                new List<string> { "Jessica", "2"},
                new List<string> { "Mars", "1"},
                new List<string> { "MA", "0"},
                new List<string> { "Ma", "1"},
                new List<string> { "Jake", "0"},
                new List<string> { "saarah", "0"},
            };
            return chatHistoryNames;
        }
        [SetUp]
        public void notificationsTestsSetUp()
        {
            NavigationMenu navigationMenu = new NavigationMenu(driver);
            navigationMenu.goToChatPage();
        }

        [Test, Order(1), Description("Search Chat History"), TestCaseSource(nameof(listofChats))]
        public void searchChatHistoryTest(List<string> chatHistoryNames)
        {
            ChatHistoryPage chatHistoryPage = new ChatHistoryPage(driver);
            chatHistoryPage.searchChatHistory(chatHistoryNames[0]);
            chatHistoryPage.verifyNumberOfChats(chatHistoryNames[1]);

            //logging to extent reports
            test.Log(Status.Pass, "Successfully verified chat history");
        }
    }
}
