using LibraryBooks.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBooks.Core.Repositories.EntityFrameworkCore
{
    // repository implementation for entity framework
    public class EfCoreRepositoryBase<TDbContext, TEntity, TPrimaryKey> : RepositoryBase<TEntity, TPrimaryKey> where TEntity : Entity<TPrimaryKey> where TDbContext : DbContext
    {
        private TDbContext Context { get; }

        protected DbSet<TEntity> Table => Context.Set<TEntity>();

        public EfCoreRepositoryBase(TDbContext context)
        {
            Context = context;
        }

        public override void Delete(TPrimaryKey id)
        {
            var entity = Get(id);
            Delete(entity);
        }

        public override void Delete(TEntity entity) => Table.Remove(entity);

        public override IQueryable<TEntity> GetAll() => Table.AsQueryable();

        public override TEntity Insert(TEntity entity) => Table.Add(entity).Entity;

        public override TEntity Update(TEntity entity) => Table.Update(entity).Entity;

        public void SaveChanges() => Context.SaveChanges();

    }

    public class EfCoreRepositoryBase<TDbContext, TEntity> : EfCoreRepositoryBase<TDbContext, TEntity, int> where TEntity : Entity<int> where TDbContext : DbContext
    {
        public EfCoreRepositoryBase(TDbContext context) : base(context)
        {
        }
    }
}