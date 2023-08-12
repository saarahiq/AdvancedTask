using AdvancedTask.Models;
using AdvancedTask.PageObjectComponents;
using AdvancedTask.Pages;
using AdvancedTask.Pages.ProfilePageTabs;
using AdvancedTask.Utilities;
using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTask.Test
{
    public class EducationTests : CommonDriver
    {
        public static List<EducationModel> readEducationTest(string[] jsonFiles)
        {
            var educations = new List<EducationModel>();
            foreach (var file in jsonFiles)
            {
                EducationModel education = readEducation("JSONData\\Education\\" + file);
                educations.Add(education);
            }
            return educations;
        }
        public static List<EducationModel> readPositiveEducationAddTests()
        {
            var testFiles = new string[] {
                "positiveAddNewEducation_01.json" ,
                "positiveAddNewEducation_02.json"
            };
            return readEducationTest(testFiles);
        }
        private static List<EducationModel> readPositiveEditEducationTests()
        {
            var testFile = new string[]
            {
                "positiveEditEducation.json"
            };
            return readEducationTest(testFile);
        }
        private static List<EducationModel> readNegativeAddEducationTests()
        {
            var testFiles = new string[]
            {
                "negativeAddNewEducation_01.json",
                "negativeAddNewEducation_02.json",
                "negativeAddNewEducation_03.json",
                "negativeAddNewEducation_04.json",
                "negativeAddNewEducation_05.json"
            };
            return readEducationTest(testFiles);
        }
        private static List<EducationModel> readNegativeDuplicateEducationTest()
        {
            var testFiles = new string[]
            {
                "negativeAddDuplicateEducation.json"
            };
            return readEducationTest(testFiles);
        }
        private static List<EducationModel> readNegativeEditEducationTests()
        {
            var testFiles = new string[]
            {

                "negativeEditEducation_01.json",
                "negativeEditEducation_02.json",
                "negativeEditEducation_03.json",
                "negativeEditEducation_04.json",
                "negativeEditEducation_05.json"
            };
            return readEducationTest(testFiles);
        }
        [SetUp]
        public void educationTestsSetUp()
        {
            ProfilePage profilePage = new ProfilePage(driver);
            profilePage.goToEducationTab();
        }
        [Test, Order(1), Description("Add Education Successfully"), TestCaseSource(nameof(readPositiveEducationAddTests))]
        public void positiveAddNewEducation(EducationModel addEducation)
        {
            Education educationPage = new Education(driver);
            educationPage.addNewEducation(addEducation.universityName, addEducation.country, addEducation.title, addEducation.degree, addEducation.yearOfGraduation);

            //Check if the New Education records have been added successfully
            PopUpComponent popUpComponent = new PopUpComponent(driver);
            string popUpMessage = popUpComponent.getMessage();
            string[] newEducationAdded = educationPage.getLatestEducation();
            Assert.AreEqual(popUpMessage, "Education has been added", "Could not verify that the Education was added.");
            Assert.AreEqual(addEducation.universityName, newEducationAdded[0], "Actual and expected Education university name does not match");
            Assert.AreEqual(addEducation.country, newEducationAdded[1], "Actual and expected Education country do not match");
            Assert.AreEqual(addEducation.title, newEducationAdded[2], "Actual and expected Education title do not match");
            Assert.AreEqual(addEducation.degree, newEducationAdded[3], "Actual and expected Education degree do not match");
            Assert.AreEqual(addEducation.yearOfGraduation, newEducationAdded[4], "Actual and expected Education year do not match");
            //logging to extent reports
            test.Log(Status.Pass, "Successfully verified creating an Education record");
        }

        [Test, Order(2), Description("Edit an existing Education record successfully"), TestCaseSource(nameof(readPositiveEditEducationTests))]
        public void positiveEditEducation(EducationModel editEducation)
        {
            Education educationPage = new Education(driver);
            educationPage.editEducation(editEducation.universityName, editEducation.country, editEducation.title, editEducation.degree, editEducation.yearOfGraduation);

            //Check if the New Education records have been added successfully
            PopUpComponent popUpComponent = new PopUpComponent(driver);
            string popUpMessage = popUpComponent.getMessage();
            string[] updatedEducation = educationPage.getFirstEducation();
            Assert.AreEqual(popUpMessage, "Education as been updated", "Could not verify that the Education was added.");
            Assert.AreEqual(editEducation.universityName, updatedEducation[0], "Actual and expected Education university name does not match");
            Assert.AreEqual(editEducation.country, updatedEducation[1], "Actual and expected Education country do not match");
            Assert.AreEqual(editEducation.title, updatedEducation[2], "Actual and expected Education title do not match");
            Assert.AreEqual(editEducation.degree, updatedEducation[3], "Actual and expected Education degree do not match");
            Assert.AreEqual(editEducation.yearOfGraduation, updatedEducation[4], "Actual and expected Education year do not match");
            //logging to extent reports
            test.Log(Status.Pass, "Successfully verified updating an Education record");
        }

        [Test, Order(3), Description("Enter an Education without Required Fields"), TestCaseSource(nameof(readNegativeAddEducationTests))]
        public void negativeAddNewEducation(EducationModel negativeEducation)
        {
            Education educationPage = new Education(driver);
            educationPage.addNewEducation(negativeEducation.universityName, negativeEducation.country, negativeEducation.title, negativeEducation.degree, negativeEducation.yearOfGraduation);

            PopUpComponent popUpComponent = new PopUpComponent(driver);
            string popUpMessage = popUpComponent.getMessage();
            Assert.AreEqual("Please enter all the fields", popUpMessage, "Actual and expected education do not match.");
            //logging to extent reports
            test.Log(Status.Pass, "Successfully verified an Education record cannot be created without entering the reqiured fields");
        }

        [Test, Order(4), Description("Enter a Duplicate Education"), TestCaseSource(nameof(readNegativeDuplicateEducationTest))]
        public void addDuplicateEducation(EducationModel duplicateEducation)
        {
            Education educationPage = new Education(driver);
            educationPage.addNewEducation(duplicateEducation.universityName, duplicateEducation.country, duplicateEducation.title, duplicateEducation.degree, duplicateEducation.yearOfGraduation);

            // Check if the New Education record has not been added
            PopUpComponent popUpComponent = new PopUpComponent(driver);
            string popUpMessage = popUpComponent.getMessage();
            Assert.AreEqual("This information is already exist.", popUpMessage, "Actual and expected education record do not match.");
            //logging to extent reports
            test.Log(Status.Pass, "Successfully verified a duplicate Education record cannot be created");
        }

        [Test, Order(5), Description("Edit an Education without Required Fields"), TestCaseSource(nameof(readNegativeEditEducationTests))]
        public void negativeEditEducation(EducationModel negativeEducation)
        {
            Education educationPage = new Education(driver);
            educationPage.editEducation(negativeEducation.universityName, negativeEducation.country, negativeEducation.title, negativeEducation.degree, negativeEducation.yearOfGraduation);

            // Check if the New Education record has not been added
            PopUpComponent popUpComponent = new PopUpComponent(driver);
            string popUpMessage = popUpComponent.getMessage();
            Assert.AreEqual("Please enter all the fields", popUpMessage, "Actual and expected education record do not match.");
            //logging to extent reports
            test.Log(Status.Pass, "Successfully verified an Education record cannot be updated without entering the reqiured fields");
        }

        [Test, Order(6), Description("Delete an existing Education record successfully")]
        public void deleteEducation()
        {
            Education educationPage = new Education(driver);
            educationPage.deleteEducation();

            // Check if the Education record has been deleted successfully
            PopUpComponent popUpComponent = new PopUpComponent(driver);
            string popUpMessage = popUpComponent.getMessage();
            Assert.AreEqual("Education entry successfully removed", popUpMessage, "Actual and expected education record do not match.");
            //logging to extent reports
            test.Log(Status.Pass, "Successfully verified deleting an Education record");
        }
    }
}

