using Castle.DynamicProxy;
using LibraryBooks.Utils;

namespace LibraryBooks.Interceptors
{
    public class LoggerInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            //Notification.ShowWarning(invocation.Arguments[1].ToString());
            invocation.Proceed();
        }
    }
}
