using Blazor.Core.Browser;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;
using System.Threading;
using Blazor.Utilities.ExceptionMethods;
using Blazor.Utilities.LoggerUtility;

namespace Blazor.Core.Controls
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
                if (GetInstance.GetDriver != null)
                {
                    return GetInstance.GetDriver;
                }

                return null;
            }
        }

        public static WebDriverWait GetWaitDriver
        {
            get
            {
                if (GetInstance.GetDriver != null)
                {
                    return GetInstance.GetWaitDriver;
                }

                return null;
            }
        }

        public static IWebElement GetElementWait(By by, string controlName = "")
        {
            return GetWebDriver.FindElementWait(by, controlName);
        }

        public static Actions Action => new Actions(GetWebDriver);

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

        private static void WaitForAlert(IWebDriver driver)
        {
            int i = 0;
            while (i < 15)
            {
                try
                {
                    driver.SwitchTo().Alert();
                    BrowserSleep();
                    break;
                }
                catch (NoAlertPresentException)
                {
                    Thread.Sleep(100);
                }
                i++;
            }
        }

        public static void BrowserSleep(int sleepTime = 1)
        {
            GetWebDriver.Sleep(sleepTime);
        }

        public static void HandlerModalDialogs()
        {
            try
            {
                WaitForAlert(GetWebDriver);

                var alert = GetWebDriver.SwitchTo().Alert();
                alert.Accept();

                BrowserSleep();
                WaitForPageToLoad();
            }
            catch (Exception)
            {
                SwitchToDefaultContent();
            }
        }

        public static void HandlerModalDialogsAndValidateText(string expectedMessage)
        {
            try
            {
                WaitForAlert(GetWebDriver);

                var alert = GetWebDriver.SwitchTo().Alert();
                var alertMessage = alert.Text;

                var messageFailed =
                "The information message in Handler Modal dialog is not the expected [" + expectedMessage + "].";
                var messagePassed =
                "The information message in Handler Modal dialog is correct.";
                ExceptionManager.AssertAreEqual(alertMessage, expectedMessage, messagePassed, messageFailed);

                alert.Accept();
                BrowserSleep();
            }
            catch (Exception)
            {
                SwitchToDefaultContent();
            }
        }

        public static void SwitchToDefaultContent()
        {
            GetWebDriver.SwitchTo().DefaultContent();
        }
        public static bool TakeScreenshotAllScreen(string saveLocation)
        {
            try
            {
                //Take screenshot of all screen
                var screenshotDriver = GetWebDriver as ITakesScreenshot;
                if (screenshotDriver != null)
                {
                    var screenshot = screenshotDriver.GetScreenshot();
                    screenshot.SaveAsFile(saveLocation, ScreenshotImageFormat.Png); //System.Drawing.Imaging.ImageFormat.Png
                    Thread.Sleep(500);

                    //Log
                    LoggerManager.Instance.Information($"Image: [ {saveLocation} ] saved successfully.");

                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                //Log
                LoggerManager.Instance.Warning(ex.Message + " " + ex.StackTrace);

                return false;
            }
        }
    }
}
