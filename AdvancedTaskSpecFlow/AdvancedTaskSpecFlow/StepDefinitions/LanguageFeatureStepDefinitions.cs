using AdvancedTaskSpecFlow.Pages.ProfilePageTabs;
using AdvancedTaskSpecFlow.Utilities;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace AdvancedTaskSpecFlow.StepDefinitions
{
    [Binding]
    public class LanguageFeatureStepDefinitions
    {
        private readonly CommonDriver commonDriver;
        public LanguageFeatureStepDefinitions(CommonDriver commonDriver)
        {
            this.commonDriver = commonDriver;
        }

        [When(@"Input valid '([^']*)','([^']*)'")]
        public void WhenInputValid(string languageLevel, string languageName)
        {
            //Add new language record
            commonDriver.language.AddNewLanguage(languageName,languageLevel);
        }

        [Then(@"I added new language record successfully")]
        public void ThenIAddedNewLanguageRecordSuccessfully()
        {
            //Check if the language record has been added successfully
            //Check if the new language record has been added
            string checkPopUpMessage = commonDriver.language.GetPopUpmessage();
            string[] newAddedLanguage = commonDriver.language.GetLastLanguage();
            Assert.AreEqual(checkPopUpMessage, newAddedLanguage[0] + " has been added to your languages", "Actual and expected skill record do not match.");
        }
    }
}
