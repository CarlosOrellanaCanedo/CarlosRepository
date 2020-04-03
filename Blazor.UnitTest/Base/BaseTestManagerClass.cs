using Blazor.Core.Browser;

namespace Blazor.UnitTest.Base
{
    public class BaseTestManagerClass
    {

        public void MyTestInitializeConnection()
        {
            BrowserManager.Instance.Init();
        }

        public void MyTestCleanupClose()
        {
            BrowserManager.Instance.Close();
        }
    }
}
