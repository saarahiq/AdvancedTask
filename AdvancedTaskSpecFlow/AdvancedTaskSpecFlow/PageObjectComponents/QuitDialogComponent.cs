using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTaskSpecFlow.PageObjectComponents
{
    public class QuitDialogComponent
    {
        readonly IWebDriver driver;
        public QuitDialogComponent(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void QuitDialog()
        {
            new Actions(driver).SendKeys(Keys.Escape).Perform();
        }
    }
}
