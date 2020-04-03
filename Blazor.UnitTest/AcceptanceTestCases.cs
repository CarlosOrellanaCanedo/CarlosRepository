using NUnit.Framework;
using Blazor.Pages.Pages.DashboardModule;
using Blazor.Pages.Pages.IssuesModule;
using Blazor.Pages.Pages.LoginModule;
using Blazor.Pages.Pages.MyProfileModule;
using Blazor.UnitTest.Base;

namespace Blazor.UnitTest
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
                .IsAccountDisplayed()
                .ValidateUserName("Matt Damon")
                .ValidateRealName("Carlos Orellana")
                .ValidateEmail("carlos@outlook.com")
                .IsCheckedKeepMyEmailAddressprivate()
                .ValidateCompany("Home")
                .ValidateLocation("Bol");
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