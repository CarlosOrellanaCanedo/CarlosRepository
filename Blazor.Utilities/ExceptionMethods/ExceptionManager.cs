using System.Collections.Generic;
using Blazor.Utilities.ExtensionMethods;
using Blazor.Utilities.LoggerUtility;
using Blazor.Utilities.ReportManager;

namespace Blazor.Utilities.ExceptionMethods
{
    public static class ExceptionManager
    {
        public static void WarningMessageLog(string warningMessage)
        {
            LoggerManager.Instance.Warning(warningMessage);
            TestCaseProvider.Instance.AddStepInCurrentTestCase(LogStepStatus.Warning, warningMessage);
        }

        public static void ExceptionMessage(string exceptionMessage)
        {
            LoggerManager.Instance.Information(exceptionMessage);
            TestCaseProvider.Instance.AddStepInCurrentTestCase(LogStepStatus.Passed, exceptionMessage);
            throw new AutomationException(exceptionMessage);
        }

        /// <summary>
        /// This method manages the errors 
        /// </summary>
        /// <param name="message"></param>
        public static void ExceptionErrorMessage(string message)
        {
            LoggerManager.Instance.Error(message);
            TestCaseProvider.Instance.AddStepInCurrentTestCase(LogStepStatus.Failed, message);
            throw new AutomationException(message);
        }

        public static void AssertAreNotEqual(string notExpectedValue, string actualValue, string messagePased, string messageFailed)
        {
            if (notExpectedValue == null)
            {
                string messageNotExepected =
                    $"The notExpected Value is null; it's not possible to validate the AssertAreNotEqual assertion. on [ {ControlNameInfo.ControlName} ] element";
                throw new AutomationException(messageNotExepected);
            }

            if (actualValue == null)
            {
                string messageActualValue =
                    $"The actualValue is null; it's not possible to validate the AssertAreNotEqual assertion. on [ {ControlNameInfo.ControlName} ] element";
                throw new AutomationException(messageActualValue);
            }

            if (actualValue.Equals(notExpectedValue))
            {
                LoggerManager.Instance.Information(messageFailed);
                TestCaseProvider.Instance.AddStepInCurrentTestCase(LogStepStatus.Failed, messageFailed);
                throw new AutomationException(messageFailed);
            }

            LoggerManager.Instance.Information(messagePased);
            TestCaseProvider.Instance.AddStepInCurrentTestCase(LogStepStatus.Passed, messagePased);
        }

        public static void IsTrue(bool actualValue, string messagePassed, string messageFailed)
        {
            if (!actualValue)
            {
                LoggerManager.Instance.Information(messageFailed);
                TestCaseProvider.Instance.AddStepInCurrentTestCase(LogStepStatus.Failed, messageFailed);
                throw new AutomationException(messageFailed);
            }

            LoggerManager.Instance.Information(messagePassed);
            TestCaseProvider.Instance.AddStepInCurrentTestCase(LogStepStatus.Passed, messagePassed);
        }

        public static void IsFalse(bool actualValue, string messagePassed, string messageFailed)
        {
            if (actualValue)
            {
                LoggerManager.Instance.Information(messageFailed);
                TestCaseProvider.Instance.AddStepInCurrentTestCase(LogStepStatus.Failed, messageFailed);
                throw new AutomationException(messageFailed);
            }

            LoggerManager.Instance.Information(messagePassed);
            TestCaseProvider.Instance.AddStepInCurrentTestCase(LogStepStatus.Passed, messagePassed);
        }

        public static void AssertAreEqual(int expectedValue, int actualValue, string messagePassed, string messageFailed)
        {
            if (!actualValue.Equals(expectedValue))
            {
                LoggerManager.Instance.Information(messageFailed);
                TestCaseProvider.Instance.AddStepInCurrentTestCase(LogStepStatus.Failed, messageFailed);
                throw new AutomationException(messageFailed);
            }

            LoggerManager.Instance.Information(messagePassed);
            TestCaseProvider.Instance.AddStepInCurrentTestCase(LogStepStatus.Passed, messagePassed);
        }

