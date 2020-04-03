using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.Utilities.LoggerUtility
{
    public static class TestCaseInfo
    {
        public static string Site { get; set; }
        public static string Browser { get; set; }
        public static string TestCaseName { get; set; }

        public static List<string> Categories = new List<string>();

    }
}
