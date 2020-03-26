using Pages.AccessToProjects;

namespace Pages.LoginModule
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
