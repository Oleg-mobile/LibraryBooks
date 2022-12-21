using System;

namespace LibraryBooks.Interceptors
{
    // Calls methods through an interceptor
    public class InterceptorCaller
    {
        public virtual void CallCallback(Action callback, string methodName) => callback();  // Action - delegate
    }
}
