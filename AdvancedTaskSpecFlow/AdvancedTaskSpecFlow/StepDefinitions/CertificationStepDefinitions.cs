using AdvancedTaskSpecFlow.Utilities;
using AventStack.ExtentReports;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using NUnit.Framework;
using System;
using System.Diagnostics.Metrics;
using TechTalk.SpecFlow;

namespace AdvancedTaskSpecFlow.StepDefinitions
{
    [Binding]
    public class CertificationStepDefinitions
    {
        private readonly CommonDriver commonDriver;
        public CertificationStepDefinitions(CommonDriver commonDriver)
        {
            this.commonDriver = commonDriver;
        }

        public void LoginAndGoToCertificationTab()
        {
            bool loggedInSuccessfully = commonDriver.Login("jessica@hotmail.com", "123123");
            if (loggedInSuccessfully)
            {
                commonDriver.profilePage.goToCertificationTab();
            }
        }
        [Given(@"I logged in successfully and navigate to Certifications Tab to add")]
        public void GivenILoggedInSuccessfullyAndNavigateToCertificationsTabToAdd()
        {
            LoginAndGoToCertificationTab();
        }

        [When(@"I click on Add New button and add '([^']*)', '([^']*)', '([^']*)'")]
        public void WhenIClickOnAddNewButtonAndAdd(string certificate, string certifiedFrom, string year)
        {
            commonDriver.certificationPage.addNewCertification(certificate, certifiedFrom, year);
        }

        [Then(@"The new Certification record with '([^']*)', '([^']*)', '([^']*)' should be added successfully and I should see the '([^']*)'")]
        public void ThenTheNewCertificationRecordWithShouldBeAddedSuccessfullyAndIShouldSeeThe(string certificate, string certifiedFrom, string year, string message)
        {
            //Check if the New Certification records have been added successfully

            string popUpMessage = commonDriver.popUpComponent.getMessage();
            Assert.AreEqual(popUpMessage, message, "Could not verify that the Certification was added.");


            if (popUpMessage != "Please enter Certification Name, Certification From and Certification Year" && popUpMessage != "This information is already exist.")
            {
                string[] newCertificationAdded = commonDriver.certificationPage.getLatestCertification();
                Assert.AreEqual(certificate, newCertificationAdded[0], "Actual and expected Certification certificate does not match");
                Assert.AreEqual(certifiedFrom, newCertificationAdded[1], "Actual and expected Certification certified from do not match");
                Assert.AreEqual(year, newCertificationAdded[2], "Actual and expected Certification year do not match");
            }
            //logging to extent reports
            CommonDriver.test.Log(Status.Pass, "Successfully verified creating a Certification record");
            commonDriver.SaveScreenshot("Certification Tests");
        }

        [Given(@"I logged in successfully and navigate to Certifications Tab to edit")]
        public void GivenILoggedInSuccessfullyAndNavigateToCertificationsTabToEdit()
        {
            LoginAndGoToCertificationTab();
        }

        [When(@"I edit '([^']*)', '([^']*)', '([^']*)' in Certifications Tab")]
        public void WhenIEditInCertificationsTab(string certificate, string certifiedFrom, string year)
        {
            commonDriver.certificationPage.editCertification(certificate, certifiedFrom, year);
        }

        [Then(@"The  Certification details should be updated with '([^']*)', '([^']*)', '([^']*)' and I should see the '([^']*)'")]
        public void ThenTheCertificationDetailsShouldBeUpdatedWithAndIShouldSeeTheMySQLHasBeenUpdatedToYourCertification(string certificate, string certifiedFrom, string year, string message)
        {
            //Check if the New Certification records have been added successfully

            string popUpMessage = commonDriver.popUpComponent.getMessage();
            Assert.AreEqual(popUpMessage, message, "Could not verify that the Certification was added.");


            if (popUpMessage != "Please enter Certification Name, Certification From and Certification Year" && popUpMessage != "This information is already exist.")
            {
                string[] newCertificationAdded = commonDriver.certificationPage.getFirstCertification();
                Assert.AreEqual(certificate, newCertificationAdded[0], "Actual and expected Certification certificate name does not match");
                Assert.AreEqual(certifiedFrom, newCertificationAdded[1], "Actual and expected Certification certified from do not match");
                Assert.AreEqual(year, newCertificationAdded[2], "Actual and expected Certification year do not match");
            }
            //logging to extent reports
            CommonDriver.test.Log(Status.Pass, "Successfully verified updating a Certification record");
            commonDriver.SaveScreenshot("Certification Tests");
        }

        [Given(@"I logged in successfully and navigate to Certifications Tab to delete")]
        public void GivenILoggedInSuccessfullyAndNavigateToCertificationsTabToDelete()
        {
            LoginAndGoToCertificationTab();
        }

        [When(@"I click on the Delete button for '([^']*)', '([^']*)', '([^']*)'")]
        public void WhenIClickOnTheDeleteButtonFor(string certificate, string certifiedFrom, string year)
        {
            commonDriver.certificationPage.deleteCertification(certificate, certifiedFrom, year);
        }


        [Then(@"The Certification details should be deleted and I should see the '([^']*)'")]
        public void ThenTheCertificationDetailsShouldBeDeletedAndIShouldSeeThe(string message)
        {
            string popUpMessage = commonDriver.popUpComponent.getMessage();
            Assert.AreEqual(message, popUpMessage, "Actual and expected certification record do not match.");
            CommonDriver.test.Log(Status.Pass, "Successfully verified deletion of a Certification record");
            commonDriver.SaveScreenshot("Certification Tests");
        }
    }
}
