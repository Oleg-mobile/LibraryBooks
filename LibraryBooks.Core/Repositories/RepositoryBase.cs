using LibraryBooks.Core.Common;
using LibraryBooks.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBooks.Core.Repositories
{
    // base class (additional common methods)
    public abstract class RepositoryBase<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey> where TEntity : Entity<TPrimaryKey>
    {
        public abstract void Delete(TPrimaryKey id);

        public abstract void Delete(TEntity entity);

        public TEntity FirstOrDefault(TPrimaryKey id)
        {
            return GetAll().FirstOrDefault(e => e.Id.Equals(id));
        }

        public TEntity Get(TPrimaryKey id)
        {
            var entity = FirstOrDefault(id);
            if (entity is null)
            {
                throw new EntityNotFounfException(typeof(TEntity), id);
            }

            return entity;
        }

        public abstract IQueryable<TEntity> GetAll();

        public abstract TEntity Insert(TEntity entity);

        public abstract TEntity Update(TEntity entity);
    }

    public abstract class RepositoryBase<TEntity> : RepositoryBase<TEntity, int> where TEntity : Entity<int>
    {

    }
}
