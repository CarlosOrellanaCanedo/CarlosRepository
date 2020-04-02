using BlazorPage.Pages.IssuesModule;
using BlazorPages.AccessToProjects;

namespace BlazorPages.Pages.IssuesModule
{
    public static class Issues
    {
        public static IssuesPage GoTo()
        {
            NavigationManager.NavigationMethods.SelectModules("issues");
            return new IssuesPage();
        }
    }
}
