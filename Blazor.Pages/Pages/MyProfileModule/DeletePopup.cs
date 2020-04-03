using Blazor.Core.Controls;
using Blazor.Core.Factories;
using Blazor.Pages.Pages.LoginModule;

namespace Blazor.Pages.Pages.MyProfileModule
{
    public class DeletePopup
    {
        public DeletePopup()
        {
            SeleniumActions.GetWebDriver.SwitchTo().ActiveElement();
        }

        public FromDeleteAccuntPopupTo ClickDeleteAccount()
        {
            string className = "//div[@class='k-dialog-wrapper']/child::div[@class='k-widget k-window k-window-wrapper telerik-blazor k-centered  ' " +
                "and @aria-modal='true']" +
                "/child::div[@class='k-content k-window-content k-dialog-content']" +
                "/descendant::button[text()='Delete Account']";
            ControlFactory.GetControl<ButtonElement>(Locator.XPath, className, "Delete Account").Click();

            SeleniumActions.SwitchToDefaultContent();

            return new FromDeleteAccuntPopupTo();
        }
    }

    public class FromDeleteAccuntPopupTo
    {
        public LoginPage GoToLoginPage() => new LoginPage();
    }
}
