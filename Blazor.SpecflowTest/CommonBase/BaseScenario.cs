using Blazor.SpecflowTest.Tools;
using Blazor.Utilities.EnvironmentVariables;
using Blazor.Utilities.ExceptionMethods;
using Blazor.Utilities.LoggerUtility;
using Blazor.Utilities.Process;
using Blazor.Utilities.ReportManager;
using Blazor.Utilities.TestUtilities;
using NUnit.Framework;
using System;
using System.IO;
using TechTalk.SpecFlow;

namespace Blazor.SpecflowTest.CommonBase
{
    [Binding]
    public sealed class BaseScenario
    {
        private string TestName { get; set; }
        private string FullName { get; set; }
        private string Description { get; set; }

        [BeforeScenario]
        public void MyScenarioInitialize()
        {
            //var scenarioTags = ScenarioContext.Current.ScenarioInfo.Tags;

            TestName = TestContext.CurrentContext.Test.Name;
            FullName = TestContext.CurrentContext.Test.FullName;
            Description = FeatureContext.Current.FeatureInfo.Title;
            TestCaseInfo.TestCaseName = TestName;
            TestName = TestName;
            FullName = FullName;

            //TC Folder Name
            var tcFolder = Path.Combine(Util.GetImagesAndVideoFullPath(), TestName);
            Util.SaveCurrentTc(TestName);
            Util.CreateTcFolder(tcFolder);

            TestCaseProvider.Instance.AddNewTestCase(TestName, Description);
            BaseTestManagerClass.MyTestInitializeConnection();
        }

        [AfterScenario]
        public void MyScenarioCleanup()
        {
            try
            {
                // TC Description - Feature title
                var testFinalStatus = CheckTestCaseStatus();
                var message = EnvironmentVariableHelper.GetBddStepDescription() + 
                    TestContext.CurrentContext.Result.Message;

                var stackTrace = TestContext.CurrentContext.Result.StackTrace;

                TestCaseProvider.Instance.LogTestCaseFinalStatus(testFinalStatus, message,
                    stackTrace, FullName, Description, "", "BDD", TestName);

                BaseTestManagerClass.MyTestCleanupClose(); 
                ProcessManager.KillProcess("chrome");
            }
            catch (Exception e)
            {
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
