using Blazor.LoggerManager.Logger;
using Blazor.LoggerManager.LoggerUtilities;
using Blazor.ReportManager;
using Blazor.UnitTest.Tools;
using Blazor.Utilities.ExceptionMethods;
using Blazor.Utilities.Process;
using NUnit.Framework;
using System;
using System.IO;

namespace Blazor.UnitTest.Base
{
    [TestFixture]
    public class BaseTestCase : BaseTestManagerClass
    {
        [SetUp]
        public void MyTestInitialize()
        {
            Util.CreateFolder(ConfigurationVariable.TestCaseResultsPath);
            Util.CreateFolder(ConfigurationVariable.TestCaseResultsImageVideoPath);

            TestCaseInfo.TestCaseName = TestContext.CurrentContext.Test.Name;
            TestCaseInfo.TestCaseFullName = TestContext.CurrentContext.Test.FullName;
            TestCaseInfo.TestCaseDescription = "";


            // TC Folder Name
            var tcFolder = Path.Combine(ConfigurationVariable.TestCaseResultsImageVideoPath, TestCaseInfo.TestCaseName);
            Util.SaveCurrentTc(TestCaseInfo.TestCaseName);
            Util.CreateFolder(tcFolder);
            // Start the new test case logger on extent report
            TestCaseProvider.Instance.AddNewTestCase(TestCaseInfo.TestCaseName, TestCaseInfo.TestCaseDescription);
            MyTestInitializeConnection();
        }

        [TearDown]
        public void MyTestCleanup()
        {
            try
            {
                // Clean up all connections and generate report
                var testFinalStatus = CheckTestCaseStatus();
                var message = TestContext.CurrentContext.Result.Message;

                var stackTrace = TestContext.CurrentContext.Result.StackTrace;

                TestCaseProvider.Instance
                    .LogTestCaseFinalStatus(testFinalStatus, message, stackTrace,
                    TestCaseInfo.TestCaseFullName, TestCaseInfo.TestCaseName);

                MyTestCleanupClose();
                ProcessManager.KillProcess("chrome");
            }
            catch (Exception e)
            {
                // Clean up all connections and generate report
                MyTestCleanupClose();

                //Kill chrome driver
                ProcessManager.KillProcess("chromedriver");
                ProcessManager.KillProcess("chrome");

                ExceptionManager.WarningMessageLog(e.Message);
            }
        }

        protected string CheckTestCaseStatus()
        {
            //Get final test status
            var testFinalStatus = TestContext.CurrentContext.Result.Outcome.Status.ToString();
            switch (testFinalStatus)
            {
                case "Error":
                case "Failed":
                case "Failure":
                case "Skipped":
                case "Inconclusive":
                    ScreenCapture.TakeScreenshot();
                    break;
            }

            return testFinalStatus;
        }
    }
}
