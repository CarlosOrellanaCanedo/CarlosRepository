using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Configuration;

namespace BlazorFramework.Browser
{
    public class DriverManager
    {
        public IWebDriver DriverFactory()
        {
            IWebDriver instance;
            var driverVersion = ConfigurationManager.AppSettings["BrowserToExecuteTests"];

            switch (driverVersion)
            {
                case "Chrome":
                    instance = ChromeDriverMethod();
                    break;

                default:
                    instance = ChromeDriverMethod();
                    break;
            }

            return instance;
        }

        private IWebDriver ChromeDriverMethod()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("disable-infobars");
            chromeOptions.AddArguments("--start-maximized");

            return new ChromeDriver(DriverUtils.Path, chromeOptions, TimeSpan.FromMinutes(2));
        }
    }
}
