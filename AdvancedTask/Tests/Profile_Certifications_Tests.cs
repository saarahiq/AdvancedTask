using AdvancedTask.Models;
using AdvancedTask.Pages.ProfilePage;
using AdvancedTask.Utilities;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Numerics;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AdvancedTask.Test
{
    [TestFixture]
    [Parallelizable]
    public class ProfileCertificationTests : CommonDriver
    {
        public static List<CertificationModel> readCertificationTest(string[] jsonFiles)
        {
            var certifications = new List<CertificationModel>();
            foreach (var file in jsonFiles)
            {
                CertificationModel certification = readCertification(file);
                certifications.Add(certification);
            }
            return certifications;
        }
        public static List<CertificationModel> readPositiveCertAddTests()
        {
            var testFiles = new string[] {
                "positiveAddNewCert_01.json" ,
                "positiveAddNewCert_02.json" 
            };
            return readCertificationTest(testFiles);
        }
        public static List<CertificationModel> readPositiveCertEditTests()
        {
            var testFiles = new string[] {
                "positiveEditCert.json"
            };
            return readCertificationTest(testFiles);
        }
        public static List<CertificationModel> readNegativeAddCertTests()
        {
            var testFiles = new string[] {
                "negativeAddNewCert_01.json",
                "negativeAddNewCert_02.json",
                "negativeAddNewCert_03.json"
            };
            return readCertificationTest(testFiles);
        }
        public static List<CertificationModel> readNegativeDuplicateCertTests()
        {
            var testFiles = new string[] {
                "negativeAddDuplicateCert.json"
            };
            return readCertificationTest(testFiles);
        }
        public static List<CertificationModel> readNegativeEditCertTests()
        {
            var testFiles = new string[] {
                "negativeEditCert_01.json",
                "negativeEditCert_02.json",
                "negativeEditCert_03.json"
            };
            return readCertificationTest(testFiles);
        }

        [Test, Order(1), Description("Add Certification successfully"), TestCaseSource(nameof(readPositiveCertAddTests))]
        public void positiveAddNewCertification(CertificationModel addCertification)
        {
            Certification certificationPage = new Certification(driver);
            certificationPage.addNewCertification(addCertification.certificate, addCertification.certifiedFrom, addCertification.year);

            //Check if the New Certification records have been added successfully
            string popUpMessage = certificationPage.getPopUpMessage();
            string[] newCertificationAdded = certificationPage.getLatestCertification();
            Assert.AreEqual(popUpMessage, newCertificationAdded[0] + " has been added to your certification", "Actual and expected certification record do not match.");
            Assert.AreEqual(addCertification.certificate, newCertificationAdded[0], "Actual and expected certification name do not match.");
            Assert.AreEqual(addCertification.certifiedFrom, newCertificationAdded[1], "Actual and expected certification certified from do not match.");
            Assert.AreEqual(addCertification.year, newCertificationAdded[2], "Actual and expected certification year do not match.");
            //logging to extent reports
            test.Log(Status.Pass, "Successfully verified creating a Certification record");
        }

        [Test, Order(2), Description("Edit an existing Certification successfully"), TestCaseSource(nameof(readPositiveCertEditTests))]
        public void positiveEditCertification(CertificationModel editCertification)
        {
            Certification certificationPage = new Certification(driver);
            Thread.Sleep(2000);
            certificationPage.editCertification(editCertification.certificate, editCertification.certifiedFrom, editCertification.year);

            // Check if the Certification record has been updated successfully
            string popUpMessage = certificationPage.getPopUpMessage();
            string[] updatedCertificationAdded = certificationPage.getFirstCertification();
            Assert.AreEqual(popUpMessage, updatedCertificationAdded[0] + " has been updated to your certification", "Actual and expected certification record do not match.");
            Assert.AreEqual(editCertification.certificate, updatedCertificationAdded[0], "Actual and expected certification name do not match.");
            Assert.AreEqual(editCertification.certifiedFrom, updatedCertificationAdded[1], "Actual and expected certification certified from do not match.");
            Assert.AreEqual(editCertification.year, updatedCertificationAdded[2], "Actual and expected certification year do not match.");
            //logging to extent reports

            test.Log(Status.Pass, "Successfully verified updating a Certification record");
        }
        [Test, Order(3), Description("Enter a Certification without Required Fields"), TestCaseSource(nameof(readNegativeAddCertTests))]
        public void negativeAddNewCertification(CertificationModel negativeCertification)
        {
            Certification certificationPage = new Certification(driver);
            certificationPage.addNewCertification(negativeCertification.certificate, negativeCertification.certifiedFrom, negativeCertification.year);

            // Check if the New Certification record has been deleted
            string popUpMessage = certificationPage.getPopUpMessage();
            Assert.AreEqual("Please enter Certification Name, Certification From and Certification Year", popUpMessage, "Actual and expected certification record do not match.");
            //logging to extent reports
            test.Log(Status.Pass, "Successfully verified a Certification record cannot be created without entering the reqiured fields");
        }

        [Test, Order(4), Description("Enter a Duplicate Certification"), TestCaseSource(nameof(readNegativeDuplicateCertTests))]
        public void addDuplicateCertification(CertificationModel duplicateCertification)
        {
            Certification certificationPage = new Certification(driver);
            certificationPage.addNewCertification(duplicateCertification.certificate, duplicateCertification.certifiedFrom, duplicateCertification.year);

            // Check if the New Certification record has not been added
            string popUpMessage = certificationPage.getPopUpMessage();
            Assert.AreEqual("This information is already exist.", popUpMessage, "Actual and expected certification record do not match.");
            //logging to extent reports
            test.Log(Status.Pass, "Successfully verified a duplicate Certification record cannot be created");
        }

        [Test, Order(5), Description("Edit a Certification without Required Fields"), TestCaseSource(nameof(readNegativeEditCertTests))]
        public void negativeEditCertification(CertificationModel negativeCertification)
        {
            Certification certificationPage = new Certification(driver);
            certificationPage.editCertification(negativeCertification.certificate, negativeCertification.certifiedFrom, negativeCertification.year);

            //Check if the New Certification record has not been edited
            string popUpMessage = certificationPage.getPopUpMessage();
            Assert.AreEqual("Please enter Certification Name, Certification From and Certification Year", popUpMessage, "Actual and expected certification record do not match.");
            //logging to extent reports
            test.Log(Status.Pass, "Successfully verified a Certification record cannot be updated without entering the reqiured fields");

        }
        [Test, Order(6), Description("Delete an existing Certification")]
        public void deleteCertification()
        {
            Certification certificationPage = new Certification(driver);
            certificationPage.deleteCertification();

            // Check if the New Certification record has been deleted successfully
            string popUpMessage = certificationPage.getPopUpMessage();
            Assert.AreEqual("Applied Science has been deleted from your certification", popUpMessage, "Actual and expected certification record do not match.");
            //logging to extent reports
            test.Log(Status.Pass, "Successfully verified deleting a Certification record");
        }

    }
}