﻿using AdvancedTask.Models;
using AdvancedTask.PageObjectComponents;
using AdvancedTask.Pages;
using AdvancedTask.Utilities;
using AventStack.ExtentReports;
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
                ShareSkillModel shareSkill = readShareSkill("JSONData\\ShareSkill\\" + file);
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
        [SetUp]
        public void editShareSkillSetUp()
        {
            NavigationMenu navigationMenu = new NavigationMenu(driver);
            navigationMenu.goToManageListingsButton();
        }
        [Test, Order(1), Description("Edit a ShareSkill successfully"), TestCaseSource(nameof(readPositiveEditShareSkillTests))]
        public void positiveEditNewSkill(ShareSkillModel editShareSkill)
        {
            EditShareSkillPage shareSkillPage = new EditShareSkillPage(driver);
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
            //logging to extent reports
            test.Log(Status.Pass, "Successfully updated a service listing");
        }
        [Test, Order(2), Description("Edit the Title with empty input"), TestCaseSource(nameof(readNegativeEmptyTitleTest))]
        public void negativeEditEmptyTitle(ShareSkillModel editShareSkill)
        {
            EditShareSkillPage shareSkillPage = new EditShareSkillPage(driver);
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
            PopUpComponent popUpComponent = new PopUpComponent(driver);
            string popUpMessage = popUpComponent.getMessage();
            Assert.AreEqual("Please complete the form correctly.", popUpMessage, "Actual and expected popup message do not match.");
            //logging to extent reports
            test.Log(Status.Pass, "Successfully verified Title field cannot be empty");
        }

        [Test, Order(3), Description("Edit the Title with Symbols"), TestCaseSource(nameof(readNegativeTitleWithSymbolsTest))]
        public void negativeEditTitleWithSymbols(ShareSkillModel editShareSkill)
        {
            EditShareSkillPage shareSkillPage = new EditShareSkillPage(driver);
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
            PopUpComponent popUpComponent = new PopUpComponent(driver);
            string popUpMessage = popUpComponent.getMessage();
            Assert.AreEqual("Please complete the form correctly.", popUpMessage, "Actual and expected popup message do not match.");
            //logging to extent reports
            test.Log(Status.Pass, "Successfully verified Title field cannot have symbols");
        }

        [Test, Order(4), Description("Edit the Title with special characters"), TestCaseSource(nameof(readNegativeTitleWithSpecialCharactersTest))]
        public void negativeEditTitleWithSpecialCharacters(ShareSkillModel editShareSkill)
        {
            EditShareSkillPage shareSkillPage = new EditShareSkillPage(driver);
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
            PopUpComponent popUpComponent = new PopUpComponent(driver);
            string popUpMessage = popUpComponent.getMessage();
            Assert.AreEqual("Please complete the form correctly.", popUpMessage, "Actual and expected popup message do not match.");
            //logging to extent reports
            test.Log(Status.Pass, "Successfully verified Title field cannot have special characters");
        }

        [Test, Order(5), Description("Edit the Title with more than 100 characters"), TestCaseSource(nameof(readNegativeTitleWithMoreThan100CharactersTest))]
        public void negativeEditTitleWithMoreThan100Characters(ShareSkillModel editShareSkill)
        {
            EditShareSkillPage shareSkillPage = new EditShareSkillPage(driver);
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
            //logging to extent reports
            test.Log(Status.Pass, "Successfully verified Title field cannot have more than 100 characters");
        }

        [Test, Order(6), Description("Edit the Description with empty input"), TestCaseSource(nameof(readNegativeEmptyDescriptionTest))]
        public void negativeEditEmptyDescription(ShareSkillModel editShareSkill)
        {
            EditShareSkillPage shareSkillPage = new EditShareSkillPage(driver);
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
            PopUpComponent popUpComponent = new PopUpComponent(driver);
            string popUpMessage = popUpComponent.getMessage();
            Assert.AreEqual("Please complete the form correctly.", popUpMessage, "Actual and expected popup message do not match.");
            //logging to extent reports
            test.Log(Status.Pass, "Successfully verified Description field cannot be empty");
        }

        [Test, Order(7), Description("Edit the Description with only a space input"), TestCaseSource(nameof(readNegativeDescriptionWithOnlySpaceTest))]
        public void negativeEditDescriptionWithOnlySpace(ShareSkillModel editShareSkill)
        {
            EditShareSkillPage shareSkillPage = new EditShareSkillPage(driver);
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
            PopUpComponent popUpComponent = new PopUpComponent(driver);
            string popUpMessage = popUpComponent.getMessage();
            Assert.AreEqual("Please complete the form correctly.", popUpMessage, "Actual and expected popup message do not match.");
            //logging to extent reports
            test.Log(Status.Pass, "Successfully verified Description field cannot start with invalid character");
        }

        [Test, Order(8), Description("Edit the Description with special characters"), TestCaseSource(nameof(readNegativeDescriptionWithSpecialCharactersTest))]
        public void negativeEditDescriptionWithSpecialCharacters(ShareSkillModel editShareSkill)
        {
            EditShareSkillPage shareSkillPage = new EditShareSkillPage(driver);
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
            PopUpComponent popUpComponent = new PopUpComponent(driver);
            string popUpMessage = popUpComponent.getMessage();
            Assert.AreEqual("Please complete the form correctly.", popUpMessage, "Actual and expected popup message do not match.");
            //logging to extent reports
            test.Log(Status.Pass, "Successfully verified Title field cannot have special characters");
        }

        [Test, Order(9), Description("Edit the Description with characters more than 600"), TestCaseSource(nameof(readNegativeDescriptionWithMoreThan600CharactersTest))]
        public void negativeEditDescriptionWithMoreThan600Characters(ShareSkillModel editShareSkill)
        {
            EditShareSkillPage shareSkillPage = new EditShareSkillPage(driver);
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
            //logging to extent reports
            test.Log(Status.Pass, "Successfully verified Title field cannot have more than 600 characters");
        }

        [Test, Order(10), Description("Remove all tags and save ShareSkill Listing"), TestCaseSource(nameof(readNegativeRemoveAllTagsTest))]
        public void negativeEditRemoveAllTags(ShareSkillModel editShareSkill)
        {
            EditShareSkillPage shareSkillPage = new EditShareSkillPage(driver);
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
            PopUpComponent popUpComponent = new PopUpComponent(driver);
            string popUpMessage = popUpComponent.getMessage();
            Assert.AreEqual("Please complete the form correctly.", popUpMessage, "Actual and expected popup message do not match.");
            //logging to extent reports
            test.Log(Status.Pass, "Successfully verified Tags field cannot be empty");
        }

        [Test, Order(11), Description("Edit the Start Date with an empty date"), TestCaseSource(nameof(readNegativeAvailableDaysStartDateEmptyTest))]
        public void negativeEditAvailableDaysStartDateWithEmptyDate(ShareSkillModel editShareSkill)
        {
            EditShareSkillPage shareSkillPage = new EditShareSkillPage(driver);
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
            PopUpComponent popUpComponent = new PopUpComponent(driver);
            string popUpMessage = popUpComponent.getMessage();
            Assert.AreEqual("Please complete the form correctly.", popUpMessage, "Actual and expected popup message do not match.");
            //logging to extent reports
            test.Log(Status.Pass, "Successfully verified Title field cannot have symbols");
        }

        [Test, Order(12), Description("Edit the Start Date with a date in the past"), TestCaseSource(nameof(readNegativeAvailableDaysStartDateInPastTest))]
        public void negativeEditAvailableDaysStartDateInThePast(ShareSkillModel editShareSkill)
        {
            EditShareSkillPage shareSkillPage = new EditShareSkillPage(driver);
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
            PopUpComponent popUpComponent = new PopUpComponent(driver);
            string popUpMessage = popUpComponent.getMessage();
            Assert.AreEqual("Please complete the form correctly.", popUpMessage, "Actual and expected popup message do not match.");
            //logging to extent reports
            test.Log(Status.Pass, "Successfully verified Start date field cannot have a past date");
        }

        [Test, Order(13), Description("Edit the Start Date with a date greater than End Date"), TestCaseSource(nameof(readNegativeAvailableDaysStartDateGreaterThanEndDateTest))]
        public void negativeEditAvailableDaysStartDateGreaterThanEndDate(ShareSkillModel editShareSkill)
        {
            EditShareSkillPage shareSkillPage = new EditShareSkillPage(driver);
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
            PopUpComponent popUpComponent = new PopUpComponent(driver);
            string popUpMessage = popUpComponent.getMessage();
            Assert.AreEqual("Please complete the form correctly.", popUpMessage, "Actual and expected popup message do not match.");
            //logging to extent reports
            test.Log(Status.Pass, "Successfully verified Start date field cannot be greater than the End date");
        }
        [Test, Order(14), Description("Cancel updating of Shareskill Listing"), TestCaseSource(nameof(readPositiveEditShareSkillTests))]
        public void cancelUpdatingOfShareskillListing(ShareSkillModel editShareSkill)
        {
            EditShareSkillPage shareSkillPage = new EditShareSkillPage(driver);
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
            //logging to extent reports
            test.Log(Status.Pass, "Successfully verified Service listing was not updated");
        }
        
    }
}

