using Castle.DynamicProxy;
using FluentValidation;
using LibraryBooks.Utils;
using System.Linq;

namespace LibraryBooks.Interceptors
{
    public class ValidationInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            try
            {
                invocation.Proceed();
            }
            catch (ValidationException ex)
            {
                var message = ex.Errors?.First().ErrorMessage ?? ex.Message;
                Notification.ShowWarning(message);
            }
        }
    }
}
