using LibraryBooks.Core.Models;

namespace LibraryBooks.Core.Repositories
{
    public interface IRepository<TEntity, TPrimaryKey> where TEntity : Entity<TPrimaryKey>
    {
        // Методы работы с данными
        IQueryable<TEntity> GetAll();
        TEntity Get(TPrimaryKey id);
        TEntity FirstOrDefault(TPrimaryKey id);
        TEntity Insert(TEntity entity);
        TEntity Update(TEntity entity);
        void Delete(TPrimaryKey id);
        void Delete(TEntity entity);
    }

    // Упрощенная оболочка IRepository (наш случай)
    public interface IRepository<TEntity> : IRepository<TEntity, int> where TEntity : Entity<int>
    {

    }
}
