using AdvancedTaskSpecFlow.Pages.ProfilePageTabs;
using AdvancedTaskSpecFlow.Utilities;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace AdvancedTaskSpecFlow.StepDefinitions
{
    [Binding]
    public class LanguageFeatureStepDefinitions:CommonDriver
    {
        [When(@"Input valid '([^']*)','([^']*)'")]
        public void WhenInputValid(string languageLevel, string languageName)
        {
            //Add new language record
            language.AddNewLanguage(languageName,languageLevel);
        }

        [Then(@"I added new language record successfully")]
        public void ThenIAddedNewLanguageRecordSuccessfully()
        {
            //Check if the language record has been added successfully
            //Check if the new language record has been added
            string checkPopUpMessage = language.GetPopUpmessage();
            string[] newAddedLanguage = language.GetLastLanguage();
            Assert.AreEqual(checkPopUpMessage, newAddedLanguage[0] + " has been added to your languages", "Actual and expected skill record do not match.");
        }
    }
}
