using BlazorFramework.Browser;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;
using Utilities.ExceptionMethods;

namespace BlazorFramework.Controls
{
    public static class SeleniumActions
    {

        /// <summary>Gets the get instance.</summary>
        /// <value>The get instance.</value>
        public static BrowserManager GetInstance
        {
            get
            {
                if (BrowserManager.Instance != null)
                {
                    return BrowserManager.Instance;
                }

                return null;
            }
        }

        /// <summary>Gets the get web driver.</summary>
        /// <value>The get web driver.</value>
        public static IWebDriver GetWebDriver
        {
            get
            {
                if (GetInstance.Driver != null)
                {
                    return GetInstance.Driver;
                }

                return null;
            }
        }

        public static WebDriverWait GetWaitDriver
        {
            get
            {
                if (GetInstance.Driver != null)
                {
                    return GetInstance.WaitDriver;
                }

                return null;
            }
        }

        public static IWebElement FindElementWait(this IWebDriver driver, By locator,
             string controlName)
        {
            try
            {
                var element = GetWaitDriver.Until(d => d.FindElement(locator));
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

        public static IWebElement GetElementWait(By by, string controlName = "")
        {
            return GetWebDriver.FindElementWait(by, controlName);
        }

        public static Actions Action => new Actions(GetWebDriver);

        /// <summary>Gets the element.</summary>
        /// <param name="by">The by.</param>
        /// <param name="controlName"></param>
        /// <returns></returns>
        /// <exception cref="System.Exception">Control not found:  + by</exception>
        public static IWebElement GetElement(By by, string controlName = "") //TODO add controlName
        {
            try
            {
                return GetWebDriver.FindElement(by);
            }
            catch
            {
                string errorMessage = $"Control not found: {by}";
                if (!string.IsNullOrEmpty(controlName))
                {
                    errorMessage = $"Control not found: [ {controlName} ] [ {by} ].";
                }

                throw new NoSuchElementException(errorMessage);
            }
        }

        /// <summary>Gets the element.</summary>
        /// <param name="driver">The driver.</param>
        /// <param name="by">The by.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception">Control not found:  + by</exception>
        public static IWebElement GetElement(IWebDriver driver, By by)
        {
            try
            {
                return driver.FindElement(by);
            }
            catch
            {
                throw new Exception("Control not found: " + by);
            }
        }

        /// <summary>Gets the elements.</summary>
        /// <param name="by">The by.</param>
        /// <returns></returns>
        public static ReadOnlyCollection<IWebElement> GetElements(By by)
        {
            return GetWebDriver.FindElements(by);
        }

        /// <summary>Gets the elements.</summary>
        /// <param name="webElement">The web element.</param>
        /// <param name="by">The by.</param>
        /// <returns></returns>
        public static ReadOnlyCollection<IWebElement> GetElements(IWebElement webElement, By by)
        {
            return webElement.FindElements(by);
        }

        /// <summary>
        /// Allow select the element and display in the screen if the element is Enable
        /// </summary>
        /// <param name="element"></param>
        public static void MoveToElementAction(IWebElement element)
        {
            Action.MoveToElement(element);
            Action.Perform();
        }




        /// <summary>
        /// This method allow Scrolling in the web page
        /// </summary>
        public static void ScrollUp()
        {
            GetWebDriver.SwitchTo().ParentFrame();
            ((IJavaScriptExecutor)GetWebDriver).ExecuteScript("scroll(0,-250)");
        }

        /// <summary>
        /// This method allow Scrolling in the web page
        /// </summary>
        public static void ScrollDown(int value = 250)
        {
            GetWebDriver.SwitchTo().ParentFrame();
            ((IJavaScriptExecutor)GetWebDriver).ExecuteScript("scroll(0, " + value + ")");
        }

        public static void ValidateUrlPage(string url)
        {
            if (GetWebDriver.Url.ToLowerInvariant().Equals(url.ToLowerInvariant()))
            {
                throw new Exception($"The current URL does not: {url}");
            }
        }

        public static void MouseHover_SubMenuClick(string PrimaryMenu, string SubMenu)
        {
            //Doing a MouseHover  
            WebDriverWait wait = new WebDriverWait(GetWebDriver, TimeSpan.FromSeconds(10));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(PrimaryMenu)));
            Actions action = new Actions(GetWebDriver);
            action.MoveToElement(element).Perform();
            //Clicking the SubMenu on MouseHover   
            var menuelement = GetElement(By.XPath(SubMenu));
            menuelement.Click();
        }

        public static void WaitForPageToLoad()
        {
            try
            {
                var javascript = (IJavaScriptExecutor)GetWebDriver;
                if (javascript == null)
                {
                    string message = "Driver must support javascript execution";
                    throw new ArgumentException(@"driver", message);
                }

                //TODO: review why this part made action on alert 
                GetWaitDriver.Until(d =>
                {
                    try
                    {
                        string readyState = javascript
                        .ExecuteScript("if (document.readyState) return document.readyState;").ToString();

                        return readyState.ToLower() == "complete";
                    }
                    catch (InvalidOperationException e)
                    {
                        //Window is no longer available
                        return e.Message.ToLower().Contains("Unable to get the Browser");
                    }
                    catch (WebDriverException e)
                    {
                        //Browser is no longer available
                        return e.Message.ToLower().Contains("Unable to Connect");
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                });
            }
            catch
            {
                //No need to log
            }
        }

    }
}
