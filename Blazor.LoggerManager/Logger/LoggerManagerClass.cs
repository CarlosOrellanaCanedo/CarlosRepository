using System.Configuration;
using Serilog;
using System;
using System.IO;
using Blazor.LoggerManager.LoggerUtilities;

namespace Blazor.LoggerManager.Logger
{
    public sealed class LoggerManagerClass
    {
        private static string LoggerReportPath = ConfigurationVariable.TestCaseResultsPath;

        private LoggerManagerClass()
        {
            const string customTemplate = "{Timestamp:yyyy-MMM-dd HH:mm:ss} [{Level}] {Message}{NewLine}{Exception}";
            const string loggerFileName = @"Logs.txt";

            var fullPath = Path.Combine(LoggerReportPath, loggerFileName);

            if (Directory.Exists(LoggerReportPath))
            {
                Log.Logger = new LoggerConfiguration()
                    .Enrich.WithProperty("MachineName", Environment.MachineName)
                    .Enrich.WithProperty("BlazorSite", TestCaseInfo.Site)
                    .Enrich.WithProperty("Browser", TestCaseInfo.Browser)
                    //.WriteTo.Seq("http://10.170.48.153:5341/")
                    .WriteTo.RollingFile(fullPath, outputTemplate: customTemplate)
                    //.WriteTo.ColoredConsole()
                    .CreateLogger();
            }
            else
            {
                Console.WriteLine($"The folder: [ {LoggerReportPath} ] does not exist.");
                Console.WriteLine(@"Logging will start in the console...");

                Log.Logger = new LoggerConfiguration()
                    .WriteTo.ColoredConsole()
                    .CreateLogger();
            }
        }

        public void Information(string message, bool isFinalResult = false)
        {
            if (isFinalResult)
            {
                Log.ForContext("TestCase", TestCaseInfo.TestCaseName)
                   .ForContext("TcResult", "Passed")
                   .Information("{TestCase} " + message, TestCaseInfo.TestCaseName);
            }
            else
            {
                Log.ForContext("TestCase", TestCaseInfo.TestCaseName)
                   .Information(message);
            }
        }

        public void Warning(string message, bool isFinalResult = false)
        {
            if (isFinalResult)
            {
                Log.ForContext("TestCase", TestCaseInfo.TestCaseName)
                    .ForContext("TcResult", "Warning")
                    .Warning("{TestCase} " + message, TestCaseInfo.TestCaseName);
            }
            else
            {
                Log.ForContext("TestCase", TestCaseInfo.TestCaseName)
                    .Warning(message);
            }
        }

        public void Error(string message, bool isFinalResult = false)
        {
            if (isFinalResult)
            {
                Log.ForContext("TestCase", TestCaseInfo.TestCaseName)
                    .ForContext("TcResult", "Failed")
                    .Error("{TestCase} " + message, TestCaseInfo.TestCaseName);
            }
            else
            {
                Log.ForContext("TestCase", TestCaseInfo.TestCaseName)
                    .Error(message);
            }
        }

        private static LoggerManagerClass _logger;
        public static LoggerManagerClass Instance => _logger ?? (_logger = new LoggerManagerClass());
    }
}
