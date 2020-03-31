using NUnit.Framework;


namespace TestCases.Base
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
