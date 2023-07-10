using AdvancedTask.Models;
using AdvancedTask.Pages;
using AdvancedTask.Utilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTask.Test
{
    public class EditShareSkill_Tests : CommonDriver
    {
        public static List<ShareSkillModel> readShareskillTest(string[] jsonFiles)
        {
            var shareSkills = new List<ShareSkillModel>();
            foreach (var file in jsonFiles)
            {
                ShareSkillModel shareSkill = readShareSkill(file);
                shareSkills.Add(shareSkill);
            };
           return shareSkills;
        }

        public static List<ShareSkillModel> readPositiveEditShareSkillTests()
        {
            var testFiles = new string[]
            {
                "positiveEdit.json"
            };
            return readShareskillTest(testFiles);
        }
        public static List<ShareSkillModel> readNegativeEmptyTitleTest()
        {
            var testFiles = new string[]
            {
                "negativeEditTitle_01.json"
            };
            return readShareskillTest(testFiles);
        }
        public static List<ShareSkillModel> readNegativeTitleWithSymbolsTest()
        {
            var testFiles = new string[]
            {
                "negativeEditTitle_02.json"
            };
            return readShareskillTest(testFiles);
        }
        public static List<ShareSkillModel> readNegativeTitleWithSpecialCharactersTest()
        {
            var testFiles = new string[]
            {
                "negativeEditTitle_03.json"
            };
            return readShareskillTest(testFiles);
        }
        public static List<ShareSkillModel> readNegativeTitleWithMoreThan100CharactersTest()
        {
            var testFiles = new string[]
            {
                "negativeEditTitle_04.json"
            };
            return readShareskillTest(testFiles);
        }

        [Test, Order(1), Description("Edit a ShareSkill successfully"), TestCaseSource(nameof(readPositiveEditShareSkillTests))]
        public void positiveEditNewSkill(ShareSkillModel editShareSkill)
        {
            EditShareSkillPage shareSkillPage = new EditShareSkillPage(driver);
            shareSkillPage.goToManageListingsPage();
            shareSkillPage.editShareSkill(
                editShareSkill.title,
                editShareSkill.description,
                editShareSkill.category,
                editShareSkill.subCategory,
                editShareSkill.tagsToRemove,
                editShareSkill.tagsToAdd,
                editShareSkill.serviceType,
                editShareSkill.locationType,
                editShareSkill.availableDays,
                editShareSkill.skillTrade,
                editShareSkill.credit,
                editShareSkill.skillExchangeTagsToRemove,
                editShareSkill.skillExchangeTagsToAdd,
                editShareSkill.workSampleFilename,
                editShareSkill.active);
        }
        [Test, Order(2), Description("Edit the Title with empty input"), TestCaseSource(nameof(readNegativeEmptyTitleTest))]
        public void negativeEditEmptyTitle(ShareSkillModel editShareSkill)
        {
            EditShareSkillPage shareSkillPage = new EditShareSkillPage(driver);
            shareSkillPage.goToManageListingsPage();
            Thread.Sleep(2000);
            shareSkillPage.editShareSkill(
                editShareSkill.title,
                editShareSkill.description,
                editShareSkill.category,
                editShareSkill.subCategory,
                editShareSkill.tagsToRemove,
                editShareSkill.tagsToAdd,
                editShareSkill.serviceType,
                editShareSkill.locationType,
                editShareSkill.availableDays,
                editShareSkill.skillTrade,
                editShareSkill.credit,
                editShareSkill.skillExchangeTagsToRemove,
                editShareSkill.skillExchangeTagsToAdd,
                editShareSkill.workSampleFilename,
                editShareSkill.active);
            shareSkillPage.verifyInvalidTitle("Please type a Title.");
            shareSkillPage.verifyPopUpMessage("Please complete the form correctly.");

        }

        [Test, Order(3), Description("Edit the Title with Symbols"), TestCaseSource(nameof(readNegativeTitleWithSymbolsTest))]
        public void negativeEditTitleWithSymbols(ShareSkillModel editShareSkill)
        {
            EditShareSkillPage shareSkillPage = new EditShareSkillPage(driver);
            shareSkillPage.goToManageListingsPage();
            shareSkillPage.editShareSkill(
                editShareSkill.title,
                editShareSkill.description,
                editShareSkill.category,
                editShareSkill.subCategory,
                editShareSkill.tagsToRemove,
                editShareSkill.tagsToAdd,
                editShareSkill.serviceType,
                editShareSkill.locationType,
                editShareSkill.availableDays,
                editShareSkill.skillTrade,
                editShareSkill.credit,
                editShareSkill.skillExchangeTagsToRemove,
                editShareSkill.skillExchangeTagsToAdd,
                editShareSkill.workSampleFilename,
                editShareSkill.active);
            shareSkillPage.verifyInvalidTitle("First character must be an alphabet character or a number.");
            shareSkillPage.verifyPopUpMessage("Please complete the form correctly.");

        }

        [Test, Order(4), Description("Edit the Title with special characters"), TestCaseSource(nameof(readNegativeTitleWithSpecialCharactersTest))]
        public void negativeEditTitleWithSpecialCharacters(ShareSkillModel editShareSkill)
        {
            EditShareSkillPage shareSkillPage = new EditShareSkillPage(driver);
            shareSkillPage.goToManageListingsPage();
            shareSkillPage.editShareSkill(
                editShareSkill.title,
                editShareSkill.description,
                editShareSkill.category,
                editShareSkill.subCategory,
                editShareSkill.tagsToRemove,
                editShareSkill.tagsToAdd,
                editShareSkill.serviceType,
                editShareSkill.locationType,
                editShareSkill.availableDays,
                editShareSkill.skillTrade,
                editShareSkill.credit,
                editShareSkill.skillExchangeTagsToRemove,
                editShareSkill.skillExchangeTagsToAdd,
                editShareSkill.workSampleFilename,
                editShareSkill.active);
            shareSkillPage.verifyInvalidTitle("Special characters are not allowed.");
            shareSkillPage.verifyPopUpMessage("Please complete the form correctly.");
        }

        [Test, Order(5), Description("Edit the Title with more than 100 characters"), TestCaseSource(nameof(readNegativeTitleWithMoreThan100CharactersTest))]
        public void negativeEditTitleWithMoreThan100Characters(ShareSkillModel editShareSkill)
        {
            EditShareSkillPage shareSkillPage = new EditShareSkillPage(driver);
            shareSkillPage.goToManageListingsPage();
            shareSkillPage.editShareSkill(
                editShareSkill.title,
                editShareSkill.description,
                editShareSkill.category,
                editShareSkill.subCategory,
                editShareSkill.tagsToRemove,
                editShareSkill.tagsToAdd,
                editShareSkill.serviceType,
                editShareSkill.locationType,
                editShareSkill.availableDays,
                editShareSkill.skillTrade,
                editShareSkill.credit,
                editShareSkill.skillExchangeTagsToRemove,
                editShareSkill.skillExchangeTagsToAdd,
                editShareSkill.workSampleFilename,
                editShareSkill.active);
            
        }
    }
}
