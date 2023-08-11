using AdvancedTaskSpecFlow.PageObjectComponents;
using AdvancedTaskSpecFlow.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTaskSpecFlow.Pages
{
    public class SignInPage
    {
        readonly IWebDriver driver;
        readonly QuitDialogComponent quitDialogComponent;
        public SignInPage(IWebDriver driver)
        {
            this.driver = driver;
            this.quitDialogComponent = new(driver);
        }
        private IWebElement signInButton => driver.FindElement(By.XPath("//*[@id=\"home\"]/div/div/div[1]/div/a"));
        private IWebElement emailTextbox => driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[1]/input"));
        private IWebElement passwordTextbox => driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[2]/input"));
        private IWebElement rememberMeCheckbox => driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[3]/div/input"));
        private IWebElement loginButton => driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[4]/button"));
        private IWebElement userName => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[2]/div/div/div[1]"));
        public bool SignIn(string email, string password)
        {
            //Identify sign in button and click
            signInButton.Click();
            Wait.WaitToBeVisible(driver, "XPath", "/html/body/div[2]/div/div/div[1]/div/div[1]/input", 10);
            //Identify email textbox and enter email
            Wait.WaitToBeVisible(driver, "XPath", "/html/body/div[2]/div/div/div[1]/div/div[1]/input", 5);
            emailTextbox.SendKeys(email);
            //Identify password textbox and enter valid password
            passwordTextbox.SendKeys(password);
            //Identify remember me checkbox and click
            rememberMeCheckbox.Click();
            //Identify login button and click
            loginButton.Click();
            try
            {
                GetUsername();
                return true;
            }
            catch (Exception ex)
            {
                quitDialogComponent.QuitDialog();
                return false;

            }

        }
       
        public string GetUsername()
        {
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[2]/div/div/div[1]", 10);
            return userName.Text;
        }

       
    }
}
