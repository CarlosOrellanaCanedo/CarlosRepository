using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.ExceptionMethods
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
