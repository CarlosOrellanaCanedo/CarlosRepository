using System;
using System.Configuration;
using System.IO;
using System.Linq;
using Blazor.LoggerManager.Logger;
using Blazor.LoggerManager.LoggerUtilities;
using Microsoft.Expression.Encoder.ScreenCapture;

namespace Blazor.SpecflowTest.Tools
{
    /// <summary>
    /// Screen Recorder class is a Singleton class, this helps to capture a video record.
    /// </summary>
    public sealed class ScreenRecorder
    {
        private ScreenCaptureJob screenCaptureJob = new ScreenCaptureJob();
        private string OutputDirectoryName = string.Empty;

        private ScreenRecorder()
        {

        }

        /// <summary>
        /// Sets the video output Location, create a path with the test cases name.
        /// </summary>
        /// <param name="testName"></param>
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

        /// <summary>
        /// This method deletes the all old recordings
        /// </summary>
        public void DeleteOldRecordings()
        {
            int daysCount = Convert.ToInt16(ConfigurationManager.AppSettings["recordingHistory"]); Directory.GetFiles(OutputDirectoryName)
                 .Select(f => new FileInfo(f))
                 .Where(f => ((f.LastAccessTime < DateTime.Now.AddDays(-daysCount)) && (f.FullName.Contains(ConfigurationVariable.VideoName))))
                 .ToList()
                 .ForEach(f => f.Delete());
        }

        /// <summary>
        /// Starts the video recording
        /// </summary>
        public void StartRecording()
        {
            //DeleteOldRecordings();
            screenCaptureJob.Start();
        }

        /// <summary>
        /// Stops the video recording
        /// </summary>
        public void StopRecording()
        {
            screenCaptureJob.Stop();
            //screenCaptureJob.Dispose();
        }

        /// <summary>
        /// Creates a singleton instance
        /// </summary>
        private static ScreenRecorder _instance;
        public static ScreenRecorder Instance =>
            _instance ?? (_instance = new ScreenRecorder());
    }
}
