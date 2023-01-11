using Castle.Windsor;

namespace LibraryBooks.Common
{
    public class IocManager
    {
        // Контейнер для регистрации зависимостей (ссылка на экземпляр объекта)
        private static IWindsorContainer _iocContainer;

        // Singleton
        // Единый контейнер, доступный для всех
        public static IWindsorContainer IocContainer
        {
            get
            {
                if (_iocContainer is null)
                {
                    _iocContainer = new WindsorContainer();
                }

                return _iocContainer;
            }
        }

        public static TService Resolve<TService>() => IocContainer.Resolve<TService>();
    }
}
