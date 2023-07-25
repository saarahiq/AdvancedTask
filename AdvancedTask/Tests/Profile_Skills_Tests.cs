using AdvancedTask.Models;
using AdvancedTask.PageObjectComponents;
using AdvancedTask.Pages;
using AdvancedTask.Pages.ProfilePageTabs;
using AdvancedTask.Utilities;
using AventStack.ExtentReports;
using MongoDB.Driver;
using NUnit.Framework;
using OpenQA.Selenium;
using RazorEngine.Compilation.ImpromptuInterface.InvokeExt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTask.Test
{
    [TestFixture]
    [Parallelizable]
    public class ProfileSkillsTests : CommonDriver
    {
        public static List<SkillModel> readSkillsTest(string[] jsonFiles)
        {
            var skills = new List<SkillModel>();
            foreach (var file in jsonFiles)
            {
                SkillModel skill = readSkills(file);
                skills.Add(skill);
            }
            return skills;
        }
        private static List<SkillModel> readPositiveAddSkillTests()
        {
            var testFiles = new string[]
            {
                "positiveAddNewSkill_01.json",
                "positiveAddNewSkill_02.json"

            };
            return readSkillsTest(testFiles);
        }
        private static List<SkillModel> readPositiveEditSkillTests()
        {
            var testFile = new string[]
            {
                "positiveEditSkill.json"
            };
            return readSkillsTest(testFile);
        }
        private static List<SkillModel> readDeleteSkillTests()
        {
            var testFile = new string[]
            {
                "positiveEditSkill.json"
            };
            return readSkillsTest(testFile);
        }
        private static List<SkillModel> readNegativeAddSkillTests()
        {
            var testFiles = new string[]
            {
                "negativeAddNewSkill_01.json",
                "negativeAddNewSkill_02.json"
            };
            return readSkillsTest(testFiles);
        }
        private static List<SkillModel> readNegativeDuplicateSkillTest()
        {
            var testFiles = new string[]
            {
                "negativeAddDuplicateSkill.json"
            };
            return readSkillsTest(testFiles);
        }
        private static List<SkillModel> readNegativeEditSkillTests()
        {
            var testFiles = new string[]
            {
                "negativeEditSkill_01.json",
                "negativeEditSkill_02.json"
            };
            return readSkillsTest(testFiles);
        }
        [SetUp]
        public void skillsTestsSetUp()
        {
            ProfilePage profilePage = new ProfilePage(driver);
            profilePage.goToSkillsTab();
        }

        [Test, Order(1), Description("Add Skill successfully"), TestCaseSource(nameof(readPositiveAddSkillTests))]
        public void positiveAddNewSkill(SkillModel addSkill)
        {
            
            Skills skillsPage = new Skills(driver, test);
            skillsPage.addNewSkill(addSkill.skill, addSkill.skillLevel);

            //Check if the New Skill records have been added successfully
            PopUpComponent popUpComponent = new PopUpComponent(driver);
            string popUpMessage = popUpComponent.getMessage();
            string[] newSkillAdded = skillsPage.getLatestSkill();
            Assert.AreEqual(popUpMessage, newSkillAdded[0] + " has been added to your skills", "Actual and expected skill record do not match");
            Assert.AreEqual(addSkill.skill, newSkillAdded[0], "Actual and expected skill record do not match");
            Assert.AreEqual(addSkill.skillLevel, newSkillAdded[1], "Actual and expected skill record do not match");
            //logging to extent reports
            test.Log(Status.Pass, "Successfully verified creating a Skill record");
        }
        [Test, Order(2), Description("Edit an existing Skill record successfully"), TestCaseSource(nameof(readPositiveEditSkillTests))]
        public void positiveEditSkill(SkillModel editSkill)
        {
            Skills skillsPage = new Skills(driver, test);
            skillsPage.editSkills(editSkill.skill, editSkill.skillLevel);

            //Check if the Skill record had been updated successfully
            PopUpComponent popUpComponent = new PopUpComponent(driver);
            string popUpMessage = popUpComponent.getMessage();
            string[] updatedSkillAdded = skillsPage.getFirstSkill();
            Assert.AreEqual(popUpMessage, updatedSkillAdded[0] + " has been updated to your skills", "Actual and expected skill record do not match");
            Assert.AreEqual(editSkill.skill, updatedSkillAdded[0], "Actual and expected skill record do not match");
            Assert.AreEqual(editSkill.skillLevel, updatedSkillAdded[1], "Actual and expected skill record do not match");
            //logging to extent reports
            test.Log(Status.Pass, "Successfully verified updating a Skill record");
        }
        [Test, Order(3), Description("Enter a Skill without Required Fields"), TestCaseSource(nameof(readNegativeAddSkillTests))]
        public void negativeAddNewSkill(SkillModel negativeSkill)
        {
            Skills skillsPage = new Skills(driver, test);
            skillsPage.addNewSkill(negativeSkill.skill, negativeSkill.skillLevel);

            // Check if the New Certification record has been deleted
            PopUpComponent popUpComponent = new PopUpComponent(driver);
            string popUpMessage = popUpComponent.getMessage();
            Assert.AreEqual("Please enter skill and experience level", popUpMessage, "Actual and expected skill record do not match.");
            //logging to extent reports
            test.Log(Status.Pass, "Successfully verified a Skill record cannot be created without entering the reqiured fields");
        }
        [Test, Order(4), Description("Enter a Duplicate Skill"), TestCaseSource(nameof(readNegativeDuplicateSkillTest))]
        public void addDuplicateSkill(SkillModel duplicateSkill)
        {
            Skills skillsPage = new Skills(driver, test);
            skillsPage.addNewSkill(duplicateSkill.skill, duplicateSkill.skillLevel);

            // Check if the New Skill record has not been added
            PopUpComponent popUpComponent = new PopUpComponent(driver);
            string popUpMessage = popUpComponent.getMessage();
            Assert.AreEqual("This skill is already exist in your skill list.", popUpMessage, "Actual and expected certification record do not match.");
            //logging to extent reports
            test.Log(Status.Pass, "Successfully verified a duplicate Skill record cannot be created");
        }
        [Test, Order(5), Description("Edit a Skill without Required Fields"), TestCaseSource(nameof(readNegativeEditSkillTests))]
        public void negativeEditSkill(SkillModel negativeSkill)
        {
            Skills skillsPage = new Skills(driver, test);
            skillsPage.editSkills(negativeSkill.skill, negativeSkill.skillLevel);

            //Check if the Skill record has not been edited
            PopUpComponent popUpComponent = new PopUpComponent(driver);
            string popUpMessage = popUpComponent.getMessage();
            Assert.AreEqual("Please enter skill and experience level", popUpMessage, "Actual and expected skill record do not match.");
            //logging to extent reports
            test.Log(Status.Pass, "Successfully verified a Skill record cannot be updated without entering the reqiured fields");
        }
       [Test, Order(6), Description("Delete an existing Skill record successfully"), TestCaseSource(nameof(readDeleteSkillTests))]
        public void deleteSkill(SkillModel deleteSkill)
        {
            Skills skillsPage = new Skills(driver, test);
            skillsPage.deleteSkill(deleteSkill.skill, deleteSkill.skillLevel);

            // Check if the Skill record has been deleted successfully
            PopUpComponent popUpComponent = new PopUpComponent(driver);
            string popUpMessage = popUpComponent.getMessage();
            Assert.AreEqual($"{deleteSkill.skill} has been deleted", popUpMessage, "Actual and expected certification record do not match.");
            //logging to extent reports
            test.Log(Status.Pass, "Successfully verified deleting a Skill record");
        }

    }
}
