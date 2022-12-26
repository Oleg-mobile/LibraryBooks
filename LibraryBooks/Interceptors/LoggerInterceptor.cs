using Castle.DynamicProxy;
using LibraryBooks.Common;
using LibraryBooks.Utils;
using System;

namespace LibraryBooks.Interceptors
{
    // Logs the execution of methods and exceptions
    public class LoggerInterceptor : IInterceptor
    {
        private readonly ILogger _logger;

        public LoggerInterceptor()
        {
            _logger = IocManager.IocContainer.Resolve<ILogger>();
        }

        public void Intercept(IInvocation invocation)
        {
            string methodName = invocation.Arguments[1].ToString();

            try
            {
                _logger.Info($"Был вызван метод {methodName}");
                invocation.Proceed();
            }
            catch (Exception ex)
            {
                _logger.Error($"Произошла ошибка в методе {methodName}", ex);
            }
        }
    }
}
