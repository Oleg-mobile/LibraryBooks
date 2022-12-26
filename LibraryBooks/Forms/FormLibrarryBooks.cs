using AutoMapper;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using FluentValidation;
using LibraryBooks.Common;
using LibraryBooks.Core;
using LibraryBooks.Core.Repositories;
using LibraryBooks.Core.Repositories.EntityFrameworkCore;
using LibraryBooks.Core.Repositories.Users;
using LibraryBooks.Interceptors;
using LibraryBooks.Utils;
using System;
using System.Windows.Forms;

namespace LibraryBooks.Forms
{
    public class FormLibrarryBooks : Form
    {
        // Контейнер для регистрации зависимостей (ссылка на экземпляр объекта)
        private static IWindsorContainer _iocContainer;  // Static - для всей программы, без ссылки на объект
        // Singleton
        protected static IWindsorContainer IocContainer  // Protected - только для наследников
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

        private static InterceptorCaller interceptorCallerWithAll;
        private static InterceptorCaller interceptorCallerWithLogger;

        protected IMapper Mapper { get; }

        public FormLibrarryBooks()
        {
            Mapper = Resolve<IMapper>();
        }

        // Регистрация зависимостей
        private static void RegisterServices()
        {
            // Создание контейнера (регистрация)
            _iocContainer.Register(Component.For<LibraryBooksContext, LibraryBooksContext>().LifestyleTransient());
            // Если нужен IRepository<,>, то получим его реализацию EfCoreRepositoryBase<,>
            _iocContainer.Register(Component.For(typeof(IRepository<,>)).ImplementedBy(typeof(EfCoreRepositoryBase<,>)).LifestyleTransient());
            _iocContainer.Register(Component.For(typeof(IUserRepository)).ImplementedBy(typeof(UserRepository)).LifestyleTransient());
            // Добавить все что связано с маппингом из сборки с файлом Program
            var config = new MapperConfiguration(c => { c.AddMaps(typeof(Program)); });  // profiles - описание как маппить
            _iocContainer.Register(Component.For(typeof(IMapper)).LifestyleSingleton().Instance(config.CreateMapper()));
            // Найти все классы сборки Program, реализующие интерфейс IValidator, и зарегистрировать их под этим интерфейсом
            // Реализация интерфейсов в классе, который в <>
            _iocContainer.Register(Classes.FromAssembly(typeof(Program).Assembly).BasedOn(typeof(IValidator<>)).WithService.Base());

            //  Transient - объект живет только во время работы метода (внутри класса)
            //  Singleton - один объект на время жизни программы
            //  Scoped    - объект живет внутри одного запроса (сайтов)

            _iocContainer.Register(Component.For(typeof(ILogger)).ImplementedBy(typeof(Logger)).LifestyleTransient());
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

        // Singleton
        protected void CallWithAllInterceptors(Action callback, string methodName)  // Вызов всех перехватчиков из ProxyGenerator
        {
            if (interceptorCallerWithAll == null)
            {
                interceptorCallerWithAll = ProxyGeneratorFactory.CreateWithAll<InterceptorCaller>();
            }

            interceptorCallerWithAll.CallCallback(callback, methodName);
        }

        // Singleton
        protected void CallWithLoggerInterceptor(Action callback, string methodName)
        {
            if (interceptorCallerWithLogger == null)
            {
                interceptorCallerWithLogger = ProxyGeneratorFactory.Create<InterceptorCaller>(new LoggerInterceptor());
            }

            interceptorCallerWithLogger.CallCallback(callback, methodName);
        }
    }
}
