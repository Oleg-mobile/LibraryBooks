using Castle.DynamicProxy;

namespace LibraryBooks.Interceptors
{
    // Создает прокси-класс
    public static class ProxyGeneratorFactory
    {
        private static ProxyGenerator _generator = new ProxyGenerator();
        // Массив с интерцепторами (перехватчиками)
        private static IInterceptor[] _interceptors =
        {
            new LoggerInterceptor(),
            new ValidationInterceptor()
        };

        // Создает прокси-класс со всеми перехватчиками
        public static TInstance CreateWithAll<TInstance>(params object[] objects) where TInstance : class
            => (TInstance)_generator.CreateClassProxy(typeof(TInstance), objects, _interceptors);

        // Создает прокси-класс с определенным перехватчиком или перехватчиками
        public static TInstance Create<TInstance>(params IInterceptor[] interceptors) where TInstance : class
            => _generator.CreateClassProxy<TInstance>(interceptors);
    }
}