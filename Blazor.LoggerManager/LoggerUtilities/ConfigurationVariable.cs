﻿using System.Configuration;

namespace Blazor.LoggerManager.LoggerUtilities
{
    public static class ConfigurationVariable
    {
        public static string TestCaseResultsPath => ConfigurationManager.AppSettings["TestCaseResultsPath"];
        public static string TestCaseResultsImageVideoPath => ConfigurationManager.AppSettings["TestCaseResultsImageVideoPath"];
        public static string ReportFileName => ConfigurationManager.AppSettings["ReportFileName"];
        public static string ScreenPath { get; set; }
        public static string VideoPath { get; set; }
        public static string VideoName { get; set; }
    }
}
