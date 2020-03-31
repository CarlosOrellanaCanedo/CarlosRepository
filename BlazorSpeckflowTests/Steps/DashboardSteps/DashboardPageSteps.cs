using Pages.DashboardModule;
using TechTalk.SpecFlow;

namespace BlazorSpecFlowTest.Steps.DashboardSteps
{
    [Binding]
    public class DashboardPageSteps
    {
        private DashboardPage _dashboardPage;
        private readonly ScenarioContext _scenarioContext;
        public DashboardPageSteps(ScenarioContext scenarioContext)
        {
            _dashboardPage = new DashboardPage();
            _scenarioContext = scenarioContext;
        }

        [When(@"go to Dashboard page")]
        public void WhenGoToDashboardPage()
        {
            Dashboard.GoTo();
        }

        [Then(@"in the Dashboard page, validate Statistics text is displayed")]
        public void ThenInTheDashboardPageValidateStatisticsTextIsDisplayed()
        {
            _dashboardPage.IsStatisticsDisplayed();
        }
    }
}
