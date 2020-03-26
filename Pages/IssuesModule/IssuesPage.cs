using BlazorFramework.Controls;
using BlazorFramework.Factories;
using OpenQA.Selenium;

namespace Pages.IssuesModule
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
