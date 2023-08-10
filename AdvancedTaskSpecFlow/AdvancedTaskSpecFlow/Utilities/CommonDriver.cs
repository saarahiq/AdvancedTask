using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using AdvancedTaskSpecFlow.Pages;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Newtonsoft.Json;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using RazorEngine.Compilation.ImpromptuInterface.Dynamic;
using AventStack.ExtentReports;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvancedTaskSpecFlow.Pages.ProfilePageTabs;
using AdvancedTaskSpecFlow.Pages.ManageRequestPageTabs;
using System.Security.Cryptography.X509Certificates;
using TechTalk.SpecFlow;

namespace AdvancedTaskSpecFlow.Utilities
{
    public class CommonDriver
    {
        public IWebDriver driver;
        public Language language;
        public AddNewShareSkillPage addNewShareSkillPage;
        public SentRequests sentRequests;
        public NotificationsPage notificationsPage;
        public SignInPage signInPage;
        public RegistrationPage registrationPage;
        private bool login;
        public CommonDriver() : this(true) { }
        public CommonDriver(bool login) { this.login = login; }
       

        public static string? ScreenshotPath { get; private set; }
        public object TestReport { get; private set; }

        //Page object initialization

        [BeforeScenario]
        public void Setup()
        {
            this.driver = new ChromeDriver();
            this.signInPage = new SignInPage(driver);
            this.language = new Language(driver);
            this.addNewShareSkillPage = new AddNewShareSkillPage(driver);
            this.sentRequests = new SentRequests(driver);
            this.notificationsPage = new NotificationsPage(driver);
            this.registrationPage = new RegistrationPage(driver);

            //Open chrome browser
            driver.Manage().Window.Maximize();

            //Launch Mars portal
            driver.Navigate().GoToUrl("http://localhost:5000");
            if (login)
            {
                signInPage.SignIn("mars.advanced@example.com","123456");
            }
        }


        [AfterScenario]
        public void CleanUp()
        {
            driver.Dispose();
        }

    }
}

