using BlazorFramework.Controls;
using BlazorFramework.Factories;
using BlazorPages.Models;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace BlazorPages.Pages.MyProfileModule
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

        public MyProfilePage ValidateUserName(string value)
        {
            string xpath = "//label[@class='k-label' and text()='User Name']";
            string attribute = ControlFactory.GetControl<SpanElement>(Locator.XPath, xpath,
                    "User Name", PostAction.Sleep).GetAttribute("for");
            ControlFactory.GetControl<TextFieldElement>(Locator.Id, attribute, "User Name").ValidateTextFieldValue(value);
            return this;
        }
        public MyProfilePage SetRealName(string value)
        {
            string xpath = "//label[@class='k-label' and text()='Real Name']";
            string attribute = ControlFactory.GetControl<SpanElement>(Locator.XPath, xpath,
                    "Real Name", PostAction.Sleep).GetAttribute("for");
            ControlFactory.GetControl<TextFieldElement>(Locator.Id, attribute, "Real Name").SetValue(value);
            return this;
        }
        public MyProfilePage ValidateRealName(string value)
        {
            string xpath = "//label[@class='k-label' and text()='Real Name']";
            string attribute = ControlFactory.GetControl<SpanElement>(Locator.XPath, xpath,
                    "Real Name", PostAction.Sleep).GetAttribute("for");
            ControlFactory.GetControl<TextFieldElement>(Locator.Id, attribute, "Real Name").ValidateTextFieldValue(value);
            return this;
        }

        public MyProfilePage SetEmail(string value)
        {
            string xpath = "//label[@class='k-label' and text()='Email']";
            string attribute = ControlFactory.GetControl<SpanElement>(Locator.XPath, xpath,
                    "Email", PostAction.Sleep).GetAttribute("for");
            
            ControlFactory.GetControl<TextFieldElement>(Locator.Id, attribute, "Email").SetValue(value);
            return this;
        }

        public MyProfilePage ValidateEmail(string value)
        {
            string xpath = "//label[@class='k-label' and text()='Email']";
            string attribute = ControlFactory.GetControl<SpanElement>(Locator.XPath, xpath,
                    "Email", PostAction.Sleep).GetAttribute("for");

            ControlFactory.GetControl<TextFieldElement>(Locator.Id, attribute, "Email").ValidateTextFieldValue(value);
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
        public MyProfilePage IsPleaseProvideValidEmailAddressMessageDisplayed()
        {
            string xpath = "validation-message";

            ControlFactory.GetControl<SpanElement>(Locator.ClassName, xpath, "Please provide a valid email address")
                .ValidateSpanContains("Please provide a valid email address.");
            return this;
        }

        public MyProfilePage CheckKeepMyEmailAddressprivate()
        {
            string xpath = "//label[@class='form-check-label h6' " +
                "and contains(., 'Keep my email address private')]/child::input[@type='checkbox']";
            ControlFactory.GetControl<CheckBoxtElement>(Locator.XPath, xpath,
                    "Keep my email address private", PostAction.Sleep).Check();

            return this; ;
        }

        public MyProfilePage IsCheckedKeepMyEmailAddressprivate()
        {
            string xpath = "//label[@class='form-check-label h6' and " +
                "contains(., 'Keep my email address private')]/child::input[@type='checkbox']";
            ControlFactory.GetControl<CheckBoxtElement>(Locator.XPath, xpath,
                    "Keep my email address private", PostAction.Sleep).IsChecked();

            return this; ;
        }

        public MyProfilePage IsUncheckedKeepMyEmailAddressprivate()
        {
            string xpath = "//label[@class='form-check-label h6' " +
                "and contains(., 'Keep my email address private')]/child::input[@type='checkbox']";
            ControlFactory.GetControl<CheckBoxtElement>(Locator.XPath, xpath,
                    "Keep my email address private", PostAction.Sleep).IsUnchecked();

            return this; ;
        }

        public MyProfilePage SetCompany(string value)
        {
            string xpath = "//label[@class='k-label' and text()='Company']";
            string attribute = ControlFactory.GetControl<SpanElement>(Locator.XPath, xpath,
                    "Company", PostAction.Sleep).GetAttribute("for");

            ControlFactory.GetControl<TextFieldElement>(Locator.Id, attribute, "Company").SetValue(value);
            return this;
        }

        public MyProfilePage ValidateCompany(string value)
        {
            string xpath = "//label[@class='k-label' and text()='Company']";
            string attribute = ControlFactory.GetControl<SpanElement>(Locator.XPath, xpath,
                    "Company", PostAction.Sleep).GetAttribute("for");

            ControlFactory.GetControl<TextFieldElement>(Locator.Id, attribute, "Company").ValidateTextFieldValue(value);
            return this;
        }

        public MyProfilePage SetLocation(string value)
        {
            string xpath = "//label[@class='k-label' and text()='Location']";
            string attribute = ControlFactory.GetControl<SpanElement>(Locator.XPath, xpath,
                    "Location", PostAction.Sleep).GetAttribute("for");

            ControlFactory.GetControl<TextFieldElement>(Locator.Id, attribute, "Location").SetValue(value);
            return this;
        }

        public MyProfilePage ValidateLocation(string value)
        {
            string xpath = "//label[@class='k-label' and text()='Location']";
            string attribute = ControlFactory.GetControl<SpanElement>(Locator.XPath, xpath,
                    "Location", PostAction.Sleep).GetAttribute("for");

            ControlFactory.GetControl<TextFieldElement>(Locator.Id, attribute, "Location").ValidateTextFieldValue(value);
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
        public Dictionary<string, string> DataTable { get; set; }

        public MyProfilePage ProcessMyProfileForm(Account account)
        {
            if (account.RealName != "") { SetRealName(account.RealName); };
            if (account.UserName != "") { SetUserName(account.UserName); };
            if (account.Email != "") { SetEmail(account.Email); };
            if (account.Company != "") { SetCompany(account.Company); };
            if (account.Location != "") { SetLocation(account.Location); };
            if (account.KeepMyEmailAddressPrivate) { CheckKeepMyEmailAddressprivate(); }

            return this;
        }
        public MyProfilePage ValidateMyProfileForm(Account account)
        {
            if (account.RealName != "") { ValidateRealName(account.RealName); };
            if (account.UserName != "") { ValidateUserName(account.UserName); };
            if (account.Email != "") { ValidateEmail(account.Email); };
            if (account.Company != "") { ValidateCompany(account.Company); };
            if (account.Location != "") { ValidateLocation(account.Location); };
            if (account.KeepMyEmailAddressPrivate) { IsCheckedKeepMyEmailAddressprivate(); }
            if (account.KeepMyEmailAddressPrivate == false) { IsUncheckedKeepMyEmailAddressprivate(); }

            return this;
        }
    }

    public class FromMyProfileTo
    {
        public DeletePopup GoToDeleteAccountPopup() => new DeletePopup();
        public UpdatePopup GoToUpdateAccountPopup() => new UpdatePopup();
    }
}
