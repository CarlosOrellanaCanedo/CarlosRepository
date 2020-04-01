using System;
using System.Collections.Generic;

namespace BlazorUtilities.ExceptionMethods
{
    public static class ExceptionManager
    {
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
                Console.WriteLine(messageFailed);
                throw new AutomationException(messageFailed);
            }

            Console.WriteLine(messagePased);
        }

        public static void IsTrue(bool actualValue, string messagePassed, string messageFailed)
        {
            if (!actualValue)
            {
                Console.WriteLine(messageFailed);
                throw new AutomationException(messageFailed);
            }

            Console.WriteLine(messagePassed);
        }

        public static void IsFalse(bool actualValue, string messagePassed, string messageFailed)
        {
            if (actualValue)
            {
                Console.WriteLine(messageFailed);
                throw new AutomationException(messageFailed);
            }

            Console.WriteLine(messagePassed);
        }

        public static void AssertAreEqual(int expectedValue, int actualValue, string messagePassed, string messageFailed)
        {
            if (!actualValue.Equals(expectedValue))
            {
                Console.WriteLine(messageFailed);
                throw new AutomationException(messageFailed);
            }

            Console.WriteLine(messagePassed);
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
                Console.WriteLine(messageFailed);
                throw new AutomationException(messageFailed);
            }

            Console.WriteLine(messagePassed);
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
                Console.WriteLine(message);
            }
            else
            {
                message += string.Format("Both lists are not equal on the {0} section - FAILED", section);
                Console.WriteLine(message);
                throw new AutomationException(message);
            }
            Console.WriteLine(message);
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
                Console.WriteLine(messageFailed);
                throw new AutomationException(messageFailed);
            }

            Console.WriteLine(messagePassed);
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
                Console.WriteLine(messageFailed);
                throw new AutomationException(messageFailed);
            }

            Console.WriteLine(messagePassed);
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
                Console.WriteLine(messageFailed);
                throw new AutomationException(messageFailed);
            }

            Console.WriteLine(messagePassed);
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
                Console.WriteLine(messageFailed);
                throw new AutomationException(messageFailed);
            }

            Console.WriteLine(messagePassed);
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
                Console.WriteLine(messageFail);
            }
        }
    }
}
