using BlazorFramework.Controls;
using System;

namespace BlazorFramework.Factories
{
    public static class ControlFactory
    {
        public static T GetControl<T>(object locator, string value, string controlName)
        {
            return (T)Activator.CreateInstance(typeof(T), new[] { locator, value, controlName });
        }

        public static T GetControl<T>(object locator, string value, string controlName, params PostAction[] postAction)
        {
            return (T)Activator.CreateInstance(typeof(T), new[] { locator, value, controlName, postAction });
        }

        public static T GetControl<T>(object container, object locator, string value, string controlName)
        {
            return (T)Activator.CreateInstance(typeof(T), new[] { container, locator, value, controlName });
        }
    }
}
