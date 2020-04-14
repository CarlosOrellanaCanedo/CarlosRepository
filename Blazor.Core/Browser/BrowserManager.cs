using Blazor.LoggerManager.Logger;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Configuration;

namespace Blazor.Core.Browser
{
    public sealed class BrowserManager
    {
        public int DefaultWaitTime = 30;

        public IWebDriver GetDriver { get; private set; }

        public WebDriverWait GetWaitDriver { get; private set; }


        public string Url => ConfigurationManager.AppSettings["ServerPath"];


        private BrowserManager()
        {

        }

        /// <summary>Initializes this instance.</summary>
        public void Init()
        {
            GetDriver = new DriverManager().DriverFactory();
            GetWaitDriver = new WebDriverWait(GetDriver, TimeSpan.FromSeconds(DefaultWaitTime));

            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
            TestCaseInfo.Site = Url;
            GetDriver.Navigate().GoToUrl(Url);
            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
            GetDriver.Manage().Window.Maximize();
            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
            GetDriver.Manage().Cookies.DeleteAllCookies();

        }

        public void GoTo(string url)
        {
            GetDriver.Navigate().GoToUrl(url);
        }

        public void Close()
        {
            if (GetDriver != null)
            {
                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                GetDriver.Close();
                GetDriver.Quit();
                GetDriver.Dispose();
                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                GetDriver = null;
            }

            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));

        }

        private static BrowserManager _instance;
        public static BrowserManager Instance =>
            _instance ?? (_instance = new BrowserManager());
    }
}
