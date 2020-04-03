using Blazor.Pages.AccessToProjects;

namespace Blazor.Pages.Pages.DashboardModule
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
