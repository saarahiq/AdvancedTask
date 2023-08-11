using AdvancedTaskSpecFlow.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTaskSpecFlow.Pages.ProfilePageTabs
{
    public class Language
    {
        readonly IWebDriver driver;
        public Language(IWebDriver driver)
        {
            this.driver = driver;
        }
        private IWebElement languageLevelDropdown => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select"));
        private ICollection<IWebElement> languageLevelOptions => driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select/option"));
        private IWebElement firstLanguageLevelDropdown => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td/div/div[2]/select"));
        private ICollection<IWebElement> firstLanguageLevelOptions => driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td/div/div[2]/select/option"));
        private IWebElement addNewButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div"));
        private IWebElement addNewLanguageTextbox => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[1]/input"));
        private IWebElement addButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[3]/input[1]"));
        private IWebElement popUpMessage => driver.FindElement(By.CssSelector(".ns-box-inner"));
        private IWebElement getLastLanguageName => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
        private IWebElement getLastLanguageLevel => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[2]"));
        private IWebElement firstEditButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td[3]/span[1]"));
        private IWebElement editLanguageName => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td/div/div[1]/input"));
        private IWebElement updateButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td/div/span/input[1]"));
        private IWebElement firstLanguageName => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td[1]"));
        private IWebElement firstLanguageLevel => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td[2]"));
        private IWebElement deleteButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td[3]/span[2]"));
        private void SelectLanguageLevel(string languageLevel)
        {
            //Select language level from language level dropdown
            languageLevelDropdown.Click();
            //categoryOption.Click();
            var found = false;
            foreach (var option in languageLevelOptions)
            {
                if (option.Text == languageLevel)
                {
                    found = true;
                    option.Click();
                }
            }
            if (!found) { return; }
        }
        

        public void AddNewLanguage(string languageLevel,string languageName)
        {
            //Add new language skill
            //Identify add new button and click
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div", 10);
            addNewButton.Click();
            //Identify ad language textbox and input
            addNewLanguageTextbox.SendKeys(languageName);
            //Identify language level dropdown and select
            SelectLanguageLevel(languageLevel);
            //Identify add button and click
            addButton.Click();
        }
        private void EditLanguageLevel(string languagelevel)
        {
            //Edit language level from language level dropdown
            firstLanguageLevelDropdown.Click();
            //categoryOption.Click();
            var found = false;
            foreach (var editOption in firstLanguageLevelOptions)
            {
                if (editOption.Text == languagelevel)
                {
                    found = true;
                    editOption.Click();
                }
            }
            if (!found) { return; }
        }
       

        public string GetPopUpmessage()
        {
            Wait.WaitToBeVisible(driver, "CssSelector", ".ns-box-inner", 15);
            return popUpMessage.Text;
        }

        public string[] GetLastLanguage()
        {
            return new[] { getLastLanguageName.Text, getLastLanguageLevel.Text };
        }
        public void EditFirstLanguage(string languageLevel,string languageName)
        {
            //Identify edit button and click
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td[3]/span[1]", 10);
            firstEditButton.Click();
            //Edit language name
            editLanguageName.Click();
            editLanguageName.Clear();
            editLanguageName.SendKeys(languageName);
            //Edit language level
            EditLanguageLevel(languageLevel);
            //Identify update buttonand click
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td/div/span/input[1]", 10);
            updateButton.Click();
        }
        public string[] GetFirstLanguage()
        {
            return new[] { firstLanguageName.Text, firstLanguageLevel.Text };
        }
        public void DeleteFirstlanguage()
        {
            //Identify delete button and click
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td[3]/span[2]", 10);
            deleteButton.Click();
        }
        
    }
}

