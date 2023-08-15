using AdvancedTaskSpecFlow.Models;
using AdvancedTaskSpecFlow.Pages.ProfilePageTabs;
using AdvancedTaskSpecFlow.Utilities;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Model;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace AdvancedTaskSpecFlow.StepDefinitions
{
    [Binding]
    public class EditShareSkillStepDefinitions
    {
        private readonly CommonDriver commonDriver;
        public EditShareSkillStepDefinitions(CommonDriver commonDriver)
        {
            this.commonDriver = commonDriver;
        }

        public void LoginAndGoToManageListingsPage()
        {
            bool loggedInSuccessfully = commonDriver.Login("jessica@hotmail.com", "123123");
            if (loggedInSuccessfully)
            {
                commonDriver.navigationMenu.goToManageListingsButton();
            }
        }
        public void SaveEditShareSkill(string title, 
            string description, 
            string category, 
            string subCategory, 
            string tagsToRemove, 
            string tagsToAdd, 
            string serviceType, 
            string locationType, 
            string startDate, 
            string endDate, 
            string availableDays, 
            string skillTrade, 
            string credit, 
            string skillExchangeTagsToRemove, 
            string skillExchangeTagsToAdd, 
            string active)
        {
            var _tagsToRemove = tagsToRemove.Split(',').ToList();
            var _tagsToAdd = tagsToAdd.Split(',').ToList();

            var groupOfDays = availableDays.Split(';').ToList();

            var daysObject = new Dictionary<string, DayModel>();

            foreach (var groupOfDay in groupOfDays)
            {
                var dayAndTime = groupOfDay.Split(',');
                var day = dayAndTime[0];
                var startTime = dayAndTime[1];
                var endTime = dayAndTime[2];

                var dayModelStartEndTime = new DayModel(startTime, endTime);

                daysObject.Add(day, dayModelStartEndTime);
            }

            var _availableDays = new AvailableDaysModel(startDate, endDate, daysObject);

            var _skillExchangeTagsToRemove = skillExchangeTagsToRemove.Split(',').ToList();
            var _skillExchangeTagsToAdd = skillExchangeTagsToAdd.Split(',').ToList();
            commonDriver.editShareSkillPage.editShareSkill(title, description, category, subCategory, _tagsToRemove, _tagsToAdd, serviceType, locationType, _availableDays, skillTrade, credit, _skillExchangeTagsToRemove, _skillExchangeTagsToAdd, String.Empty, active);
            commonDriver.editShareSkillPage.saveEditShareSkill();
        }

        [Given(@"I logged in successfully and navigate to the Manage Listings page")]
        public void GivenILoggedInSuccessfullyAndNavigateToTheManageListingsPage()
        {
            LoginAndGoToManageListingsPage();
        }

        [When(@"I click on the Edit button and enter '([^']*)', '([^']*)', '([^']*)','([^']*)', '([^']*)', '([^']*)','([^']*)', '([^']*)', '([^']*)', '([^']*)','([^']*)', '([^']*)', '([^']*)', '([^']*)', '([^']*)', '([^']*)'")]
        public void WhenIClickOnTheEditButtonAndEnter(string title, 
            string description,
            string category, 
            string subCategory, 
            string tagsToRemove, 
            string tagsToAdd, 
            string serviceType, 
            string locationType,
            string startDate, 
            string endDate, 
            string availableDays, 
            string skillTrade, 
            string credit, 
            string skillExchangeTagsToRemove, 
            string skillExchangeTagsToAdd, 
            string active)
        {
            SaveEditShareSkill(title, 
                description, 
                category, 
                subCategory, 
                tagsToRemove, 
                tagsToAdd, 
                serviceType, 
                locationType, 
                startDate, 
                endDate, 
                availableDays, 
                skillTrade, 
                credit, 
                skillExchangeTagsToRemove, 
                skillExchangeTagsToAdd, 
                active);
        }

        [Then(@"The new Service Listing record should be successfully updated")]
        public void ThenTheNewServiceListingRecordWithShouldBeUpdatedSuccessfullyAndIShouldSeeThe()
        {
            CommonDriver.test.Log(Status.Pass, "Successfully updated a service listing");
            commonDriver.SaveScreenshot("Edit Service Listing");
        }

        [Given(@"I logged in successfully and navigate to the Manage Listings page to edit the title")]
        public void GivenILoggedInSuccessfullyAndNavigateToTheManageListingsPageToEditTheTitle()
        {
            LoginAndGoToManageListingsPage();
        }

        [When(@"I click on the Edit button and enter '([^']*)', '([^']*)', '([^']*)','([^']*)', '([^']*)', '([^']*)','([^']*)', '([^']*)', '([^']*)', '([^']*)','([^']*)', '([^']*)', '([^']*)', '([^']*)', '([^']*)', '([^']*)' to see if it doesn't save with an invalid title")]
        public void WhenIClickOnTheEditButtonAndEnterToSeeIfItDoesntSaveWithAnInvalidTitle(string title, 
            string description, 
            string category, 
            string subCategory, 
            string tagsToRemove, 
            string tagsToAdd, 
            string serviceType, 
            string locationType, 
            string startDate, 
            string endDate, 
            string availableDays, 
            string skillTrade, 
            string credit, 
            string skillExchangeTagsToRemove, 
            string skillExchangeTagsToAdd, 
            string active)
        {
            SaveEditShareSkill(title, 
                description, 
                category, 
                subCategory, 
                tagsToRemove, 
                tagsToAdd, 
                serviceType, 
                locationType, 
                startDate, 
                endDate, 
                availableDays, 
                skillTrade, 
                credit, 
                skillExchangeTagsToRemove, 
                skillExchangeTagsToAdd, 
                active);
        }

        [Then(@"The new Service Listing record should not be updated successfully and I should see the '([^']*)' and '([^']*)' for title")]
        public void ThenTheNewServiceListingRecordShouldNotBeUpdatedSuccessfullyAndIShouldSeeTheAndForTitle(string message, string fieldErrorMessage)
        {
            string popUpMessage = commonDriver.popUpComponent.getMessage();
            Assert.AreEqual(message, popUpMessage, "Actual and expected service listing record do not match.");

            commonDriver.editShareSkillPage.verifyInvalidTitle(fieldErrorMessage);

            CommonDriver.test.Log(Status.Pass, "Unable to update a service listing");
            commonDriver.SaveScreenshot("Edit Service Listing");
        }

        [Given(@"I logged in successfully and navigate to the Manage Listings page to edit the description")]
        public void GivenILoggedInSuccessfullyAndNavigateToTheManageListingsPageToEditTheDescription()
        {
            LoginAndGoToManageListingsPage();
        }

        [When(@"I click on the Edit button and enter '([^']*)', '([^']*)', '([^']*)','([^']*)', '([^']*)', '([^']*)','([^']*)', '([^']*)', '([^']*)', '([^']*)','([^']*)', '([^']*)', '([^']*)', '([^']*)', '([^']*)', '([^']*)' to see if it doesn't save with an invalid description")]
        public void WhenIClickOnTheEditButtonAndEnterToSeeIfItDoesntSaveWithAnInvalidDescription(string title, 
            string description, 
            string category, 
            string subCategory,
            string tagsToRemove, 
            string tagsToAdd, 
            string serviceType, 
            string locationType, 
            string startDate, 
            string endDate, 
            string availableDays, 
            string skillTrade, 
            string credit, 
            string skillExchangeTagsToRemove, 
            string skillExchangeTagsToAdd, 
            string active)
        {
            SaveEditShareSkill(title, 
                description, 
                category, 
                subCategory, 
                tagsToRemove, 
                tagsToAdd, 
                serviceType, 
                locationType, 
                startDate, 
                endDate, 
                availableDays, 
                skillTrade, 
                credit, 
                skillExchangeTagsToRemove, 
                skillExchangeTagsToAdd, 
                active);
        }

        [Then(@"The new Service Listing record should not be updated successfully and I should see the '([^']*)' and '([^']*)' for description")]
        public void ThenTheNewServiceListingRecordShouldNotBeUpdatedSuccessfullyAndIShouldSeeTheAndForDescription(string message, string fieldErrorMessage)
        {
            string popUpMessage = commonDriver.popUpComponent.getMessage();
            Assert.AreEqual(message, popUpMessage, "Actual and expected service listing record do not match.");

            commonDriver.editShareSkillPage.verifyInvalidDescription(fieldErrorMessage);

            CommonDriver.test.Log(Status.Pass, "Unable to update a service listing");
            commonDriver.SaveScreenshot("Edit Service Listing");
        }

        [Given(@"I logged in successfully and navigate to the Manage Listings page to edit the tags")]
        public void GivenILoggedInSuccessfullyAndNavigateToTheManageListingsPageToEditTheTags()
        {
            LoginAndGoToManageListingsPage();
        }

        [When(@"I click on the Edit button and enter '([^']*)', '([^']*)', '([^']*)','([^']*)', '([^']*)', '([^']*)','([^']*)', '([^']*)', '([^']*)', '([^']*)','([^']*)', '([^']*)', '([^']*)', '([^']*)', '([^']*)', '([^']*)' to see if it doesn't save with an invalid tags")]
        public void WhenIClickOnTheEditButtonAndEnterToSeeIfItDoesntSaveWithAnInvalidTags(string title, 
            string description, 
            string category, 
            string subCategory, 
            string tagsToRemove, 
            string tagsToAdd, 
            string serviceType, 
            string locationType, 
            string startDate, 
            string endDate,
            string availableDays, 
            string skillTrade, 
            string credit, 
            string skillExchangeTagsToRemove, 
            string skillExchangeTagsToAdd, 
            string active)
        {
            SaveEditShareSkill(title, 
                description, 
                category, 
                subCategory, 
                tagsToRemove, 
                tagsToAdd, 
                serviceType, 
                locationType, 
                startDate, 
                endDate, 
                availableDays, 
                skillTrade, 
                credit, 
                skillExchangeTagsToRemove, 
                skillExchangeTagsToAdd, 
                active);
        }

        [Then(@"The new Service Listing record should not be updated successfully and I should see the '([^']*)' and '([^']*)' for tags")]
        public void ThenTheNewServiceListingRecordShouldNotBeUpdatedSuccessfullyAndIShouldSeeTheAndForTags(string message, string fieldErrorMessage)
        {
            string popUpMessage = commonDriver.popUpComponent.getMessage();
            Assert.AreEqual(message, popUpMessage, "Actual and expected service listing record do not match.");

            commonDriver.editShareSkillPage.verifyInvalidTags(fieldErrorMessage);
            CommonDriver.test.Log(Status.Pass, "Unable to update a service listing");
            commonDriver.SaveScreenshot("Edit Service Listing");
        }

        [Given(@"I logged in successfully and navigate to the Manage Listings page to edit the start and end date")]
        public void GivenILoggedInSuccessfullyAndNavigateToTheManageListingsPageToEditTheStartAndEndDate()
        {
            LoginAndGoToManageListingsPage();
        }

        [When(@"I click on the Edit button and enter '([^']*)', '([^']*)', '([^']*)','([^']*)', '([^']*)', '([^']*)','([^']*)', '([^']*)', '([^']*)', '([^']*)','([^']*)', '([^']*)', '([^']*)', '([^']*)', '([^']*)', '([^']*)' to see if it doesn't save with an invalid start and end date")]
        public void WhenIClickOnTheEditButtonAndEnterToSeeIfItDoesntSaveWithAnInvalidStartAndEndDate(string title, 
            string description, 
            string category, 
            string subCategory, 
            string tagsToRemove, 
            string tagsToAdd, 
            string serviceType,
            string locationType, 
            string startDate, 
            string endDate, 
            string availableDays, 
            string skillTrade, 
            string credit, 
            string skillExchangeTagsToRemove, 
            string skillExchangeTagsToAdd, 
            string active)
        {
            SaveEditShareSkill(title, 
                description, 
                category, 
                subCategory, 
                tagsToRemove, 
                tagsToAdd, 
                serviceType, 
                locationType, 
                startDate, 
                endDate, 
                availableDays, 
                skillTrade, 
                credit, 
                skillExchangeTagsToRemove, 
                skillExchangeTagsToAdd, 
                active);
        }

        [Then(@"The new Service Listing record should not be updated and I should see the ""([^""]*)"" and ""([^""]*)"" for start and end date")]
        public void ThenTheNewServiceListingRecordShouldNotBeUpdatedAndIShouldSeeTheAndForStartAndEndDate(string message, string fieldErrorMessage)
        {
            string popUpMessage = commonDriver.popUpComponent.getMessage();
            Assert.AreEqual(message, popUpMessage, "Actual and expected service listing record do not match.");

            if (fieldErrorMessage == "Start Date cannot be set to a day in the past")
            {
                commonDriver.editShareSkillPage.verifyInvalidStartDateError(fieldErrorMessage);
            }
            else if (fieldErrorMessage == "Start Date shouldn't be greater than End Date")
            {
                commonDriver.editShareSkillPage.verifyInvalidStartDateError(fieldErrorMessage);
            }

            CommonDriver.test.Log(Status.Pass, "Unable to update a service listing");
            commonDriver.SaveScreenshot("Edit Service Listing");
        }
    }
}
