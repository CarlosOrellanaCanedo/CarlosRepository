using BlazorFramework.Controls;
using BlazorFramework.Factories;
using OpenQA.Selenium;
using System.Collections.Generic;

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

            ControlFactory.GetControl<SpanElement>(Locator.ClassName, xpath, "An email is required")
                .ValidateSpanContains("Please provide a valid email address.");
            return this;
        }

        public MyProfilePage CheckKeepMyEmailAddressprivate()
        {
            string xpath = "//label[@class='k-label' and text()='Email']";
            ControlFactory.GetControl<CheckBoxtElement>(Locator.XPath, xpath,
                    "Data Interval", PostAction.Sleep).Check();

            return this; ;
        }

        public MyProfilePage IsCheckedKeepMyEmailAddressprivate()
        {
            string xpath = "//label[@class='k-label' and text()='Email']";
            ControlFactory.GetControl<CheckBoxtElement>(Locator.XPath, xpath,
                    "Data Interval", PostAction.Sleep).IsChecked();

            return this; ;
        }

        public MyProfilePage IsUncheckedKeepMyEmailAddressprivate()
        {
            string xpath = "//label[@class='k-label' and text()='Email']";
            ControlFactory.GetControl<CheckBoxtElement>(Locator.XPath, xpath,
                    "Data Interval", PostAction.Sleep).IsUnchecked();

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

        public void processMyProfileForm()
        {
            foreach(KeyValuePair<string, string> entry in DataTable)
            {
                processTableData(entry.Key, entry.Value);
            }
        }

        private MyProfilePage processTableData(string option, string value)
        {
            switch(option.ToLower())
            {
                case "user name": SetUserName(value); break;
                case "real name": SetRealName(value); break;
                case "email": SetEmail(value); break;
                case "company": SetCompany(value); break;
                case "location": SetLocation(value); break;
                
            }
            return this;
        }
        public void ValidateMyProfileForm()
        {
            foreach (KeyValuePair<string, string> entry in DataTable)
            {
                ValidateTableData(entry.Key, entry.Value);
            }
        }
        private MyProfilePage ValidateTableData(string option, string value)
        {
            switch (option.ToLower())
            {
                case "user name": ValidateUserName(value); break;
                case "real name": ValidateRealName(value); break;
                case "email": ValidateEmail(value); break;
                case "Keep my email address private":
                    if (value.ToLower().Equals("true"))
                    {
                        IsCheckedKeepMyEmailAddressprivate();
                    }
                    else
                    {
                        IsUncheckedKeepMyEmailAddressprivate();
                    }
                    break;
                case "company": ValidateCompany(value); break;
                case "location": ValidateLocation(value); break;

            }
            return this;
        }
    }

    public class FromMyProfileTo
    {
        public DeletePopup GoToDeleteAccountPopup() => new DeletePopup();
        public UpdatePopup GoToUpdateAccountPopup() => new UpdatePopup();
    }
}
