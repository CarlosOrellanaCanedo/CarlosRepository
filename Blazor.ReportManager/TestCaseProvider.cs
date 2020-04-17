using RelevantCodes.ExtentReports;
using System;
using System.Text.RegularExpressions;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Net;
using Blazor.LoggerManager.LoggerUtilities;
using Blazor.LoggerManager.Logger;

namespace Blazor.ReportManager
{
    /// <summary>
    /// Log steps status Enum
    /// </summary>
    public enum LogStepStatus
    {
        Passed,
        Failed,
        Warning,
        Skipped
    };

    /// <summary>
    /// TestCaseProvider class constains all necessary methods to create a new Extent Report.
    /// Create a test cases in the report and capture all steps executed.
    /// Capture and save an Image of the screen when the test case failed, and
    /// SAve a video with all execution test cases.
    /// </summary>
    public sealed class TestCaseProvider
    {
        private ExtentTest _currentTestCase;
        private ExtentReports _extentReports;

        private readonly string _fileLogsFailed =
            Path.Combine(ConfigurationVariable.TestCaseResultsPath, "BlazorFailedTests");

        private readonly string _fileLogsFailedAndMessage = Path.Combine(ConfigurationVariable.TestCaseResultsPath, 
            "BlazorFailedTestAnsMessage");

        private readonly string _reprotFileFullPath = Path.Combine(ConfigurationVariable.TestCaseResultsPath,                 
            ConfigurationVariable.ReportFileName);

        /// <summary>
        /// Create Singleton instance
        /// </summary>
        private static TestCaseProvider instance;
        public static TestCaseProvider Instance =>
            instance ?? (instance = new TestCaseProvider());

        /// <summary>
        /// Create ExtentReport instance and assign the Project Name
        /// </summary>
        private TestCaseProvider()
        {
            _fileLogsFailed = _fileLogsFailed + ".txt";
            _fileLogsFailedAndMessage = _fileLogsFailedAndMessage + ".txt";

            _extentReports = new ExtentReports(_reprotFileFullPath + ".html", false, DisplayOrder.NewestFirst);
            _extentReports.AssignProject("Blazor");

            string local = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);


            if (local != null)
            {
                string extenConfigpath = Path.Combine(local, @"extent-config.xml");

                if (File.Exists(extenConfigpath))
                {
                    _extentReports.LoadConfig(extenConfigpath);
                }
            }
        }

        /// <summary>
        /// This method allow us strat the test cases to Extent report
        /// </summary>
        /// <param name="testName">string test name</param>
        /// <param name="description">string test description</param>
        public void AddNewTestCase(string testName, string description)
        {
            _currentTestCase = _extentReports.StartTest(testName, description);
        }

        /// <summary>
        /// This method allow us end the test cases to extent report and create the report
        /// </summary>
        public void EndCurrentTestCase()
        {
            _extentReports.EndTest(_currentTestCase);
            _extentReports.Flush();
        }

        /// <summary>
        /// This method allow us add the screenshot in the test cases when the step is failed
        /// </summary>
        private void AddPicturesOnFail()
        {
            try
            {
                var tcFolder = ConfigurationVariable.ScreenPath;
                _currentTestCase.Log(LogStatus.Error,
                        _currentTestCase.AddScreenCapture(tcFolder));
            }
            catch (Exception ex)
            {
                LoggerManagerClass.Instance.Error(ex.Message);
            }
        }

        /// <summary>
        /// This methos allow us add the an screen cast whit all test cases execution
        /// </summary>
        private void AddScreenCast()
        {
            string videoPath = ConfigurationVariable.VideoPath;

            if (File.Exists(videoPath))
            { //_currentTestCase.Log(LogStatus.Error, "<a href=\"" + "file:///" + videoPath + "\">Video</a>");
                
                _currentTestCase.AddScreencast(videoPath);
                _currentTestCase.Log(LogStatus.Error, "<a href=\"" + "file:///" + videoPath + "\">Video</a>");
            }
        }

