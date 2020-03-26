using NUnit.Framework;
using Pages;
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
    }
}