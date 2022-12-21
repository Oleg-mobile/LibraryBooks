using Castle.DynamicProxy;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]

namespace LibraryBooks.Interceptors
{
    public static class ProxyGeneratorFactory
    {
        private static ProxyGenerator _generator = new ProxyGenerator();
        private static IInterceptor[] _interceptors =
        {
            new ValidationInterceptor(),
            new LoggerInterceptor()
        };

        public static TInstance CreateWithAll<TInstance>(params object[] objects) where TInstance : class
            => (TInstance)_generator.CreateClassProxy(typeof(TInstance), objects, _interceptors);

        public static TInstance Create<TInstance>(params IInterceptor[] interceptors) where TInstance : class
            => _generator.CreateClassProxy<TInstance>(interceptors);
    }
}