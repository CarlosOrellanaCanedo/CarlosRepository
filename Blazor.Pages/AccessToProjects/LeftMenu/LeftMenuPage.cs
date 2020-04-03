using Blazor.Core.Controls;
using OpenQA.Selenium;

namespace Blazor.Pages.AccessToProjects.LeftMenu
{
    public class LeftMenuPage : ILeftMenuPage
    {
        private IWebElement GetLeftContainer
        {
            get
            {
                SeleniumActions.GetWebDriver.SwitchTo().ParentFrame();
                SeleniumActions.GetWaitDriver.
                    Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("nav")));
                return SeleniumActions.GetElementWait(By.Id("nav"), "Left Pane");
            }
        }
        public void SelectGroup(string groupName)
        {
            IWebElement leftContainer = GetLeftContainer;

            string xpath = $"//a[@href='{groupName}']";
            SeleniumActions.GetWaitDriver.
                    Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(xpath)));
            string attribute = leftContainer.FindElementWait(By.XPath(xpath), groupName).GetAttribute("class");

            if(!attribute.Trim().ToLower().Contains("active"))
            {
                leftContainer.FindElementWait(By.XPath(xpath), groupName).Click();
            }
        }
    }
}
