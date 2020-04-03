using System;

namespace Blazor.Utilities.ExceptionMethods
{
    public class AutomationException : Exception
    {
        public AutomationException(string message) : base(message)
        {
        }

        public AutomationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
