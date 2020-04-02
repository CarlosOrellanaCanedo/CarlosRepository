using BlazorPages.Pages.MyProfileModule;
using TechTalk.SpecFlow;

namespace BlazorSpeckflowTests.Steps.MyProfileSteps
{
    [Binding]
    public sealed class UpdatePopupSteps
    {
        private UpdatePopup _updatePopup;
        private UpdatePopup updatePopup
        {
            get
            {
                if (_updatePopup == null)
                {
                    _updatePopup = new UpdatePopup();
                }

                return _updatePopup;
            }
            set
            {
                    _updatePopup = value;
            }
        }

        private readonly ScenarioContext context;

        public UpdatePopupSteps(ScenarioContext injectedContext)
        {
            context = injectedContext;
        }

        [When(@"in the 'Update' popup, click on \[OK] button")]
        public void WhenInTheUpdatePopupClickOnOkButton()
        {
            updatePopup.ClickOk();
        }
    }
}
