using BlazorFramework.Controls;
using BlazorFramework.Factories;

namespace Pages
{
    public class DashboardPage
    {
        public DashboardPage()
        {
            //SeleniumActions.ValidateUrlPage("https://demos.telerik.com/blazor-dashboard-app/dashboard");
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
            string xpath = "//span[@class='k-dropdown-wrap k-state-default ']/child::span[@class='k-select']";
            ControlFactory.GetControl<DropDownListElement>(Locator.XPath, xpath,
                "Data Interval").ClickOnDropDown();
            string xpathSelect = $"//div[@class='k-list-scroller']/descendant::li[@class='k-item   telerik-blazor' and contains(.,'{value}')]";
            ControlFactory.GetControl<SpanElement>(Locator.XPath, xpathSelect, value).Click();

            return this;
        }

        public DashboardPage ValidateDataInterval(string value)
        {
            string xpath = "//span[@class='k-dropdown-wrap k-state-default ']/child::span[@class='k-input']";
            ControlFactory.GetControl<SpanElement>(Locator.XPath, xpath, "Data Interval").ValidateSpan(value);
            return this;
        }
    }
}
