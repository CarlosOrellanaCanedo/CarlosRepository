using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Configuration;

namespace BlazorFramework.Browser
{
    public sealed class BrowserManager
    {
        public int DefaultWaitTime = 40;

        public IWebDriver Driver { get; private set; }

        public WebDriverWait WaitDriver { get; private set; }


        public string Url => ConfigurationManager.AppSettings["ServerPath"];


        private BrowserManager()
        {

        }

        /// <summary>Initializes this instance.</summary>
        public void Init()
        {
            Driver = new DriverManager().DriverFactory();
            WaitDriver = new WebDriverWait(Driver, TimeSpan.FromSeconds(DefaultWaitTime));

            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
            Driver.Navigate().GoToUrl(Url);
            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
            Driver.Manage().Window.Maximize();
            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
            Driver.Manage().Cookies.DeleteAllCookies();

        }

        public void GoTo(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }

        public void Close()
        {
            if (Driver != null)
            {
                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                Driver.Close();
                Driver.Quit();
                Driver.Dispose();
                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                Driver = null;
            }

            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));

        }

        private static BrowserManager _instance;
        public static BrowserManager Instance =>
            _instance ?? (_instance = new BrowserManager());
    }
}
