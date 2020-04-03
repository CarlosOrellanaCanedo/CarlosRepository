using System;
using System.Collections.Generic;
using Blazor.Utilities.LoggerUtility;

namespace Blazor.Utilities.ExceptionMethods
{
    public static class ExceptionManager
    {
        public static void AssertAreNotEqual(string notExpectedValue, string actualValue, string messagePased, string messageFailed)
        {
            if (notExpectedValue == null)
            {
                string messageNotExepected =
                    $"The notExpected Value is null; it's not possible to validate the AssertAreNotEqual assertion. on [ {ControlNameInfo.ControlName} ] element";
                LoggerManager.Instance.Error(messageNotExepected, true);
                throw new AutomationException(messageNotExepected);
            }

            if (actualValue == null)
            {
                string messageActualValue =
                    $"The actualValue is null; it's not possible to validate the AssertAreNotEqual assertion. on [ {ControlNameInfo.ControlName} ] element";
                LoggerManager.Instance.Error(messageActualValue, true);
                throw new AutomationException(messageActualValue);
            }

            if (actualValue.Equals(notExpectedValue))
            {
                Console.WriteLine(messageFailed);
                LoggerManager.Instance.Error(messageFailed, true);
                throw new AutomationException(messageFailed);
            }

            LoggerManager.Instance.Information(messagePased);
            Console.WriteLine(messagePased);
        }

        public static void IsTrue(bool actualValue, string messagePassed, string messageFailed)
        {
            if (!actualValue)
            {
                Console.WriteLine(messageFailed);
                LoggerManager.Instance.Error(messageFailed, true);
                throw new AutomationException(messageFailed);
            }
            LoggerManager.Instance.Information(messagePassed);
            Console.WriteLine(messagePassed);
        }

        public static void IsFalse(bool actualValue, string messagePassed, string messageFailed)
        {
            if (actualValue)
            {
                Console.WriteLine(messageFailed);
                LoggerManager.Instance.Error(messageFailed, true);
                throw new AutomationException(messageFailed);
            }
            LoggerManager.Instance.Information(messagePassed);
            Console.WriteLine(messagePassed);
        }

        public static void AssertAreEqual(int expectedValue, int actualValue, string messagePassed, string messageFailed)
        {
            if (!actualValue.Equals(expectedValue))
            {
                Console.WriteLine(messageFailed);
                LoggerManager.Instance.Error(messageFailed, true);
                throw new AutomationException(messageFailed);
            }
            LoggerManager.Instance.Information(messagePassed);
            Console.WriteLine(messagePassed);
        }

        public static void AssertAreEqual(string expectedValue, string actualValue, string messagePassed, string messageFailed)
        {
            if (expectedValue == null)
            {
                string messageNotExepected =
                    $"The Expected Value is null; it's not possible to validate the AssertAreEqual assertion. on [ {ControlNameInfo.ControlName} ] element";
                LoggerManager.Instance.Error(messageNotExepected, true);
                throw new AutomationException(messageNotExepected);
            }

            if (actualValue == null)
            {
                string messageActualValue =
                    $"The actualValue is null; it's not possible to validate the AssertAreEqual assertion. on [ {ControlNameInfo.ControlName} ] element";
                LoggerManager.Instance.Error(messageActualValue, true);
                throw new AutomationException(messageActualValue);
            }

            if (!actualValue.Equals(expectedValue))
            {
                Console.WriteLine(messageFailed);
                LoggerManager.Instance.Error(messageFailed, true);
                throw new AutomationException(messageFailed);
            }
            LoggerManager.Instance.Information(messagePassed);
            Console.WriteLine(messagePassed);
        }

