using AdvancedTaskSpecFlow.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTaskSpecFlow.Pages.ProfilePageTabs
{
    public class Description
    {
        readonly IWebDriver driver;
        public Description(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement pencil => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/div/div/div/h3/span/i"));
        public IWebElement descTextBox => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/div/div/form/div/div/div[2]/div[1]/textarea"));
        private IWebElement saveButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/div/div/form/div/div/div[2]/button"));
        private IWebElement availability => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[2]/div/span/i"));
        private IWebElement availDropdown => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[2]/div/span/select/option[2]"));
        private ICollection<IWebElement> availOptions => driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[2]/div/span/select/option"));
        private IWebElement hours => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[3]/div/span/i"));
        private IWebElement hoursDropDown => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[3]/div/span/select"));
        private ICollection<IWebElement> hoursOptions => driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[3]/div/span/select/option"));
        private IWebElement earnTarget => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[4]/div/span/i"));
        private IWebElement earnTargetDropDown => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[4]/div/span/select/option[3]"));
        private ICollection<IWebElement> earnTargetOptions => driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[4]/div/span/select/option"));

        private IWebElement editedAvail => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[2]/div/span/select/option[3]"));
        private IWebElement editedEarnTarget => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[4]/div/span/select/option[4]"));
        private IWebElement popUpMessage => driver.FindElement(By.CssSelector(".ns-box-inner"));
        private void SelectAvailabilityLevel(string Availability)
        {
            //Select availability
            availability.Click();
            availDropdown.Click();
            //categoryOption.Click();
            var found = false;
            foreach (var option in availOptions)
            {
                if (option.Text == Availability)
                {
                    found = true;
                    option.Click();
                }
            }
            if (!found) { return; }
        }

        private void SelectHoursLevel(string Hours)
        {
            //Select availability
            hours.Click();
            hoursDropDown.Click();
            //categoryOption.Click();
            var found = false;
            foreach (var option1 in hoursOptions)
            {
                if (option1.Text == Hours)
                {
                    found = true;
                    option1.Click();
                }
            }
            if (!found) { return; }
        }

        private void SelectEarnTargetLevel(string EarnTarget)
        {
            //Select availability
            earnTarget.Click();
            earnTargetDropDown.Click();
            //categoryOption.Click();
            var found = false;
            foreach (var option2 in earnTargetOptions)
            {
                if (option2.Text == EarnTarget)
                {
                    found = true;
                    option2.Click();
                }
            }
            if (!found) { return; }
        }
        public void AddDescription(string Availabilty,string Hours,string EarnTarget,string Description)
        {
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[2]/div/span/i", 10);
            //Identify availability level dropdown and select
            availability.Click();
            SelectAvailabilityLevel(Availabilty);
            hours.Click();
            hoursDropDown.Click();
            SelectHoursLevel(Hours);
            earnTarget.Click();
            earnTargetDropDown.Click();
            SelectEarnTargetLevel(EarnTarget);
            pencil.Click();
            Actions actions = new Actions(driver);
            actions.Click(descTextBox).KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).SendKeys(Keys.Backspace).Build().Perform();
            descTextBox.Click();
            //Identify description textbox & add description
            descTextBox.SendKeys(Description);
            saveButton.Click();
        }

        public void EditDescription(string Availabilty, string Hours, string EarnTarget, string Description)
        {
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[2]/div/span/i", 10);
            availability.Click();
            EditAvailabilityLevel(Availabilty);
            EditHoursLevel(Hours);
            EditEarnTargetLevel(EarnTarget);
            pencil.Click();
            descTextBox.Click();
            descTextBox.Clear();
            descTextBox.SendKeys(Description);
            saveButton.Click();
        }

       

        public void SpecialCharAddDescription(string Availabilty, string Hours, string EarnTarget, string Description)
        {
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[2]/div/span/i", 10);
            availability.Click();
            SelectAvailabilityLevel(Availabilty);
            SelectHoursLevel(Hours);
            SelectEarnTargetLevel(EarnTarget);
            pencil.Click();
            descTextBox.Click();
            //selectAll(driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/div/div/form/div/div/div[2]/div[1]/textarea")));
            Actions actions = new Actions(driver);
            actions.Click(descTextBox).KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).SendKeys(Keys.Backspace).Build().Perform();
            //descTextBox.Clear();
            //Identify description textbox & add description
            descTextBox.SendKeys(Description);
            saveButton.Click();
        }

        public void FailtoAddDescription(string Availabilty, string Hours, string EarnTarget, string Description)
        {

            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[2]/div/span/i", 10);
            availability.Click();
            SelectAvailabilityLevel(Availabilty);
            SelectHoursLevel(Hours);
            SelectEarnTargetLevel(EarnTarget);
            pencil.Click();
            descTextBox.Click();
            //selectAll(driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/div/div/form/div/div/div[2]/div[1]/textarea")));
            Actions actions = new Actions(driver);
            actions.Click(descTextBox).KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).SendKeys(Keys.Backspace).Build().Perform();

            //descTextBox.Clear();
            //Identify description textbox & add description
            descTextBox.SendKeys(Description);
            saveButton.Click();


        }
        private void EditAvailabilityLevel(string Availability)
        {
            //Select availability
            availability.Click();
            editedAvail.Click();
            //categoryOption.Click();
            var found = false;
            foreach (var option in availOptions)
            {
                if (option.Text == Availability)
                {
                    found = true;
                    option.Click();
                }
            }
            if (!found) { return; }
        }

        private void EditHoursLevel(string Hours)
        {
            //Select availability
            hours.Click();
            hoursDropDown.Click();
            //categoryOption.Click();
            var found = false;
            foreach (var option1 in hoursOptions)
            {
                if (option1.Text == Hours)
                {
                    found = true;
                    option1.Click();
                }
            }
            if (!found) { return; }
        }
        private void EditEarnTargetLevel(string EarnTarget)
        {
            //Select availability
            earnTarget.Click();
            editedEarnTarget.Click();
            //categoryOption.Click();
            var found = false;
            foreach (var option2 in earnTargetOptions)
            {
                if (option2.Text == EarnTarget)
                {
                    found = true;
                    option2.Click();
                }
            }
            if (!found) { return; }
        }
        public string GetPopUpmessage()
        {
            Wait.WaitToBeVisible(driver, "CssSelector", ".ns-box-inner", 15);
            return popUpMessage.Text;
        }

        public string[] GetDescription()
        {
            return new[] { descTextBox.Text };
        }
    }
}
