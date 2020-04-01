using BlazorSpeckflowTests.CommonBase;
using Pages.MyProfileModule;
using System;
using TechTalk.SpecFlow;

namespace BlazorSpeckflowTests.Steps.MyProfileSteps
{
    [Binding]
    public class MyProfilePageSteps
    {
        private MyProfilePage _myProfile;
        private readonly ScenarioContext _scenarioContext;
        public MyProfilePageSteps(ScenarioContext scenarioContext)
        {
            _myProfile = new MyProfilePage();
            _scenarioContext = scenarioContext;
        }

        [Given(@"go to MyProfile page")]
        public void GivenGoToMyProfilePage()
        {
            MyProfile.GoTo();
        }
        
        [When(@"update my Account information:")]
        public void WhenUpdateMyAccountInformation(Table table)
        {
            _myProfile.DataTable = table.ToDictionary();
            _myProfile.processMyProfileForm();
            _myProfile.ClickUpdateProfile();
        }
        
        [Then(@"is account page displayed")]
        public void ThenIsAccountPageDisplayed()
        {
        }
    }
}
