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
        private static IWindsorContainer _iocContainer;

        protected static IWindsorContainer IocContainer 
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

        private static void RegisterServices()
        {
            _iocContainer.Register(Component.For<LibraryBooksContext, LibraryBooksContext>().LifestyleTransient());
            _iocContainer.Register(Component.For(typeof(IRepository<,>)).ImplementedBy(typeof(EfCoreRepositoryBase<,>)).LifestyleTransient());
        }

        protected TService Resolve<TService>()
        {
            return IocContainer.Resolve<TService>();
        }
    }
}
