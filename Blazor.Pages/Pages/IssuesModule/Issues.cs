using Blazor.Pages.AccessToProjects;
using Blazor.Page.Pages.IssuesModule;

namespace Blazor.Pages.Pages.IssuesModule
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
