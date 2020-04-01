using System;

namespace BlazorUtilities.ExceptionMethods
{
    public class AutomationException : Exception
    {
        public AutomationException()
        {
        }

        public AutomationException(string message) : base(message)
        {
        }

        public AutomationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
