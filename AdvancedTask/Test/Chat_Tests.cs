using AdvancedTask.JSON_Objects;
using AdvancedTask.PageObjectComponent;
using AdvancedTask.Pages;
using AdvancedTask.Utilities;
using MongoDB.Bson;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTask.Test
{
    [TestFixture]
    [Parallelizable]
    public class Chat_Tests : CommonDriver
    {
        public static ICollection<ChatObject> ReadChatTests(string[] jsonFiles)
        {
            var chats = new List<ChatObject>();
            foreach (var file in jsonFiles)
            {
                ChatObject chat = ReadTestChat("JSONData\\Chat\\" + file);
                chats.Add(chat);
            }
            return chats;
        }
        
        
        public static ICollection<ChatObject> ReadPositiveChatTests()
        {
            return ReadChatTests(new string[]
            {
                "PositiveChat.json"
            });
        }

        public static ICollection<ChatObject> ReadNegativeChatTests()
        {
            return ReadChatTests(new string[]
            {
                "NegativeChat.json"
            });
        }

        [SetUp]
        public void NavigationtoChatPage()
        {
            MenuNavigation menuNavigation = new MenuNavigation(driver);
            menuNavigation.GoToChatPage();
        }

        [Test, Order(1), Description("Check if user is able to chat with first user"), TestCaseSource(nameof(ReadPositiveChatTests))]
        public void TestChatFirstUser(ChatObject chat)
        {
          chatPage.Chatwithfirstuser(chat);
                    
        }

        [Test, Order(2), Description("Check if user is able to chat with searched user"), TestCaseSource(nameof(ReadPositiveChatTests))]
        public void TestChatSuccessfully(ChatObject chat)
        {
            chatPage.ChatwithSearchedUser(chat);
            string MatchedUser = chatPage.UserMatch();
            Assert.That(MatchedUser == "Nik", "User does not match");
        }
        [Test,Order(3),Description("Check if user is able to chat by typing name of user in lowercase/uppercase in search bar"),TestCaseSource(nameof(ReadNegativeChatTests))]
        public void TestSearchUserFailed(ChatObject chat)
        {
            chatPage.SearchUserLowerCase(chat);
            
        }
    }
    
}