using AdvancedTask.Models;
using AdvancedTask.Pages;
using Newtonsoft.Json;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTask.Utilities
{
    public class CommonDriver
    {
        public IWebDriver driver;
        public User testUser;
        public MarsLoginPage marsLoginPage;

        //Page object initialization
        [SetUp]
        public void Setup()
        {
            this.driver = new ChromeDriver();
            this.marsLoginPage = new MarsLoginPage(driver);
            this.testUser = ReadTestUser("Data\\TestUser.json");
            //Open chrome browser
            driver.Manage().Window.Maximize();
            //Launch Mars portal
            driver.Navigate().GoToUrl("http://localhost:5000");
            marsLoginPage.Login(this.testUser);
         
        }

        [TearDown]
        public void TearDown()
        {
            driver.Close();
            driver.Quit();

        }

        public static User ReadTestUser(string path)
        {
            var json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<User>(json);
        }
        public static CertificationModel readCertification(string jsonCertFile)
        {
            var json = File.ReadAllText(String.Concat("C:\\Users\\saara\\source\\repos\\AdvancedTask\\AdvancedTask\\JSONData\\Certifications\\", jsonCertFile));
            return JsonConvert.DeserializeObject<CertificationModel>(json);
        }
        public static SkillModel readSkills(string jsonSkillFile)
        {
            var json = File.ReadAllText(String.Concat("C:\\Users\\saara\\source\\repos\\AdvancedTask\\AdvancedTask\\JSONData\\Skills\\", jsonSkillFile));
            return JsonConvert.DeserializeObject<SkillModel>(json);
        }
    }
}
