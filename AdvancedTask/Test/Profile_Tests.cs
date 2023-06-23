using AdvancedTask.Models;
using AdvancedTask.Pages.ProfilePage;
using AdvancedTask.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTask.Test
{
    [TestFixture]
    [Parallelizable]
    public class CertificationTests : CommonDriver
    {
        [Test, Order(1), Description("Add Certification")]
        public void addNewCertification()
        {
            Certification certificationPage = new Certification(driver);
            CertificationModel certification = CommonDriver.readCertification("certificationsPositive_01.json");
            certificationPage.addNewCertification(certification.certificate, certification.certifiedFrom, certification.year);
        }
        
        [Test, Order(2), Description("Edit an existing Certification")]
        public void editCertification()
        {
            Certification certificationPage = new Certification(driver);
            certificationPage.editCertification("MySQL", "Udemy", "2023");
        }

        [Test, Order(3), Description("Delete an existing Certification")]
        public void deleteCertification()
        {
            Certification certificationPage = new Certification(driver);
            certificationPage.deleteCertification();
        }

        [Test, Order(4), Description("Enter a Certification without Certificate Name")]
        public void enterCertificateWithoutName()
        {
            
        }
    }

    public class SkillTests : CommonDriver
    {
        [Test, Order(1), Description("Add Skill")]
        public void addNewSkill()
        {
            
        }
    }

    public class EducationTests : CommonDriver
    {
        [Test, Order(1), Description("Add Education")]
        public void addNewEducation()
        {

        }
    }
}
