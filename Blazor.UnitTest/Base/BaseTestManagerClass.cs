using Blazor.Core.Browser;
using Blazor.LoggerManager.Logger;
using Blazor.LoggerManager.LoggerUtilities;
using Blazor.ReportManager;
using Blazor.UnitTest.Tools;

namespace Blazor.UnitTest.Base
{
    public class BaseTestManagerClass
    {
        /// <summary>
        /// The method initializes the web driver and start recording the video.
        /// </summary>
        public void MyTestInitializeConnection()
        {
            BrowserManager.Instance.Init();
            ScreenRecorder.Instance.SetVideoOutputLocation(TestCaseInfo.TestCaseName);
            ScreenRecorder.Instance.StartRecording();
        }

        /// <summary>
        /// The method cleanup and close all services.
        /// </summary>
        public void MyTestCleanupClose()
        {
            // Close WebDriver Instance
            BrowserManager.Instance.Close();
            // Stop and save video
            ScreenRecorder.Instance.StopRecording();
            // Extent Report close the report
            TestCaseProvider.Instance.EndCurrentTestCase();
        }
    }
}
