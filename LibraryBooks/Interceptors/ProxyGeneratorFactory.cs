using Castle.DynamicProxy;

namespace LibraryBooks.Interceptors
{
    // Creates a proxy class
    public static class ProxyGeneratorFactory
    {
        private static ProxyGenerator _generator = new ProxyGenerator();
        // Array with interceptors
        private static IInterceptor[] _interceptors =
        {
            new ValidationInterceptor(),
            new LoggerInterceptor()
        };

        // Creates a proxy class with all interceptors
        public static TInstance CreateWithAll<TInstance>(params object[] objects) where TInstance : class
            => (TInstance)_generator.CreateClassProxy(typeof(TInstance), objects, _interceptors);

        // Creates a proxy class with a specific interceptor or interceptors
        public static TInstance Create<TInstance>(params IInterceptor[] interceptors) where TInstance : class
            => _generator.CreateClassProxy<TInstance>(interceptors);
    }
}