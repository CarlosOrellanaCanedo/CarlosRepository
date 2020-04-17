using System.Collections.Generic;
using Blazor.LoggerManager.Logger;
using Blazor.ReportManager;

namespace Blazor.Utilities.ExceptionMethods
{
    public static class ExceptionManager
    {
        /// <summary>
        /// This method logs the Warning Message Logs
        /// </summary>
        /// <param name="warningMessage">strign warning message</param>
        public static void WarningMessageLog(string warningMessage)
        {
            LoggerManagerClass.Instance.Warning(warningMessage);
            TestCaseProvider.Instance.AddStepInCurrentTestCase(LogStepStatus.Warning, warningMessage);
        }

        /// <summary>
        /// This method logs the exception messages and throw and exception.
        /// </summary>
        /// <param name="exceptionMessage">string exception message</param>
        public static void ExceptionMessage(string exceptionMessage)
        {
            LoggerManagerClass.Instance.Information(exceptionMessage);
            TestCaseProvider.Instance.AddStepInCurrentTestCase(LogStepStatus.Passed, exceptionMessage);
            throw new AutomationException(exceptionMessage);
        }

        /// <summary>
        /// This method manages the errors 
        /// </summary>
        /// <param name="message">string exception error message</param>
        public static void ExceptionErrorMessage(string exceptionErrorMessage)
        {
            LoggerManagerClass.Instance.Error(exceptionErrorMessage);
            TestCaseProvider.Instance.AddStepInCurrentTestCase(LogStepStatus.Failed, exceptionErrorMessage);
            throw new AutomationException(exceptionErrorMessage);
        }

        /// <summary>
        /// This method evaluates it the actual value is not equal to expected value.
        /// </summary>
        /// <param name="notExpectedValue">string not expected value</param>
        /// <param name="actualValue">string actual value</param>
        /// <param name="messagePased">string message passed</param>
        /// <param name="messageFailed">string message failed</param>
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
                LoggerManagerClass.Instance.Information(messageFailed);
                TestCaseProvider.Instance.AddStepInCurrentTestCase(LogStepStatus.Failed, messageFailed);
                throw new AutomationException(messageFailed);
            }

