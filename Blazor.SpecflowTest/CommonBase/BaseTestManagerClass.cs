using Blazor.Core.Controls;
using Blazor.Utilities.ReportManager;

namespace Blazor.SpecflowTest.CommonBase
{
    public static class BaseTestManagerClass
    {
        /// <summary>Mies the test initialize connection.</summary>
        public static void MyTestInitializeConnection()
        {
            //Browser driver init
            SeleniumActions.GetInstance.Init();

            //Login as
            Login();
        }


        /// <summary>Mies the test cleanup close.</summary>
        public static void MyTestCleanupClose()
        {
            //Browser driver close
            SeleniumActions.GetInstance.Close();
            TestCaseProvider.Instance.EndCurrentTestCase();
        }

        /// <summary>
        /// Logout Web Page Method
        /// </summary>
        public static void Logout()
        {
        }

        /// <summary>
        /// Login Method
        /// </summary>
        public static void Login()
        {
            //Log
            TestCaseProvider
                .Instance
                .AddStepInCurrentTestCase(LogStepStatus.Passed,
                "<a style>GoTo LoginPage.</a>");
        }
    }
}
