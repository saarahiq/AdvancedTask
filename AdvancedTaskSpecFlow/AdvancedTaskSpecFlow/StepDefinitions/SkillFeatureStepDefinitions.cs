using AdvancedTaskSpecFlow.PageObjectComponents;
using AdvancedTaskSpecFlow.Pages.ProfilePageTabs;
using AdvancedTaskSpecFlow.Utilities;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace AdvancedTaskSpecFlow.StepDefinitions
{
    [Binding]
    public class SkillFeatureStepDefinitions
    {
        private readonly CommonDriver commonDriver;
        public SkillFeatureStepDefinitions(CommonDriver commonDriver)
        {
            this.commonDriver = commonDriver;
        }

        public void LoginAndGoToSkillsTab()
        {
            //Open chrome browser
            commonDriver.driver.Manage().Window.Maximize();
            //Launch Mars portal
            commonDriver.driver.Navigate().GoToUrl("http://localhost:5000");
            var loggedInSuccessfully = commonDriver.signInPage.SignIn("jessica@hotmail.com", "123123");
            if (loggedInSuccessfully)
            {
                commonDriver.profilePage.goToSkillsTab();
            }
        }

        [Given(@"I logged in successfully and navigate to Skills Tab to add")]
        public void GivenILoggedInSuccessfullyAndNavigateToSkillsTabToAdd()
        {
            LoginAndGoToSkillsTab();
        }

        [When(@"I click on Add New button and add '([^']*)' and '([^']*)'")]
        public void WhenIClickOnAddNewButtonAndAddAnd(string skill, string skillLevel)
        {
            commonDriver.skillsPage.addNewSkill(skill, skillLevel);
        }


        [Then(@"The new Skill record with '([^']*)' and '([^']*)' should be added successfully and I should see the '([^']*)'")]
        public void ThenTheNewSkillRecordWithAndShouldBeAddedSuccessfullyAndIShouldSeeThe(string skill, string skillLevel, string message)
        {
            string popUpMessage = commonDriver.popUpComponent.getMessage();
            Assert.AreEqual(popUpMessage, message, "Actual and expected skill record do not match");

            if (popUpMessage != "Please enter skill and experience level" || popUpMessage != "This skill is already exist in your skill list.")
            {
                string[] newSkillAdded = commonDriver.skillsPage.getLatestSkill();
                Assert.AreEqual(skill, newSkillAdded[0], "Actual and expected skill record do not match");
                Assert.AreEqual(skillLevel, newSkillAdded[1], "Actual and expected skill record do not match");
            }
            commonDriver.SaveScreenshot("Skills Tests");
        }

        [Given(@"I logged in successfully and navigate to Skills Tab to edit")]
        public void GivenILoggedInSuccessfullyAndNavigateToSkillsTabToEdit()
        {
            LoginAndGoToSkillsTab();
        }

        [When(@"I edit '([^']*)' and '([^']*)'")]
        public void WhenIEditAnd(string skill, string skillLevel)
        {
            commonDriver.skillsPage.editSkills(skill, skillLevel);
        }

        [Then(@"The new Skill details should be updated with '([^']*)' and '([^']*)' and I should see the '([^']*)'")]
        public void ThenTheNewSkillDetailsShouldBeUpdatedWithAndAndIShouldSeeThe(string skill, string skillLevel, string message)
        {
            string popUpMessage = commonDriver.popUpComponent.getMessage();
            Assert.AreEqual(popUpMessage, message, "Actual and expected skill record do not match");
            
            if (popUpMessage != "This skill is already added to your skill list." && popUpMessage != "Please enter skill and experience level")
            {
                string[] updatedSkillAdded = commonDriver.skillsPage.getFirstSkill();
                Assert.AreEqual(skill, updatedSkillAdded[0], "Actual and expected skill record do not match");
                Assert.AreEqual(skillLevel, updatedSkillAdded[1], "Actual and expected skill record do not match");
            }
            commonDriver.SaveScreenshot("Skills Tests");
        }

        [Given(@"I logged in successfully and navigate to Skills Tab to delete")]
        public void GivenILoggedInSuccessfullyAndNavigateToSkillsTabToDelete()
        {
            LoginAndGoToSkillsTab();
        }

        [When(@"I click on the Delete button for '([^']*)' and '([^']*)'")]
        public void WhenIClickOnTheDeleteButtonForAnd(string skill, string skillLevel)
        {
            commonDriver.skillsPage.deleteSkill(skill, skillLevel);
        }

        [Then(@"The Skill record should be successfully deleted and I should see the '([^']*)'")]
        public void ThenTheSkillRecordShouldBeSuccessfullyDeletedAndIShouldSeeThe(string message)
        {
            string popUpMessage = commonDriver.popUpComponent.getMessage();
            Assert.AreEqual(message, popUpMessage, "Actual and expected certification record do not match.");
            commonDriver.SaveScreenshot("Skills Tests");
        }
    }
}
