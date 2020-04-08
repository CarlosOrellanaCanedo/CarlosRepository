using System.Configuration;

namespace Blazor.Utilities.TestUtilities
{
    public static class ConfigurationVariable
    {
        public static string TestCaseResultsPath => ConfigurationManager.AppSettings["TestCaseResultsPath"];
        public static string ReportFileName => ConfigurationManager.AppSettings["ReportFileName"];
    }
}