        public static void AssertAreEqual(string expectedValue, string actualValue, string messagePassed, string messageFailed)
        {
            if (expectedValue == null)
            {
                string messageNotExepected =
                    $"The Expected Value is null; it's not possible to validate the AssertAreEqual assertion. on [ {ControlNameInfo.ControlName} ] element";
                throw new AutomationException(messageNotExepected);
            }

            if (actualValue == null)
            {
                string messageActualValue =
                    $"The actualValue is null; it's not possible to validate the AssertAreEqual assertion. on [ {ControlNameInfo.ControlName} ] element";
                throw new AutomationException(messageActualValue);
            }

            if (!actualValue.Equals(expectedValue))
            {
                LoggerManager.Instance.Information(messageFailed);
                TestCaseProvider.Instance.AddStepInCurrentTestCase(LogStepStatus.Failed, messageFailed);
                throw new AutomationException(messageFailed);
            }

            LoggerManager.Instance.Information(messagePassed);
            TestCaseProvider.Instance.AddStepInCurrentTestCase(LogStepStatus.Passed, messagePassed);
        }

        public static void AssertAreEqual(IEnumerable<string> expectedValue, IEnumerable<string> actualValue, string section = "")
        {
            if (expectedValue == null)
            {
                throw new AutomationException("The expectedValue is null; it's not possible to validate the AssertAreEqual assertion.");
            }

            if (actualValue == null)
            {
                throw new AutomationException("The actualValue is null; it's not possible to validate the AssertAreEqual assertion.");
            }

            var areEqual = new HashSet<string>(expectedValue).SetEquals(actualValue);

            string dataOnExpectedValue = "";
            foreach (var data in expectedValue)
            {
                dataOnExpectedValue += data + "\n";
            }

            string dataOnActualValue = "";
            foreach (var data in actualValue)
            {
                dataOnActualValue += data + "\n";
            }

            string message = "Expected List:"
                + "<pre>" + dataOnExpectedValue + "</pre>"
                + "Actual List:"
                + "<pre>" + dataOnActualValue + "</pre><br/>";

            if (areEqual)
            {
                message += string.Format("Both lists are equal on the {0} section - PASSED", section);
                TestCaseProvider.Instance.AddStepInCurrentTestCase(LogStepStatus.Passed, message);
            }
            else
            {
                message += string.Format("Both lists are not equal on the {0} section - FAILED", section);
                TestCaseProvider.Instance.AddStepInCurrentTestCase(LogStepStatus.Failed, message);
                throw new AutomationException(message);
            }
            LoggerManager.Instance.Information(message);
        }

