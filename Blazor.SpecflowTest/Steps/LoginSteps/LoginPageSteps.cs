﻿using Blazor.Pages.Pages.LoginModule;
using TechTalk.SpecFlow;

namespace Blazor.SpeckflowTest.Steps.LoginSteps
{
    [Binding]
    public class LoginPageSteps
    {
        private LoginPage _loginPage;
        private LoginPage loginPage
        {
            get
            {
                if(_loginPage == null)
                {
                    _loginPage = new LoginPage();
                }
                return _loginPage;
            }
            set
            {
                _loginPage = value;
            }
        }
        private readonly ScenarioContext _scenarioContext;
        public LoginPageSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"Login Blazor web page")]
        public void GivenLoginBlazorWebPage()
        {
            loginPage
               .SetEmailOrUserName("carlos@outlook.com")
               .SetPassword("control123")
               .ValidateLoginButton()
               .ClickLoginButton();
        }

        [Then(@"in the 'Login' page, validate the 'Issues' span is displayed")]
        public void ThenInThePageValidateTheSpanIsDisplayed()
        {
            loginPage.IsLoginPage();
        }

    }
}
