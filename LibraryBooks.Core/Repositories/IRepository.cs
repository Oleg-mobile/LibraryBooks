using LibraryBooks.Core.Models;

namespace LibraryBooks.Core.Repositories
{
    public interface IRepository<TEntity, TPrimaryKey> where TEntity : Entity<TPrimaryKey>
    {
        // methods for working with data
        // TODO Create не нужен?
        IQueryable<TEntity> GetAll();
        TEntity Get(TPrimaryKey id);
        TEntity FirstOrDefault(TPrimaryKey id);
        TEntity Insert(TEntity entity);
        TEntity Update(TEntity entity);
        void Delete(TPrimaryKey id);
        void Delete(TEntity entity);
    }

    // simplified wrapper IRepository (our case)
    public interface IRepository<TEntity> : IRepository<TEntity, int> where TEntity : Entity<int>
    {

    }
}
