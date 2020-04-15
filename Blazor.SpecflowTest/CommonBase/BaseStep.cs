using Blazor.ReportManager;
using Blazor.Utilities.EnvironmentVariables;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Blazor.SpecflowTest.CommonBase
{
    [Binding]
    public sealed class BaseStep
    {
        [BeforeStep]
        public static void MyStepInitialize()
        {
            //string step = ScenarioStepContext.Current.StepInfo.Text;
            //string stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();

            //string stepConvert = $"<span style='color:blue'>{stepType} : {step}</span>";
            //TestCaseProvider.Instance.AddStepInCurrentTestCase(LogStepStatus.Passed, stepConvert);
        }

        [AfterStep]
        public static void MyStepCleanup()
        {
            //TestCaseProvider.Instance.EndCurrentTestCase();
        }
    }
}
