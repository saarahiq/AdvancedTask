using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using AdvancedTaskSpecFlow.Pages;
using AdvancedTaskSpecFlow.Pages.ProfilePageTabs;
using AdvancedTaskSpecFlow.Pages.ManageRequestPageTabs;


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
        public CommonDriver() 
        {
            this.driver = new ChromeDriver();
            this.signInPage = new SignInPage(driver);
            this.language = new Language(driver);
            this.addNewShareSkillPage = new AddNewShareSkillPage(driver);
            this.sentRequests = new SentRequests(driver);
            this.notificationsPage = new NotificationsPage(driver);
            this.registrationPage = new RegistrationPage(driver);
        }       
        public void Dispose()
        {
            driver.Dispose();
        }
    }
}

