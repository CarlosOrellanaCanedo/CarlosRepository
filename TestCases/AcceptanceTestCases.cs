﻿using NUnit.Framework;
using Pages.DashboardModule;
using Pages.IssuesModule;
using Pages.LoginModule;
using Pages.MyProfileModule;
using TestCases.Base;

namespace TestCases
{
    [TestFixture]
    class AcceptanceTestCases : BaseTestCase
    {
        [Test]
        public void TestLoginValidAccount()
        {
            new LoginPage()
                .SetEmailOrUserName("carlos@outlook.com")
                .SetPassword("control123")
                .ValidateLoginButton()
                .ClickLoginButton()

                .GoToDashboardPage
                .IsDashboarLinkActive();
        }

        [Test]
        public void TestDasboardChangeDataInterval()
        {
            new LoginPage()
                .SetEmailOrUserName("carlos@outlook.com")
                .SetPassword("control123")
                .ValidateLoginButton()
                .ClickLoginButton()

                .GoToDashboardPage
                .IsDashboarLinkActive()
                .SelectDashboardLink()
                .ValidateDataInterval("1 Month")
                .SelectDataInterval("2 Weeks")
                .ValidateDataInterval("2 Weeks");
        }

        [Test]
        public void TestNavigationToMyProfilePage()
        {
            new LoginPage()
                .SetEmailOrUserName("carlos@outlook.com")
                .SetPassword("control123")
                .ValidateLoginButton()
                .ClickLoginButton();

            MyProfile.GoTo()
                .IsAccountDisplayed();

            Dashboard.GoTo()
                .IsStatisticsDisplayed();

            Issues.GoTo()
                .IsTableTitleDisplayed();

            SingOut.GoTo()
                .IsLoginPage();
        }

        [Test]
        public void TestUpdateCurrentProfile()
        {
            new LoginPage()
                .SetEmailOrUserName("carlos@outlook.com")
                .SetPassword("control123")
                .ValidateLoginButton()
                .ClickLoginButton();

            MyProfile.GoTo()
                .IsAccountDisplayed()
                .SetUserName("Matt Damon")
                .SetRealName("Carlos Orellana")
                .SetEmail("carlos@outlook.com")
                .CheckKeepMyEmailAddressprivate()
                .SetCompany("Home")
                .SetLocation("Bol")
                .ClickUpdateProfile()

                .GoToUpdateAccountPopup()
                .ClickOk()

                .GoToMyProfilePage()
                .IsAccountDisplayed();
        }

        [Test]
        public void TestUpdateCurrentProfileAndValidateMessageAlert()
        {
            new LoginPage()
                .SetEmailOrUserName("carlos@outlook.com")
                .SetPassword("control123")
                .ValidateLoginButton()
                .ClickLoginButton();

            MyProfile.GoTo()
                .IsAccountDisplayed()
                .SetUserName("Matt Damon")
                .SetRealName("Carlos Orellana")
                .SetEmail("carlos@outlook.com")
                .CheckKeepMyEmailAddressprivate()
                .SetCompany("Home")
                .SetLocation("Bol")
                .ClickUpdateProfile()

                .GoToUpdateAccountPopup()
                .ClickUpdateProfileValidateMessageAlert()

                .GoToMyProfilePage()
                .IsAccountDisplayed();
        }

        [Test]
        public void TestAnEmailRequiredMessageIsDisaplayed()
        {
            new LoginPage()
                .SetEmailOrUserName("carlos@outlook.com")
                .SetPassword("control123")
                .ValidateLoginButton()
                .ClickLoginButton();

            MyProfile.GoTo()
                .IsAccountDisplayed()
                .SetUserName("Matt Damon")
                .SetRealName("Carlos Orellana")
                .IsAnEmailIsRequiredMessageDisplayed();
        }

        [Test]
        public void TestDeleteCurrentProfile()
        {
            new LoginPage()
                .SetEmailOrUserName("carlos@outlook.com")
                .SetPassword("control123")
                .ValidateLoginButton()
                .ClickLoginButton();

            MyProfile.GoTo()
                .IsAccountDisplayed()
                .ClickDeleteAccount()

                .GoToDeleteAccountPopup()
                .ClickDeleteAccount()

                .GoToLoginPage()
                .IsLoginPage();
        }
    }

}