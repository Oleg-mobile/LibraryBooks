using System;

namespace LibraryBooks.Interceptors
{
    // Вызывает методы через перехватчик
    public class InterceptorCaller
    {
        public virtual void CallCallback(Action callback, string methodName) => callback();  // Action - делегат
    }
}
