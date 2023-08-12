using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using AdvancedTaskSpecFlow.Pages;
using AdvancedTaskSpecFlow.Pages.ProfilePageTabs;
using AdvancedTaskSpecFlow.Pages.ManageRequestPageTabs;
using AdvancedTaskSpecFlow.PageObjectComponents;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;

namespace AdvancedTaskSpecFlow.Utilities
{
    public class CommonDriver:IDisposable
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

        public static string ReportPath = Resources.ExtentReportPath;

        public static ExtentTest test;
        public static ExtentReports extent;

        public CommonDriver() 
        {
            // Initialise Test
            var html = new ExtentHtmlReporter(ReportPath);
            extent = new ExtentReports();
            extent.AttachReporter(html);
            test = extent.CreateTest("AdvancedTaskSpecFlow");

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
        }

        public void Dispose()
        {
            driver.Dispose();
            extent.Flush();
        }
    }
}

