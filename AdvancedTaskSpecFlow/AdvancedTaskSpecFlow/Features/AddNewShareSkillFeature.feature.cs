﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.9.0.0
//      SpecFlow Generator Version:3.9.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace AdvancedTaskSpecFlow.Features
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("AddNewShareSkillFeature")]
    public partial class AddNewShareSkillFeatureFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private static string[] featureTags = ((string[])(null));
        
#line 1 "AddNewShareSkillFeature.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "AddNewShareSkillFeature", "As a user, I\'d like to add new share skill with valid details.\r\nAs a user, I can\'" +
                    "t add new share skill with invalid details.", ProgrammingLanguage.CSharp, featureTags);
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<NUnit.Framework.TestContext>(NUnit.Framework.TestContext.CurrentContext);
        }
        
        public void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("01) I can add new share skill with valid details.")]
        [NUnit.Framework.CategoryAttribute("tag1")]
        [NUnit.Framework.TestCaseAttribute("Interview skill exchange", "I like to exchange my interview skill traing with other skills.", "Business", "Presentations", "Selling,Interview", "Hourly basis service", "On-site", "12/12/2023", "", "Credit", "", "9", "Hidden", "", "", "", "", "", "", null)]
        [NUnit.Framework.TestCaseAttribute("Web design", "I work as a dancing teacher for ten years.", "Programming & Tech", "Web & Mobile App", "Design", "One-off service", "Online", "01/01/2024", "31/01/2024", "Skill-exchange", "software testing", "", "Active", "", "", "", "", "", "", null)]
        [NUnit.Framework.TestCaseAttribute("Singing Teaching", "I am a singing teacher.", "Music & Audio", "Voice Over", "Teaching", "", "", "12/08/2024", "", "Credit", "", "5", "", "9:00-17:00", "", "9:00-17:00", "", "9:00-17:00", "", null)]
        [NUnit.Framework.TestCaseAttribute("Game Playing", "I like to play games.", "Fun & Lifestyle", "Gaming", "Gaming,Fun", "", "", "12/12/2024", "", "", "dancing", "", "", "12:00", "", "12:00", "12:00", "12:00", "12:00", null)]
        [NUnit.Framework.TestCaseAttribute("Essay Writing", "I can help you in writing essay.", "Writing & Translation", "Creative Writing", "Writing", "", "", "12/09/2025", "31/01/2026", "Credit", "", "8", "", "12:00", "12:00", "12:00", "12:00", "12:00", "12:00-17:00", null)]
        public void _01ICanAddNewShareSkillWithValidDetails_(
                    string title, 
                    string description, 
                    string category, 
                    string subCategory, 
                    string tags, 
                    string serviceType, 
                    string locationType, 
                    string startDate, 
                    string endDate, 
                    string skillTrade, 
                    string skillExchange, 
                    string credit, 
                    string active, 
                    string monTime, 
                    string tueTime, 
                    string wedTime, 
                    string thurTime, 
                    string friTime, 
                    string satTime, 
                    string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "tag1"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("Title", title);
            argumentsOfScenario.Add("Description", description);
            argumentsOfScenario.Add("Category", category);
            argumentsOfScenario.Add("SubCategory", subCategory);
            argumentsOfScenario.Add("Tags", tags);
            argumentsOfScenario.Add("ServiceType", serviceType);
            argumentsOfScenario.Add("LocationType", locationType);
            argumentsOfScenario.Add("StartDate", startDate);
            argumentsOfScenario.Add("EndDate", endDate);
            argumentsOfScenario.Add("SkillTrade", skillTrade);
            argumentsOfScenario.Add("SkillExchange", skillExchange);
            argumentsOfScenario.Add("Credit", credit);
            argumentsOfScenario.Add("Active", active);
            argumentsOfScenario.Add("MonTime", monTime);
            argumentsOfScenario.Add("TueTime", tueTime);
            argumentsOfScenario.Add("WedTime", wedTime);
            argumentsOfScenario.Add("ThurTime", thurTime);
            argumentsOfScenario.Add("FriTime", friTime);
            argumentsOfScenario.Add("SatTime", satTime);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("01) I can add new share skill with valid details.", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 7
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 8
 testRunner.Given("Launch Mars portal and login with default user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 9
 testRunner.When(string.Format("I click on add button and input valid \'{0}\', \'{1}\', \'{2}\', \'{3}\', \'{4}\', \'{5}\', \'" +
                            "{6}\', \'{7}\', \'{8}\', \'{9}\', \'{10}\', \'{11}\', \'{12}\',\'{13}\', \'{14}\', \'{15}\', \'{16}\'" +
                            ", \'{17}\', \'{18}\'", title, description, category, subCategory, tags, serviceType, locationType, startDate, endDate, skillTrade, skillExchange, credit, active, monTime, tueTime, wedTime, thurTime, friTime, satTime), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 10
 testRunner.Then(string.Format("The new share skill with \'{0}\', \'{1}\'should be added successfully", title, category), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("02) I can not add new share skill with invalid details.")]
        [NUnit.Framework.TestCaseAttribute("", "programming", "Business", "Presentations", "Selling", "Hourly basis service", "On-site", "12/12/2023", "", "Credit", "", "9", "Hidden", "", "", "", "", "", "", null)]
        [NUnit.Framework.TestCaseAttribute("!QA", "programming", "Programming & Tech", "Web & Mobile App", "Design", "One-off service", "Online", "01/01/2024", "31/01/2024", "Skill-exchange", "testing", "", "Active", "", "", "", "", "", "", null)]
        [NUnit.Framework.TestCaseAttribute("IT", "", "Programming & Tech", "Web & Mobile App", "Design", "One-off service", "Online", "01/01/2024", "31/01/2024", "Skill-exchange", "testing", "", "Active", "", "", "", "", "", "", null)]
        [NUnit.Framework.TestCaseAttribute("PHD", "progr*aming", "Business", "Presentations", "Selling", "Hourly basis service", "On-site", "12/12/2023", "", "Credit", "", "9", "Hidden", "", "", "", "", "", "", null)]
        [NUnit.Framework.TestCaseAttribute("BA", "!programming", "Business", "Presentations", "Selling", "Hourly basis service", "On-site", "12/12/2023", "", "Credit", "", "9", "Hidden", "", "", "", "", "", "", null)]
        [NUnit.Framework.TestCaseAttribute("DA", "programming", "Programming", "Web & Mobile App", "Design", "One-off service", "Online", "01/01/2024", "31/01/2024", "Skill-exchange", "testing", "", "Active", "", "", "", "", "", "", null)]
        [NUnit.Framework.TestCaseAttribute("MA", "programming", "Programming & Tech", "Mobile", "Design", "One-off service", "Online", "01/01/2024", "31/01/2024", "Credit", "", "5", "Active", "", "", "", "", "", "", null)]
        [NUnit.Framework.TestCaseAttribute("GD", "programming", "Programming & Tech", "Web & Mobile App", "", "One-off service", "Online", "01/01/2024", "31/01/2024", "Credit", "", "5", "Hidden", "", "", "", "", "", "", null)]
        [NUnit.Framework.TestCaseAttribute("PGD", "programming", "Programming & Tech", "Web & Mobile App", "Design", "One-off service", "Online", "01/01/2023", "31/01/2024", "Credit", "", "6", "Active", "", "", "", "", "", "", null)]
        [NUnit.Framework.TestCaseAttribute("Dev", "programming", "Business", "Presentations", "Selling", "Hourly basis service", "On-site", "12/12/2023", "", "Skill-exchange", "", "", "Hidden", "", "", "", "", "", "", null)]
        public void _02ICanNotAddNewShareSkillWithInvalidDetails_(
                    string title, 
                    string description, 
                    string category, 
                    string subCategory, 
                    string tags, 
                    string serviceType, 
                    string locationType, 
                    string startDate, 
                    string endDate, 
                    string skillTrade, 
                    string skillExchange, 
                    string credit, 
                    string active, 
                    string monTime, 
                    string tueTime, 
                    string wedTime, 
                    string thurTime, 
                    string friTime, 
                    string satTime, 
                    string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("Title", title);
            argumentsOfScenario.Add("Description", description);
            argumentsOfScenario.Add("Category", category);
            argumentsOfScenario.Add("SubCategory", subCategory);
            argumentsOfScenario.Add("Tags", tags);
            argumentsOfScenario.Add("ServiceType", serviceType);
            argumentsOfScenario.Add("LocationType", locationType);
            argumentsOfScenario.Add("StartDate", startDate);
            argumentsOfScenario.Add("EndDate", endDate);
            argumentsOfScenario.Add("SkillTrade", skillTrade);
            argumentsOfScenario.Add("SkillExchange", skillExchange);
            argumentsOfScenario.Add("Credit", credit);
            argumentsOfScenario.Add("Active", active);
            argumentsOfScenario.Add("MonTime", monTime);
            argumentsOfScenario.Add("TueTime", tueTime);
            argumentsOfScenario.Add("WedTime", wedTime);
            argumentsOfScenario.Add("ThurTime", thurTime);
            argumentsOfScenario.Add("FriTime", friTime);
            argumentsOfScenario.Add("SatTime", satTime);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("02) I can not add new share skill with invalid details.", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 22
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 23
 testRunner.Given("Launch Mars portal and login with default user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 24
 testRunner.When(string.Format("I click on add button and input invalid \'{0}\', \'{1}\',\'{2}\', \'{3}\', \'{4}\', \'{5}\',\'" +
                            "{6}\', \'{7}\', \'{8}\', \'{9}\', \'{10}\', \'{11}\', \'{12}\',\'{13}\', \'{14}\', \'{15}\', \'{16}\'" +
                            ", \'{17}\', \'{18}\'", title, description, category, subCategory, tags, serviceType, locationType, startDate, endDate, skillTrade, skillExchange, credit, active, monTime, tueTime, wedTime, thurTime, friTime, satTime), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 25
 testRunner.Then(string.Format("The new share skill with invalid\'{0}\', \'{1}\'should be added failed", title, category), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
