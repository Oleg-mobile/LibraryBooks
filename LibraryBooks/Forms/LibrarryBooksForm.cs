using AutoMapper;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using LibraryBooks.Core;
using LibraryBooks.Core.Repositories;
using LibraryBooks.Core.Repositories.EntityFrameworkCore;
using LibraryBooks.Core.Repositories.Users;
using System.Windows.Forms;

namespace LibraryBooks.Forms
{
    public class LibrarryBooksForm : Form   // not abstract
    {
        // container for dependency registration (reference to an object instance)
        private static IWindsorContainer _iocContainer;  // static - for the entire program, without reference to an object
        // Singleton
        protected static IWindsorContainer IocContainer  // protected - only for heirs
        {
            get
            {
                if (_iocContainer is null)
                {
                    _iocContainer = new WindsorContainer();
                    RegisterServices();
                }

                return _iocContainer;
            }
        }

        protected IMapper Mapper { get; }

        public LibrarryBooksForm()
        {
            Mapper = Resolve<IMapper>();
        }

        // dependency registration
        private static void RegisterServices()
        {
            // container creation (registration)
            _iocContainer.Register(Component.For<LibraryBooksContext, LibraryBooksContext>().LifestyleTransient());
            // if you want a IRepository<,>, you will get its implementation like this - EfCoreRepositoryBase<,>
            _iocContainer.Register(Component.For(typeof(IRepository<,>)).ImplementedBy(typeof(EfCoreRepositoryBase<,>)).LifestyleTransient());
            _iocContainer.Register(Component.For(typeof(IUserRepository)).ImplementedBy(typeof(UserRepository)).LifestyleTransient());

            var config = new MapperConfiguration(c => { c.AddMaps(typeof(Program)); });  // profiles - describe how to map
            _iocContainer.Register(Component.For(typeof(IMapper)).LifestyleSingleton().Instance(config.CreateMapper()));
        }

        protected TService Resolve<TService>() => IocContainer.Resolve<TService>();

    }
}
