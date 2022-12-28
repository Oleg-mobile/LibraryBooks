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
                // INFO: Проверка на null:
                // ?. - если объект не равен null, то обращаемся к компоненту объекта после ".", иначе - не обращаемся
                // ?? - если операнд слева не равен null, то возвращает операнд слева, иначе - справа
                var message = ex.Errors?.First().ErrorMessage ?? ex.Message;
                Notification.ShowWarning(message);
                throw ex;
            }
        }
    }
}
