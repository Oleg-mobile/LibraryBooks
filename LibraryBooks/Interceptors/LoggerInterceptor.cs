using Castle.DynamicProxy;
using System.Windows.Forms;

namespace LibraryBooks.Interceptors
{
    public class LoggerInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            //MessageBox.Show(invocation.Arguments[1].ToString());
            invocation.Proceed();
        }
    }
}
