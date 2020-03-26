using OpenQA.Selenium;
using Pages.AccessToProjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pages.MyProfileModule
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
