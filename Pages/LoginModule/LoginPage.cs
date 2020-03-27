using BlazorFramework.Controls;
using BlazorFramework.Factories;
using OpenQA.Selenium;
using Pages.DashboardModule;
using Pages.MyProfileModule;

namespace Pages.LoginModule
{
    public class LoginPage
    {
        public LoginPage IsLoginPage()
        {
            SeleniumActions.WaitForPageToLoad();

            string xpath = "//div[@class='signin-form p-5']/child::h1[@id='app-title' and text()='ISSUES']";
            SeleniumActions.GetWaitDriver.
                    Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(xpath)));
            ControlFactory.GetControl<SpanElement>(Locator.XPath, xpath, "ISSUES").IsDisplayed();
            return this;
        }

        public LoginPage SetEmailOrUserName(string value)
        {
            ControlFactory.GetControl<TextFieldElement>(Locator.XPath, "//input[@placeholder='Email or Username']",
                "Email or User Name").SetValue(value);
            return this;
        }

        public LoginPage SetPassword(string value)
        {
            ControlFactory.GetControl<TextFieldElement>(Locator.XPath, "//input[@placeholder='Password']",
                "Password").SetPassword(value);
            return this;
        }
        public LoginPage ValidateLoginButton()
        {
            ControlFactory.GetControl<ButtonElement>
                (Locator.XPath, "//button[@class='k-primary form-control k-button telerik-blazor k-button-icontext']",
                "Login").IsEnabled();
            return this;
        }

        public FromloginPage ClickLoginButton()
        {
            ControlFactory.GetControl<ButtonElement>
                 (Locator.XPath, "//button[@class='k-primary form-control k-button telerik-blazor k-button-icontext']",
                 "Login").Click();

            return new FromloginPage();
        }
    }

    public class FromloginPage
    {
        public DashboardPage GoToDashboardPage => PageFactory.CreatePage<DashboardPage>();
    }
}
