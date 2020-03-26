using Pages.AccessToProjects;
using Pages.DashboardModule;

namespace Pages.DashboardModule
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
