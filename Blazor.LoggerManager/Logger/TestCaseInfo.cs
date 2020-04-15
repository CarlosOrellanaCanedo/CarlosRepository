using System.Collections.Generic;
using System.Text;

namespace Blazor.LoggerManager.Logger
{ 
    public static class TestCaseInfo
    {
        public static string Site { get; set; }
        public static string Browser { get; set; }

        private static string _testCaseName;
        public static string TestCaseName { 
            get
            {
                return _testCaseName;
            }
            set 
            {
                string temp = value;
                if (temp != null)
                {
                    _testCaseName = temp.RemoveSpecialCharacters();
                }
                else
                {
                    _testCaseName = "";
                }
            }
        }

        private static string _testCaseFullName;
        public static string TestCaseFullName
        {
            get
            {
                return _testCaseFullName;
            }
            set
            {
                string temp = value;
                if (temp != null)
                {
                    _testCaseFullName = temp.RemoveSpecialCharacters();
                }
                else
                {
                    _testCaseFullName = "";
                }
            }
        }

        private static string _testCaseDescription;
        public static string TestCaseDescription
        {
            get
            {
                return _testCaseDescription;
            }
            set
            {
                string temp = value;
                if (temp != null)
                {
                    _testCaseDescription = temp.RemoveSpecialCharacters();
                }
                else
                {
                    _testCaseDescription = "";
                }
            }
        }

        private static string _featureName;
        public static string FeatureName
        {
            get
            {
                return _featureName;
            }
            set
            {
                string temp = value;
                if (temp != null)
                {
                    _featureName = temp.RemoveSpecialCharacters();
                }
                else
                {
                    _featureName = "";
                }
            }
        }

        public static List<string> Categories = new List<string>();

        private static string RemoveSpecialCharacters(this string str)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in str)
            {
                if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z'))
                {
                    sb.Append(c);
                }
            }

            return sb.ToString();
        }
    }
}
