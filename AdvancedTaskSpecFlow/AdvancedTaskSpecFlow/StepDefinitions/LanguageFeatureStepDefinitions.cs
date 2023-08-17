using AdvancedTaskSpecFlow.Pages.ProfilePageTabs;
using AdvancedTaskSpecFlow.Utilities;
using Microsoft.CodeAnalysis;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace AdvancedTaskSpecFlow.StepDefinitions
{
    [Binding]
    public class LanguageFeatureStepDefinitions
    {
        private readonly CommonDriver commonDriver;
        private string[] deletedLanguage = new string[0];
        public LanguageFeatureStepDefinitions(CommonDriver commonDriver)
        {
            this.commonDriver = commonDriver;
        }

        [When(@"Input valid '([^']*)','([^']*)'")]
        public void WhenInputValid(string languageName,string languageLevel)
        {
            //Add new language record with valid details
            commonDriver.language.AddNewLanguage(languageName,languageLevel);
        }

        [Then(@"I added new language record successfully")]
        public void ThenIAddedNewLanguageRecordSuccessfully()
        {
            //Check if the language record has been added successfully
            string checkPopUpMessage = commonDriver.language.GetPopUpmessage();
            string[] newAddedLanguage = commonDriver.language.GetLastLanguage();
            Assert.AreEqual(checkPopUpMessage, newAddedLanguage[0] + " has been added to your languages", "Actual and expected skill record do not match.");
        }

        [When(@"Input invalid '([^']*)','([^']*)'")]
        public void WhenInputInvalid(string languageName, string languageLevel)
        {
            //Add new language record with invalid details
            commonDriver.language.AddNewLanguage(languageName, languageLevel);
        }

        [Then(@"I added new language record failed")]
        public void ThenIAddedNewLanguageRecordFailed()
        {
            //Check if the language record has been added failed
            string checkPopUpMessage = commonDriver.language.GetPopUpmessage();
            Assert.AreEqual(checkPopUpMessage, "Please enter language and level", "Actual and expected skill record do not match.");
        }

        [When(@"Input repeat '([^']*)','([^']*)'")]
        public void WhenInputRepeat(string languageName, string languageLevel)
        {
            //Add new language record with repeat details
            commonDriver.language.AddNewLanguage(languageName, languageLevel);
        }

        [Then(@"I can't add new language record with repeat details")]
        public void ThenICantAddNewLanguageRecordWithRepeatDetails()
        {
            //Check if the language record has been added failed with repeat details
            string checkPopUpMessage = commonDriver.language.GetPopUpmessage();
            Assert.AreEqual(checkPopUpMessage, "This language is already exist in your language list.", "Actual and expected skill record do not match.");
        }

        [When(@"Edit first language record with valid '([^']*)','([^']*)'")]
        public void WhenEditFirstLanguageRecordWithValid(string languageName, string languageLevel)
        {
            //Edit the first language record with valid details
            commonDriver.language.EditFirstLanguage(languageName, languageLevel);
        }

        [Then(@"The first language record has been edited successfully")]
        public void ThenTheFirstLanguageRecordHasBeenEditedSuccessfully()
        {
            //Check if the first language record has been edited successfully
            string checkPopUpMessage = commonDriver.language.GetPopUpmessage();
            string[] updatedLanguage = commonDriver.language.GetFirstLanguage();
            Assert.AreEqual(checkPopUpMessage, updatedLanguage[0] + " has been updated to your languages", "Actual and expected skill record do not match.");
        }

        [When(@"Edit first language record with invalid '([^']*)','([^']*)'")]
        public void WhenEditFirstLanguageRecordWithInvalid(string languageName, string languageLevel)
        {
            //Edit the first language record with invalid details
            commonDriver.language.EditFirstLanguage(languageName, languageLevel);
        }

        [Then(@"The first language record has been edited failed")]
        public void ThenTheFirstLanguageRecordHasBeenEditedFailed()
        {
            //Check if the first language record has been edited failed
            string checkPopUpMessage = commonDriver.language.GetPopUpmessage();
            Assert.AreEqual(checkPopUpMessage, "Please enter language and level", "Actual and expected skill record do not match.");
        }

        [When(@"Edit first langiage record with repeat '([^']*)','([^']*)'")]
        public void WhenEditFirstLangiageRecordWithRepeat(string languageName, string languageLevel)
        {
            //Edit the first language record with repeat details
            commonDriver.language.EditFirstLanguage(languageName, languageLevel);
        }

        [Then(@"I edit first language record with repeat details failed")]
        public void ThenIEditFirstLanguageRecordWithRepeatDetailsFailed()
        {
            //Check if the language record has been added failed with repeat details
            string checkPopUpMessage = commonDriver.language.GetPopUpmessage();
            Assert.AreEqual(checkPopUpMessage, "This language is already added to your language list.", "Actual and expected skill record do not match.");
        }


        [When(@"I delete an existing language record '([^']*)'")]
        public void WhenIDeleteAnExistingLanguageRecord(string languageName)
        {
            //Delete an existing language record
            commonDriver.language.Deletelanguage(languageName);
        }

        [Then(@"The language record '([^']*)'should be deleted successfully")]
        public void ThenTheLanguageRecordShouldBeDeletedSuccessfully(string languageName)
        {
            //Check the language record has been deleted successfully
            string checkPopUpMessage = commonDriver.language.GetPopUpmessage();
            Assert.AreEqual(checkPopUpMessage, languageName + " has been deleted from your languages", "Actual and expected skill record do not match.");
        }


    }
}
