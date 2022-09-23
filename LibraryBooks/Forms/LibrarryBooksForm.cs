using Castle.MicroKernel.Registration;
using Castle.Windsor;
using LibraryBooks.Core;
using LibraryBooks.Core.Repositories;
using LibraryBooks.Core.Repositories.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryBooks.Forms
{
    public abstract class LibrarryBooksForm : Form
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

        // dependency registration
        private static void RegisterServices()
        {
            // container creation (registration)
            _iocContainer.Register(Component.For<LibraryBooksContext, LibraryBooksContext>().LifestyleTransient());
            // if you want a IRepository<,>, you will get its implementation like this - EfCoreRepositoryBase<,>
            _iocContainer.Register(Component.For(typeof(IRepository<,>)).ImplementedBy(typeof(EfCoreRepositoryBase<,>)).LifestyleTransient());
        }

        protected TService Resolve<TService>()
        {
            return IocContainer.Resolve<TService>();
        }
    }
}
