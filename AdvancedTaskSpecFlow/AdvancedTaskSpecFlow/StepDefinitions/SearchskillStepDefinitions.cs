using AdvancedTaskSpecFlow.Utilities;
using System;
using TechTalk.SpecFlow;

namespace AdvancedTaskSpecFlow.StepDefinitions
{
    [Binding]
    public class SearchskillStepDefinitions
    {

        private readonly CommonDriver commonDriver;
        public SearchskillStepDefinitions(CommonDriver commonDriver)
        {
            this.commonDriver = commonDriver;
        }

        public void GivenLaunchMarsPortal()
        {
            //Open chrome browser
            commonDriver.driver.Manage().Window.Maximize();
            //Launch Mars portal
            commonDriver.driver.Navigate().GoToUrl("http://localhost:5000");
        }
        public void LoginAndGoToSearchSkillPage()
        {
            var loggedInSuccessfully = commonDriver.signInPage.SignIn("mars.advanced@example.com", "123456");
            if (loggedInSuccessfully)
            {
                commonDriver.profilePage.gotoSearchSkillPage();
            }
        }
        [Given(@"Launch Mars portal and login with valid user credentials and go to searchskill page")]
        public void GivenLaunchMarsPortalAndLoginWithValidUserCredentialsAndGoToSearchskillPage()
        {
            GivenLaunchMarsPortal();
            LoginAndGoToSearchSkillPage();
        }

        [When(@"I click on category and sub category")]
        public void WhenIClickOnCategoryAndSubCategory()
        {
            commonDriver.searchskillPage.SearchByCategory();
        }

        [Then(@"appropriate category should be displayed in result")]
        public void ThenAppropriateCategoryShouldBeDisplayedInResult()
        {
            throw new PendingStepException();
        }

        // search by skills

        [When(@"I click search skill textbox and enter '([^']*)'")]
        public void WhenIClickSearchSkillTextboxAndEnter(string skill)
        {
            commonDriver.searchskillPage.Searchskill(skill);
        }

        [Then(@"result should be displayed as per searched skill")]
        public void ThenResultShouldBeDisplayedAsPerSearchedSkill()
        {
            throw new PendingStepException();
        }
        // search by user

        [When(@"I click search user textbox and enter '([^']*)'")]
        public void WhenIClickSearchUserTextboxAndEnter(string user)
        {
            commonDriver.searchskillPage.SearchskillByUser(user);
        }

        [Then(@"result should be displayed as per searched user")]
        public void ThenResultShouldBeDisplayedAsPerSearchedUser()
        {
            throw new PendingStepException();
        }


    }
}
