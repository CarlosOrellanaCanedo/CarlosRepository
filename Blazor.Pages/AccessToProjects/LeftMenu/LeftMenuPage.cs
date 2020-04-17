using Blazor.Core.Controls;
using Blazor.ReportManager;
using OpenQA.Selenium;

namespace Blazor.Pages.AccessToProjects.LeftMenu
{
    public class LeftMenuPage : ILeftMenuPage
    {
        /// <summary>
        /// Get the Left Menu container
        /// </summary>
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

        /// <summary>
        /// Select the Group using the group name displayed in the page
        /// </summary>
        /// <param name="groupName"></param>
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
            
            TestCaseProvider.Instance.AddStepInCurrentTestCase(LogStepStatus.Passed, $"Go to: {groupName}");
        }
    }
}
