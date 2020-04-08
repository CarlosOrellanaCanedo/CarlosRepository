using System.Collections;

namespace Blazor.Utilities.TestUtilities
{
    public class TestExecution
    {
        private readonly string _testOutcome;
        private readonly string _testName;
        private readonly string _testFullName;
        private readonly string _testDescription;
        private readonly string _errorMessage;
        private readonly string _stackTrace;
        private readonly string _source;
        private readonly IList _categories;

        public TestExecution(string testOutcome, string testName, string testFullName,
                             string testDescription, string errorMessage, string stackTrace,
                             string source)
        {
            _testOutcome = testOutcome;
            _testName = testName;
            _testFullName = testFullName;
            _testDescription = testDescription;
            _errorMessage = errorMessage;
            _stackTrace = stackTrace;
            _source = source;
        }

        public string Source
        {
            get { return _source; }
        }

        public string TestOutcome
        {
            get { return _testOutcome; }
        }

        public string TestName
        {
            get { return _testName; }
        }

        public string TestFullName
        {
            get { return _testFullName; }
        }

        public string TestDescription
        {
            get { return _testDescription; }
        }

        public string ErrorMessage
        {
            get { return _errorMessage; }
        }

        public string StackTrace
        {
            get { return _stackTrace; }
        }

    }
}
