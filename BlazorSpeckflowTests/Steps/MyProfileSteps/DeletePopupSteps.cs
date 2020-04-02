using BlazorPages.Pages.MyProfileModule;
using TechTalk.SpecFlow;

namespace BlazorSpeckflowTests.Steps.MyProfileSteps
{
    [Binding]
    public sealed class DeletePopupSteps
    {
        private DeletePopup _deletePopup;
        private DeletePopup deletePopup
        {
            get
            {
                if (_deletePopup == null)
                {
                    _deletePopup = new DeletePopup();
                }

                return _deletePopup;
            }
            set
            {
                _deletePopup = value;
            }
        }

        private readonly ScenarioContext context;

        public DeletePopupSteps(ScenarioContext injectedContext)
        {
            context = injectedContext;
        }

        [When(@"in the 'Delete Account' popup, select the Delete Account button")]
        public void WhenInTheAccountPopupSelectTheDeleteAccountButton()
        {
            deletePopup.ClickDeleteAccount();
        }
    }
}
