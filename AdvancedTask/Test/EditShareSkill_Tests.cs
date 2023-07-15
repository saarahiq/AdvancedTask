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
        public static List<ShareSkillModel> readNegativeEmptyDescriptionTest()
        {
            var testFiles = new string[]
            {
                "negativeEditDescription_05.json"
            };
            return readShareskillTest(testFiles);
        }
        public static List<ShareSkillModel> readNegativeDescriptionWithOnlySpaceTest()
        {
            var testFiles = new string[]
            {
                "negativeEditDescription_06.json"
            };
            return readShareskillTest(testFiles);
        }
        public static List<ShareSkillModel> readNegativeDescriptionWithSpecialCharactersTest()
        {
            var testFiles = new string[]
            {
                "negativeEditDescription_07.json"
            };
            return readShareskillTest(testFiles);
        }

        public static List<ShareSkillModel> readNegativeDescriptionWithMoreThan600CharactersTest()
        {
            var testFiles = new string[]
            {
                "negativeEditDescription_08.json"
            };
            return readShareskillTest(testFiles);
        }

        public static List<ShareSkillModel> readNegativeRemoveAllTagsTest()
        {
            var testFiles = new string[]
            {
                "negativeEditTags_09.json"
            };
            return readShareskillTest(testFiles);
        }
        public static List<ShareSkillModel> readNegativeAvailableDaysStartDateEmptyTest()
        {
            var testFiles = new string[]
            {
                "negativeEditStartDate_10.json"
            };
            return readShareskillTest(testFiles);
        }

        public static List<ShareSkillModel> readNegativeAvailableDaysStartDateInPastTest()
        {
            var testFiles = new string[]
            {
                "negativeEditStartDate_11.json"
            };
            return readShareskillTest(testFiles);
        }

        public static List<ShareSkillModel> readNegativeAvailableDaysStartDateGreaterThanEndDateTest()
        {
            var testFiles = new string[]
            {
                "negativeEditEndDate_12.json"
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
            shareSkillPage.saveEditShareSkill();
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
            shareSkillPage.saveEditShareSkill();
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
            shareSkillPage.saveEditShareSkill();
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
            shareSkillPage.saveEditShareSkill();
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
            shareSkillPage.saveEditShareSkill();
        }

        [Test, Order(6), Description("Edit the Description with empty input"), TestCaseSource(nameof(readNegativeEmptyDescriptionTest))]
        public void negativeEditEmptyDescription(ShareSkillModel editShareSkill)
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
            shareSkillPage.saveEditShareSkill();
            shareSkillPage.verifyInvalidDescription("Please type a description.");
            shareSkillPage.verifyPopUpMessage("Please complete the form correctly.");
        }

        [Test, Order(7), Description("Edit the Description with only a space input"), TestCaseSource(nameof(readNegativeDescriptionWithOnlySpaceTest))]
        public void negativeEditDescriptionWithOnlySpace(ShareSkillModel editShareSkill)
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
            shareSkillPage.saveEditShareSkill();
            shareSkillPage.verifyInvalidDescription("First character must be an alphabet character or a number.");
            shareSkillPage.verifyPopUpMessage("Please complete the form correctly.");
        }

        [Test, Order(8), Description("Edit the Description with special characters"), TestCaseSource(nameof(readNegativeDescriptionWithSpecialCharactersTest))]
        public void negativeEditDescriptionWithSpecialCharacters(ShareSkillModel editShareSkill)
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
            shareSkillPage.saveEditShareSkill();
            shareSkillPage.verifyInvalidDescription("Special characters are not allowed.");
            shareSkillPage.verifyPopUpMessage("Please complete the form correctly.");
        }

        [Test, Order(9), Description("Edit the Description with characters more than 600"), TestCaseSource(nameof(readNegativeDescriptionWithMoreThan600CharactersTest))]
        public void negativeEditDescriptionWithMoreThan600Characters(ShareSkillModel editShareSkill)
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
            shareSkillPage.saveEditShareSkill();
        }

        [Test, Order(10), Description("Remove all tags and save ShareSkill Listing"), TestCaseSource(nameof(readNegativeRemoveAllTagsTest))]
        public void negativeEditRemoveAllTags(ShareSkillModel editShareSkill)
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
            shareSkillPage.saveEditShareSkill();
            shareSkillPage.verifyInvalidTags("Please enter a tag");
            shareSkillPage.verifyPopUpMessage("Please complete the form correctly.");
        }

        [Test, Order(11), Description("Edit the Start Date with an empty date"), TestCaseSource(nameof(readNegativeAvailableDaysStartDateEmptyTest))]
        public void negativeEditAvailableDaysStartDateWithEmptyDate(ShareSkillModel editShareSkill)
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
            shareSkillPage.saveEditShareSkill();
            shareSkillPage.verifyInvalidStartDateError("Start Date shouldn't be greater than End Date");
            shareSkillPage.verifyPopUpMessage("Please complete the form correctly.");
        }

        [Test, Order(12), Description("Edit the Start Date with a date in the past"), TestCaseSource(nameof(readNegativeAvailableDaysStartDateInPastTest))]
        public void negativeEditAvailableDaysStartDateInThePast(ShareSkillModel editShareSkill)
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
            shareSkillPage.saveEditShareSkill();
            shareSkillPage.verifyInvalidStartDateError("Start Date cannot be set to a day in the past");
            shareSkillPage.verifyPopUpMessage("Please complete the form correctly.");
        }

        [Test, Order(13), Description("Edit the Start Date with a date greater than End Date"), TestCaseSource(nameof(readNegativeAvailableDaysStartDateGreaterThanEndDateTest))]
        public void negativeEditAvailableDaysStartDateGreaterThanEndDate(ShareSkillModel editShareSkill)
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
            shareSkillPage.saveEditShareSkill();
            shareSkillPage.verifyInvalidStartDateError("Start Date shouldn't be greater than End Date");
            shareSkillPage.verifyPopUpMessage("Please complete the form correctly.");
        }
        [Test, Order(14), Description("Cancel updating of Shareskill Listing"), TestCaseSource(nameof(readPositiveEditShareSkillTests))]
        public void cancelUpdatingOfShareskillListing(ShareSkillModel editShareSkill)
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
            shareSkillPage.cancelEditShareSkill();
        }
        
    }
}

