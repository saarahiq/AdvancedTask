using AdvancedTask.Models;
using AdvancedTask.Utilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTask.Test
{
   
    public class Language_Tests : CommonDriver
    {
        public static ICollection<LanguageModel> ReadLanguageTests(string[] jsonFiles)
        {
            var languages = new List<LanguageModel>();
            foreach (var file in jsonFiles)
            {
                LanguageModel language = ReadTestLanguage("JSONData\\Language\\" + file);
                languages.Add(language);
            }
            return languages;
        }
        public static ICollection<LanguageModel> ReadPositiveAddTests()
        {
            return ReadLanguageTests(new string[] { 
                "positiveAddNewlanguage_01.json" ,

                "positiveAddNewlanguage_02.json"
            });
        }
        public static ICollection<LanguageModel> ReadPositiveEditTests()
        {
            return ReadLanguageTests(new string[] {
                "positiveEditlanguage.json"
            });
        }
        public static ICollection<LanguageModel> ReadNegativeAddTests()
        {
            return ReadLanguageTests(new string[] {
                "negativeAddNewLanguage_01.json",
                "negativeAddNewLanguage_02.json",
                
               });
        }
        public static ICollection<LanguageModel> ReadNegativeAddRepeatTests()
        {
            return ReadLanguageTests(new string[] {
                "negativeAddRepeatLanguage_01.json"
               });
        }
        public static ICollection<LanguageModel> ReadNegativeEditTests()
        {
            return ReadLanguageTests(new string[] {
                "negativeEditLanguage_01.json",
                "negativeEditLanguage_02.json"
               });
        }

        [Test, Order(1), Description("Check if user is able to add new language"), TestCaseSource(nameof(ReadPositiveAddTests))]
        public void TestAddNewLanguageSuccessfully(LanguageModel language)
        {
            languagePage.AddNewLanguage(language);
            //Check if the new language record has been added
            string checkPopUpMessage = languagePage.GetPopUpmessage();
            string[] newAddedLanguage = languagePage.GetLastLanguage();
            Assert.AreEqual(checkPopUpMessage, newAddedLanguage[0] + " has been added to your languages", "Actual and expected skill record do not match.");
        }

        [Test, Order(2), Description("Check if user is able to edit the first language"), TestCaseSource(nameof(ReadPositiveEditTests))]
        public void TestEditLanguageSuccessfully(LanguageModel language)
        {
            languagePage.EditFirstLanguage(language);

            //Check if the new language record has been updated
            string checkPopUpMessage = languagePage.GetPopUpmessage();
            string[] newEditedLanguage = languagePage.GetFirstLanguage();
            
            Assert.AreEqual(checkPopUpMessage, newEditedLanguage[0] + " has been updated to your languages", "Actual and expected skill record do not match.");
        }
        [Test, Order(3), Description("Check if user is able to delete the first language")]
        public void TestDeleteLanguageSuccessfully()
        {
            languagePage.DeleteFirstlanguage();

            //Check if the  language record has been deleted
            string[] deletedLanguage = languagePage.GetFirstLanguage();
            string checkPopUpMessage = languagePage.GetPopUpmessage();
            Assert.AreEqual(checkPopUpMessage, deletedLanguage[0] + " has been deleted from your languages", "Actual and expected skill record do not match.");
        }

        [Test, Order(4), Description("Check if user is not able to add new language"), TestCaseSource(nameof(ReadNegativeAddTests))]
        public void TestAddNewLanguageFailed(LanguageModel language)
        {
            languagePage.AddNewLanguage(language);
            //Check if the new language record has not been added 
            string checkPopUpMessage = languagePage.GetPopUpmessage();
            Assert.AreEqual("Please enter language and level", checkPopUpMessage,  "Actual and expected skill record do not match.");
        }

        [Test, Order(5), Description("Check if user is not able to add repeat language"), TestCaseSource(nameof(ReadNegativeAddRepeatTests))]
        public void TestAddRepeatLanguageFailed(LanguageModel language)
        {
            languagePage.AddNewLanguage(language);
            //Check if the new language record has not been added 
            string checkPopUpMessage = languagePage.GetPopUpmessage();
            Assert.AreEqual("This language is already exist in your language list.", checkPopUpMessage, "Actual and expected skill record do not match.");
        }
        [Test, Order(6), Description("Check if user is not able to edit language"), TestCaseSource(nameof(ReadNegativeEditTests))]
        public void TestEditLanguageFailed(LanguageModel language)
        {
            languagePage.EditFirstLanguage(language);
            //Check if the language record has not been edited 
            string checkPopUpMessage = languagePage.GetPopUpmessage();
            Assert.AreEqual("Please enter language and level", checkPopUpMessage,  "Actual and expected skill record do not match.");
        }

        
    }
}
