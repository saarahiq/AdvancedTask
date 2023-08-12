using AdvancedTask.JSON_Objects;
using AdvancedTask.Utilities;
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
    public class Description_Tests : CommonDriver
    {
        public static ICollection<DescriptionObject> ReadDescriptionTests(string[] jsonFiles)
        {
            var descriptions = new List<DescriptionObject>();
            foreach (var file in jsonFiles)
            {
                DescriptionObject description = ReadTestDescription("JSONData\\Description\\" + file);
                Console.WriteLine(file);
                Console.WriteLine(description.DescriptionTextBox);
                descriptions.Add(description);
            }
            return descriptions;
        }

        
        public static ICollection<DescriptionObject> ReadPositiveDescAddTests()
        {
            return ReadDescriptionTests(new string[]
            {
                "PositiveAddDescription.json"
            });
        }

        public static ICollection<DescriptionObject> ReadPositiveDescEditTests()
        {
            return ReadDescriptionTests(new string[] {
                "EditDescription.json"
            });
        }
        public static ICollection<DescriptionObject> ReadNegativeAddDescTests()
        {
            return ReadDescriptionTests(new string[] {
                "NegativeAddDescription.json"
            });
        }

        public static ICollection<DescriptionObject> ReadNegativeSpecialCharDescTests()
        {
            return ReadDescriptionTests(new string[] {
                "NegativeSpecialCharAddDescription.json"
            });
        }

        [Test, Order(1), Description("Check if user is able to add description"), TestCaseSource(nameof(ReadPositiveDescAddTests))]
        public void TestAddDescriptionSuccessfully(DescriptionObject description)
        {
            descriptionPage.AddDescription(description);
            //Check if the new description record has been added
            string checkPopUpMessage = descriptionPage.GetPopUpmessage();
            Assert.AreEqual(checkPopUpMessage, "Description has been saved successfully", "Description is not added.");
        }

        [Test, Order(2), Description("Check if user is able to edit description"), TestCaseSource(nameof(ReadPositiveDescEditTests))]
        public void TestEditDescriptionSuccessfully(DescriptionObject description)
        {
            
            descriptionPage.EditDescription(description);
            //Check if the new description has been updated
            string checkPopUpMessage = descriptionPage.GetPopUpmessage();
            Assert.AreEqual(checkPopUpMessage, "Description has been saved successfully", "Description is not added.");
        }

        [Test, Order(4), Description("Check if user is not able to add description"), TestCaseSource(nameof(ReadNegativeAddDescTests))]
        public void TestDescriptionFailed(DescriptionObject description)
        {
            descriptionPage.FailtoAddDescription(description);
            //Check if the wihtout entering anything in textbox we can still save description 
            string checkPopUpMessage = descriptionPage.GetPopUpmessage();
            Assert.AreEqual("Please,a description is required", checkPopUpMessage, "Description is added");
        }
        [Test, Order(5), Description("Check if user is not able to add description starting with special character"), TestCaseSource(nameof(ReadNegativeSpecialCharDescTests))]
        public void TestSpecialCharAddDescription(DescriptionObject description)
        {
             descriptionPage.SpecialCharAddDescription(description);
            //Check if description still gets added with special character 
            string checkPopUpMessage = descriptionPage.GetPopUpmessage();
            Assert.AreEqual("First character can only be digit or letters", checkPopUpMessage, "Description added.");
        }
    }
}
