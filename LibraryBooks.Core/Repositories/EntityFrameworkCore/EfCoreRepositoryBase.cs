using LibraryBooks.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryBooks.Core.Repositories.EntityFrameworkCore
{
    // Реализация репозитория для инфраструктуры сущностей (основные операции CRUD)
    public class EfCoreRepositoryBase<TDbContext, TEntity, TPrimaryKey> : RepositoryBase<TEntity, TPrimaryKey> where TEntity : Entity<TPrimaryKey> where TDbContext : DbContext
    {
        /// <summary>
        /// to access the context
        /// </summary>
        protected TDbContext Context { get; }

        protected DbSet<TEntity> Table => Context.Set<TEntity>();  // Универсальный способ доступа к таблице базы данных

        public EfCoreRepositoryBase(TDbContext context)
        {
            // set; реализация
            Context = context;
        }

        public override void Delete(TPrimaryKey id)
        {
            var entity = Get(id);  // Возвращает null, если такой сущности нет
            Delete(entity);
        }

        public override void Delete(TEntity entity)
        {
            Table.Remove(entity);
            SaveChanges();
        }

        public override IQueryable<TEntity> GetAll() => Table.AsQueryable();

        public override TEntity Insert(TEntity entity)
        {
            var result = Table.Add(entity).Entity;
            SaveChanges();
            return result;
        }

        public override TEntity Update(TEntity entity)
        {
            var result = Table.Update(entity).Entity;
            SaveChanges();
            return result;
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
            Context.ChangeTracker.Clear();  // Сбросить все отслеживаемые объекты
        }

    }

    public class EfCoreRepositoryBase<TEntity, TPrimaryKey> : EfCoreRepositoryBase<LibraryBooksContext, TEntity, TPrimaryKey> where TEntity : Entity<TPrimaryKey>
    {
        public EfCoreRepositoryBase(LibraryBooksContext context) : base(context)
        {
        }
    }
}