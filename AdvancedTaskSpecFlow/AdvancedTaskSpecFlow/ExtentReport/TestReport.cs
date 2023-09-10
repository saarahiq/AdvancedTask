using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTaskSpecFlow.ExtentReport
{
    public class TestReport
    {
        public static ExtentHtmlReporter? htmlReporter;
        private static ExtentReports? extent = null;
        public static ExtentReports GetInstance()
        {
            if (extent == null)
            {

                string reportPath = Path.Combine(GetReportPath(), "Report.html");
                Console.WriteLine(reportPath);

                htmlReporter = new ExtentHtmlReporter(reportPath);
                extent = new ExtentReports();
                extent.AttachReporter(htmlReporter);
                extent.AddSystemInfo("OS", "Windows");
                extent.AddSystemInfo("Host Name", "Nikita");
                extent.AddSystemInfo("Enviroment", "QA");
                extent.AddSystemInfo("UserName", "Nikita");
            }
            return extent;

        }
        public static string GetReportPath()
        {
            string currentDir = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            string reportPath = Path.Combine(currentDir, "TestReport");
            return reportPath;
        }

        public static string GetScreenShotPath()
        {
            return Path.Combine(GetReportPath(), "Screenshots");
        }
    }
}
