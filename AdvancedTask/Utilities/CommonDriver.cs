using AdvancedTask.JSON_Objects;
using AdvancedTask.Pages;
using Newtonsoft.Json;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTask.Utilities
{
    public class CommonDriver
    {
        public IWebDriver driver;
        public UserObject testUser;
        public MarsLoginPage marsLoginPage;

        //Page object initialization
        [SetUp]
        public void Setup()
        {
            this.driver = new ChromeDriver();
            this.marsLoginPage = new MarsLoginPage(driver);
            this.testUser = ReadTestUser("JSONData\\User\\testUser.json");
            //Open chrome browser
            driver.Manage().Window.Maximize();
            //Launch Mars portal
            driver.Navigate().GoToUrl("http://localhost:5000");
            marsLoginPage.RegisterAndLogin(this.testUser);
         
        }
       
        public static UserObject ReadTestUser(string path)
        {
            var json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<UserObject>(json);
        }
    }
}