        /// <summary>
        /// This method allows us all actions or steps performed in the test cases execution.
        /// </summary>
        /// <param name="logStepStatus"></param>
        /// <param name="details"></param>
        /// <param name="exceptionMessage"></param>
        public void AddStepInCurrentTestCase(LogStepStatus logStepStatus,
            string details = "", string exceptionMessage = "")
        {
            switch (logStepStatus)
            {
                case LogStepStatus.Passed:
                    _currentTestCase.Log(LogStatus.Pass, details);
                    break;
                case LogStepStatus.Failed:
                    _currentTestCase.Log(LogStatus.Fail, details);
                    if (!string.IsNullOrEmpty(exceptionMessage))
                    {
                        _currentTestCase.Log(LogStatus.Error,
                            "Exception Info: " + exceptionMessage);
                    }
                    break;
                case LogStepStatus.Warning:
                    _currentTestCase.Log(LogStatus.Warning, details);
                    break;

                case LogStepStatus.Skipped:
                    _currentTestCase.Log(LogStatus.Skip, details);
                    break;
            }
        }

        /// <summary>
        /// This method allow us create log of test cases whit the final status
        /// </summary>
        /// <param name="status">string Final Status</param>
        /// <param name="errorMessage">string Error test case Message</param>
        /// <param name="testContextStackTrace">string Conext Stack Trace</param>
        /// <param name="tcFullName">string Test Case full name</param>
        /// <param name="tcName">string Test Case name</param>
        public void LogTestCaseFinalStatus(string status, string errorMessage,
            string testContextStackTrace, string tcFullName, string tcName)
        {
            LogStatus logStatus;
            string fullError = string.Empty;

            switch (status)
            {
                case "Failed":
                    logStatus = LogStatus.Fail;
                    fullError = TestCaseHasFailed(errorMessage, testContextStackTrace, tcFullName, tcName, logStatus);
                    
                    break;
                case "Inconclusive":
                    logStatus = LogStatus.Warning;
                    fullError = TestCaseHasFailed(errorMessage, testContextStackTrace, tcFullName, tcName, logStatus);
                    break;

                case "Skipped":
                    logStatus = LogStatus.Skip;
                    LoggerManagerClass.Instance.Warning(@"Test ended with: [ " + logStatus + @" ]. ", true);
                    break;

                case "Passed":
                    logStatus = LogStatus.Pass;
                    LoggerManagerClass.Instance.Information(@"Test ended with: [ " + logStatus + @" ]. ", true);
                    break;

                case "Unknown":
                    logStatus = LogStatus.Unknown;
                    fullError = TestCaseHasFailed(errorMessage, testContextStackTrace, tcFullName, tcName, logStatus);
                    break;

                case "Warning":
                    logStatus = LogStatus.Warning;
                    fullError = TestCaseHasFailed(errorMessage, testContextStackTrace, tcFullName, tcName, logStatus);
                    break;

                default:
                    logStatus = LogStatus.Fail;
                    fullError = TestCaseHasFailed(errorMessage, testContextStackTrace, tcFullName, tcName, logStatus);
                    break;
            }

            _currentTestCase.Log(logStatus, @"Test ended with: [ " + logStatus + @" ]. " + fullError);
        }

