using BlazorPages.Models;
using BlazorPages.Pages.MyProfileModule;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace BlazorSpeckflowTests.Steps.MyProfileSteps
{
    [Binding]
    public class MyProfilePageSteps
    {
        private MyProfilePage _myProfilePage;
        private MyProfilePage MyProfilePage
        {
            get
            {
                if (_myProfilePage == null)
                {
                    _myProfilePage = new MyProfilePage();
                }

                return _myProfilePage;
            }
            set
            {
                _myProfilePage = value;
            }
        }

        private readonly ScenarioContext _scenarioContext;
        public MyProfilePageSteps(ScenarioContext injectedContext)
        {
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
            Account account = table.CreateInstance<Account>();
            MyProfilePage.ProcessMyProfileForm(account);

        }

        [When(@"in the 'Account page, click on \[Update] button")]
        public void WhenInTheAccountClickOnUpdateButton()
        {
            MyProfilePage.ClickUpdateProfile().GoToUpdateAccountPopup();
        }

     

        [Then(@"in the 'Account' page the 'Account' span is displayed")]
        public void ThenInTheAccountPageTheAccountSpanIsDisplayed()
        {
            MyProfilePage.IsAccountDisplayed();
        }

        [Then(@"in the 'Account' page, validate the expected values in the form:")]
        public void ThenInTheAccountPageValidateTheExpectedValuesInTheForm(Table table)
        {
            Account account = table.CreateInstance<Account>();
            MyProfilePage.ValidateMyProfileForm(account);
        }

        [Then(@"in the 'Email' field, 'an Email is required' message is displayed when it is empty")]
        public void ThenInTheEmailFieldAnAlertMessageIsDisplayedWhenItIsEmpty()
        {
            MyProfilePage.IsAnEmailIsRequiredMessageDisplayed();
        }

        [Then(@"in the 'Email' field, 'Please provide a valid email address' message is displayed. When it is an invalid format")]
        public void ThenInTheEmailFieldPleaseProvideValidEmailAddresMessageIsDisplayed()
        {
            MyProfilePage.IsPleaseProvideValidEmailAddressMessageDisplayed();
        }

        [When(@"in the 'Account' page, select the Delete Account button")]
        public void WhenInTheAccountPageSelectTheDeleteAccountButton()
        {
            MyProfilePage.ClickDeleteAccount();
        }

        [When(@"in the 'Account' popup, select the Delete Account button")]
        public void WhenInTheAccountPopupSelectTheDeleteAccountButton()
        {
            MyProfilePage.ClickDeleteAccount();
        }
    }
}
