using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace Blazor.Core.Controls
{
    public class WebElementFinder
    {
        private By _locator;
        private readonly string _controlName;

        public WebElementFinder(WebElementBase elementBase)
        {
            _controlName = elementBase.ControlName;

            SetSeleniumLocators(elementBase);
        }

        private void SetSeleniumLocators(WebElementBase elementBase)
        {
            //By Id
            if (elementBase.Id != null)
            {
                _locator = By.Id(elementBase.Id);
                return;
            }

            //By Name
            if (elementBase.Name != null)
            {
                _locator = By.Name(elementBase.Name);
                return;
            }

            //By XPath
            if (elementBase.XPath != null)
            {
                _locator = By.XPath(elementBase.XPath);
                return;
            }

            //By Css Selector
            if (elementBase.Css != null)
            {
                _locator = By.CssSelector(elementBase.Css);
                return;
            }

            //By Class Name
            if (elementBase.Class != null)
            {
                _locator = By.ClassName(elementBase.Class);
                return;
            }

            //By Tag Name
            if (elementBase.Tag != null)
            {
                _locator = By.TagName(elementBase.Tag);
                return;
            }

            //By Partial Link Text
            if (elementBase.PartialLinkText != null)
            {
                _locator = By.PartialLinkText(elementBase.PartialLinkText);
            }
        }

        public void FindElement()
        {
            Func<IWebElement> firstAttempt = () =>
            {
                return SeleniumActions.GetWaitDriver.Until(d => d.FindElement(_locator));
            };

            Func<IWebElement> secondAttempt = () =>
            {
                return SeleniumActions.GetWaitDriver.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(_locator));
            };

            string errorMessage;
            IWebElement element;
            if (TryFindElement(new[] { firstAttempt, secondAttempt }, out element, out errorMessage))
            {
                _seleniumElement = element;
            }
            else
            {
                _seleniumElement = null;

                //Log
                string message = string.Format("Unable to find the following element: [ {0} ] [ {1} ]. [ {2} ].",
                    _locator, _controlName, errorMessage);
                throw new NoSuchElementException(message);
            }
        }

        private bool TryFindElement(IEnumerable<Func<IWebElement>> findFunctions,
            out IWebElement element, out string errorMessage)
        {
            errorMessage = string.Empty;
            element = null;

            foreach (var findFunction in findFunctions)
            {
                if (TryFind(findFunction, out element, out errorMessage))
                {
                    return true;
                }
            }

            return false;
        }

        private bool TryFind(Func<IWebElement> findAction,
            out IWebElement element, out string errorMessage)
        {
            errorMessage = string.Empty;

            try
            {
                element = findAction();
                return true;
            }
            catch (Exception ex)
            {
                //Log
                errorMessage = $"{ex.Message}. Failed attemp";
                Console.WriteLine(errorMessage);

                element = null;
                return false;
            }
        }

        private IWebElement _seleniumElement;
        public IWebElement Element => _seleniumElement;
    }
}
