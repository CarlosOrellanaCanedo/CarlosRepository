using BlazorFramework.Controls;
using BlazorFramework.Factories;
using OpenQA.Selenium;
using System;

namespace Pages.MyProfileModule
{
    public class MyProfilePage
    {

        public MyProfilePage IsAccountDisplayed()
        {
            SeleniumActions.WaitForPageToLoad();
            string xpath = "//span[@class='small text-uppercase text-muted d-block' and text()='Account']";
            SeleniumActions.GetWaitDriver.
                    Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(xpath)));
            ControlFactory.GetControl<SpanElement>(Locator.XPath, xpath, "Account").IsDisplayed();
            return this;
        }
        public MyProfilePage SetUserName(string value)
        {
            string xpath = "//label[@class='k-label' and text()='User Name']";
            string attribute = ControlFactory.GetControl<SpanElement>(Locator.XPath, xpath,
                    "User Name", PostAction.Sleep).GetAttribute("for");
            ControlFactory.GetControl<TextFieldElement>(Locator.Id, attribute, "User Name").SetValue(value);
            return this;
        }
        public MyProfilePage SetRealName(String value)
        {
            string xpath = "//label[@class='k-label' and text()='Real Name']";
            string attribute = ControlFactory.GetControl<SpanElement>(Locator.XPath, xpath,
                    "Real Name", PostAction.Sleep).GetAttribute("for");
            ControlFactory.GetControl<TextFieldElement>(Locator.Id, attribute, "Real Name").SetValue(value);
            return this;
        }

        public MyProfilePage SetEmail(String value)
        {
            string xpath = "//label[@class='k-label' and text()='Email']";
            string attribute = ControlFactory.GetControl<SpanElement>(Locator.XPath, xpath,
                    "Email", PostAction.Sleep).GetAttribute("for");
            
            ControlFactory.GetControl<TextFieldElement>(Locator.Id, attribute, "Email").SetValue(value);
            return this;
        }

        public MyProfilePage IsAnEmailIsRequiredMessageDisplayed()
        {
            string xpath = "//button[@class='k-button telerik-blazor k-primary' and text()='Update profile']";
            ControlFactory.GetControl<ButtonElement>(Locator.XPath, xpath, "Update Profile").Click();

            xpath = "validation-message";

            ControlFactory.GetControl<SpanElement>(Locator.ClassName, xpath, "An email is required")
                .ValidateSpanContains("An email is required");
            return this;
        }

        public MyProfilePage CheckKeepMyEmailAddressprivate()
        {
            string xpath = "//label[@class='k-label' and text()='Email']";
            ControlFactory.GetControl<CheckBoxtElement>(Locator.XPath, xpath,
                    "Data Interval", PostAction.Sleep).Check();

            return this; ;
        }

        public MyProfilePage SetCompany(String value)
        {
            string xpath = "//label[@class='k-label' and text()='Company']";
            string attribute = ControlFactory.GetControl<SpanElement>(Locator.XPath, xpath,
                    "Company", PostAction.Sleep).GetAttribute("for");

            ControlFactory.GetControl<TextFieldElement>(Locator.Id, attribute, "Company").SetValue(value);
            return this;
        }

        public MyProfilePage SetLocation(String value)
        {
            string xpath = "//label[@class='k-label' and text()='Location']";
            string attribute = ControlFactory.GetControl<SpanElement>(Locator.XPath, xpath,
                    "Location", PostAction.Sleep).GetAttribute("for");

            ControlFactory.GetControl<TextFieldElement>(Locator.Id, attribute, "Location").SetValue(value);
            return this;
        }

        public FromMyProfileTo ClickUpdateProfile()
        {
            string xpath = "//button[@class='k-button telerik-blazor k-primary' and text()='Update profile']";
            ControlFactory.GetControl<ButtonElement>(Locator.XPath, xpath, "Update Profile").Click();
            return new FromMyProfileTo();
        }

        public FromMyProfileTo ClickDeleteAccount()
        {
            string xpath = "//button[@class='dangerButton k-button telerik-blazor' and text()='Delete Account']";
            ControlFactory.GetControl<ButtonElement>(Locator.XPath, xpath, "Delete Account").Click();
            
            return new FromMyProfileTo();
        }
    }

    public class FromMyProfileTo
    {
        public DeletePopup GoToDeleteAccountPopup() => new DeletePopup();
        public UpdatePopup GoToUpdateAccountPopup() => new UpdatePopup();
    }
}
