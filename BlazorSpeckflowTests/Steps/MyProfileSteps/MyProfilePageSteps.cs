using BlazorSpeckflowTests.CommonBase;
using Pages.MyProfileModule;
using TechTalk.SpecFlow;

namespace BlazorSpeckflowTests.Steps.MyProfileSteps
{
    [Binding]
    public class MyProfilePageSteps
    {
        private MyProfilePage _myProfile;
        private UpdatePopup _updatePopup;
        private DeletePopup _deletePopup;

        private readonly ScenarioContext _scenarioContext;
        public MyProfilePageSteps(ScenarioContext injectedContext)
        {
            _myProfile = new MyProfilePage();
            _scenarioContext = injectedContext;
        }

        [Given(@"go to MyProfile page")]
        public void GivenGoToMyProfilePage()
        {
            MyProfile.GoTo();
        }
        
        [When(@"in the 'Account' page, set the following values:")]
        public void WhenInTheAccountPageSetTheFollowingValues(Table table)
        {
            _myProfile.DataTable = table.ToDictionary();
            _myProfile.processMyProfileForm();
            
        }

        [When(@"in the 'Account page, click on \[Update] button")]
        public void WhenInTheAccountClickOnUpdateButton()
        {
            _updatePopup = _myProfile.ClickUpdateProfile().GoToUpdateAccountPopup();
        }

        [When(@"in the 'Update' popup, click on \[OK] button")]
        public void WhenInTheUpdatePopupClickOnOkButton()
        {
            _myProfile = _updatePopup.ClickOk().GoToMyProfilePage();
        }

        [Then(@"in the 'Account' page the 'Account' span is displayed")]
        public void ThenInTheAccountPageTheAccountSpanIsDisplayed()
        {
            _myProfile.IsAccountDisplayed();
        }

        [Then(@"in the 'Account' page, validate the expected values in the form:")]
        public void ThenInTheAccountPageValidateTheExpectedValuesInTheForm(Table table)
        {
            _myProfile.DataTable = table.ToDictionary();
            _myProfile.ValidateMyProfileForm();
        }

        [Then(@"in the 'Email' field, 'an Email is required' message is displayed when it is empty")]
        public void ThenInTheEmailFieldAnAlertMessageIsDisplayedWhenItIsEmpty()
        {
            _myProfile.IsPleaseProvideValidEmailAddressMessageDisplayed();
        }

        [Then(@"in the 'Email' field, 'Please provide a valid email address' message is displayed. When it is an invalid format")]
        public void ThenInTheEmailFieldPleaseProvideValidEmailAddresMessageIsDisplayed()
        {
            _myProfile.IsPleaseProvideValidEmailAddressMessageDisplayed();
        }

        [When(@"in the 'Account' page, select the Delete Account button")]
        public void WhenInTheAccountPageSelectTheDeleteAccountButton()
        {
            _deletePopup = _myProfile.ClickDeleteAccount().GoToDeleteAccountPopup();
        }

        [When(@"in the 'Account' popup, select the Delete Account button")]
        public void WhenInTheAccountPopupSelectTheDeleteAccountButton()
        {
            _deletePopup.ClickDeleteAccount().GoToLoginPage();
        }
    }
}
