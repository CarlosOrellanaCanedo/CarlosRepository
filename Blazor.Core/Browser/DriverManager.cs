using Blazor.LoggerManager.Logger;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Configuration;

namespace Blazor.Core.Browser
{
    public class DriverManager
    {
        public IWebDriver DriverFactory()
        {
            IWebDriver instance;
            var driverVersion = ConfigurationManager.AppSettings["BrowserToExecuteTests"];
            TestCaseInfo.Browser = driverVersion;

            switch (driverVersion)
            {
                case "Chrome":
                    var chromeOptions = new ChromeOptions();
                    chromeOptions.AddArguments("--disable-infobars");
                    chromeOptions.AddArguments("--start-maximized");

                    instance = new ChromeDriver(DriverUtils.Path, chromeOptions, TimeSpan.FromMinutes(2));

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
