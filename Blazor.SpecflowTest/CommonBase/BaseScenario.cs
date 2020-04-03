using Blazor.Core.Browser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace Blazor.SpecflowTest.CommonBase
{
    [Binding]
    public sealed class BaseScenario
    {
        [BeforeScenario]
        public void CreateWebDriver(ScenarioContext context)
        {
            // We are using Chrome, but you can use any driver
            BrowserManager.Instance.Init();
        }

        [AfterScenario]
        public void CloseWebDriver(ScenarioContext context)
        {
            BrowserManager.Instance.Close();
        }
    }
}
