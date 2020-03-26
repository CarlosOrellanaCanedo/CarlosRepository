using Pages.AccessToProjects;
using Pages.DashboardModule;

namespace Pages.IssuesModule
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
