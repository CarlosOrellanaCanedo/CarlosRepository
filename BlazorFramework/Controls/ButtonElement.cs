using Utilities.ExceptionMethods;

namespace BlazorFramework.Controls
{
    public class ButtonElement : WebElementBase
    {
        public ButtonElement()
        {

        }

        public ButtonElement(Locator locator, string value, string controlName)
            : base(locator, value, controlName)
        {

        }

        public void Click()
        {
            WebElement.Click();
            string message = $"The (Button) [ {ControlName} ] was clicked";
        }

        public void GoToElement()
        {
            SeleniumActions.MoveToElementAction(WebElement);
            string message = $"Moved to (Button) [ {ControlName} ].";
        }

        public void IsDisplayed()
        {
            bool isDisplayed = WebElement.Displayed;

            string messagePassed = $"The (Button) [ {ControlName} ] is Displayed - CORRECT -.";
            string messageFailed = $"The (Button) [ {ControlName} ] is not Displayed - WRONG -, when it should be Displayed.";

            ExceptionManager.IsTrue(isDisplayed, messagePassed, messageFailed);
        }

        public void IsDisabled()
        {
            bool isDisabled = false;
            string attributeDisabled = WebElement.GetAttribute("disabled");
            if (attributeDisabled != null)
            {
                isDisabled = WebElement.GetAttribute("disabled").Contains("true");
            }
            string messagePassed = $"The (Button) [ {ControlName} ] is Disabled - CORRECT -.";
            string messageFailed = $"The (Button) [ {ControlName} ] is not Disabled - WRONG -, when it should by Disabled.";

            ExceptionManager.IsTrue(isDisabled, messagePassed, messageFailed);
        }

        public void IsEnabled()
        {
            string attributeDisabled = WebElement.GetAttribute("disabled");
            string messagePassed = $"The (Button) [ {ControlName} ] is Enabled - CORRECT -.";
            string messageFailed = $"The (Button) [ {ControlName} ] is Disabled - WRONG -, when it should by Enabled.";

            ExceptionManager.IsTrue(attributeDisabled == null, messagePassed, messageFailed);
        }
    }

}
