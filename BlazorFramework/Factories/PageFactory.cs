using System;
using Utilities.ExceptionMethods;

namespace BlazorFramework.Factories
{
    public static class PageFactory
    {
        public static T CreatePage<T>()
        {
            ManageAttributeValue<T>();

            return Instantiate(() => (T)Activator.CreateInstance(typeof(T)));
        }

        public static T CreatePage<T>(string title)
        {
            ManageAttributeValue<T>();

            return Instantiate(() => (T)Activator.CreateInstance(typeof(T), title));
        }

        public static T CreatePage<T>(string title, string iframe)
        {
            ManageAttributeValue<T>();

            return Instantiate(() => (T)Activator.CreateInstance(typeof(T), title, iframe));
        }

        public static T CreatePage<T>(DateTime dateTime)
        {
            ManageAttributeValue<T>();

            return Instantiate(() => (T)Activator.CreateInstance(typeof(T), dateTime));
        }

        private static T Instantiate<T>(Func<T> activate)
        {
            try
            {
                object instance = activate();
                if (instance != null)
                {
                    //Log
                    var message = $"<a style>GoTo {typeof(T).Name}.</a>";
                    Console.WriteLine(message);

                    return (T)instance;
                }

                return default(T);
            }
            catch (Exception ex)
            {
                var automationExecption = ex.InnerException as AutomationException;
                if (automationExecption != null)
                {
                    throw ex.InnerException;
                }

                var messageFailed = $"There was an error creating the page: [ {typeof(T).Name} ]";
                throw new Exception(messageFailed);
            }
        }

        private static void ManageAttributeValue<T>()
        {
            PageAttributeContext.Wait = 0;

            var value = typeof(T).GetAttributeValue((WaitPostAction w) => w.Value);
            if (value != 0)
            {
                PageAttributeContext.Wait = value;
            }
        }
    }
}
