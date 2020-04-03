using OpenQA.Selenium;
using System;
using Blazor.Utilities.ExceptionMethods;

namespace Blazor.Core.Controls
{
    [Flags]
    public enum PostAction
    {
        None = 0x0,
        WaitForAjax = 0x1,
        WaitForPageToLoad = 0x2,
        WaitForSpinningProgress = 0x4,
        Sleep = 0x8,
        SwithToDefaultContext = 0x10,
        SendTabKey = 0x20
    }

    public enum Locator
    {
        Id,
        Name,
        ClassName,
        CssSelector,
        XPath,
        TagName,
        LinkText,
        PartialLinkText
    }

    public class WebElementBase
    {
        public WebElementBase()
        {
        }

        public WebElementBase(Locator locator, string value, string controlName)
        {
            ControlName = controlName;
            SearchProperty(locator, value);
            PostActions = new PostAction[0];
            ControlNameInfo.ControlName = controlName;
        }

        public WebElementBase(Locator locator, string value, string controlName, PostAction[] postAction)
        {
            ControlName = controlName;
            SearchProperty(locator, value);
            PostActions = postAction;
            ControlNameInfo.ControlName = controlName;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Class { get; set; }
        public string Css { get; set; }
        public string XPath { get; set; }
        public string Tag { get; set; }
        public string ControlName { get; set; }
        public string LinkText { get; set; }
        public string PartialLinkText { get; set; }

        public PostAction[] PostActions { get; set; }

        private void SearchProperty(Locator locator, string value)
        {
            switch (locator)
            {
                case Locator.Id:
                    Id = value;
                    break;
                case Locator.Name:
                    Name = value;
                    break;
                case Locator.ClassName:
                    Class = value;
                    break;
                case Locator.CssSelector:
                    Css = value;
                    break;
                case Locator.XPath:
                    XPath = value;
                    break;
                case Locator.TagName:
                    Tag = value;
                    break;
                case Locator.LinkText:
                    LinkText = value;
                    break;
                case Locator.PartialLinkText:
                    PartialLinkText = value;
                    break;
            }
        }

        private IWebElement _webElement;
        public IWebElement WebElement
        {
            get
            {
                //It seems that this is working better like this:
                //if (_webElement == null)
                //{
                //Here finds the WebElement
                var webElement = new WebElementFinder(this);
                webElement.FindElement();
                _webElement = webElement.Element;
                //}

                return _webElement;
            }
        }
    }
}
