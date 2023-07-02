using AdvancedTask.Models;
using AdvancedTask.Pages.ProfilePage;
using AdvancedTask.Utilities;
using MongoDB.Driver;
using NUnit.Framework;
using OpenQA.Selenium;
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
        [Test, Order(1), Description("Add Skill successfully"), TestCaseSource(nameof(readPositiveAddSkillTests))]
        public void positiveAddNewSkill(SkillModel addSkill)
        {
            Skills skillsPage = new Skills(driver);
            skillsPage.addNewSkill(addSkill.skill, addSkill.skillLevel);

            //Check if the New Skill records have been added successfully
            string popUpMessage = skillsPage.getPopUpMessage();
            string[] newSkillAdded = skillsPage.getLatestSkill();
            Assert.AreEqual(popUpMessage, newSkillAdded[0] + " has been added to your skills", "Actual and expected skill record do not match");
            Assert.AreEqual(addSkill.skill, newSkillAdded[0], "Actual and expected skill record do not match");
            Assert.AreEqual(addSkill.skillLevel, newSkillAdded[1], "Actual and expected skill record do not match");
        }
        [Test, Order(2), Description("Edit an existing Skill record successfully"), TestCaseSource(nameof(readPositiveEditSkillTests))]
        public void positiveEditSkill(SkillModel editSkill)
        {
            Skills skillsPage = new Skills(driver);
            skillsPage.editSkills(editSkill.skill, editSkill.skillLevel);

            //Check if the Skill record had been updated successfully
            string popUpMessage = skillsPage.getPopUpMessage();
            string[] updatedSkillAdded = skillsPage.getFirstSkill();
            Assert.AreEqual(popUpMessage, updatedSkillAdded[0] + " has been updated to your skills", "Actual and expected skill record do not match");
            Assert.AreEqual(editSkill.skill, updatedSkillAdded[0], "Actual and expected skill record do not match");
            Assert.AreEqual(editSkill.skillLevel, updatedSkillAdded[1], "Actual and expected skill record do not match");
        }
        [Test, Order(3), Description("Enter a Skill without Required Fields"), TestCaseSource(nameof(readNegativeAddSkillTests))]
        public void negativeAddNewSkill(SkillModel negativeSkill)
        {
            Skills skillsPage = new Skills(driver);
            skillsPage.addNewSkill(negativeSkill.skill, negativeSkill.skillLevel);

            // Check if the New Certification record has been deleted
            string popUpMessage = skillsPage.getPopUpMessage();
            Assert.AreEqual("Please enter skill and experience level", popUpMessage, "Actual and expected skill record do not match.");
        }
        [Test, Order(4), Description("Enter a Duplicate Skill"), TestCaseSource(nameof(readNegativeDuplicateSkillTest))]
        public void addDuplicateSkill(SkillModel duplicateSkill)
        {
            Skills skillsPage = new Skills(driver);
            skillsPage.addNewSkill(duplicateSkill.skill, duplicateSkill.skillLevel);

            // Check if the New Skill record has not been added
            string popUpMessage = skillsPage.getPopUpMessage();
            Assert.AreEqual("This skill is already exist in your skill list.", popUpMessage, "Actual and expected certification record do not match.");
        }
        [Test, Order(5), Description("Edit a Skill without Required Fields"), TestCaseSource(nameof(readNegativeEditSkillTests))]
        public void negativeEditSkill(SkillModel negativeSkill)
        {
            Skills skillsPage = new Skills(driver);
            skillsPage.editSkills(negativeSkill.skill, negativeSkill.skillLevel);

            //Check if the Skill record has not been edited
            string popUpMessage = skillsPage.getPopUpMessage();
            Assert.AreEqual("Please enter skill and experience level", popUpMessage, "Actual and expected skill record do not match.");
        }
       [Test, Order(6), Description("Delete an existing Skill record successfully")]
        public void deleteSkill()
        {
            Skills skillsPage = new Skills(driver);
            skillsPage.deleteSkill();

            // Check if the Skill record has been deleted successfully
            string popUpMessage = skillsPage.getPopUpMessage();
            Assert.AreEqual("Python has been deleted", popUpMessage, "Actual and expected certification record do not match.");
        }

    }
}
