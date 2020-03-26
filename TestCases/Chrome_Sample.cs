using NUnit.Framework;
using Pages;
using TestCases.Base;

namespace TestCases
{
    [TestFixture]
    class Chrome_Sample : BaseTestCase
    {
        //private IWebDriver driver;
        //public string homeURL;

        //[SetUp]
        //public void SetupTest()
        //{
        //    homeURL = "https://www.niceincontact.com/contact-us";
        //    driver = new ChromeDriver();

        //}

        [Test]
        public void Login()
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

            //driver.Navigate().GoToUrl(homeURL);
        }
    }
}