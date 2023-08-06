using AdvancedTask.JSON_Objects;
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
    [TestFixture]
    [Parallelizable]
    public class ShareSkill_Tests:CommonDriver
    {
        public static ICollection<ShareSkillObject> ReadShareSkillTests(string[] jsonFiles)
          {
            var newSkills = new List<ShareSkillObject>();
            foreach (var file in jsonFiles)
            {
                ShareSkillObject skill = ReadTestShareSkill("JSONData\\ShareSkill\\" + file);
            newSkills.Add(skill);
            }
            return newSkills;
          } 
        public static ICollection<ShareSkillObject> ReadPositiveAddTests()
        {
            return ReadShareSkillTests(new string[]
            {
                "positiveShareSkill_01.json",
                "positiveShareSkill_02.json"
            });
        }
        public static ICollection<ShareSkillObject> ReadNeagtiveAddTests()
        {
            return ReadShareSkillTests(new string[]
            {
                "negativeShareSkill_01.json",
                "negativeShareSkill_02.json",
                "negativeShareSkill_03.json",
                "negativeShareSkill_04.json",
                "negativeShareSkill_05.json",
                "negativeShareSkill_06.json"
            });
        }
        [Test, Order(1), Description("Check if user is able to add new share skill successfully"),TestCaseSource(nameof(ReadPositiveAddTests))]
        public void TestAddNewShareSkillSuccessfully(ShareSkillObject skill)
        {
            shareSkillPage.CreateShareSkill(skill);
            //Check if the new share skill has been added
            string[] addedShareSkill = shareSkillPage.GetFirstSkill();
            Assert.AreEqual(skill.Title, addedShareSkill[0], "Actual and expected skill record do not match.");
            Assert.AreEqual(skill.Category, addedShareSkill[1], "Actual and expected skill record do not match.");
            test.Log(Status.Info, "Added skill title: " + addedShareSkill[0]);
            test.Log(Status.Info, "Added skill category: " + addedShareSkill[1]);
        }
        [Test, Order(2), Description("Check if user is not able to add new share skill"), TestCaseSource(nameof(ReadNeagtiveAddTests))]
        public void TestNegativeAddNewShareSkill(ShareSkillObject skill)
        {
            shareSkillPage.CreateShareSkill(skill);
            //Check if the new share skill has been added failed
            string checkErrorPopUpMessage = shareSkillPage.GetErrorPopUpMessage();
            Assert.AreEqual("Please complete the form correctly.", checkErrorPopUpMessage, "Actual and expected skill record do not match.");

        }
    }
    
}
