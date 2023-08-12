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
    [NUnit.Framework.DescriptionAttribute("Education")]
    public partial class EducationFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private static string[] featureTags = ((string[])(null));
        
#line 1 "Education.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "Education", "As a Mars website user, I want to add, edit and delete Education in my profile\r\ns" +
                    "o that I can manage my profile details successfully", ProgrammingLanguage.CSharp, featureTags);
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
        [NUnit.Framework.DescriptionAttribute("Add Education record in Profile details")]
        [NUnit.Framework.CategoryAttribute("order(1)")]
        [NUnit.Framework.TestCaseAttribute("Harvard University", "United States", "B.Sc", "Computer Science", "2018", "Education has been added", null)]
        [NUnit.Framework.TestCaseAttribute("Oxford University", "United Kingdom", "PHD", "Psychology", "2015", "Education has been added", null)]
        [NUnit.Framework.TestCaseAttribute("", "New Zealand", "B.A", "Business", "2010", "Please enter all the fields", null)]
        [NUnit.Framework.TestCaseAttribute("Auckland University", "Country of College/University", "M.B.A", "Master", "2013", "Please enter all the fields", null)]
        [NUnit.Framework.TestCaseAttribute("", "Country of College/University", "Title", "", "Year of graduation", "Please enter all the fields", null)]
        [NUnit.Framework.TestCaseAttribute("Harvard University", "United States", "B.Sc", "Computer Science", "2018", "This information is already exist.", null)]
        public void AddEducationRecordInProfileDetails(string universityName, string country, string title, string degree, string graduationYear, string message, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "order(1)"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("University Name", universityName);
            argumentsOfScenario.Add("Country", country);
            argumentsOfScenario.Add("Title", title);
            argumentsOfScenario.Add("Degree", degree);
            argumentsOfScenario.Add("Graduation Year", graduationYear);
            argumentsOfScenario.Add("Message", message);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Add Education record in Profile details", null, tagsOfScenario, argumentsOfScenario, featureTags);
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
 testRunner.Given("I logged in successfully and navigate to Education Tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 9
 testRunner.When(string.Format("I click on Add New button and add \'{0}\',\'{1}\', \'{2}\', \'{3}\', \'{4}\'", universityName, country, title, degree, graduationYear), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 10
 testRunner.Then(string.Format("The new Education record with \'{0}\',\'{1}\', \'{2}\', \'{3}\', \'{4}\' should be added an" +
                            "d I should see the \'{5}\'", universityName, country, title, degree, graduationYear, message), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Edit an existing Education record with valid details")]
        [NUnit.Framework.CategoryAttribute("order(2)")]
        [NUnit.Framework.TestCaseAttribute("Massey", "New Zealand", "PHD", "Microbiology", "2021", "Education as been updated", null)]
        [NUnit.Framework.TestCaseAttribute("", "Australia", "BFA", "Food Science", "2023", "Please enter all the fields", null)]
        [NUnit.Framework.TestCaseAttribute("Melbourne University", "Australia", "Title", "Food Science", "Year of graduation", "Please enter all the fields", null)]
        [NUnit.Framework.TestCaseAttribute("Massey", "New Zealand", "PHD", "Microbiology", "2021", "This information is already exist.", null)]
        public void EditAnExistingEducationRecordWithValidDetails(string universityName, string country, string title, string degree, string graduationYear, string message, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "order(2)"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("University Name", universityName);
            argumentsOfScenario.Add("Country", country);
            argumentsOfScenario.Add("Title", title);
            argumentsOfScenario.Add("Degree", degree);
            argumentsOfScenario.Add("Graduation Year", graduationYear);
            argumentsOfScenario.Add("Message", message);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Edit an existing Education record with valid details", null, tagsOfScenario, argumentsOfScenario, featureTags);
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
  testRunner.Given("I logged in successfully and navigate to Education Tab to edit", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 24
  testRunner.When(string.Format("I edit \'{0}\',\'{1}\', \'{2}\', \'{3}\', \'{4}\' in Education Tab", universityName, country, title, degree, graduationYear), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 25
  testRunner.Then(string.Format("The Education details should be updated with \'{0}\',\'{1}\', \'{2}\', \'{3}\', \'{4}\' and" +
                            " I should see the \'{5}\'", universityName, country, title, degree, graduationYear, message), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Delete an existing Education record in Profile details")]
        [NUnit.Framework.CategoryAttribute("order(3)")]
        [NUnit.Framework.TestCaseAttribute("Massey", "New Zealand", "PHD", "Microbiology", "2021", "Education entry successfully removed", null)]
        public void DeleteAnExistingEducationRecordInProfileDetails(string universityName, string country, string title, string degree, string graduationYear, string message, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "order(3)"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("University Name", universityName);
            argumentsOfScenario.Add("Country", country);
            argumentsOfScenario.Add("Title", title);
            argumentsOfScenario.Add("Degree", degree);
            argumentsOfScenario.Add("Graduation Year", graduationYear);
            argumentsOfScenario.Add("Message", message);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Delete an existing Education record in Profile details", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 35
 this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 36
  testRunner.Given("I logged in successfully and navigate to Education Tab to delete", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 37
  testRunner.When(string.Format("I click on the Delete button for \'{0}\',\'{1}\', \'{2}\', \'{3}\', \'{4}\'", universityName, country, title, degree, graduationYear), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 38
  testRunner.Then(string.Format("The Education details should be deleted and I should see the \'{0}\'", message), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
