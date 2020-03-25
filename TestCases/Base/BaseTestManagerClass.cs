using BlazorFramework.Browser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCases.Base
{
    public class BaseTestManagerClass
    {

        public void MyTestInitializeConnection()
        {
            BrowserManager.Instance.Init();

            //LoginPage.LoginPage loginStart = Login.LoginStart;
            //loginStart.LoginAs();
        }

        public void MyTestCleanupClose()
        {
            BrowserManager.Instance.Close();
        }
    }
}
