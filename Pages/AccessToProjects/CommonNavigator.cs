using BlazorPages.AccessToProjects.LeftMenu;

namespace BlazorPages.AccessToProjects
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
