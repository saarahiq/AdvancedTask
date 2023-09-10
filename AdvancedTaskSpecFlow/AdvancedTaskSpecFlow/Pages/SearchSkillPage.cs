using AdvancedTaskSpecFlow.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTaskSpecFlow.Pages
{
    public class SearchSkillPage
    {
        readonly IWebDriver driver;
        public SearchSkillPage(IWebDriver driver) { this.driver = driver; }


        private IWebElement searchSkill => driver.FindElement(By.XPath("//*[@id=\"service-search-section\"]/div[2]/div/section/div/div[1]/div[2]/input"));

        private IWebElement searchskillSearch => driver.FindElement(By.XPath("//*[@id=\"service-search-section\"]/div[2]/div/section/div/div[1]/div[2]/i"));

        private IWebElement searchUser => driver.FindElement(By.XPath("//*[@id=\"service-search-section\"]/div[2]/div/section/div/div[1]/div[3]/div[1]/div/div[1]/input"));

        private IWebElement selectUser => driver.FindElement(By.XPath("//*[@id=\"service-search-section\"]/div[2]/div/section/div/div[1]/div[3]/div[1]/div/div[2]/div[1]"));
        private IWebElement searchUserSearch => driver.FindElement(By.XPath("//*[@id=\"service-search-section\"]/div[2]/div/section/div/div[1]/div[3]/div[1]/div/div[1]/i"));

        private IWebElement searchedUser => driver.FindElement(By.XPath("//*[@id=\"service-search-section\"]/div[2]/div/section/div/div[2]/div/div[2]/div/div/div[1]/div[1]/a[1]"));

        private IWebElement searchForuser => driver.FindElement(By.XPath("//*[@id=\"service-search-section\"]/div[2]/div/section/div/div[1]/div[3]/div[1]/div/div[2]/div[1]/div/span"));
        private IWebElement searchskillTxtBox => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/div[1]/div[1]/input"));
        private IWebElement searchedskill => driver.FindElement(By.XPath("//*[@id=\"service-search-section\"]/div[2]/div/section/div/div[2]/div/div[2]/div/div/div[1]/div[1]/a[2]/p"));

        private IWebElement skillSearchbutton => driver.FindElement(By.XPath("//*[@id=\"service-search-section\"]/div[2]/div/section/div/div[1]/div[2]/i"));
        private IWebElement progtechLink => driver.FindElement(By.XPath("//*[@id=\"service-search-section\"]/div[2]/div/section/div/div[1]/div[1]/div/a[7]"));
        private IWebElement qaLink => driver.FindElement(By.XPath("//*[@id=\"service-search-section\"]/div[2]/div/section/div/div[1]/div[1]/div/a[11]"));
        private IWebElement onlineButton => driver.FindElement(By.XPath("//*[@id=\"service-search-section\"]/div[2]/div/section/div/div[1]/div[5]/button[1]"));
        private IWebElement onsiteButton => driver.FindElement(By.XPath("//*[@id=\"service-search-section\"]/div[2]/div/section/div/div[1]/div[5]/button[2]"));
        private IWebElement showAllButton => driver.FindElement(By.XPath("//*[@id=\"service-search-section\"]/div[2]/div/section/div/div[1]/div[5]/button[3]"));
        private IWebElement graphicDesignLink => driver.FindElement(By.XPath("//*[@id=\"service-search-section\"]/div[2]/div/section/div/div[1]/div[1]/div/a[2]"));
        private IWebElement bookAlbumLink => driver.FindElement(By.XPath("//*[@id=\"service-search-section\"]/div[2]/div/section/div/div[1]/div[1]/div/a[4]"));
        private IWebElement searchButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/div[1]/div[1]/i"));
        private IWebElement imageSelect => driver.FindElement(By.XPath("//*[@id=\"service-search-section\"]/div[2]/div/section/div/div[2]/div/div[2]/div/div/div[1]/a/img"));
        private IWebElement categoryCheck => driver.FindElement(By.XPath("//*[@id=\"service-detail-section\"]/div[2]/div/div[2]/div[1]/div[1]/div[2]/div[2]/div/div/div[2]/div/div[1]/div/div[2]"));
        private IWebElement subcategoryCheck => driver.FindElement(By.XPath("//*[@id=\"service-detail-section\"]/div[2]/div/div[2]/div[1]/div[1]/div[2]/div[2]/div/div/div[2]/div/div[2]/div/div[2]"));


        public void SearchByCategory()
        {
            
            Thread.Sleep(5000);
            graphicDesignLink.Click();
            bookAlbumLink.Click();
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"service-search-section\"]/div[2]/div/section/div/div[2]/div/div[2]/div/div/div[1]/a/img", 5);
            imageSelect.Click();
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"service-detail-section\"]/div[2]/div/div[2]/div[1]/div[1]/div[2]/div[2]/div/div/div[2]/div/div[1]/div/div[2]", 5);
        }
        public void Searchskill(string skill)
        {

            Thread.Sleep(5000);
            searchSkill.Click();
           searchSkill.SendKeys(skill);
            searchskillSearch.Click();
            onlineButton.Click();
            onsiteButton.Click();
            showAllButton.Click();

        }
        public void SearchskillByUser(string user)
        {

            searchUser.Click();
           searchUser.SendKeys(user);
            Thread.Sleep(1000);
            selectUser.Click();
            onsiteButton.Click();

        }

        

        public string Category()
        {
            return graphicDesignLink.Text;
        }

        public string CategoryMatch()
        {
            return categoryCheck.Text;

        }

        public string UserMatch()
        {
            return searchedUser.Text;
        }
        public string UserSearch()
        {
            //var user = driver.FindElement(By.XPath(" //*[@id=\"service-search-section\"]/div[2]/div/section/div/div[1]/div[3]/div[1]/div/div[2]/div[1]/div/span "));
            return searchForuser.Text;

        }

        public string Searchedskill()
        {
            return searchedskill.Text;
        }


    }
}
