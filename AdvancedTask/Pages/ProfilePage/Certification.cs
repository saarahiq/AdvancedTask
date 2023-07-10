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
    public class Certification
    {
        readonly IWebDriver driver;
        public Certification(IWebDriver driver)
        {
            this.driver = driver;
        }
        private IWebElement certificationTab => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[4]"));
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
        private IWebElement deleteButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[1]/tr/td[4]/span[2]/i"));
        private IWebElement popUpMessage => driver.FindElement(By.CssSelector(".ns-box-inner"));
        private IWebElement getFirstCertName => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[1]/tr/td[1]"));
        private IWebElement getFirstCertFrom => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[1]/tr/td[2]"));
        private IWebElement getFirstCertYear => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[1]/tr/td[3]"));
        private IWebElement getLatestCertName => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[1]"));
        private IWebElement getLatestCertFrom => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[2]"));
        private IWebElement getLatestCertYear => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[3]"));

        public void addNewCertification(string certificate, string certifiedFrom, string year)
        {
            //Click on Certifications tab
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[4]", 5);
            certificationTab.Click();
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
            //Click on Certifications tab
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[4]", 5);
            certificationTab.Click();
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
        public void deleteCertification()
        {
            //Delete first Certification 
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[4]", 5);
            certificationTab.Click();
            deleteButton.Click();
        }
        public string getPopUpMessage()
        {
            Wait.WaitToBeClickable(driver, "CssSelector", ".ns-box-inner", 15);
            return popUpMessage.Text;
        }
        public string[] getFirstCertification()
        {
            return new[] { getFirstCertName.Text, getFirstCertFrom.Text, getFirstCertYear.Text };
        }
        public string[] getLatestCertification()
        {
            return new[] {getLatestCertName.Text, getLatestCertFrom.Text, getLatestCertYear.Text};
        }
        
    }
}