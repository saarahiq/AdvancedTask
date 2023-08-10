using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTaskSpecFlow.Pages.ManageRequestPageTabs
{
    public class SentRequests
    {
        readonly IWebDriver driver;
        public SentRequests(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}
