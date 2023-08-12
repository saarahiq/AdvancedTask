using AdvancedTaskSpecFlow.PageObjectComponents;
using AdvancedTaskSpecFlow.Utilities;
using AventStack.ExtentReports;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace AdvancedTaskSpecFlow.StepDefinitions
{
    [Binding]
    public class EducationStepDefinitions
    {

        private readonly CommonDriver commonDriver;
        public EducationStepDefinitions(CommonDriver commonDriver)
        {
            this.commonDriver = commonDriver;
        }

        public void LoginAndGoToEducationTab()
        {
            //Open chrome browser
            commonDriver.driver.Manage().Window.Maximize();
            //Launch Mars portal
            commonDriver.driver.Navigate().GoToUrl("http://localhost:5000");
            var loggedInSuccessfully = commonDriver.signInPage.SignIn("jessica@hotmail.com", "123123");
            if (loggedInSuccessfully)
            {
                commonDriver.profilePage.goToEducationTab();
            }
        }

        [Given(@"I logged in successfully and navigate to Education Tab")]
        public void GivenILoggedInSuccessfullyAndNavigateToEducationTab()
        {
            LoginAndGoToEducationTab();
        }

        [When(@"I click on Add New button and add '([^']*)','([^']*)', '([^']*)', '([^']*)', '([^']*)'")]
        public void WhenIClickOnAddNewButtonAndAdd(string university, string country, string title, string degree, string year)
        {
            commonDriver.educationPage.addNewEducation(university, country, title, degree, year);
        }

        [Then(@"The new Education record with '([^']*)','([^']*)', '([^']*)', '([^']*)', '([^']*)' should be added and I should see the '([^']*)'")]
        public void ThenTheNewEducationRecordWithShouldBeAddedAndIShouldSeeThe(string university, string country, string title, string degree, string year, string message)
        {
            //Check if the New Education records have been added successfully
            
            string popUpMessage = commonDriver.popUpComponent.getMessage();
            Assert.AreEqual(popUpMessage, message, "Could not verify that the Education was added.");
            
            
            if (popUpMessage != "Please enter all the fields" && popUpMessage != "This information is already exist.")
            {
                string[] newEducationAdded = commonDriver.educationPage.getLatestEducation();
                Assert.AreEqual(university, newEducationAdded[0], "Actual and expected Education university name does not match");
                Assert.AreEqual(country, newEducationAdded[1], "Actual and expected Education country do not match");
                Assert.AreEqual(title, newEducationAdded[2], "Actual and expected Education title do not match");
                Assert.AreEqual(degree, newEducationAdded[3], "Actual and expected Education degree do not match");
                Assert.AreEqual(year, newEducationAdded[4], "Actual and expected Education year do not match");
            }

            //logging to extent reports
            CommonDriver.test.Log(Status.Pass, "Successfully verified creating an Education record");
            commonDriver.SaveScreenshot("Education Tests");
        }

        [Given(@"I logged in successfully and navigate to Education Tab to edit")]
        public void GivenILoggedInSuccessfullyAndNavigateToEducationTabToEdit()
        {
            LoginAndGoToEducationTab();
        }

        [When(@"I edit '([^']*)','([^']*)', '([^']*)', '([^']*)', '([^']*)' in Education Tab")]
        public void WhenIEditInEducationTab(string university, string country, string title, string degree, string year)
        {
            commonDriver.educationPage.editEducation(university, country, title, degree, year);
        }

        [Then(@"The Education details should be updated with '([^']*)','([^']*)', '([^']*)', '([^']*)', '([^']*)' and I should see the '([^']*)'")]
        public void ThenTheEducationDetailsShouldBeUpdatedWithAndIShouldSeeThe(string university, string country, string title, string degree, string year, string message)
        {
            string popUpMessage = commonDriver.popUpComponent.getMessage();
            Assert.AreEqual(popUpMessage, message, "Could not verify that the Education was edited.");
            

            if (popUpMessage != "Please enter all the fields" && popUpMessage != "This information is already exist.")
            {
                string[] newEducationAdded = commonDriver.educationPage.getFirstEducation();
                Assert.AreEqual(university, newEducationAdded[0], "Actual and expected Education university name does not match");
                Assert.AreEqual(country, newEducationAdded[1], "Actual and expected Education country do not match");
                Assert.AreEqual(title, newEducationAdded[2], "Actual and expected Education title do not match");
                Assert.AreEqual(degree, newEducationAdded[3], "Actual and expected Education degree do not match");
                Assert.AreEqual(year, newEducationAdded[4], "Actual and expected Education year do not match");
            }

            //logging to extent reports
            CommonDriver.test.Log(Status.Pass, "Successfully verified editing an Education record");
            commonDriver.SaveScreenshot("Education Tests");
        }

        [Given(@"I logged in successfully and navigate to Education Tab to delete")]
        public void GivenILoggedInSuccessfullyAndNavigateToEducationTabToDelete()
        {
            LoginAndGoToEducationTab();
        }

        [When(@"I click on the Delete button for '([^']*)','([^']*)', '([^']*)', '([^']*)', '([^']*)'")]
        public void WhenIClickOnTheDeleteButtonFor(string university, string country, string title, string degree, string year)
        {
           commonDriver.educationPage.deleteEducation(university, country, title, degree, year);
        }

        [Then(@"The Education details should be deleted and I should see the '([^']*)'")]
        public void ThenTheEducationDetailsShouldBeDeletedAndIShouldSeeThe(string message)
        {
            string popUpMessage = commonDriver.popUpComponent.getMessage();
            Assert.AreEqual(message, popUpMessage, "Actual and expected certification record do not match.");
            commonDriver.SaveScreenshot("Education Tests");
        }
    }
}
