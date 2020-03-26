using BlazorFramework.Controls;
using BlazorFramework.Factories;
using OpenQA.Selenium;
using System;

namespace Pages.DashboardModule
{
    public class DashboardPage
    {
        public DashboardPage IsStatisticsDisplayed()
        {
            SeleniumActions.WaitForPageToLoad();
            
            string xpath = "//span[@class='small text-uppercase text-muted d-block' and text()='Statistics']";
            SeleniumActions.GetWaitDriver.
                    Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(xpath)));
            ControlFactory.GetControl<SpanElement>(Locator.XPath, xpath, "Statistics").IsDisplayed();
            return this;
        }

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
                if (attribute.ToLower().Trim().Equals("false"))
                {
                    ControlFactory.GetControl<ButtonElement>(Locator.XPath, xpath,
                                                "Data Interval").Click();

                    attribute = ControlFactory.GetControl<SpanElement>(Locator.XPath, xpath,
                    "Data Interval", PostAction.Sleep).GetAttribute("aria-expanded");
                }
                else
                {
                    expanded = true;
                }
                try
                {
                    SeleniumActions.GetWaitDriver.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(xpathSelect)));
                }
                catch(Exception)
                {
                   //pending Loger
                }
               
                count++;
            }

            try
            {
                SeleniumActions.GetWaitDriver.
                    Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(xpathSelect)));
            }
            catch (Exception)
            {
                //pending Loger
            }

            ControlFactory.GetControl<SpanElement>(Locator.XPath, xpathSelect, value, PostAction.Sleep).Click();
            SeleniumActions.WaitForPageToLoad();
            return this;
        }

        public DashboardPage ValidateDataInterval(string value)
        {
            string xpath = "//span[@aria-haspopup='listbox' and starts-with(@class,'k-widget k-dropdown k-header')]";

            string attribute = ControlFactory.GetControl<SpanElement>(Locator.XPath, xpath,
                    "Data Interval", PostAction.Sleep).GetAttribute("aria-describedby");

            try
            {
                SeleniumActions.GetWaitDriver
                    .Until(SeleniumExtras.WaitHelpers.ExpectedConditions.
                    TextToBePresentInElement(SeleniumActions.GetElement(By.Id(attribute)), value));
            }
            catch (Exception)
            {
                //pending Loger
            }

            ControlFactory.GetControl<SpanElement>(Locator.Id, attribute, "Data Interval").ValidateSpan(value);
            return this;
        }
    }
}