        /// <summary>
        /// This method allow us process all data when an test case's step failed
        /// </summary>
        /// <param name="errorMessage">string error message</param>
        /// <param name="testContextStackTrace">string context stack trace</param>
        /// <param name="tcFullName">string Test Case full name</param>
        /// <param name="tcName">string Test Case name</param>
        /// <param name="finalStatus">string Test Case final status</param>
        /// <returns></returns>
        private string TestCaseHasFailed(string errorMessage, string testContextStackTrace, string tcFullName, 
            string tcName, LogStatus finalStatus)
        {
            string bddStep = string.Empty;
            string errorForLog = string.Empty;
            string fullError = string.Empty;

            AddPicturesOnFail();
            AddScreenCast();
            LogFailedTCs(tcFullName);

            if (!string.IsNullOrEmpty(errorMessage))
            {
                bool hasBddStep;
                bddStep = GetBddStep(errorMessage, out hasBddStep);
                if (hasBddStep)
                {
                    errorMessage = errorMessage.Replace(bddStep, string.Empty);
                }

                int index = errorMessage.IndexOf(": ", 0, StringComparison.Ordinal);
                if (index >= 0)
                {
                    errorMessage = errorMessage.Substring(index + 2);
                }

                string message = $"{@bddStep} <pre>{WebUtility.HtmlEncode(errorMessage)}</pre>";
                fullError += message;
                errorForLog += errorMessage;
            }

            //Log failed testcase with the error message included
            LogFailedTcsWithErrorMessage(tcName, bddStep + errorForLog);

            //Manage Stack Trace Message
            if (!string.IsNullOrEmpty(testContextStackTrace))
            {
                errorForLog += WebUtility.HtmlEncode(testContextStackTrace);

                fullError += "<pre>" +
                             "<div class=\"expand-one\"><a href=\"#\">Click here for more details...</a></div>" +
                             $"<div class=\"content-one\">{WebUtility.HtmlEncode(testContextStackTrace)}</div>" +
                             "</pre>";
            }

            //Log to report
            LoggerManagerClass.Instance.Error($"Test ended with: [ {finalStatus} @]. {errorForLog}", true);

            return fullError;
        }

        /// <summary>
        /// Write the Logs Failed on txt file and in the Extent Report.
        /// </summary>
        /// <param name="tcName"></param>
        private void LogFailedTCs(string tcName)
        {
            try
            {
                if (!File.Exists(_fileLogsFailed))
                {
                    File.Create(_fileLogsFailed).Close();
                    Thread.Sleep(TimeSpan.FromSeconds(1));

                    //Log
                    LoggerManagerClass.Instance.Information($"File to log failed tests: {_fileLogsFailed} created.");
                }

                using (var sw = new StreamWriter(_fileLogsFailed, true))
                {
                    sw.WriteLine(tcName);
                }
                Thread.Sleep(TimeSpan.FromSeconds(1));

            }
            catch (Exception ex)
            {
                //Log
                LoggerManagerClass.Instance.Error(tcName + " - " + ex.Message);
            }
        }

        /// <summary>
        /// Write the Log Filed Test case with Error Message
        /// </summary>
        /// <param name="tcName"></param>
        /// <param name="errorMessage"></param>
        private void LogFailedTcsWithErrorMessage(string tcName, string errorMessage)
        {
            try
            {
                if (!File.Exists(_fileLogsFailedAndMessage))
                {
                    File.Create(_fileLogsFailedAndMessage).Close();
                    Thread.Sleep(TimeSpan.FromSeconds(1));

                    //Log
                    LoggerManagerClass.Instance.Information($"File to log failed tests and error messages: " +
                        $"{_fileLogsFailedAndMessage} created.");
                }

                errorMessage = Regex.Replace(errorMessage, @"\t|\n|\r", "");
                errorMessage = errorMessage.Replace("::", ":");

                using (var sw = new StreamWriter(_fileLogsFailedAndMessage, true))
                {
                    sw.WriteLine($"{tcName} :: {errorMessage}");
                }
                Thread.Sleep(TimeSpan.FromSeconds(1));
            }
            catch (Exception ex)
            {
                //Log
                LoggerManagerClass.Instance.Error(tcName + " - " + ex.Message);
            }
        }

        /// <summary>
        /// Get the BDD Step html element from the message
        /// </summary>
        /// <param name="message"></param>
        /// <param name="hasBddStep"></param>
        /// <returns></returns>
        private string GetBddStep(string message, out bool hasBddStep)
        {
            hasBddStep = false;
            if (message.Contains("<div class='bdd-step'>"))
            {
                hasBddStep = true;
                return Regex.Match(message, "<div class='bdd-step'>(.+)</div>").Groups[0].Value;
            }

            return string.Empty;
        }
    }
}
