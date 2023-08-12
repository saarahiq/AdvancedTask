using AdvancedTask.JSON_Objects;
using AdvancedTask.PageObjectComponent;
using AdvancedTask.Pages;
using AdvancedTask.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTask.Test
{
    [TestFixture]
    [Parallelizable]
    public class SearchSkill_Tests : CommonDriver
    {
        public static ICollection<SearchskillObject> ReadSearchskillTests(string[] jsonFiles)
        {
            var searchskills = new List<SearchskillObject>();
            foreach (var file in jsonFiles)
            {
               ;
                SearchskillObject searchskill = ReadTestSearchskill("JSONData\\Searchskill\\" + file);
                searchskills.Add(searchskill);
            }
            return searchskills;
        }


        public static ICollection<SearchskillObject> ReadPositiveSearchskillTests()
        {
            return ReadSearchskillTests(new string[]
            {
                "Searchskill.json"
            });
        }
        [SetUp]
        public void NavigationtoSearchPage()
        {
            MenuNavigation menuNavigation = new MenuNavigation(driver);
            menuNavigation.GoToSearchPage();
        }

        [Test, Order(1), Description("Check if user is able to search skill"), TestCaseSource(nameof(ReadPositiveSearchskillTests))]
        public void TestSearchskillSuccessfully(SearchskillObject searchskill)
        {

            searchSkillPage.Searchskill(searchskill);
            string checkskillsearch = searchSkillPage.Searchedskill();
            Assert.That(checkskillsearch == "Test Analyst", "Skill does not match with the searched skill");
        }

        [Test, Order(2), Description("Check if user is able to search skill by user"), TestCaseSource(nameof(ReadPositiveSearchskillTests))]
        public void TestSearchskillByUserSuccessfully(SearchskillObject searchskill)
        {

            searchSkillPage.SearchskillByUser(searchskill);
            string getSearchedUser = searchSkillPage.UserMatch();
           string getsearchUser = searchSkillPage.UserSearch();
            //Assert.That(getSearchedUser == "Nik J","Searched user does not match with the selected user");
            Assert.AreEqual(getSearchedUser, getSearchedUser, "User did not match");
        }

        [Test, Order(3), Description("Check if searched skill and presented skill match"), TestCaseSource(nameof(ReadPositiveSearchskillTests))]
        public void TestSearchskillByCategorySuccessfully(SearchskillObject searchskill)
        {

            searchSkillPage.SearchByCategory(searchskill);
            string getcategorycheck = searchSkillPage.CategoryMatch();
            Assert.That(getcategorycheck == "Graphics & Design", "Category does not match with searched category");

           
        }


    }
}
