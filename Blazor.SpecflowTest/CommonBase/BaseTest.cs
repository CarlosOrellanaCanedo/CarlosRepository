using Blazor.Utilities.LoggerUtility;
using Blazor.Utilities.ReportManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
