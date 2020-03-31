using BlazorFramework.Browser;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace BlazorSpecFlowTest.CommonBase
{
    [Binding]
    public class TestHooks
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
