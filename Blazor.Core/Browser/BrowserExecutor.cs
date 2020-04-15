using Blazor.Core.Controls;
using OpenQA.Selenium;
using System.Threading;

namespace Blazor.Core.Browser
{
    public static class BrowserExecutor
    {
        /// <summary>
        /// Help to execute selenium driver using Java Script
        /// </summary>
        /// <param name="driver">Selenium driver</param>
        /// <param name="script">Java Script method to use</param>
        /// <returns></returns>
        public static object ExecuteJavaScript(this IWebDriver driver, string script)
        {
            try
            {
                var js = (IJavaScriptExecutor)driver;
                return js.ExecuteScript("return " + script);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Help to execute selenium driver using Java Script and send arguments
        /// </summary>
        /// <param name="javaScript">Java script method</param>
        /// <param name="arguments">Arguments</param>
        /// <returns></returns>
        public static object ExecuteJavaScript(string javaScript, params object[] arguments)
        {
            try
            {
                IWebDriver driver = SeleniumActions.GetWebDriver;
                var js = driver as IJavaScriptExecutor;
                if (js != null)
                {
                    object o = js.ExecuteScript(javaScript, arguments);
                    Thread.Sleep(100);

                    return o;
                }
            }
            catch
            {
                string messageWarning = string.Format("Error executing the Javascript [ {0} ]", javaScript);

                return null;
            }

            string message = string.Format("Error executing the Javascript [ {0} ]", javaScript);

            return null;
        }
    }
}
