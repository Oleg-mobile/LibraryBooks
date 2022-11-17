using Castle.Windsor;

namespace LibraryBooks.Common
{
    public class IocManager
    {
        // container for dependency registration (reference to an object instance)
        private static IWindsorContainer _iocContainer;  // static - for the entire program, without reference to an object

        // Singleton
        // a single container accessible to all
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
