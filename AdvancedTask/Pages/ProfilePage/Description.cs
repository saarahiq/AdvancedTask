using AdvancedTask.JSON_Objects;
using AdvancedTask.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using RazorEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTask.Pages.ProfilePage
{
    public class Description
    {
        readonly IWebDriver driver;
        public Description(IWebDriver driver) { this.driver = driver; }

        private IWebElement pencil => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/div/div/div/h3/span/i"));
      
        public IWebElement descTextBox => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/div/div/form/div/div/div[2]/div[1]/textarea"));
        private IWebElement saveButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/div/div/form/div/div/div[2]/button"));
        private IWebElement availability => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[2]/div/span/i"));
        private IWebElement availDropdown => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[2]/div/span/select/option[2]"));
        private ICollection<IWebElement> availOptions => driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[2]/div/span/select/option"));
        private IWebElement hours => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[3]/div/span/i"));
        private IWebElement hoursDropDown => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[3]/div/span/select/option[4]"));
        private ICollection<IWebElement> hoursOptions => driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[3]/div/span/select/option"));
        private IWebElement earnTarget => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[4]/div/span/i"));
        private IWebElement earnTargetDropDown => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[4]/div/span/select/option[3]"));
        private ICollection<IWebElement> earnTargetOptions => driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[4]/div/span/select/option"));

        private IWebElement editedAvail => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[2]/div/span/select/option[3]"));
        private IWebElement editedEarnTarget => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[4]/div/span/select/option[4]"));
        private IWebElement popUpMessage => driver.FindElement(By.CssSelector(".ns-box-inner"));
        private void SelectAvailabilityLevel(string availlevel)
        {
            //Select availability
            availability.Click();
            availDropdown.Click();
            //categoryOption.Click();
            var found = false;
            foreach (var option in availOptions)
            {
                if (option.Text == availlevel)
                {
                    found = true;
                    option.Click();
                }
            }
            if (!found) { return; }
        }

        private void SelectHoursLevel(string hourslevel)
        {
            //Select availability
            hours.Click();
            hoursDropDown.Click();
            //categoryOption.Click();
            var found = false;
            foreach (var option1 in hoursOptions)
            {
                if (option1.Text == hourslevel)
                {
                    found = true;
                    option1.Click();
                }
            }
            if (!found) { return; }
        }

        private void SelectEarnTargetLevel(string earnTargetlevel)
        {
            //Select availability
            earnTarget.Click();
            earnTargetDropDown.Click();
            //categoryOption.Click();
            var found = false;
            foreach (var option2 in earnTargetOptions)
            {
                if (option2.Text == earnTargetlevel)
                {
                    found = true;
                    option2.Click();
                }
            }
            if (!found) { return; }
        }
        public void AddDescription(DescriptionObject description)
        {
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[2]/div/span/i", 10);
            //Identify availability level dropdown and select
            SelectAvailabilityLevel(description.AvailabilityDropdown);
            //Identify hours level dropdown and select
            SelectHoursLevel(description.HoursDropdown);
            //Identify earntarget level dropdown and select
            SelectEarnTargetLevel(description.EarntargetDropdown);
            //Identify save button and click
            pencil.Click();
            Actions actions = new Actions(driver);
            actions.Click(descTextBox).KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).SendKeys(Keys.Backspace).Build().Perform();
            descTextBox.Click();
            //Identify description textbox & add description
            descTextBox.SendKeys(description.DescriptionTextBox);
            saveButton.Click();
            
            
        }

        private void EditAvailabilityLevel(string availlevel)
        {
            //Select availability
            availability.Click();
            editedAvail.Click();
            //categoryOption.Click();
            var found = false;
            foreach (var option in availOptions)
            {
                if (option.Text == availlevel)
                {
                    found = true;
                    option.Click();
                }
            }
            if (!found) { return; }
        }

        private void EditHoursLevel(string hourslevel)
        {
            //Select availability
            hours.Click();
            hoursDropDown.Click();
            //categoryOption.Click();
            var found = false;
            foreach (var option1 in hoursOptions)
            {
                if (option1.Text == hourslevel)
                {
                    found = true;
                    option1.Click();
                }
            }
            if (!found) { return; }
        }
        private void EditEarnTargetLevel(string earnTargetlevel)
        {
            //Select availability
            earnTarget.Click();
            editedEarnTarget.Click();
            //categoryOption.Click();
            var found = false;
            foreach (var option2 in earnTargetOptions)
            {
                if (option2.Text == earnTargetlevel)
                {
                    found = true;
                    option2.Click();
                }
            }
            if (!found) { return; }
        }



        public void EditDescription(DescriptionObject description)
        {

            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[2]/div/span/i]", 10);
            //Identify availability level dropdown and select
            EditAvailabilityLevel(description.AvailabilityDropdown);
            //Identify hours level dropdown and select
            EditHoursLevel(description.HoursDropdown);
            //Identify earntarget level dropdown and select
            EditEarnTargetLevel(description.EarntargetDropdown);
            //Identify save button and click
            pencil.Click();
            descTextBox.Click();
            descTextBox.Clear();
            descTextBox.SendKeys(description.DescriptionTextBox);
            saveButton.Click();
            


        }

        public void FailtoAddDescription(DescriptionObject description)
        {
            //Add new language skill
            //Identify add new button and click
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[2]/div/span/i", 10);
            //Identify availability level dropdown and select
            SelectAvailabilityLevel(description.AvailabilityDropdown);
            //Identify hours level dropdown and select
            SelectHoursLevel(description.HoursDropdown);
            //Identify earntarget level dropdown and select
            SelectEarnTargetLevel(description.EarntargetDropdown);
            //Identify save button and click
            pencil.Click();
            descTextBox.Click();
            //selectAll(driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/div/div/form/div/div/div[2]/div[1]/textarea")));
            Actions actions = new Actions(driver);
            actions.Click(descTextBox).KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).SendKeys(Keys.Backspace).Build().Perform();
            
            //descTextBox.Clear();
            //Identify description textbox & add description
            descTextBox.SendKeys(description.DescriptionTextBox);
            saveButton.Click();
            

        }

        public void SpecialCharAddDescription(DescriptionObject description)
        {
            //Add new language skill
            //Identify add new button and click
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[2]/div/span/i", 10);
            SelectAvailabilityLevel(description.AvailabilityDropdown);
            //Identify hours level dropdown and select
            SelectHoursLevel(description.HoursDropdown);
            //Identify earntarget level dropdown and select
            SelectEarnTargetLevel(description.EarntargetDropdown);
            //Identify save button and click
            pencil.Click();
            descTextBox.Click();
            //Identify description textbox & add description
            descTextBox.SendKeys(description.DescriptionTextBox);
            saveButton.Click();
            //Identify availability level dropdown and select
            

        }

        public string GetPopUpmessage()
        {
            Wait.WaitToBeVisible(driver, "CssSelector", ".ns-box-inner", 15);
            return popUpMessage.Text;
        }

        public string[] GetDescription()
        {
            return new[] { descTextBox.Text};
        }
    }

}
