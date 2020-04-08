using System;
using Blazor.Utilities.ExceptionMethods;
using Blazor.Utilities.LoggerUtility;
using Blazor.Utilities.ReportManager;

namespace Blazor.Core.Controls
{
    public class HyperLinkElement : WebElementBase
    {
        public HyperLinkElement()
        {

        }

        public HyperLinkElement(Locator locator, string value, string controlName)
            : base(locator, value, controlName)
        {

        }

        public HyperLinkElement(Locator locator, string value, string controlName, PostAction[] postAction)
            : base(locator, value, controlName, postAction)
        {

        }

        public void Click()
        {
            WebElement.Click();

            string message = $"The (Hyperlink) [ {ControlName} ] was clicked";
            LoggerManager.Instance.Information(message);
            TestCaseProvider.Instance.AddStepInCurrentTestCase(LogStepStatus.Passed, message);
        }

        /// <summary>
        /// Validate that text of a hyperlink
        /// </summary>
        /// <param name="expectedValue"></param>
        public void ValidateLinkTextValue(string expectedValue)
        {
            var actualText = WebElement.Text;

            string messagePassed = $"The (Hyperlink) [ {ControlName} ] contains the CORRECT value: [ {expectedValue} ]";
            string messageFailed = $"The (Hyperlink) [ {ControlName} ] contains the WRONG value: [ {actualText} ], when it should contain the expected value: [ {expectedValue} ]";

            ExceptionManager.AssertAreEqual(expectedValue, actualText, messagePassed, messageFailed);
        }

        public string GetText()
        {
            string text = WebElement.Text;

            string message = $"The (Hyperlink): [ {ControlName} ] contains the text: [ {text} ].";
            LoggerManager.Instance.Information(message);
            TestCaseProvider.Instance.AddStepInCurrentTestCase(LogStepStatus.Passed, message);

            return text;
        }
        public void IsDisplayed()
        {
            bool isDisplayed = WebElement.Displayed;

            string messagePassed = $"The (Hyperlink) [ {ControlName} ] is Displayed - CORRECT -.";
            string messageFailed = $"The (Hyperlink) [ {ControlName} ] is not Displayed - WRONG -, when it should be Displayed.";

            ExceptionManager.IsTrue(isDisplayed, messagePassed, messageFailed);
        }

        public void IsNotDisplayed()
        {
            try
            {
                var isDisplayed = WebElement.Displayed;

                string messagePassed = $"The (Hyperlink) [ {ControlName} ] is not Displayed - CORRECT -.";
                string messageFailed = $"The (Hyperlink) [ {ControlName} ] is Displayed - WRONG -, when it should be Displayed.";

                ExceptionManager.IsFalse(isDisplayed, messagePassed, messageFailed);
            }
            catch (Exception)
            {
                string messagePassed = $"The (Hyperlink) [ {ControlName} ] is not Displayed - CORRECT -.";
                string messageFailed = $"The (Hyperlink) [ {ControlName} ] is Displayed - WRONG -, when it should be Displayed.";

                ExceptionManager.IsTrue(true, messagePassed, messageFailed);
            }
        }

        public void IsEnabled()
        {
            var isEnabled = WebElement.Enabled;
            string messagePassed = $"The (Hyperlink) [ {ControlName} ] is Enabled - CORRECT -.";
            string messageFailed = $"The (Hyperlink) [ {ControlName} ] is not Enabled - WRONG -, when it should by Enabled.";

            ExceptionManager.IsTrue(isEnabled, messagePassed, messageFailed);
        }

    }
}
