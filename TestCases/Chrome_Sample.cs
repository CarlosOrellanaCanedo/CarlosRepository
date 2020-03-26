using NUnit.Framework;
using Pages.DashboardModule;
using Pages.IssuesModule;
using Pages.LoginModule;
using Pages.MyProfileModule;
using TestCases.Base;

namespace TestCases
{
    [TestFixture]
    class Chrome_Sample : BaseTestCase
    {
        [Test]
        public void TestLogin()
        {
            new LoginPage()
                .SetEmailOrUserName("carlos.orellanacanedo@outlook.com")
                .SetPassword("control123")
                .ValidateLoginButton()
                .ClickLoginButton()

                .GoToDashboardPage
                .IsDashboarLinkActive();
        }

        [Test]
        public void TestDasboardDataIntervalDropDownList()
        {
            new LoginPage()
                .SetEmailOrUserName("carlos.orellanacanedo@outlook.com")
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
                .SetEmailOrUserName("carlos.orellanacanedo@outlook.com")
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
    }
}