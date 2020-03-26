using BlazorFramework.Controls;
using BlazorFramework.Factories;
using Pages.DashboardModule;

namespace Pages
{
    public class LoginPage
    {
        public LoginPage()
        {
            //SeleniumActions.ValidateUrlPage("https://demos.telerik.com/blazor-dashboard-app/signin");
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
