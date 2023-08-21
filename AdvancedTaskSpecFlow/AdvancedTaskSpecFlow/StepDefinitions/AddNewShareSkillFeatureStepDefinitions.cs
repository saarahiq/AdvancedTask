using AdvancedTaskSpecFlow.Models;
using AdvancedTaskSpecFlow.Pages;
using AdvancedTaskSpecFlow.Pages.ProfilePageTabs;
using AdvancedTaskSpecFlow.Utilities;
using AventStack.ExtentReports.Model;
using Microsoft.CodeAnalysis;
using NUnit.Framework;
using System;
using System.Data;
using TechTalk.SpecFlow;
using static Microsoft.AspNetCore.Razor.Language.TagHelperMetadata;

namespace AdvancedTaskSpecFlow.StepDefinitions
{
    [Binding]
    public class AddNewShareSkillFeatureStepDefinitions
    {
        private readonly CommonDriver commonDriver;
        public AddNewShareSkillFeatureStepDefinitions(CommonDriver commonDriver)
        {
            this.commonDriver = commonDriver;
        }

        private AddShareSkillModel newShareSkill(string Title, string Description, string Category, string SubCategory, string Tags, string ServiceType, string LocationType, string StartDate, string EndDate, string SkillTrade, string SkillExchange, string Credit, string Active, string MonTime, string TueTime, string WedTime, string ThurTime, string FriTime, string SatTime)
        {
            AddShareSkillModel addShareSkillModel = new AddShareSkillModel();
            addShareSkillModel.Title = Title;
            addShareSkillModel.Description = Description;
            addShareSkillModel.Category = Category;
            addShareSkillModel.Subcategory = SubCategory;
            addShareSkillModel.Tags = Tags.Split(',');
            addShareSkillModel.ServiceType = ServiceType;
            addShareSkillModel.LocationType = LocationType;
            addShareSkillModel.StartDate = StartDate;
            addShareSkillModel.EndDate = EndDate;
            addShareSkillModel.SkillTrade = SkillTrade;
            addShareSkillModel.SkillExchange = SkillExchange.Split(',');
            addShareSkillModel.Credit = Credit;
            addShareSkillModel.Active = Active;           
            var availableDays = new List<AvailableDay>();
            var availableDayColumns = new string[] { MonTime, TueTime, WedTime, ThurTime, FriTime, SatTime};
            for (int j = 0; j < availableDayColumns.Length; j++)
            {
                var time = availableDayColumns[j];
                if (time != "")
                {
                    var hours = time.Split('-');
                    var startTime = hours[0];
                    var endTime = "";
                    if (hours.Length > 1)
                    {
                        endTime = hours[1];
                    }
                    availableDays.Add(new AvailableDay(j + 2, startTime, endTime));
                }

            }
            addShareSkillModel.AvailableDays = availableDays.ToArray(); 
            return addShareSkillModel;
        }

        [When(@"I click on add button and input valid '([^']*)', '([^']*)', '([^']*)', '([^']*)', '([^']*)', '([^']*)', '([^']*)', '([^']*)', '([^']*)', '([^']*)', '([^']*)', '([^']*)', '([^']*)','([^']*)', '([^']*)', '([^']*)', '([^']*)', '([^']*)', '([^']*)'")]
        public void WhenIClickOnAddButtonAndInputValid(string Title, string Description, string Category, string SubCategory, string Tags, string ServiceType, string LocationType, string StartDate, string EndDate, string SkillTrade, string SkillExchange, string Credit, string Active, string MonTime, string TueTime, string WedTime, string ThurTime, string FriTime, string SatTime)
        {
            var model = newShareSkill(Title, Description, Category, SubCategory, Tags, ServiceType, LocationType, StartDate, EndDate, SkillTrade, SkillExchange, Credit, Active, MonTime, TueTime, WedTime, ThurTime, FriTime, SatTime);

            //Add new share skill with valid details
            commonDriver.addNewShareSkillPage.CreateShareSkill(model);
        }

        [Then(@"The new share skill with '([^']*)', '([^']*)'should be added successfully")]
        public void ThenTheNewShareSkillWithShouldBeAddedSuccessfully(string Title, string Category)
            {
                string[] addedSkill = commonDriver.addNewShareSkillPage.GetFirstSkill();
                Assert.AreEqual(Title, addedSkill[0], "Actual and expected skill record do not match.");
                Assert.AreEqual(Category, addedSkill[1], "Actual and expected skill record do not match.");
            }

       
        [When(@"I click on add button and input invalid '([^']*)', '([^']*)','([^']*)', '([^']*)', '([^']*)', '([^']*)','([^']*)', '([^']*)', '([^']*)', '([^']*)', '([^']*)', '([^']*)', '([^']*)','([^']*)', '([^']*)', '([^']*)', '([^']*)', '([^']*)', '([^']*)'")]
        public void WhenIClickOnAddButtonAndInputInvalid(string Title, string Description, string Category, string SubCategory, string Tags, string ServiceType, string LocationType, string StartDate, string EndDate, string SkillTrade, string SkillExchange, string Credit, string Active, string MonTime, string TueTime, string WedTime, string ThurTime, string FriTime, string SatTime)
        {
            var model = newShareSkill(Title, Description, Category, SubCategory, Tags, ServiceType, LocationType, StartDate, EndDate, SkillTrade, SkillExchange, Credit, Active, MonTime, TueTime, WedTime, ThurTime, FriTime, SatTime);
            //Add new share skill with valid details
            commonDriver.addNewShareSkillPage.CreateShareSkill(model);
        }

        [Then(@"The new share skill with invalid'([^']*)', '([^']*)'should be added failed")]
        public void ThenTheNewShareSkillWithInvalidShouldBeAddedFailed(string Title, string Category)
        {
            //Check if the new share skill has been added failed
            string checkErrorPopUpMessage = commonDriver.addNewShareSkillPage.GetErrorPopUpMessage();
            Assert.AreEqual("Please complete the form correctly.", checkErrorPopUpMessage, "Actual and expected skill record do not match.");
        }


    }
}
