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
                if (_testCaseName != null)
                {
                    return _testCaseName.RemoveSpecialCharacters();
                }
                else
                {
                    return string.Empty;
                }
            }
            set 
            {
                _testCaseName = value;
            }
        }

        private static string _testCaseFullName;
        public static string TestCaseFullName
        {
            get
            {
                if (_testCaseFullName != null)
                {
                    return _testCaseFullName.RemoveSpecialCharacters();
                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                _testCaseFullName = value;
            }
        }

        private static string _testCaseDescription;
        public static string TestCaseDescription
        {
            get
            {
                if (_testCaseDescription != null)
                {
                    return RemoveSpecialCharacters(_testCaseDescription);
                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                _testCaseDescription = value;
            }
        }

        private static string _featureName;
        public static string FeatureName
        {
            get
            {
                if (_featureName != null)
                {
                    return _featureName.RemoveSpecialCharacters();
                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                _featureName = value;
            }
        }

        public static List<string> Categories = new List<string>();

        private static string RemoveSpecialCharacters(this string str)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in str)
            {
                if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '.' || c == '_')
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }
    }
}
