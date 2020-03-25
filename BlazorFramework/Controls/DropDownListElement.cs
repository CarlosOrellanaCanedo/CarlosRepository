﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.ExceptionMethods;

namespace BlazorFramework.Controls
{
    public class DropDownListElement : WebElementBase
    {
        private const string QuerySelectScript = "var x = arguments[0]; " +
                                                     "var index = 0; " +
                                                     "var txt = \"\"; " +
                                                     "for (var i = 0; i < x.length; i++)" +
                                                     "{" +
                                                     "if(x.options[i].text == arguments[1])" +
                                                     "{" +
                                                     "index = i;" +
                                                     "break;" +
                                                     "}" +
                                                     "}" +
                                                     "x.selectedIndex = index;";

        public DropDownListElement()
        {

        }

        public DropDownListElement(Locator locator, string value, string controlName)
            : base(locator, value, controlName)
        {

        }

        public DropDownListElement(Locator locator, string value, string controlName, PostAction[] postAction)
            : base(locator, value, controlName, postAction)
        {

        }

        public void SelectItem(string itemToSelect)
        {
            var selectElement = new SelectElement(WebElement);
            selectElement.SelectByText(itemToSelect);


            string message = $"The (Dropdown) [ {ControlName} ] selected the Item: [ {itemToSelect} ]";

            Console.WriteLine(message);
        }

        public void SelectItemByValue(string itemToSelect)
        {
            var selectElement = new SelectElement(WebElement);
            selectElement.SelectByValue(itemToSelect);

            string message = $"The (Dropdown) [ {ControlName} ] selected the Item: [ {itemToSelect} ]";

            Console.WriteLine(message);
        }

        public void SelectItemByPartialText(string partialTextItemToSelect)
        {
            WebElement.FindElement(By.XPath($"./option[starts-with(text(), '{partialTextItemToSelect}')]")).Click();
            string message = $"The (Dropdown) [ {ControlName} ] selected the Item: [ {partialTextItemToSelect} ] using partial text";

            Console.WriteLine(message);
        }
        public void GoToElement()
        {
            SeleniumActions.MoveToElementAction(WebElement);

            string message = $"Moved to (Dropdown) [ {ControlName} ].";
            Console.WriteLine(message);
        }

        public void ClickOnDropDown()
        {
            WebElement.Click();

            string message = $"The (Dropdown) [ {ControlName} ] was clicked";
            Console.WriteLine(message);
        }

        public void ValidateDisplayItem(string expectedValue)
        {
            string text = WebElement.Text;

            string messagePassed = $"The (Dropdown) [ {ControlName} ] contains the CORRECT value: [ {expectedValue} ]";
            string messageFailed = $"The (Dropdown) [ {ControlName} ] contains the WRONG value: [ {text} ], when it should contain the expected value: [ {expectedValue} ]";

            ExceptionManager.AssertContains(expectedValue, text, messagePassed, messageFailed);
        }

        public void IsDisplayed()
        {
            bool isDisplayed = WebElement.Displayed;

            string messagePassed = $"The (Dropdown) [ {ControlName} ] is Displayed - CORRECT -.";
            string messageFailed = $"The (Dropdown) [ {ControlName} ] is not Displayed - WRONG -, when it should be Displayed.";

            ExceptionManager.IsTrue(isDisplayed, messagePassed, messageFailed);
        }
    }
}