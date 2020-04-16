using Blazor.LoggerManager.Logger;
using Blazor.LoggerManager.LoggerUtilities;
using Blazor.ReportManager;
using Blazor.SpecflowTest.Tools;
using Blazor.Utilities.EnvironmentVariables;
using Blazor.Utilities.ExceptionMethods;
using Blazor.Utilities.Process;
using NUnit.Framework;
using System;
using System.IO;
using TechTalk.SpecFlow;

namespace Blazor.SpecflowTest.CommonBase
{
    [Binding]
    public sealed class BaseScenario
    {

        private readonly ScenarioContext scenarioContext;

        public BaseScenario(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
        }

        [BeforeScenario]
        public void MyScenarioInitialize()
        {
            // Create Results Folders
            Util.CreateFolder(ConfigurationVariable.TestCaseResultsPath);
            Util.CreateFolder(ConfigurationVariable.TestCaseResultsImageVideoPath);

            TestCaseInfo.TestCaseName = scenarioContext.ScenarioInfo.Title;
            TestCaseInfo.TestCaseFullName = scenarioContext.ScenarioInfo.Title;
            TestCaseInfo.TestCaseDescription = scenarioContext.ScenarioInfo.Description;
            

            //TC Folder Name
            var tcFolder = Path.Combine(ConfigurationVariable.TestCaseResultsImageVideoPath, TestCaseInfo.TestCaseName);
            Util.SaveCurrentTc(TestCaseInfo.TestCaseName);
            Util.CreateFolder(tcFolder);
            TestCaseProvider.Instance.AddNewTestCase(TestCaseInfo.TestCaseName, TestCaseInfo.TestCaseDescription);
            BaseTestManagerClass.MyTestInitializeConnection();
        }

        [AfterScenario]
        public void MyScenarioCleanup()
        {
            try
            {
                // Clean up all connections and generate report
                var testFinalStatus = CheckTestCaseStatus();
                var message = EnvironmentVariableHelper.GetBddStepDescription() + 
                    TestContext.CurrentContext.Result.Message;

                var stackTrace = TestContext.CurrentContext.Result.StackTrace;

                TestCaseProvider.Instance
                    .LogTestCaseFinalStatus(testFinalStatus, message, stackTrace, 
                    TestCaseInfo.TestCaseFullName, TestCaseInfo.TestCaseName);

                BaseTestManagerClass.MyTestCleanupClose(); 
                ProcessManager.KillProcess("chrome");
            }
            catch (Exception e)
            {
                // Clean up all connections and generate report
                BaseTestManagerClass.MyTestCleanupClose();

                //Kill chrome driver
                ProcessManager.KillProcess("chromedriver");
                ProcessManager.KillProcess("chrome");

                ExceptionManager.WarningMessageLog(e.Message);
            }
        }

        /// <summary>
        /// Check the Test Case Status
        /// </summary>
        /// <returns></returns>
        private string CheckTestCaseStatus()
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
