using Blazor.Pages.AccessToProjects.LeftMenu;

namespace Blazor.Pages.AccessToProjects
{
    public class CommonNavigator : INavigationModules
    {
        public void SelectModules(string module)
        {
            var leftMenuPage = new LeftMenuPage();
            leftMenuPage.SelectGroup(module);
        }
    }
}
