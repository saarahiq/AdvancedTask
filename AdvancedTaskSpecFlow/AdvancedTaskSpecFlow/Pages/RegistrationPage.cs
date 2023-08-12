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
        public RegistrationPage(IWebDriver driver)
        {
            this.driver = driver;
        }

    }
}
