using AdvancedTask.JSON_Objects;
using AdvancedTask.Pages;
using Newtonsoft.Json;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using RazorEngine.Compilation.ImpromptuInterface.Dynamic;
using AventStack.ExtentReports;
using AdvancedTask.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvancedTask.Pages.ProfilePage;
using Gherkin.CucumberMessages.Types;
using AdvancedTask.PageObjectComponent;

namespace AdvancedTask.Utilities
{
    public class CommonDriver
    {
        public IWebDriver driver;
        public UserObject testUser;
        public MarsLoginPage marsLoginPage;
        public Language languagePage;
        public Description descriptionPage;
        public ManageListingsPage manageListingsPage;
        public ChatPage chatPage;
        public SearchSkillPage searchSkillPage;
        public NotificationsPage notificationsPage;
        public MenuNavigation menuNavigation;
        private bool login;
        public CommonDriver() : this(true) { }
        public CommonDriver(bool login) { this.login = login; }
        public ExtentReports extent = TestReport.GetInstance();
        public ExtentTest? test = null;

        //Page object initialization
        [SetUp]
        public void Setup()
        {
            this.driver = new ChromeDriver();
            this.marsLoginPage = new MarsLoginPage(driver);
            this.descriptionPage = new Description(driver);
            this.manageListingsPage = new ManageListingsPage(driver);
            this.chatPage = new ChatPage(driver);
            this.searchSkillPage = new SearchSkillPage(driver);
            this.menuNavigation = new MenuNavigation(driver);
            //this.notificationsPage = new NotificationsPage(driver);
            this.testUser = ReadTestUser("JSONData\\testUser.json");
           
            //Open chrome browser
            driver.Manage().Window.Maximize();
            //Launch Mars portal
            driver.Navigate().GoToUrl("http://localhost:5000");
            if (login)
            {
                marsLoginPage.RegisterAndLogin(this.testUser);
            }
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
        }

        public static UserObject ReadTestUser(string path)
        {
            var json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<UserObject>(json);
        }
        public static LanguageObject ReadTestLanguage(string path)
        {
            var json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<LanguageObject>(json);
        }

        public static DescriptionObject ReadTestDescription(string path)
        {
            var json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<DescriptionObject>(json);
        }
        public static SearchskillObject ReadTestSearchskill(string path)
        {
            var json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<SearchskillObject>(json);
        }

        public static ChatObject ReadTestChat(string path)
        {
            var json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<ChatObject>(json);
        }

        [TearDown]
        public void AfterTest()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stacktrace = TestContext.CurrentContext.Result.StackTrace;
            Status logstatus;
            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = Status.Fail;
                    CaptureAndLog(Status.Fail, "Fail, screenshots below");
                    break;
                case TestStatus.Inconclusive:
                    logstatus = Status.Warning;
                    break;
                case TestStatus.Skipped:
                    logstatus = Status.Skip;
                    break;
                default:
                    logstatus = Status.Pass;
                    CaptureAndLog(Status.Pass, "Success, screenshots below");
                    break;
            }
            test.Log(logstatus, "Test ended with " + logstatus + stacktrace);
            extent.Flush();
            driver.Close();

        }
        public void CaptureAndLog(Status status, string msg)
        {
            DateTime time = DateTime.Now;
            String fileName = "Screenshot_" + time.ToString("h_mm_ss") + ".png";
            String screenShotPath = Capture(fileName);
            test.AddScreenCaptureFromPath(screenShotPath);
            test.Log(status, msg);
        }

        public string Capture(String screenShotName)
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            Screenshot screenshot = ts.GetScreenshot();
            var localPath = Path.Combine(TestReport.GetScreenShotPath(), screenShotName);
            screenshot.SaveAsFile(localPath, ScreenshotImageFormat.Png);
            string relPath = Path.GetRelativePath(TestReport.GetReportPath(), localPath);
            return relPath;
        }
    }
}
