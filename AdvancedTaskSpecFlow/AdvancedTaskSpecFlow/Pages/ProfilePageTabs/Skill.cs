using AventStack.ExtentReports;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvancedTaskSpecFlow.Utilities;

namespace AdvancedTaskSpecFlow.Pages.ProfilePageTabs
{
    public class Skills
    {
        readonly IWebDriver driver;
        private ExtentTest test;
        public Skills(IWebDriver driver, ExtentTest test)
        {
            this.driver = driver;
            this.test = test;
        }

        private IWebElement addNewSkillsButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div"));
        private IWebElement enterSkill => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[1]/input"));
        private IWebElement enterSkillLevel => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[2]/select"));
        private IWebElement addButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/span/input[1]"));
        private IWebElement editButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[3]/span[1]/i"));
        private IWebElement editSkill => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td/div/div[1]/input"));
        private IWebElement editSkillLevel => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td/div/div[2]/select"));
        private IWebElement updateButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td/div/span/input[1]"));

        public void addNewSkill(string skill, string skillLevel)
        {
            //Click on Add New Button
            addNewSkillsButton.Click();
            //Enter Skill
            enterSkill.SendKeys(Keys.Control + "A");
            enterSkill.SendKeys(Keys.Backspace);
            enterSkill.SendKeys(skill);
            enterSkillLevel.Click();
            SelectElement skillLevelDropdown = new SelectElement(enterSkillLevel);
            skillLevelDropdown.SelectByText(skillLevel);
            addButton.Click();
            Thread.Sleep(2000);
            // logging to extent reports
            test.Log(Status.Pass, "Successfully created a new Skill record");
        }
        public void editSkills(string skill, string skillLevel)
        {
            //Click on edit
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[3]/span[1]/i", 15);
            editButton.Click();
            //Edit Skill

            editSkill.SendKeys(Keys.Control + "A");
            editSkill.SendKeys(Keys.Backspace);
            editSkill.SendKeys(skill);
            editSkillLevel.Click();
            SelectElement editSkillLevelDropdown = new SelectElement(editSkillLevel);
            editSkillLevelDropdown.SelectByText(skillLevel);
            updateButton.Click();
            Thread.Sleep(2000);
        }
        public void deleteSkill(string skill, string skillLevel)
        {
            //Delete first Certification 
            var findDeleteRow = driver.FindElement(By.XPath($"//tbody[tr[td[text()='{skill}'] and td[text()='{skillLevel}']]]//i[@class='remove icon']"));
            findDeleteRow.Click();
        }

        public string[] getFirstSkill()
        {
            IWebElement getFirstSkillName = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[1]"));
            IWebElement getFirstSkillLevel = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[2]"));

            return new[] { getFirstSkillName.Text, getFirstSkillLevel.Text };
        }
        public string[] getLatestSkill()
        {
            IWebElement getLatestSkillName = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
            IWebElement getLatestSkillLevel = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[2]"));

            return new[] { getLatestSkillName.Text, getLatestSkillLevel.Text };
        }
    }
}
