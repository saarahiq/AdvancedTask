using AdvancedTaskSpecFlow.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTaskSpecFlow.PageObjectComponents
{
    public class PopUpComponent
    {
        readonly IWebDriver driver;
        public PopUpComponent(IWebDriver driver)
        {
            this.driver = driver;
        }
        private IWebElement popUpMessage => driver.FindElement(By.CssSelector(".ns-box-inner"));

        public string getMessage()
        {
            Wait.WaitToBeVisible(driver, "CssSelector", ".ns-box-inner", 15);
            return popUpMessage.Text;
        }

    }
}
