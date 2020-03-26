using BlazorFramework.Controls;
using BlazorFramework.Factories;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace Pages
{
    public class DashboardPage
    {
        public DashboardPage IsDashboarLinkActive()
        {
            ControlFactory.GetControl<HyperLinkElement>(Locator.XPath, "//a[@class='nav-link active active']", "DashBoard").IsDisplayed();
            return this;
        }
        public DashboardPage SelectDashboardLink()
        {
            ControlFactory.GetControl<HyperLinkElement>(Locator.XPath,
                "//a[@class='nav-link active active']", "DashBoard", PostAction.WaitForPageToLoad).Click();
            return this;
        }

        public DashboardPage SelectDataInterval(string value)
        {
            string xpath = "//span[@aria-haspopup='listbox' and starts-with(@class,'k-widget k-dropdown k-header')]";
            string xpathSelect = $"//div[@class='telerik-blazor k-animation-container ']/child::div[@class='k-popup k-reset']" +
                $"/child::div[@class='k-list-scroller']/child::ul[@class='k-list k-reset']/child::li[contains(.,'{value}')]";
            ControlFactory.GetControl<ButtonElement>(Locator.XPath, xpath,
                "Data Interval").Click();

            string attribute = ControlFactory.GetControl<SpanElement>(Locator.XPath, xpath,
                    "Data Interval", PostAction.Sleep).GetAttribute("aria-expanded");

            bool expanded = false;
            int count = 0;
            while (!expanded || count == 5)
            {
                attribute = ControlFactory.GetControl<SpanElement>(Locator.XPath, xpath,
                    "Data Interval", PostAction.Sleep).GetAttribute("aria-expanded");

                if (attribute.ToLower().Trim().Equals("false"))
                {
                    ControlFactory.GetControl<ButtonElement>(Locator.XPath, xpath,
                                                "Data Interval").Click();
                }
                else
                {
                    expanded = true;
                }
                try
                {
                    SeleniumActions.GetWaitDriver.Until(ExpectedConditions.ElementToBeClickable(By.XPath(xpathSelect)));
                }
                catch(Exception)
                {
                   
                }
               
                count++;
            }

            
            ControlFactory.GetControl<SpanElement>(Locator.XPath, xpathSelect, value, PostAction.WaitForPageToLoad).Click();
            SeleniumActions.WaitForPageToLoad();
            return this;
        }

        public DashboardPage ValidateDataInterval(string value)
        {
            string xpath = "//span[@aria-haspopup='listbox' and starts-with(@class,'k-widget k-dropdown k-header')]";
            ControlFactory.GetControl<SpanElement>(Locator.XPath, xpath, "Data Interval").ValidateSpan(value);
            return this;
        }
    }
}
