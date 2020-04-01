using Pages.LoginModule;
using System;
using TechTalk.SpecFlow;

namespace BlazorSpeckflowTests.Steps.LoginSteps
{
    [Binding]
    public class LoginPageSteps
    {
        private LoginPage loginPage;
        private readonly ScenarioContext _scenarioContext;
        public LoginPageSteps(ScenarioContext scenarioContext)
        {
            loginPage = new LoginPage();
            _scenarioContext = scenarioContext;
        }

        [Given(@"Login Blazor web page")]
        public void GivenLoginBlazorWebPage()
        {
            new LoginPage()
               .SetEmailOrUserName("carlos@outlook.com")
               .SetPassword("control123")
               .ValidateLoginButton()
               .ClickLoginButton();
        }
    }
}
