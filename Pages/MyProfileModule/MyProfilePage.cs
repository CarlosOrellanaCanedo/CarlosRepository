﻿using BlazorFramework.Controls;
using BlazorFramework.Factories;
using System;

namespace Pages.MyProfileModule
{
    public class MyProfilePage
    {
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

        public MyProfilePage ClickUpdateProfile()
        {
            string xpath = "//button[@class='k-button telerik-blazor k-primary' and text()='Update profile']";
            ControlFactory.GetControl<ButtonElement>(Locator.XPath, xpath, "Update Profile").Click();
            return this;
        }

        public MyProfilePage ClickDeleteAccount()
        {
            string xpath = "//button[@class='dangerButton k-button telerik-blazor' and text()='Delete Account']";
            ControlFactory.GetControl<ButtonElement>(Locator.XPath, xpath, "Update Profile").Click();
            return this;
        }
    }
}