using System.Globalization;

namespace Blazor.Utilities.ExtensionMethods
{
    public static class StringExtensionMethods
    {
        public static bool ContainsIgnoreCase(this string source, string toCheck)
        {
            return CultureInfo.InvariantCulture.CompareInfo.IndexOf(source, toCheck, CompareOptions.IgnoreCase) >= 0;
        }
    }
}
