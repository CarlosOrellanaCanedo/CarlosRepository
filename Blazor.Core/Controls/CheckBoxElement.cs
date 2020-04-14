using Blazor.LoggerManager.Logger;
using Blazor.ReportManager;
using Blazor.Utilities.ExceptionMethods;

namespace Blazor.Core.Controls
{
    public class CheckBoxtElement : WebElementBase
    {
        public CheckBoxtElement()
        {

        }

        public CheckBoxtElement(Locator locator, string value, string controlName)
            : base(locator, value, controlName)
        {

        }

        public CheckBoxtElement(Locator locator, string value, string controlName, PostAction[] postAction)
            : base(locator, value, controlName, postAction)
        {

        }

        public void IsChecked()
        {
            var selected = WebElement.Selected;
            string messagePassed = $"The (Check Box) [ {ControlName} ] is checked - CORRECT -.";
            string messageFailed = $"The (Check Box) [ {ControlName} ] is not checked - WRONG -.";
            ExceptionManager.IsTrue(selected, messagePassed, messageFailed);
        }

        private bool IsCheckedElement()
        {
            var selected = WebElement.Selected;
            return selected;
        }

        public void Check()
        {
            if (!IsCheckedElement())
            {
                WebElement.Click();

                string messagePassed = $"The (Check Box) [ {ControlName} ] is checked - CORRECT -.";
                string messageFailed = $"The (Check Box) [ {ControlName} ] is not checked - WRONG -.";
                ExceptionManager.IsTrue(true, messagePassed, messageFailed);
            }
        }

        public void IsUnchecked()
        {
            var selected = WebElement.Selected;

            string messagePassed = $"The (Check Box) [ {ControlName} ] is unselect - CORRECT -.";
            string messageFailed = $"The (Check Box) [ {ControlName} ] is not unselect - WRONG -.";
            ExceptionManager.IsFalse(selected, messagePassed, messageFailed);
        }

        public void UnCheck()
        {
            if (IsCheckedElement())
            {
                WebElement.Click();

                string messagePassed = $"The (Check Box) [ {ControlName} ] is unselect - CORRECT -.";
                string messageFailed = $"The (Check Box) [ {ControlName} ] is not unselect - WRONG -.";
                ExceptionManager.IsFalse(false, messagePassed, messageFailed);
            }
        }

        public void IsDisplayed()
        {
            bool isDisplayed = WebElement.Displayed;

            string messagePassed = $"The (Check Box) [ {ControlName} ] is Displayed - CORRECT -.";
            string messageFailed = $"The (Check Box) [ {ControlName} ] is not Displayed - WRONG -, when it should be Displayed.";

            ExceptionManager.IsTrue(isDisplayed, messagePassed, messageFailed);
        }

        public void IsNotDisplayed()
        {
            var isDisplayed = WebElement.Displayed;

            string messagePassed = $"The (Check Box) [ {ControlName} ] is not Displayed - CORRECT -.";
            string messageFailed = $"The (Check Box) [ {ControlName} ] is Displayed - WRONG -, when it should be Displayed.";

            ExceptionManager.IsFalse(isDisplayed, messagePassed, messageFailed);
        }

        public void GoToElement()
        {
            SeleniumActions.MoveToElementAction(WebElement);

            string message = $"Moved to (Check Box) [ {ControlName} ].";
            LoggerManagerClass.Instance.Information(message);
            TestCaseProvider.Instance.AddStepInCurrentTestCase(LogStepStatus.Passed, message);
        }
    }

}
