using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTaskSpecFlow.Pages
{
    public class NotificationsPage
    {
        readonly IWebDriver driver;
        public NotificationsPage(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}
