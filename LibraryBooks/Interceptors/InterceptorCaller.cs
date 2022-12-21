using System;

namespace LibraryBooks.Interceptors
{
    public class InterceptorCaller
    {
        public virtual void CallCallback(Action callback, string methodName) => callback();
    }
}
