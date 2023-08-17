using AdvancedTaskSpecFlow.Pages.PageObjectComponents;
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
    public class RegistrationPage
    {
        readonly IWebDriver driver;
        readonly QuitDialogComponent quitDialogComponent;
        public RegistrationPage(IWebDriver driver)
        {
            this.driver = driver;
            this.quitDialogComponent = new(driver);
        }
        private IWebElement joinButton => driver.FindElement(By.XPath("//*[@id=\"home\"]/div/div/div[1]/div/button"));
        private IWebElement firstNameTextbox => driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[1]/input"));
        private IWebElement lastNameTextbox => driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[2]/input"));
        private IWebElement emailInputTextbox => driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[3]/input"));
        private IWebElement passwordInputTextbox => driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[4]/input"));
        private IWebElement confirmPasswordTextbox => driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[5]/input"));
        private IWebElement termsCheckbox => driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[6]/div/div/input"));
        private IWebElement submitButton => driver.FindElement(By.XPath("//*[@id=\"submit-btn\"]"));
        private IWebElement popUpMessage=> driver.FindElement(By.CssSelector(".ns-box-inner"));
        public bool Registration(string firstName,string lastName,string emailAddress,string password,string confirmPassword,string agreeToTC)
        {
            //Identify join button and click
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"home\"]/div/div/div[1]/div/button", 10);
            joinButton.Click();
            //Identify firstname textbox and enter
            Wait.WaitToBeVisible(driver, "XPath", "/html/body/div[2]/div/div/form/div[1]/input", 10);
            firstNameTextbox.SendKeys(firstName);
            //Identify lastname textbox and enter
            lastNameTextbox.SendKeys(lastName);
            //Identify email textbox and enter
            emailInputTextbox.SendKeys(emailAddress);
            //Identify password textbox and enter
            passwordInputTextbox.SendKeys(password);
            //Identify  confirm password textbox and enter
            confirmPasswordTextbox.SendKeys(confirmPassword);
            //Identify terms and conditions checkbox and click
            if (agreeToTC=="yes")
            {
                termsCheckbox.Click();
            }

            //Click on submit button

            submitButton.Click();
            try
            {
                GetPopUpMessage();
                return true;
            }
            catch (Exception ex)
            {

                quitDialogComponent.QuitDialog();
                return false;
            }
        }
        public string GetPopUpMessage()
        {
            Wait.WaitToBeVisible(driver, "CssSelector", ".ns-box-inner", 10);
            return popUpMessage.Text;

        }

    }
}
