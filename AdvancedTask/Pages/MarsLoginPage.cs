using AdvancedTask.JSON_Objects;
using AdvancedTask.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace AdvancedTask.Pages
{
    public class MarsLoginPage
    {
        readonly IWebDriver driver; 
        public MarsLoginPage(IWebDriver driver) { this.driver = driver;}
        public bool Register(UserObject user)
        {            
            //Registration
            //Click on join buton
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"home\"]/div/div/div[1]/div/button", 10);
            joinButton.Click();
            //Identify firstname textbox and enter
            Wait.WaitToBeVisible(driver, "XPath", "/html/body/div[2]/div/div/form/div[1]/input", 10);
            firstNameTextbox.SendKeys(user.FirstName);
            //Identify lastname textbox and enter
            lastNameTextbox.SendKeys(user.LastName);
            //Identify email textbox and enter
            emailInputTextbox.SendKeys(user.Email);
            //Identify password textbox and enter
            passwordInputTextbox.SendKeys(user.Password);
            //Identify  confirm password textbox and enter
            confirmPasswordTextbox.SendKeys(user.ConfirmationPassword);
            //Identify terms and conditions checkbox and click
            if (user.AgreeToTC) 
            {
                termsCheckbox.Click();
            }
            
            //Click on submit button
            
            submitButton.Click();
            try
            {
                Wait.WaitToBeVisible(driver, "CssSelector", ".ns-box-inner", 10);
                return true;
            }
            catch (Exception ex)
            {
                
                QuitDialog();
                return false;
            }
        }
        public void QuitDialog()
        {
            new Actions(driver).SendKeys(Keys.Escape).SendKeys(Keys.Escape).Perform();
        }
        public bool Login(UserObject user)
        {           
            //Sign in Mars portal
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"home\"]/div/div/div[1]/div/a", 10);
            signButton.Click();
            //Identify email textbox and enter email
            Wait.WaitToBeVisible(driver, "XPath", "/html/body/div[2]/div/div/div[1]/div/div[1]/input", 5);
            emailTextbox.SendKeys(user.Email);
            //Identify password textbox and enter password
            passwordTextbox.SendKeys(user.Password);
            //Identify remember me checkbox and click
            //rememberMeCheckbox.Click();
            //Identify login button and click
            loginButton.Click();
            try
            {
                GetUsername();
                return true;
            }
            catch (Exception ex)
            {

                QuitDialog();
                return false;
            }

        }
        public string GetUsername()
        {
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/div[1]/div[2]/div/span", 10);      
            return userName.Text;
        }
        public void RegisterAndLogin(UserObject user)
        {
           if (!Login(user)) 
            { 
                Register(user); 
                Login(user);
            }
        }
        private IWebElement joinButton => driver.FindElement(By.XPath("//*[@id=\"home\"]/div/div/div[1]/div/button"));
        private IWebElement firstNameTextbox => driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[1]/input"));
        private IWebElement lastNameTextbox => driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[2]/input"));
        private IWebElement emailInputTextbox => driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[3]/input"));
        private IWebElement passwordInputTextbox => driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[4]/input"));
        private IWebElement confirmPasswordTextbox => driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[5]/input"));
        private IWebElement termsCheckbox => driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[6]/div/div/input"));
        private IWebElement submitButton => driver.FindElement(By.XPath("//*[@id=\"submit-btn\"]"));
        private IWebElement signButton => driver.FindElement(By.XPath("//*[@id=\"home\"]/div/div/div[1]/div/a"));
        private IWebElement emailTextbox => driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[1]/input"));
        private IWebElement passwordTextbox => driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[2]/input"));
        private IWebElement rememberMeCheckbox => driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[3]/div/input"));
        private IWebElement loginButton => driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[4]/button"));
        private IWebElement userName => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/div[1]/div[2]/div/span"));
       


    }
}

