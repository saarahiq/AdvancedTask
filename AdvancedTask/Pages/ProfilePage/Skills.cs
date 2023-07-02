using AdvancedTask.Models;
using AdvancedTask.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace AdvancedTask.Pages.ProfilePage
{
    public class Skills
    {
        readonly IWebDriver driver;
        public Skills(IWebDriver driver)
        {
            this.driver = driver;
        }
        private IWebElement skillsTab => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]"));
        private IWebElement addNewSkillsButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div"));
        private IWebElement enterSkill => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[1]/input"));
        private IWebElement enterSkillLevel => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[2]/select"));
        private IWebElement addButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/span/input[1]"));
        private IWebElement editButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[3]/span[1]/i"));
        private IWebElement editSkill => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td/div/div[1]/input"));
        private IWebElement editSkillLevel => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td/div/div[2]/select"));
        private IWebElement updateButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td/div/span/input[1]"));
        private IWebElement deleteButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[3]/span[2]/i"));
        private IWebElement popUpMessage => driver.FindElement(By.CssSelector(".ns-box-inner"));
        private IWebElement getFirstSkillName => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[1]"));
        private IWebElement getFirstSkillLevel => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[2]"));
        private IWebElement getLatestSkillName => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
        private IWebElement getLatestSkillLevel => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[2]"));

        public void addNewSkill(string skill, string skillLevel)
        {
            //Click on Skills Tab
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]", 15);
            skillsTab.Click();
            //Click on Add New Button
            addNewSkillsButton.Click();
            //Enter Skill
            enterSkill.SendKeys(skill);
            enterSkillLevel.Click();
            SelectElement skillLevelDropdown = new SelectElement(enterSkillLevel);
            skillLevelDropdown.SelectByText(skillLevel);
            addButton.Click();
            Thread.Sleep(2000);
        }
        public void editSkills(string skill, string skillLevel)
        {
            //Click on Skills Tab
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]", 15);
            skillsTab.Click();
            //Click on edit
            editButton.Click();
            //Edit Skill
            editSkill.Clear();
            editSkill.SendKeys(skill);
            editSkillLevel.Click();
            SelectElement editSkillLevelDropdown = new SelectElement(editSkillLevel);
            editSkillLevelDropdown.SelectByText(skillLevel);
            updateButton.Click();
            Thread.Sleep(2000);
        }
        public void deleteSkill()
        {
            //Delete first Certification 
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]", 15);
            skillsTab.Click();
            deleteButton.Click();
        }
        public string getPopUpMessage()
        {
            Wait.WaitToBeClickable(driver, "CssSelector", ".ns-box-inner", 15);
            return popUpMessage.Text;
        }
        public string[] getFirstSkill()
        {
            return new[] { getFirstSkillName.Text, getFirstSkillLevel.Text};
        }
        public string[] getLatestSkill()
        {
            return new[] { getLatestSkillName.Text, getLatestSkillLevel.Text};
        }
    }
}
