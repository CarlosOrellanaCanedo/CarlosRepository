using Blazor.ReportManager;
using TechTalk.SpecFlow;

namespace Blazor.SpecflowTest.CommonBase
{
    [Binding]
    public sealed class BaseTest
    {
        [BeforeTestRun]  
        public static void RunBeforeAll()
        {
        }

        [AfterTestRun] //AssemblyCleanup
        public static void RunAfterAll()
        {
            TestCaseProvider.Instance.EndCurrentTestCase();
        }
    }
}
