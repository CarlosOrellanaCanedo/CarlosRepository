using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pages.AccessToProjects
{
    public class NavigationManager
    {
        public static INavigationModules NavigationMethods => new CommonNavigator();
    }
}
