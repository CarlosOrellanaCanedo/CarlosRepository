using Blazor.Core.Browser;
using Blazor.LoggerManager.Logger;
using Blazor.LoggerManager.LoggerUtilities;
using Blazor.ReportManager;
using Blazor.UnitTest.Tools;

namespace Blazor.UnitTest.Base
{
    public class BaseTestManagerClass
    {

        public void MyTestInitializeConnection()
        {
            BrowserManager.Instance.Init();
            ScreenRecorder.Instance.SetVideoOutputLocation(TestCaseInfo.TestCaseName);
            ScreenRecorder.Instance.StartRecording();
        }

        public void MyTestCleanupClose()
        {
            // Close WebDriver Instance
            BrowserManager.Instance.Close();
            // Stop and save video
            ScreenRecorder.Instance.StopRecording();
            ScreenRecorder.Instance.DeleteOldRecordings();
            // Extent Report close the report
            TestCaseProvider.Instance.EndCurrentTestCase();
        }
    }
}
