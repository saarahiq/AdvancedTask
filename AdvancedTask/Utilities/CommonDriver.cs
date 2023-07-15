using AdvancedTask.Models;
using AdvancedTask.Pages;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Newtonsoft.Json;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTask.Utilities
{
    public class CommonDriver
    {
        public IWebDriver driver;
        public User testUser;
        public MarsLoginPage marsLoginPage;
        public static string ScreenshotPath = Properties.Resources.ScreenshotPath;
        public static string ReportPath = Properties.Resources.ExtentReportPath;

        #region reports
        public static ExtentTest test;
        public static ExtentReports extent;
        #endregion

        //Page object initialization
        [SetUp]
        public void Setup()
        {
            

            this.driver = new ChromeDriver();
            this.marsLoginPage = new MarsLoginPage(driver);
            this.testUser = ReadTestUser("JSONData\\TestUser.json");
            //Open chrome browser
            driver.Manage().Window.Maximize();

            #region Initialise Reports
            // Initialise Test
            var html = new ExtentHtmlReporter(ReportPath);
            extent = new ExtentReports();
            extent.AttachReporter(html);
            test = extent.CreateTest("AdvancedTask");
            #endregion

            //Launch Mars portal
            driver.Navigate().GoToUrl("http://localhost:5000");
            marsLoginPage.Login(this.testUser);
            
        }
        public static string SaveScreenshot(IWebDriver driver, string ScreenShotFileName) // Definition
        {
            var folderLocation = (ScreenshotPath);

            if (!Directory.Exists(folderLocation))
            {
                Directory.CreateDirectory(folderLocation);
            }

            var screenShot = ((ITakesScreenshot)driver).GetScreenshot();
            var fileName = new StringBuilder(folderLocation);

            fileName.Append(ScreenShotFileName);
            fileName.Append(DateTime.Now.ToString("_dd-mm-yyyy_mss"));
            //fileName.Append(DateTime.Now.ToString("dd-mm-yyyym_ss"));
            fileName.Append(".png");
            screenShot.SaveAsFile(fileName.ToString(), ScreenshotImageFormat.Png);
            return fileName.ToString();
        }
        [TearDown]
        public void TearDown()
        {
            // Screenshot
            String img = SaveScreenshot(driver, "Report");

            // end test. (Reports)

            // calling Flush writes everything to the log file (Reports)
            extent.Flush();
            driver.Close();
            driver.Quit();

        }
        public static User ReadTestUser(string path)
        {
            var json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<User>(json);
        }
        public static CertificationModel readCertification(string jsonCertFile)
        {
            var json = File.ReadAllText(String.Concat(@"C:\Users\saara\source\repos\AdvancedTask\AdvancedTask\JSONData\Certifications\", jsonCertFile));
            return JsonConvert.DeserializeObject<CertificationModel>(json);
        }
        public static SkillModel readSkills(string jsonSkillFile)
        {
            var json = File.ReadAllText(String.Concat(@"C:\Users\saara\source\repos\AdvancedTask\AdvancedTask\JSONData\Skills\", jsonSkillFile));
            return JsonConvert.DeserializeObject<SkillModel>(json);
        }
        public static EducationModel readEducation(string jsonEducationFile)
        {
            var json = File.ReadAllText(String.Concat(@"C:\Users\saara\source\repos\AdvancedTask\AdvancedTask\JSONData\Education\", jsonEducationFile));
            return JsonConvert.DeserializeObject<EducationModel>(json);
        }
        public static ShareSkillModel readShareSkill(string jsonShareSkillFile)
        {
            var json = File.ReadAllText(String.Concat(@"C:\Users\saara\source\repos\AdvancedTask\AdvancedTask\JSONData\EditShareSkill\", jsonShareSkillFile));
            return JsonConvert.DeserializeObject<ShareSkillModel>(json);
        }
    }
}
