﻿using AdvancedTask.JSON_Objects;
using AdvancedTask.Pages;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Newtonsoft.Json;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using RazorEngine.Compilation.ImpromptuInterface.Dynamic;
using AventStack.ExtentReports;
using AdvancedTask.Report;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvancedTask.Pages.ProfilePageTabs;
using AdvancedTask.Models;
using RazorEngine;
using Language = AdvancedTask.Pages.ProfilePageTabs.Language;

namespace AdvancedTask.Utilities
{
    public class CommonDriver
    {
        public IWebDriver driver;
        public UserObject testUser;
        public Language languagePage;
        public MarsLoginPage marsLoginPage;
        public static string ScreenshotPath = Properties.Resources.ScreenshotPath;
        public static string ReportPath = Properties.Resources.ExtentReportPath;

        #region reports
        public static ExtentTest test;
        public static ExtentReports extent;
        #endregion

        //Page object initialization
        [OneTimeSetUp]
        public void Initialize()
        {
            // Initialise Test
            var html = new ExtentHtmlReporter(ReportPath);
            extent = new ExtentReports();
            extent.AttachReporter(html);
            test = extent.CreateTest("AdvancedTask");
        }
        [SetUp]
        public void Setup()
        {
            

            this.driver = new ChromeDriver();
            this.marsLoginPage = new MarsLoginPage(driver);
            this.languagePage = new Language(driver);
            this.testUser = ReadTestUser("JSONData\\TestUser.json");
            //Open chrome browser
            driver.Manage().Window.Maximize();

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
            
            driver.Close();
            driver.Quit();

        }
        [OneTimeTearDown]
        public void OneTimeTeardown()
        {
            extent.Flush();
        }
        public string Capture(String screenShotName)
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            Screenshot screenshot = ts.GetScreenshot();
            var localPath = Path.Combine(TestReport.GetScreenShotPath(), screenShotName);
            screenshot.SaveAsFile(localPath, ScreenshotImageFormat.Png);
            string relPath = Path.GetRelativePath(TestReport.GetReportPath(), localPath);
            return relPath;
        }
        public static UserObject ReadTestUser(string path)
        {
            var json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<UserObject>(json);
        }
        public static LanguageObject ReadTestLanguage(string path)
        {
            var json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<LanguageObject>(json);
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