        public static void AssertContains(string expectedValue, string actualValue, string messagePassed, string messageFailed)
        {
            if (expectedValue == null)
            {
                string messageExpected =
                    $"The Expected Value is null; it's not possible to validate the AssertContains assertion. on [ {ControlNameInfo.ControlName} ] element";
                throw new AutomationException(messageExpected);
            }

            if (actualValue == null)
            {
                string messageActualValue =
                    $"The actualValue is null; it's not possible to validate the AssertContains assertion. on [ {ControlNameInfo.ControlName} ] element";
                throw new AutomationException(messageActualValue);
            }

            if (!actualValue.Contains(expectedValue))
            {
                LoggerManager.Instance.Information(messageFailed);
                TestCaseProvider.Instance.AddStepInCurrentTestCase(LogStepStatus.Failed, messageFailed);
                throw new AutomationException(messageFailed);
            }

            LoggerManager.Instance.Information(messagePassed);
            TestCaseProvider.Instance.AddStepInCurrentTestCase(LogStepStatus.Passed, messagePassed);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="expectedValue"></param>
        /// <param name="actualValue"></param>
        /// <param name="messagePassed"></param>
        /// <param name="messageFailed"></param>
        public static void AssertContainsIgnoreCase(string expectedValue, string actualValue, string messagePassed, string messageFailed)
        {
            if (expectedValue == null)
            {
                string messageExpected =
                    $"The Expected Value is null; it's not possible to validate the AssertContains assertion. on [ {ControlNameInfo.ControlName} ] element";
                throw new AutomationException(messageExpected);
            }

            if (actualValue == null)
            {
                string messageActualValue =
                    $"The actualValue is null; it's not possible to validate the AssertContains assertion. on [ {ControlNameInfo.ControlName} ] element";
                throw new AutomationException(messageActualValue);
            }

            if (!actualValue.ContainsIgnoreCase(expectedValue))
            {
                LoggerManager.Instance.Information(messageFailed);
                TestCaseProvider.Instance.AddStepInCurrentTestCase(LogStepStatus.Failed, messageFailed);
                throw new AutomationException(messageFailed);
            }

            LoggerManager.Instance.Information(messagePassed);
            TestCaseProvider.Instance.AddStepInCurrentTestCase(LogStepStatus.Passed, messagePassed);
        }

        public static void AssertNotContains(string notExpectedValue, string actualValue, string messagePassed, string messageFailed)
        {
            if (notExpectedValue == null)
            {
                string messageExpected =
                    $"The notExpected Value is null; it's not possible to validate the AssertNotContains assertion. on [ {ControlNameInfo.ControlName} ] element";
                throw new AutomationException(messageExpected);
            }

            if (actualValue == null)
            {
                string messageActualValue =
                    $"The actualValue is null; it's not possible to validate the AssertNotContains assertion. on [ {ControlNameInfo.ControlName} ] element";
                throw new AutomationException(messageActualValue);
            }

            if (actualValue.Contains(notExpectedValue))
            {
                LoggerManager.Instance.Information(messageFailed);
                TestCaseProvider.Instance.AddStepInCurrentTestCase(LogStepStatus.Failed, messageFailed);
                throw new AutomationException(messageFailed);
            }

            LoggerManager.Instance.Information(messagePassed);
            TestCaseProvider.Instance.AddStepInCurrentTestCase(LogStepStatus.Passed, messagePassed);
        }

        public static void AssertIsNotEmpty(string actualValue, string messagePassed, string messageFailed)
        {
            if (actualValue == null)
            {
                string messageExpected =
                    $"The current Value is null; it's not possible to validate the AssertIsNotEmpty assertion. on [ {ControlNameInfo.ControlName} ] element";
                throw new AutomationException(messageExpected);
            }

            if (string.IsNullOrEmpty(actualValue))
            {
                LoggerManager.Instance.Information(messageFailed);
                TestCaseProvider.Instance.AddStepInCurrentTestCase(LogStepStatus.Failed, messageFailed);
                throw new AutomationException(messageFailed);
            }

            LoggerManager.Instance.Information(messagePassed);
            TestCaseProvider.Instance.AddStepInCurrentTestCase(LogStepStatus.Passed, messagePassed);
        }

        public static void AssertIsEmpty(string actualValue, string messagePassed, string messageFailed)
        {
            if (actualValue == null)
            {
                string messageExpected =
                    $"The current Value is null; it's not possible to validate the AssertIsEmpty assertion. on [ {ControlNameInfo.ControlName} ] element";
                throw new AutomationException(messageExpected);
            }

            if (!string.IsNullOrEmpty(actualValue))
            {
                LoggerManager.Instance.Information(messageFailed);
                TestCaseProvider.Instance.AddStepInCurrentTestCase(LogStepStatus.Failed, messageFailed);
                throw new AutomationException(messageFailed);
            }

            LoggerManager.Instance.Information(messagePassed);
            TestCaseProvider.Instance.AddStepInCurrentTestCase(LogStepStatus.Passed, messagePassed);
        }

        /// <summary>
        /// Validate that the value is not null
        /// </summary>
        /// <param name="value"></param>
        /// <param name="messageFail"></param>
        public static void ValidateNotNull(string value, string messageFail)
        {
            if (string.IsNullOrEmpty(value))
            {
                ExceptionErrorMessage(messageFail);
            }
        }
    }
}
