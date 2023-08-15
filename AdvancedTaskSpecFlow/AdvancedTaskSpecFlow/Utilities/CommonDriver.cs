using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using AdvancedTaskSpecFlow.Pages;
using AdvancedTaskSpecFlow.Pages.ProfilePageTabs;
using AdvancedTaskSpecFlow.Pages.ManageRequestPageTabs;
using AdvancedTaskSpecFlow.PageObjectComponents;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using AdvancedTask.Pages.ProfilePageTabs;
using TechTalk.SpecFlow;
using System.Text;
using AdvancedTask.Pages;

namespace AdvancedTaskSpecFlow.Utilities
{
    [Binding]
    public class CommonDriver : IDisposable
    {
        public IWebDriver driver;
        public Language language;
        public AddNewShareSkillPage addNewShareSkillPage;
        public SentRequests sentRequests;
        public NotificationsPage notificationsPage;
        public SignInPage signInPage;
        public RegistrationPage registrationPage;
        public ProfilePage profilePage;
        public Skills skillsPage;
        public PopUpComponent popUpComponent;
        public Education educationPage;
        public Certification certificationPage;
        public NavigationMenu navigationMenu;
        public ManageRequests manageRequestsPage;
        public ChatHistoryPage chatHistoryPage;
        public EditShareSkillPage editShareSkillPage;

        public static string ScreenshotPath = Resources.ScreenshotPath;
        public static string ReportPath = Resources.ExtentReportPath;

        public static ExtentTest test;
        public static ExtentReports extent;

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            // Initialise Test
            var html = new ExtentHtmlReporter(ReportPath);
            extent = new ExtentReports();
            extent.AttachReporter(html);
            test = extent.CreateTest("AdvancedTaskSpecFlow");
        }

        public CommonDriver()
        {

            this.driver = new ChromeDriver();
            this.signInPage = new SignInPage(driver);
            this.language = new Language(driver);
            this.addNewShareSkillPage = new AddNewShareSkillPage(driver);
            this.sentRequests = new SentRequests(driver);
            this.notificationsPage = new NotificationsPage(driver);
            this.registrationPage = new RegistrationPage(driver);
            this.profilePage = new ProfilePage(driver);
            this.skillsPage = new Skills(driver, test);
            this.popUpComponent = new PopUpComponent(driver);
            this.educationPage = new Education(driver);
            this.certificationPage = new Certification(driver);
            this.navigationMenu = new NavigationMenu(driver);
            this.manageRequestsPage = new ManageRequests(driver);
            this.chatHistoryPage = new ChatHistoryPage(driver);
            this.editShareSkillPage = new EditShareSkillPage(driver);
        }

        public bool Login(string email, string password)
        {
            //Open chrome browser
            this.driver.Manage().Window.Maximize();
            //Launch Mars portal
            this.driver.Navigate().GoToUrl("http://localhost:5000");
            return signInPage.SignIn(email, password);
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            extent.Flush();
        }

        public string SaveScreenshot(string ScreenShotFileName) // Definition
        {
            var folderLocation = (ScreenshotPath);

            if (!Directory.Exists(folderLocation))
            {
                Directory.CreateDirectory(folderLocation);
            }

            var screenShot = ((ITakesScreenshot)driver).GetScreenshot();
            var fileName = new StringBuilder(folderLocation);

            fileName.Append(ScreenShotFileName);
            fileName.Append(DateTime.Now.ToString("_dd-mm-yyyy_mss"));
            //fileName.Append(DateTime.Now.ToString("dd-mm-yyyym_ss"));
            fileName.Append(".png");
            screenShot.SaveAsFile(fileName.ToString(), ScreenshotImageFormat.Png);
            return fileName.ToString();
        }

        public void Dispose()
        {
            driver.Dispose();

        }
    }
}

