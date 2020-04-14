using Blazor.LoggerManager.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace Blazor.SpecflowTest.CommonBase
{
    [Binding]
    public sealed class BaseFeature
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks
        private FeatureContext featureContext;

        public BaseFeature(FeatureContext featureContext)
        {
            this.featureContext = featureContext;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            TestCaseInfo.FeatureName = featureContext.FeatureInfo.Title;
        }

        [AfterScenario]
        public void AfterScenario()
        {
            //TODO: implement logic that has to run after executing each scenario
        }
    }
}
