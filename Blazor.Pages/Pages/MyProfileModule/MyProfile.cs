using Blazor.Pages.AccessToProjects;

namespace Blazor.Pages.Pages.MyProfileModule
{
    public static class MyProfile
    {
        public static MyProfilePage GoTo()
        {
            NavigationManager.NavigationMethods.SelectModules("profile");
            return new MyProfilePage();
        }
    }
}
