using LibraryBooks.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBooks.Core.Repositories
{
    public interface IRepository<TEntity, TPrimaryKey> where TEntity : Entity<TPrimaryKey>
    {
        IQueryable<TEntity> GetAll();
        TEntity Get(TPrimaryKey id);
        TEntity FirstOrDefault(TPrimaryKey id);
        TEntity Insert(TEntity entity);
        TEntity Update(TEntity entity);
        void Delete(TPrimaryKey id);
        void Delete(TEntity entity);
    }

    public interface IRepository<TEntity> : IRepository<TEntity, int> where TEntity : Entity<int>
    {

    }
}
