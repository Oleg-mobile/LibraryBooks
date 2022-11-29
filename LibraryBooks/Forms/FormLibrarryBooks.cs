﻿using AutoMapper;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using FluentValidation;
using LibraryBooks.Common;
using LibraryBooks.Core;
using LibraryBooks.Core.Repositories;
using LibraryBooks.Core.Repositories.EntityFrameworkCore;
using LibraryBooks.Core.Repositories.Users;
using LibraryBooks.Utils;
using LibraryBooks.Validation;
using System.Windows.Forms;

namespace LibraryBooks.Forms
{
    public class FormLibrarryBooks : Form   // not abstract
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
                    _iocContainer = IocManager.IocContainer;
                    RegisterServices();
                }

                return _iocContainer;
            }
        }

        protected IMapper Mapper { get; }

        public FormLibrarryBooks()
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
            // will add everything related to the mapping from the assembly with the file Program
            var config = new MapperConfiguration(c => { c.AddMaps(typeof(Program)); });  // profiles - describe how to map
            _iocContainer.Register(Component.For(typeof(IMapper)).LifestyleSingleton().Instance(config.CreateMapper()));
            _iocContainer.Register(Component.For(typeof(IValidator<FormRegistration>)).ImplementedBy(typeof(BaseValidator<FormRegistration>)).LifestyleTransient());
            _iocContainer.Register(Component.For(typeof(IValidator<FormPasswordChange>)).ImplementedBy(typeof(BaseValidator<FormPasswordChange>)).LifestyleTransient());
            _iocContainer.Register(Component.For(typeof(IValidator<FormAuthorization>)).ImplementedBy(typeof(BaseValidator<FormAuthorization>)).LifestyleTransient());
            _iocContainer.Register(Component.For(typeof(IValidator<FormBook>)).ImplementedBy(typeof(BaseValidator<FormBook>)).LifestyleTransient());
            //  Transient - the object lives only while the method is running (within class)
            //  Singleton - one object for the lifetime of the program
            //  Scoped - object lives within a single request (sites)
        }

        protected TService Resolve<TService>() => IocContainer.Resolve<TService>();

        protected void InitDataGridViewColumns<TModel>(DataGridView table) where TModel : class
        {
            var columnSettings = AttributeUtils.GetDgvColumns<TModel>();
            foreach (var column in columnSettings)
            {
                table.Columns[column.Key].HeaderText = column.Value.DisplayName;
                table.Columns[column.Key].Visible = column.Value.IsVisible;
            }
        }
    }
}
