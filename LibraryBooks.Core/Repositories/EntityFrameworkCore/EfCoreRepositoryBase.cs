using LibraryBooks.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryBooks.Core.Repositories.EntityFrameworkCore
{
    // repository implementation for entity framework (basic CRUD operations)
    public class EfCoreRepositoryBase<TDbContext, TEntity, TPrimaryKey> : RepositoryBase<TEntity, TPrimaryKey> where TEntity : Entity<TPrimaryKey> where TDbContext : DbContext
    {
        /// <summary>
        /// to access the context
        /// </summary>
        protected TDbContext Context { get; }

        protected DbSet<TEntity> Table => Context.Set<TEntity>();  // universal way to access a database table

        public EfCoreRepositoryBase(TDbContext context)
        {
            // set; implementation
            Context = context;
        }

        public override void Delete(TPrimaryKey id)
        {
            var entity = Get(id);  // returns null if there is no such entity
            Delete(entity);
        }

        // TODO ловлю ошибку треккинга тут
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

        public void SaveChanges() => Context.SaveChanges();

    }

    public class EfCoreRepositoryBase<TEntity, TPrimaryKey> : EfCoreRepositoryBase<LibraryBooksContext, TEntity, TPrimaryKey> where TEntity : Entity<TPrimaryKey>
    {
        public EfCoreRepositoryBase(LibraryBooksContext context) : base(context)
        {
        }
    }

    //TODO сделать для Irepository TEntity
    //public class EfCoreRepositoryBase<TEntity, TPrimaryKey> : EfCoreRepositoryBase<LibraryBooksContext, TEntity, TPrimaryKey> where TEntity : Entity<TPrimaryKey>
    //{
    //    public EfCoreRepositoryBase(LibraryBooksContext context) : base(context)
    //    {
    //    }
    //}
}