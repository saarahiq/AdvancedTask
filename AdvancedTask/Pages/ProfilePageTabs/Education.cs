using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvancedTask.Models;
using AdvancedTask.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AdvancedTask.Pages.ProfilePageTabs
{
    public class Education
    {
        readonly IWebDriver driver;
        public Education(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement addNewButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/thead/tr/th[6]/div"));
        private IWebElement universityTextbox => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[1]/div[1]/input"));
        private IWebElement countryDropdown => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[1]/div[2]/select"));
        private IWebElement titleDropdown => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[2]/div[1]/select"));
        private IWebElement degreeTextbox => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[2]/div[2]/input"));
        private IWebElement yearDropdown => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[2]/div[3]/select"));
        private IWebElement saveButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[3]/div/input[1]"));
        private IWebElement editButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[1]/tr/td[6]/span[1]/i"));
        private IWebElement editUniversityTextbox => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td/div[1]/div[1]/input"));
        private IWebElement editCountryDropdown => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td/div[1]/div[2]/select"));
        private IWebElement editTitleDropdown => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td/div[2]/div[1]/select"));
        private IWebElement editDegreeTextbox => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td/div[2]/div[2]/input"));
        private IWebElement editYearDropdown => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td/div[2]/div[3]/select"));
        private IWebElement updateButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td/div[3]/input[1]"));
        private IWebElement getLatestEducationUniversity => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[2]"));
        private IWebElement getLatestEducationCountry => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
        private IWebElement getLatestEducationTitle => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[3]"));
        private IWebElement getLatestEducationDegree => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[4]"));
        private IWebElement getLatestEducationYear => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[5]"));
        private IWebElement getFirstEducationUniversity => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[1]/tr/td[2]"));
        private IWebElement getFirstEducationCountry => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[1]/tr/td[1]"));
        private IWebElement getFirstEducationTitle => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[1]/tr/td[3]"));
        private IWebElement getFirstEducationDegree => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[1]/tr/td[4]"));
        private IWebElement getFirstEducationYear => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[1]/tr/td[5]"));
        private IWebElement deleteButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[1]/tr/td[6]/span[2]/i"));
        
        public void addNewEducation(string university, string country, string title, string degree, string year)
        {
            //Click on Add New Button
            addNewButton.Click();
            // Enter University name
            universityTextbox.SendKeys(university);
            // Select country
            countryDropdown.Click();
            SelectElement countrySelectElement = new SelectElement(countryDropdown);
            countrySelectElement.SelectByText(country);
            // Select title
            titleDropdown.Click();
            SelectElement titleSelectElement = new SelectElement(titleDropdown);
            titleSelectElement.SelectByText(title);
            // Enter degree
            degreeTextbox.SendKeys(degree);
            // Select year
            yearDropdown.Click();
            SelectElement yearSelectElement = new SelectElement(yearDropdown);
            yearSelectElement.SelectByText(year);
            // Save education
            saveButton.Click();
            Thread.Sleep(2000);
        }
        public void editEducation(string university, string country, string title, string degree, string year)
        {
            //Click on Edit Button
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[1]/tr/td[6]/span[1]/i", 10);
            editButton.Click();
            // Enter University name
            editUniversityTextbox.SendKeys(Keys.Control + "A");
            editUniversityTextbox.SendKeys(Keys.Backspace);
            editUniversityTextbox.Clear();
            editUniversityTextbox.SendKeys(university);
            // Select country
            editCountryDropdown.Click();
            SelectElement countrySelectElement = new SelectElement(editCountryDropdown);
            countrySelectElement.SelectByText(country);
            // Select title
            editTitleDropdown.Click();
            SelectElement titleSelectElement = new SelectElement(editTitleDropdown);
            titleSelectElement.SelectByText(title);
            // Enter degree
            editDegreeTextbox.SendKeys(Keys.Control + "A");
            editDegreeTextbox.SendKeys(Keys.Backspace);
            editDegreeTextbox.Clear();
            editDegreeTextbox.SendKeys(degree);
            // Select year
            editYearDropdown.Click();
            SelectElement yearSelectElement = new SelectElement(editYearDropdown);
            yearSelectElement.SelectByText(year);
            // Update education
            updateButton.Click();
            Thread.Sleep(2000);
        }

        public void deleteEducation()
        {
            //Delete first Education 
            deleteButton.Click();
        }

        public string[] getFirstEducation()
        {
            return new[] { getFirstEducationUniversity.Text, getFirstEducationCountry.Text, getFirstEducationTitle.Text, getFirstEducationDegree.Text, getFirstEducationYear.Text };
        }
        public string[] getLatestEducation()
        {
            return new[] { getLatestEducationUniversity.Text, getLatestEducationCountry.Text, getLatestEducationTitle.Text, getLatestEducationDegree.Text, getLatestEducationYear.Text };
        }
    }
}
