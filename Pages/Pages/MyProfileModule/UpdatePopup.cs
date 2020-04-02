using BlazorFramework.Controls;
using BlazorFramework.Factories;

namespace BlazorPages.Pages.MyProfileModule
{
    public class UpdatePopup
    {
        public UpdatePopup()
        {
            SeleniumActions.GetWebDriver.SwitchTo().ActiveElement();
        }

        public FromUpdatePopupTo ClickUpdateProfileValidateMessageAlert()
        {
            string xpath = "//div[@class='k-content k-window-content k-dialog-content']/child::p";
            string messageToValidate = "Your profile has been successfully updated.";
            ControlFactory.GetControl<SpanElement>(Locator.XPath, xpath, "Update popup")
                .ValidateSpanContains(messageToValidate);
            
            return ClickOk();
        }

        public FromUpdatePopupTo ClickOk()
        {
            string xpath = "//button[@class='btn-block k-button telerik-blazor k-primary']";
            ControlFactory.GetControl<ButtonElement>(Locator.XPath, xpath, "Update Profile").Click();
            SeleniumActions.SwitchToDefaultContent();
            return new FromUpdatePopupTo();
        }
    }

    public class FromUpdatePopupTo
    {
        public MyProfilePage GoToMyProfilePage() => new MyProfilePage();
    }
}
