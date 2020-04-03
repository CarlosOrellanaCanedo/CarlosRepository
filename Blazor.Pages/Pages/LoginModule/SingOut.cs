using Blazor.Pages.AccessToProjects;

namespace Blazor.Pages.Pages.LoginModule
{
    public static class SingOut
    {
        public static LoginPage GoTo()
        {
            NavigationManager.NavigationMethods.SelectModules("signin");
            return new LoginPage();
        }
    }
}
