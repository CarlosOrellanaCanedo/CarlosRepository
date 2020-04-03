using NUnit.Framework;


namespace Blazor.UnitTest.Base
{
    public class BaseTestCase : BaseTestManagerClass
    {
        [SetUp]
        public void MyTestInitialize()
        {
            MyTestInitializeConnection();
        }

        [TearDown]
        public void MyTestCleanup()
        {
            MyTestCleanupClose();
        }
    }
}
