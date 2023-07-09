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
    public class ShareSkill_Tests : CommonDriver
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

        [Test, Order(1), Description("Edit a ShareSkill successfully"), TestCaseSource(nameof(readPositiveEditShareSkillTests))]
        public void positiveEditNewSkill(ShareSkillModel editShareSkill)
        {
            ShareSkillPage shareSkillPage = new ShareSkillPage(driver);
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
