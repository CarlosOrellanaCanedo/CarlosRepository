using Blazor.Core.Browser;
using Blazor.LoggerManager.Logger;
using Blazor.ReportManager;
using Blazor.Utilities.ExceptionMethods;

namespace Blazor.Core.Controls
{
    public class SpanElement : WebElementBase
    {
        public SpanElement()
        {

        }

        public SpanElement(Locator locator, string value, string controlName)
            : base(locator, value, controlName)
        {

        }

        public SpanElement(Locator locator, string value, string controlName, PostAction[] postAction)
            : base(locator, value, controlName, postAction)
        {

        }

        public string GetText()
        {
            string text = WebElement.Text;

            string message = $"The (Span) [ {ControlName} ] get the text: [ {text} ]";
            LoggerManagerClass.Instance.Information(message);
            TestCaseProvider.Instance.AddStepInCurrentTestCase(LogStepStatus.Passed, message);

            return text.Trim();
        }

        public void ValidateSpan(string expectedValue)
        {
            string text = WebElement.Text;

            string messagePassed = $"The (Span) [ {ControlName} ] contains the CORRECT value: [ {expectedValue} ]";
            string messageFailed = $"The (Span) [ {ControlName} ] contains the WRONG value: [ {text} ], when it should contain the expected value: [ {expectedValue} ]";

            ExceptionManager.AssertAreEqual(expectedValue, text, messagePassed, messageFailed);
        }

        public void ValidateSpanContains(string expectedValue)
        {
            string text = WebElement.Text;

            string messagePassed = $"The (Span) [ {ControlName} ] contains the CORRECT value: [ {expectedValue} ]";
            string messageFailed = $"The (Span) [ {ControlName} ] contains the WRONG value: [ {text} ], when it should contain the expected value: [ {expectedValue} ]";

            ExceptionManager.AssertContains(expectedValue, text, messagePassed, messageFailed);
        }

        public void ValidateDontContainsValue(string expectedValue)
        {
            var text = WebElement.Text;

            string messagePassed = $"The (Span) [ {ControlName} ] does not contain the value: [ {expectedValue} ]";
            string messageFailed = $"The (Span) [ {ControlName} ] contains the value: [ {text} ], when it should contain a different value: [ {expectedValue} ]";

            ExceptionManager.AssertNotContains(expectedValue, text, messagePassed, messageFailed);
        }

        public void ValidateValueDontBeEqualTo(string expectedValue)
        {
            var text = WebElement.Text;

            string messagePassed = $"The (Span) [ {ControlName} ] is not equals to: [ {expectedValue} ]";
            string messageFailed = $"The (Span) [ {ControlName} ] is equals to: [ {text} ], when it should be different: [ {expectedValue} ]";

            ExceptionManager.AssertAreNotEqual(expectedValue, text, messagePassed, messageFailed);
        }

        public void ValidateSpanIsNotEmpty()
        {
            var actualText = WebElement.Text;

            string messagePassed = $"The (Span) [ { ControlName} ] is not Empty, contains the value: [ { actualText} ]";
            string messageFailed = $"The (Span) [ {ControlName} ] is Empty - FAILED, when it should contain a value";

            ExceptionManager.AssertIsNotEmpty(actualText, messagePassed, messageFailed);
        }

        public void ValidateSpanIsEmpty()
        {
            var actualText = WebElement.Text;

            string messagePassed = $"The (Span) [ {ControlName} ] is Empty - PASSED.";
            string messageFailed = $"The (Span) [ {ControlName} ] contains the WRONG value: [ {actualText} ], when it should by Empty.";

            ExceptionManager.AssertIsEmpty(actualText, messagePassed, messageFailed);
        }

        public void Click()
        {
            WebElement.Click();
            string message = $"The (Span) [ {ControlName} ] was clicked";
            LoggerManagerClass.Instance.Information(message);
            TestCaseProvider.Instance.AddStepInCurrentTestCase(LogStepStatus.Passed, message);
        }

        public void IsDisplayed()
        {
            bool isDisplayed = WebElement.Displayed;

            string messagePassed = $"The (Span) [ {ControlName} ] is Displayed - PASSED.";
            string messageFailed = $"The (Span) [ {ControlName} ] is not Displayed - FAILED -, when it should be Displayed.";

            ExceptionManager.IsTrue(isDisplayed, messagePassed, messageFailed);
        }

        public void JavaScriptClick()
        {
            BrowserExecutor.ExecuteJavaScript("arguments[0].click()", WebElement);
            string message = $"The (Span) [ {ControlName} ] was clicked";
        }

        public string GetAttribute(string attibute_name)
        {
            return WebElement.GetAttribute(attibute_name);
        }
    }
}
