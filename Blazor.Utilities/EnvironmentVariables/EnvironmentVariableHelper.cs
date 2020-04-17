using System;

namespace Blazor.Utilities.EnvironmentVariables
{
    public static class EnvironmentVariableHelper
    {
        private const string BddStepDescription = "ENV_VARIABLE_BDD_STEP_DESCRIPTION";

        public static void SetBddStepDescription(string bddStep)
        {
            Environment.SetEnvironmentVariable(BddStepDescription, bddStep);
        }

        public static string GetBddStepDescription()
        {
            return string.IsNullOrEmpty(Environment.GetEnvironmentVariable(BddStepDescription))
                ? string.Empty
                : $"<div class='bdd-step'><b>Step: </b>{Environment.GetEnvironmentVariable(BddStepDescription)}</div>";
        }
    }
}
