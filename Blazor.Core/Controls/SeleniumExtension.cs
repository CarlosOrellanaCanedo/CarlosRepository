using OpenQA.Selenium;
using System;
using System.Threading;

namespace Blazor.Core.Controls
{
    public static class SeleniumExtension
    {
        public static void Sleep(this IWebDriver driver, int sleep = 2)
        {
            Thread.Sleep(TimeSpan.FromSeconds(sleep));
        }

        public static IWebElement FindElementWait(this IWebDriver driver, By locator,
             string controlName)
        {
            try
            {
                var element = SeleniumActions.GetWaitDriver.Until(d => d.FindElement(locator));
                string message = $"Element: [ {controlName} ] found.";

                return element;
            }
            catch (NoSuchElementException)
            {
                string message = $"Unable to find the following element: [ {locator} ] [ {controlName} ]";
                throw new NoSuchElementException(message);
            }
            catch (Exception e)
            {
                var errorMessage = $"[ {e.Message} ]. Control not found: [ {locator} ] [ {controlName} ]";
                throw new Exception(errorMessage);
            }
        }

        public static IWebElement FindElementWait(this IWebElement webElement, By locator,
            string controlName)
        {
            try
            {
                var element = SeleniumActions.GetWaitDriver.Until(d => d.FindElement(locator));
                string message = $"Element: [ {controlName} ] found.";

                return element;
            }
            catch (NoSuchElementException)
            {
                string message = $"Unable to find the following element: [ {locator} ] [ {controlName} ]";
                throw new NoSuchElementException(message);
            }
            catch (Exception e)
            {
                var errorMessage = $"[ {e.Message} ]. Control not found: [ {locator} ] [ {controlName} ]";
                throw new Exception(errorMessage);
            }
        }
    }
}
