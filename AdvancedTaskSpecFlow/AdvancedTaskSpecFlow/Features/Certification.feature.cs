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
    [NUnit.Framework.DescriptionAttribute("Certification")]
    public partial class CertificationFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private static string[] featureTags = ((string[])(null));
        
#line 1 "Certification.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "Certification", "As a Mars user, I want to add, edit and delete Certification records in my profil" +
                    "e\r\nso that I can manage my profile details successfully", ProgrammingLanguage.CSharp, featureTags);
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
        [NUnit.Framework.DescriptionAttribute("Add a Certification record in Profile details")]
        [NUnit.Framework.CategoryAttribute("order(1)")]
        [NUnit.Framework.TestCaseAttribute("Test Analyst", "Industry Connect", "2023", "Test Analyst has been added to your certification", null)]
        [NUnit.Framework.TestCaseAttribute("Applied Science", "AUT", "2015", "Applied Science has been added to your certification", null)]
        [NUnit.Framework.TestCaseAttribute("", "iSQI", "2020", "Please enter Certification Name, Certification From and Certification Year", null)]
        [NUnit.Framework.TestCaseAttribute("ISTQB", "", "Year", "Please enter Certification Name, Certification From and Certification Year", null)]
        [NUnit.Framework.TestCaseAttribute("Test Analyst", "Industry Connect", "2023", "This information is already exist.", null)]
        public void AddACertificationRecordInProfileDetails(string certificate, string certifiedFrom, string year, string message, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "order(1)"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("Certificate", certificate);
            argumentsOfScenario.Add("Certified From", certifiedFrom);
            argumentsOfScenario.Add("Year", year);
            argumentsOfScenario.Add("Message", message);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Add a Certification record in Profile details", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 8
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 9
 testRunner.Given("I logged in successfully and navigate to Certifications Tab to add", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 10
 testRunner.When(string.Format("I click on Add New button and add \'{0}\', \'{1}\', \'{2}\'", certificate, certifiedFrom, year), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 11
 testRunner.Then(string.Format("The new Certification record with \'{0}\', \'{1}\', \'{2}\' should be added successfull" +
                            "y and I should see the \'{3}\'", certificate, certifiedFrom, year, message), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Edit an existing Certification record with valid details")]
        [NUnit.Framework.CategoryAttribute("order(2)")]
        [NUnit.Framework.TestCaseAttribute("MySQL", "Udemy", "2018", "MySQL has been updated to your certification", null)]
        [NUnit.Framework.TestCaseAttribute("", "AUT", "2015", "Please enter Certification Name, Certification From and Certification Year", null)]
        [NUnit.Framework.TestCaseAttribute("", "Udemy", "2020", "Please enter Certification Name, Certification From and Certification Year", null)]
        [NUnit.Framework.TestCaseAttribute("MySQL", "Udemy", "Year", "Please enter Certification Name, Certification From and Certification Year", null)]
        [NUnit.Framework.TestCaseAttribute("MySQL", "Udemy", "2018", "This information is already exist.", null)]
        public void EditAnExistingCertificationRecordWithValidDetails(string certificate, string certifiedFrom, string year, string message, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "order(2)"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("Certificate", certificate);
            argumentsOfScenario.Add("Certified From", certifiedFrom);
            argumentsOfScenario.Add("Year", year);
            argumentsOfScenario.Add("Message", message);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Edit an existing Certification record with valid details", null, tagsOfScenario, argumentsOfScenario, featureTags);
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
  testRunner.Given("I logged in successfully and navigate to Certifications Tab to edit", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 24
  testRunner.When(string.Format("I edit \'{0}\', \'{1}\', \'{2}\' in Certifications Tab", certificate, certifiedFrom, year), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 25
  testRunner.Then(string.Format("The  Certification details should be updated with \'{0}\', \'{1}\', \'{2}\' and I shoul" +
                            "d see the \'{3}\'", certificate, certifiedFrom, year, message), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Delete a Certification record in Profile details")]
        [NUnit.Framework.CategoryAttribute("order(3)")]
        [NUnit.Framework.TestCaseAttribute("MySQL", "Udemy", "2018", "MySQL has been deleted from your certification", null)]
        public void DeleteACertificationRecordInProfileDetails(string certificate, string certifiedFrom, string year, string message, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "order(3)"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("Certificate", certificate);
            argumentsOfScenario.Add("Certified From", certifiedFrom);
            argumentsOfScenario.Add("Year", year);
            argumentsOfScenario.Add("Message", message);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Delete a Certification record in Profile details", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 36
 this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 37
  testRunner.Given("I logged in successfully and navigate to Certifications Tab to delete", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 38
  testRunner.When(string.Format("I click on the Delete button for \'{0}\', \'{1}\', \'{2}\'", certificate, certifiedFrom, year), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 39
  testRunner.Then(string.Format("The Certification details should be deleted and I should see the \'{0}\'", message), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
