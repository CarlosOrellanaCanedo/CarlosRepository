using System;
using System.Configuration;
using System.IO;
using System.Linq;
using Blazor.LoggerManager.LoggerUtilities;
using Microsoft.Expression.Encoder.ScreenCapture;

namespace Blazor.SpecflowTest.Tools
{
    public class ScreenRecorder
    {
        private ScreenCaptureJob screenCaptureJob = new ScreenCaptureJob();
        private string OutputDirectoryName = Path.Combine(Util.GetImagesAndVideoFullPath(), Util.GetCurrectTc());

        private ScreenRecorder()
        {

        }
        public void SetVideoOutputLocation(string testName)
        {
            if (string.IsNullOrEmpty(testName))
            {
                testName = "AutomationTest";
            }
            else
            {
                string path = Path.Combine(OutputDirectoryName, $"{testName}{DateTime.UtcNow.ToString("MMddyyyy_Hmm")}.wmv");
                screenCaptureJob.OutputScreenCaptureFileName = path;
                ConfigurationVariable.VideoPath = path;
                    
            }
        }
        private void DeleteOldRecordings()
        {
            int daysCount = Convert.ToInt16(ConfigurationManager.AppSettings["recordingHistory"]); Directory.GetFiles(OutputDirectoryName)
                 .Select(f => new FileInfo(f))
                 .Where(f => (f.LastAccessTime < DateTime.Now.AddDays(-daysCount)) && (f.FullName.Contains(".wmv")))
                 .ToList()
                 .ForEach(f => f.Delete());
        }
        public void StartRecording()
        {
            //DeleteOldRecordings();
            screenCaptureJob.Start();
        }
        public void StopRecording()
        {
            screenCaptureJob.Stop();
            //screenCaptureJob.Dispose();
        }

        private static ScreenRecorder _instance;
        public static ScreenRecorder Instance =>
            _instance ?? (_instance = new ScreenRecorder());
    }
}
