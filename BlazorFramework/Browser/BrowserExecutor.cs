using BlazorFramework.Controls;
using OpenQA.Selenium;
using System.Threading;

namespace BlazorFramework.Browser
{
    public static class BrowserExecutor
    {
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
