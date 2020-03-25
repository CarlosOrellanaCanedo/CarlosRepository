using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCases;

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
