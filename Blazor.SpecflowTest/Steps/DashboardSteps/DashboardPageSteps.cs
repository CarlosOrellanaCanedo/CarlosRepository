using Blazor.Pages.Pages.DashboardModule;
using TechTalk.SpecFlow;

namespace Blazor.SpeckflowTest.Steps.DashboardSteps
{
    [Binding]
    public class DashboardPageSteps
    {
        private DashboardPage _dashboardPage;
        private DashboardPage dashboardPage
        {
            get
            {
                if(_dashboardPage == null)
                {
                    _dashboardPage = new DashboardPage();
                }
                return _dashboardPage;
            }
            set
            {
                _dashboardPage = value;
            }
        }
        private readonly ScenarioContext _scenarioContext;
        public DashboardPageSteps(ScenarioContext scenarioContext)
        {
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
            dashboardPage.IsStatisticsDisplayed();
        }

        [When(@"in the 'Dashboard' page, change the Data Interval to (.*)")]
        public void WhenInThePageChangeTheDataIntervalTo(string dataIntervalValue)
        {
            dashboardPage.SelectDataInterval(dataIntervalValue);
        }

        [Then(@"in the 'Dashboard' page, the data interval was changed for (.*)")]
        public void ThenInThePageTheDataIntervalWasChangedFor(string dataIntervalValue)
        {
            dashboardPage.ValidateDataInterval(dataIntervalValue);
        }

    }
}
