using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTask.Pages.ProfilePageTabs
{
    public class Certification
    {
        readonly IWebDriver driver;
        public Certification(IWebDriver driver)
        {
            this.driver = driver;
        }
        private IWebElement addNewCertButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/thead/tr/th[4]/div"));
        private IWebElement enterCertName => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/div/div[1]/div/input"));
        private IWebElement certFrom => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/div/div[2]/div[1]/input"));
        private IWebElement certYear => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/div/div[2]/div[2]/select"));
        private IWebElement addButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/div/div[3]/input[1]"));
        private IWebElement editButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[1]/tr/td[4]/span[1]/i"));
        private IWebElement editCertName => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[1]/tr/td/div/div/div[1]/input"));
        private IWebElement editCertFrom => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[1]/tr/td/div/div/div[2]/input"));
        private IWebElement editCertYear => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[1]/tr/td/div/div/div[3]/select"));
        private IWebElement updateButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[1]/tr/td/div/span/input[1]"));

        public void addNewCertification(string certificate, string certifiedFrom, string year)
        {
            //Click on Add New button
            //Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/thead/tr/th[4]/div", 5);
            addNewCertButton.Click();
            //Enter Certification details
            enterCertName.SendKeys(certificate);
            certFrom.SendKeys(certifiedFrom);
            certYear.Click();
            SelectElement certYearDropdown = new SelectElement(certYear);
            certYearDropdown.SelectByText(year);
            addButton.Click();
            Thread.Sleep(1000);
        }
        public void editCertification(string certificate, string certifiedFrom, string year)
        {
            //Click on edit 
            editButton.Click();
            //Edit Certification
            editCertName.SendKeys(Keys.Control + "A");
            editCertName.SendKeys(Keys.Backspace);
            editCertName.SendKeys(certificate);
            editCertFrom.SendKeys(Keys.Control + "A");
            editCertFrom.SendKeys(Keys.Backspace);
            editCertFrom.SendKeys(certifiedFrom);
            SelectElement editCertYearDropdown = new SelectElement(editCertYear);
            editCertYearDropdown.SelectByText(year);
            updateButton.Click();
            Thread.Sleep(1000);
        }
        public void deleteCertification(string certificate, string certifiedFrom, string year)
        {
            //Delete first Certification 
            var findDeleteRow = driver.FindElement(By.XPath($"//tbody[tr[td[text()='{certificate}'] and td[text()='{certifiedFrom}'] and td[text()='{year}']]]//i[@class='remove icon']"));
            findDeleteRow.Click();
        }

        public string[] getFirstCertification()
        {
            IWebElement getFirstCertName = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[1]/tr/td[1]"));
            IWebElement getFirstCertFrom = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[1]/tr/td[2]"));
            IWebElement getFirstCertYear = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[1]/tr/td[3]"));

            return new[] { getFirstCertName.Text, getFirstCertFrom.Text, getFirstCertYear.Text };
        }
        public string[] getLatestCertification()
        {
            IWebElement getLatestCertName = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[1]"));
            IWebElement getLatestCertFrom = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[2]"));
            IWebElement getLatestCertYear = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[3]"));

            return new[] { getLatestCertName.Text, getLatestCertFrom.Text, getLatestCertYear.Text };
        }

    }
}