using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.ExceptionMethods;

namespace BlazorFramework.Controls
{
    public class TextFieldElement : WebElementBase
    {
        public TextFieldElement()
        {

        }

        public TextFieldElement(Locator locator, string value, string controlName)
            : base(locator, value, controlName)
        {

        }

        public TextFieldElement(Locator locator, string value, string controlName, PostAction[] postAction)
            : base(locator, value, controlName, postAction)
        {

        }

        public void Clear()
        {
            WebElement.SendKeys("");
            string messagePassed = $"The (Text Field) [ {ControlName} ] was Clear - CORRECT -.";
            string messageFailed = $"The (Text Field) [ {ControlName} ] was not Clear - WRONG -.";

            ExceptionManager.AssertAreEqual("", WebElement.Text, messagePassed, messageFailed);
        }

        public string GetAttribute(string attribute)
        {
            return WebElement.GetAttribute(attribute);
        }

        public void IsEditable()
        {
            string message;
            string attribute = GetAttribute("disabled");
            if (attribute == null)
            {
                message = $"The (Text Filed) [ {ControlName} ] is editable - CORRECT -.";
                Console.WriteLine(message);
            }
            else
            {
                message = $"The (Text Field) [ {ControlName} ] is not editable - WRONG -, When it should be Editable.";
                Console.WriteLine(message);
                throw new Exception(message);
            }
        }

        public void SetDateValue(string text)
        {
            WebElement.Clear();// clear the text field
            WebElement.SendKeys(text);// set the new value in the text field


            string message = $"The (Text Field) [ {ControlName} ] set the value: [ {text} ].";
            Console.WriteLine(message);
        }

        public void SetValue(string text)
        {
            WebElement.Clear();// clear the text field
            WebElement.SendKeys(text);// set the new value in the text field


            string message = $"The (Text Field) [ {ControlName} ] set the value: [ {text} ].";
            Console.WriteLine(message);
        }

        public void SetPassword(string text)
        {
            WebElement.Clear(); // clear the text field
            WebElement.SendKeys(text); // set the new value in the text field

            string message = $"The (Text Field) [ {ControlName} ] set the password value: [ *********** ].";
            Console.WriteLine(message);
        }

        public void SendEnterKey()
        {
            WebElement.SendKeys(Keys.Enter);

            string message = $"The (Text Field) [ {ControlName} ] send a Enter key.";
            Console.WriteLine(message);
        }

        public string GetText()
        {
            string text = WebElement.Text;

            string message = $"The (Text Field): [ {ControlName} ] contains the text: [ {text} ].";
            Console.WriteLine(message);

            return text;
        }

        public string GetValue()
        {
            string attribute = WebElement.GetAttribute("value");

            string message = $"The (Text Field): [ {ControlName} ] contains the attribute value: [ {attribute} ].";
            Console.WriteLine(message);

            return attribute;
        }

        public void ValidateTextFieldValue(string expectedValue)
        {
            string text = GetValue();
            string messagePassed = $"The (Text Field) [ {ControlName} ] contains the CORRECT value: [ {expectedValue} ].";
            string messageFailed = $"The (Text Field) [ {ControlName} ] contains the WRONG value: [ {text} ], when it should contain the expected value: [ {expectedValue} ].";

            ExceptionManager.AssertAreEqual(expectedValue, text, messagePassed, messageFailed);
        }

        public void ValidateTextFieldValueContains(string expectedValue)
        {
            string text = GetValue();
            string messagePassed = $"The (Text Field) [ {ControlName} ] contains the CORRECT value: [ {expectedValue} ].";
            string messageFailed = $"The (Text Field) [ {ControlName} ] contains the WRONG value: [ {text} ], when it should contain the expected value: [ {expectedValue} ].";

            ExceptionManager.AssertContains(expectedValue, text, messagePassed, messageFailed);
        }

        public void ValidateDontTextFieldValueContains(string expectedValue)
        {
            string text = GetValue();
            string messageFailed = $"The (Text Field) [ {ControlName} ] contains the value: [ {expectedValue} ], when it should contain different value.";
            string messagePassed = $"The (Text Field) [ {ControlName} ] does not contain value: [ {text} ].";

            ExceptionManager.AssertNotContains(expectedValue, text, messagePassed, messageFailed);
        }

        public void IsEmpty()
        {
            string text = GetValue();

            string messagePassed = $"The (Text Field) [ {ControlName} ] is Empty - CORRECT -.";
            string messageFailed = $"The (Text Field) [ {ControlName} ] contains the WRONG value: [ {text} ], when it should by Empty.";

            ExceptionManager.AssertIsEmpty(text, messagePassed, messageFailed);
        }

        public void IsDisplayed()
        {
            bool isDisplayed = WebElement.Displayed;

            string messagePassed = $"The (Text Field) [ {ControlName} ] is Displayed - CORRECT -.";
            string messageFailed = $"The (Text Field) [ {ControlName} ] is not Displayed - WRONG -, when it should be Displayed.";

            ExceptionManager.IsTrue(isDisplayed, messagePassed, messageFailed);
        }

        public void IsNotDisplayed()
        {
            try
            {
                bool isDisplayed = WebElement.Displayed;

                string messagePassed = $"The (Text Field) [ {ControlName} ] is not Displayed - CORRECT -.";
                string messageFailed = $"The (Text Field) [ {ControlName} ] is Displayed - WRONG -, when it should not be Displayed.";

                ExceptionManager.IsFalse(isDisplayed, messagePassed, messageFailed);
            }
            catch (Exception)
            {
                string message = $"The (Text Field) [ {ControlName} ] is not Displayed - CORRECT -.";
                Console.WriteLine(message);
            }
        }

        public void GoToElement()
        {
            SeleniumActions.MoveToElementAction(WebElement);

            string message = $"Moved to (Text Field) [ {ControlName} ].";
            Console.WriteLine(message);
        }
    }
}
