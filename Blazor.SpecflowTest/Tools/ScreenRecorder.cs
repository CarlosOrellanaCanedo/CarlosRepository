using System;
using System.Configuration;
using System.IO;
using System.Linq;
using Blazor.LoggerManager.Logger;
using Blazor.LoggerManager.LoggerUtilities;
using Microsoft.Expression.Encoder.ScreenCapture;

namespace Blazor.SpecflowTest.Tools
{
    public sealed class ScreenRecorder
    {
        private ScreenCaptureJob screenCaptureJob = new ScreenCaptureJob();
        private string OutputDirectoryName = string.Empty;

        private ScreenRecorder()
        {

        }
        public void SetVideoOutputLocation(string testName)
        {
            OutputDirectoryName = Path.Combine(ConfigurationVariable.TestCaseResultsImageVideoPath, Util.GetCurrectTc());
            if (string.IsNullOrEmpty(testName))
            {
                testName = "AutomationTest";
            }
            else
            {
                string name = $"{testName}{DateTime.UtcNow.ToString("MMddyyyy_Hmm")}.wmv";
                string path = Path.Combine(OutputDirectoryName, name);
                screenCaptureJob.OutputScreenCaptureFileName = path;
                ConfigurationVariable.VideoPath = path;
                ConfigurationVariable.VideoName = name;
                    
            }
        }
        public void DeleteOldRecordings()
        {
            int daysCount = Convert.ToInt16(ConfigurationManager.AppSettings["recordingHistory"]); Directory.GetFiles(OutputDirectoryName)
                 .Select(f => new FileInfo(f))
                 .Where(f => ((f.LastAccessTime < DateTime.Now.AddDays(-daysCount)) && (f.FullName.Contains(ConfigurationVariable.VideoName))))
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
