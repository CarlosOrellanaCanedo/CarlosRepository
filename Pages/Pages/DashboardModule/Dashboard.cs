using BlazorPages.AccessToProjects;

namespace BlazorPages.Pages.DashboardModule
{
    public static class Dashboard
    {
        public static DashboardPage GoTo()
        {
            NavigationManager.NavigationMethods.SelectModules("dashboard");
            return new DashboardPage();
        }
    }
}
