using Blazor.Utilities.EnvironmentVariables;
using TechTalk.SpecFlow;

namespace Blazor.SpecflowTest.CommonBase
{
    [Binding]
    public sealed class BaseStep
    {
        [BeforeStep]
        public static void MyStepInitialize()
        {
            var step = ScenarioStepContext.Current.StepInfo.Text;
            EnvironmentVariableHelper.SetBddStepDescription(step);
        }

        [AfterStep]
        public static void MyStepCleanup()
        {
        }
    }
}
