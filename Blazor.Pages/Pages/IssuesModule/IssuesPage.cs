using Blazor.Core.Controls;
using Blazor.Core.Factories;
using OpenQA.Selenium;

namespace Blazor.Page.Pages.IssuesModule
{
    public class IssuesPage
    {
        public IssuesPage IsTableTitleDisplayed()
        {
            SeleniumActions.WaitForPageToLoad();
            
            string xpath = "k-indicator-container";
            SeleniumActions.GetWaitDriver.
                    Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.ClassName(xpath)));
            ControlFactory.GetControl<SpanElement>(Locator.ClassName, xpath, "Table Title").IsDisplayed();
            return this;
        }
    }
}
