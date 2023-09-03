using AdvancedTaskSpecFlow.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTaskSpecFlow.Pages.ProfilePageTabs
{
    public class SideBars
    {
        readonly IWebDriver driver;
        public SideBars(IWebDriver driver)
        {
            this.driver = driver;
        }
        private IWebElement availabilityDropdown => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[2]/div/span/select"));
        private ICollection<IWebElement> availabilityOptions => driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[2]/div/span/select/option[@value]"));
        private IWebElement hoursDropdown => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[3]/div/span/select"));
        private ICollection<IWebElement> hoursOptions => driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[3]/div/span/select/option[@value]"));
        private IWebElement earnTargetDropdown => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[4]/div/span/select"));
        private ICollection<IWebElement> earnTargetOptions => driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[4]/div/span/select/option[@value]"));
        private IWebElement availabilityEditIcon => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[2]/div/span/i"));
        private IWebElement hoursEditIcon => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[3]/div/span/i"));
        private IWebElement earnTargetEditIcon => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[4]/div/span/i"));
        private IWebElement sideBarMessage => driver.FindElement(By.CssSelector(".ns-type-success"));


        private void SelectAvailability(string availability)
        {
            //Select Availability from Availability dropdown
            availabilityDropdown.Click();
            foreach (var option in availabilityOptions)
            {
                if (option.Text == availability)
                {
                    option.Click();
                    break;
                }
            }
        }

        public void EditAvailability(string Availability)
        {

            //Identify availability esit button and click
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[2]/div/span/i", 10);
            availabilityEditIcon.Click();
            //Identify language level dropdown and select
            SelectAvailability(Availability);
        }

        private void SelectHours(string hours)
        {
            //Select Availability from Availability dropdown
            hoursDropdown.Click();
            foreach (var option in hoursOptions)
            {
                if (option.Text == hours)
                {
                    option.Click();
                    break;
                }
            }
            
        }
        public void EditHours(string Hours)
        {
            //Identify availability esit button and click
            hoursEditIcon.Click();
            //Identify language level dropdown and select
            SelectHours(Hours);
        }

        private void SelectEarnTarget(string earntarget)
        {
            //Select language level from language level dropdown
            earnTargetDropdown.Click();
            foreach (var option in earnTargetOptions)
            {
                if (option.Text == earntarget)
                {
                    option.Click();
                    break;
                }
            }
        }
        public void EditEarnTarget(string earnTarget)
        {
            //Identify availability esit button and click
            earnTargetEditIcon.Click();
            //Identify language level dropdown and select
            SelectEarnTarget(earnTarget);
        }

        public string getSideBarMessage()
        {
            Wait.WaitToBeVisible(driver, "CssSelector", ".ns-type-success", 15);
            return sideBarMessage.Text;
        }
    }
}
