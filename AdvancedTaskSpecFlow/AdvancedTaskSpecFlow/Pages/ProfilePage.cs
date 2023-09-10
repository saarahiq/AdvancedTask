using AdvancedTaskSpecFlow.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTaskSpecFlow.Pages
{
    public class ProfilePage
    {
        readonly IWebDriver driver;
        public ProfilePage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void goToSkillsTab()
        {
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]", 15);
            IWebElement skillsTab = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]"));
            skillsTab.Click();
        }
        public void goToEducationTab()
        {
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]", 15);
            IWebElement educationTab = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[3]"));
            educationTab.Click();

        }
        public void goToCertificationTab()
        {
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[4]", 15);
            IWebElement certificationTab = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[4]"));
            certificationTab.Click();
        }

        public void goToDescriptionTab()
        {
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[2]/div/span/i", 15);
            IWebElement descriptionTab = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[2]/div/span/i"));
            descriptionTab.Click();
        }

        public void gotoManageListingTab()
        {
            Wait.WaitToBeClickable(driver,"XPath", "//*[@id=\"account-profile-section\"]/div/section[1]/div/a[3]",15);
            IWebElement manageListingTab = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[1]/div/a[3]"));
            manageListingTab.Click();

        }

        public void gotoSearchSkillPage()
        {
            Wait.WaitToBeClickable(driver,"XPath", "//*[@id=\"account-profile-section\"]/div/div[1]/div[1]/i", 15);
            IWebElement searchskill = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/div[1]/div[1]/i"));
            searchskill.Click();
        }

        public void gotoChatPage()
        {
            Wait.WaitToBeClickable(driver,"XPath", "//*[@id=\"account-profile-section\"]/div/div[1]/div[2]/div/a[1]",15);
            IWebElement chatButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/div[1]/div[2]/div/a[1]"));
            chatButton.Click();
        }
    }
}