            LoggerManagerClass.Instance.Information(messagePased);
            TestCaseProvider.Instance.AddStepInCurrentTestCase(LogStepStatus.Passed, messagePased);
        }

        /// <summary>
        /// This method evaluates if the actual value is true.
        /// </summary>
        /// <param name="actualValue">bool actual value</param>
        /// <param name="messagePassed">string message passed</param>
        /// <param name="messageFailed">string message failed</param>
        public static void IsTrue(bool actualValue, string messagePassed, string messageFailed)
        {
            if (!actualValue)
            {
                LoggerManagerClass.Instance.Information(messageFailed);
                TestCaseProvider.Instance.AddStepInCurrentTestCase(LogStepStatus.Failed, messageFailed);
                throw new AutomationException(messageFailed);
            }

            LoggerManagerClass.Instance.Information(messagePassed);
            TestCaseProvider.Instance.AddStepInCurrentTestCase(LogStepStatus.Passed, messagePassed);
        }

        /// <summary>
        /// This method evaluates if the actual value is False.
        /// </summary>
        /// <param name="actualValue">bool actual value</param>
        /// <param name="messagePassed">string message passed</param>
        /// <param name="messageFailed">string message failed</param>
        public static void IsFalse(bool actualValue, string messagePassed, string messageFailed)
        {
            if (actualValue)
            {
                LoggerManagerClass.Instance.Information(messageFailed);
                TestCaseProvider.Instance.AddStepInCurrentTestCase(LogStepStatus.Failed, messageFailed);
                throw new AutomationException(messageFailed);
            }

            LoggerManagerClass.Instance.Information(messagePassed);
            TestCaseProvider.Instance.AddStepInCurrentTestCase(LogStepStatus.Passed, messagePassed);
        }

        /// <summary>
        /// This method evaluates if the actual value is equal to expected value.
        /// </summary>
        /// <param name="expectedValue">int expected value</param>
        /// <param name="actualValue">int actual value</param>
        /// <param name="messagePassed">string message passed</param>
        /// <param name="messageFailed">string message failed</param>
        public static void AssertAreEqual(int expectedValue, int actualValue, string messagePassed, string messageFailed)
        {
            if (!actualValue.Equals(expectedValue))
            {
                LoggerManagerClass.Instance.Information(messageFailed);
                TestCaseProvider.Instance.AddStepInCurrentTestCase(LogStepStatus.Failed, messageFailed);
                throw new AutomationException(messageFailed);
            }

            LoggerManagerClass.Instance.Information(messagePassed);
            TestCaseProvider.Instance.AddStepInCurrentTestCase(LogStepStatus.Passed, messagePassed);
        }

        /// <summary>
        /// This method evaluates if the actual value is equal to expected value.
        /// </summary>
        /// <param name="expectedValue">string expected value</param>
        /// <param name="actualValue">string actual value</param>
        /// <param name="messagePassed">string message passed</param>
        /// <param name="messageFailed">string message failed</param>
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
                LoggerManagerClass.Instance.Information(messageFailed);
                TestCaseProvider.Instance.AddStepInCurrentTestCase(LogStepStatus.Failed, messageFailed);
                throw new AutomationException(messageFailed);
            }

            LoggerManagerClass.Instance.Information(messagePassed);
            TestCaseProvider.Instance.AddStepInCurrentTestCase(LogStepStatus.Passed, messagePassed);
        }

        /// <summary>
        /// This method evaluates if the actual value is equal to expected value.
        /// </summary>
        /// <param name="expectedValue">IEnumerable<string> expected value</param>
        /// <param name="actualValue">IEnumerable<string> actual value</param>
        /// <param name="messagePassed">string message passed</param>
        /// <param name="messageFailed">string message failed</param>
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
            LoggerManagerClass.Instance.Information(message);
        }

        /// <summary>
        /// This method evaluates if the actual value contains to expected value.
        /// </summary>
        /// <param name="expectedValue">string expected value</param>
        /// <param name="actualValue">string actual value</param>
        /// <param name="messagePassed">string message passed</param>
        /// <param name="messageFailed">string message failed</param>
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
                LoggerManagerClass.Instance.Information(messageFailed);
                TestCaseProvider.Instance.AddStepInCurrentTestCase(LogStepStatus.Failed, messageFailed);
                throw new AutomationException(messageFailed);
            }

            LoggerManagerClass.Instance.Information(messagePassed);
            TestCaseProvider.Instance.AddStepInCurrentTestCase(LogStepStatus.Passed, messagePassed);
        }

        /// <summary>
        /// This method evaluates if the actual value not contains to expected value.
        /// </summary>
        /// <param name="notExpectedValue">string not expected value</param>
        /// <param name="actualValue">string actual value</param>
        /// <param name="messagePassed">string message passed</param>
        /// <param name="messageFailed">string message failed</param>
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
                LoggerManagerClass.Instance.Information(messageFailed);
                TestCaseProvider.Instance.AddStepInCurrentTestCase(LogStepStatus.Failed, messageFailed);
                throw new AutomationException(messageFailed);
            }

            LoggerManagerClass.Instance.Information(messagePassed);
            TestCaseProvider.Instance.AddStepInCurrentTestCase(LogStepStatus.Passed, messagePassed);
        }

        /// <summary>
        /// This method evaluates if the actual value is not empty.
        /// </summary>
        /// <param name="actualValue">string actual value</param>
        /// <param name="messagePassed">string message passed</param>
        /// <param name="messageFailed">string message failed</param>
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
                LoggerManagerClass.Instance.Information(messageFailed);
                TestCaseProvider.Instance.AddStepInCurrentTestCase(LogStepStatus.Failed, messageFailed);
                throw new AutomationException(messageFailed);
            }

            LoggerManagerClass.Instance.Information(messagePassed);
            TestCaseProvider.Instance.AddStepInCurrentTestCase(LogStepStatus.Passed, messagePassed);
        }

        /// <summary>
        /// This method evaluates if the actual value Is empty.
        /// </summary>
        /// <param name="actualValue">string actual value</param>
        /// <param name="messagePassed">string message passed</param>
        /// <param name="messageFailed">string message failed</param>
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
                LoggerManagerClass.Instance.Information(messageFailed);
                TestCaseProvider.Instance.AddStepInCurrentTestCase(LogStepStatus.Failed, messageFailed);
                throw new AutomationException(messageFailed);
            }

            LoggerManagerClass.Instance.Information(messagePassed);
            TestCaseProvider.Instance.AddStepInCurrentTestCase(LogStepStatus.Passed, messagePassed);
        }

        /// <summary>
        /// This method validates that the value is not null
        /// </summary>
        /// <param name="actualValue">string actual value</param>
        /// <param name="messageFail">string message faile</param>
        public static void ValidateNotNull(string actualValue, string messagePassed, string messageFail)
        {
            if (string.IsNullOrEmpty(actualValue))
            {
                ExceptionErrorMessage(messageFail);
            }

            LoggerManagerClass.Instance.Information(messagePassed);
            TestCaseProvider.Instance.AddStepInCurrentTestCase(LogStepStatus.Passed, messagePassed);
        }
    }
}