        public static void AssertAreEqual(IEnumerable<string> expectedValue, IEnumerable<string> actualValue, string section = "")
        {
            if (expectedValue == null)
            {
                string messageNotExpected = "The expectedValue is null; it's not possible to validate the AssertAreEqual assertion.";
                LoggerManager.Instance.Error(messageNotExpected, true);
                throw new AutomationException(messageNotExpected);
            }

            if (actualValue == null)
            {
                string messageActualValue = "The actualValue is null; it's not possible to validate the AssertAreEqual assertion.";
                LoggerManager.Instance.Error(messageActualValue, true);
                throw new AutomationException(messageActualValue);
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
                LoggerManager.Instance.Information(message);
                Console.WriteLine(message);
            }
            else
            {
                message += string.Format("Both lists are not equal on the {0} section - FAILED", section);
                LoggerManager.Instance.Information(message);
                Console.WriteLine(message);
                throw new AutomationException(message);
            }
            Console.WriteLine(message);
            LoggerManager.Instance.Information(message);
        }

        public static void AssertContains(string expectedValue, string actualValue, string messagePassed, string messageFailed)
        {
            if (expectedValue == null)
            {
                string messageExpected =
                    $"The Expected Value is null; it's not possible to validate the AssertContains assertion. on [ {ControlNameInfo.ControlName} ] element";
                LoggerManager.Instance.Error(messageExpected, true);
                throw new AutomationException(messageExpected);
            }

            if (actualValue == null)
            {
                string messageActualValue =
                    $"The actualValue is null; it's not possible to validate the AssertContains assertion. on [ {ControlNameInfo.ControlName} ] element";
                LoggerManager.Instance.Error(messageActualValue, true);
                throw new AutomationException(messageActualValue);
            }

            if (!actualValue.Contains(expectedValue))
            {
                LoggerManager.Instance.Error(messageFailed, true);
                Console.WriteLine(messageFailed);
                throw new AutomationException(messageFailed);
            }

            LoggerManager.Instance.Information(messagePassed);
            Console.WriteLine(messagePassed);
        }

        public static void AssertNotContains(string notExpectedValue, string actualValue, string messagePassed, string messageFailed)
        {
            if (notExpectedValue == null)
            {
                string messageExpected =
                    $"The notExpected Value is null; it's not possible to validate the AssertNotContains assertion. on [ {ControlNameInfo.ControlName} ] element";
                LoggerManager.Instance.Error(messageExpected, true);
                throw new AutomationException(messageExpected);
            }

            if (actualValue == null)
            {
                string messageActualValue =
                    $"The actualValue is null; it's not possible to validate the AssertNotContains assertion. on [ {ControlNameInfo.ControlName} ] element";
                LoggerManager.Instance.Error(messageActualValue, true);
                throw new AutomationException(messageActualValue);
            }

            if (actualValue.Contains(notExpectedValue))
            {
                Console.WriteLine(messageFailed);
                LoggerManager.Instance.Error(messageFailed, true);
                throw new AutomationException(messageFailed);
            }
            LoggerManager.Instance.Information(messageFailed);
            Console.WriteLine(messagePassed);
        }

        public static void AssertIsNotEmpty(string actualValue, string messagePassed, string messageFailed)
        {
            if (actualValue == null)
            {
                string messageExpected =
                    $"The current Value is null; it's not possible to validate the AssertIsNotEmpty assertion. on [ {ControlNameInfo.ControlName} ] element";
                LoggerManager.Instance.Error(messageExpected, true);
                throw new AutomationException(messageExpected);
            }

            if (string.IsNullOrEmpty(actualValue))
            {
                Console.WriteLine(messageFailed);
                LoggerManager.Instance.Error(messageFailed, true);
                throw new AutomationException(messageFailed);
            }
            LoggerManager.Instance.Information(messagePassed);
            Console.WriteLine(messagePassed);
        }

        public static void AssertIsEmpty(string actualValue, string messagePassed, string messageFailed)
        {
            if (actualValue == null)
            {
                string messageExpected =
                    $"The current Value is null; it's not possible to validate the AssertIsEmpty assertion. on [ {ControlNameInfo.ControlName} ] element";
                LoggerManager.Instance.Error(messageExpected, true);
                throw new AutomationException(messageExpected);
            }

            if (!string.IsNullOrEmpty(actualValue))
            {
                Console.WriteLine(messageFailed);
                LoggerManager.Instance.Error(messageFailed, true);
                throw new AutomationException(messageFailed);
            }
            LoggerManager.Instance.Information(messagePassed);
            Console.WriteLine(messagePassed);
        }
    }
}
