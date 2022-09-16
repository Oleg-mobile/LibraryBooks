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
        public override void Delete(TPrimaryKey id)
        {
            throw new NotImplementedException();
        }

        public override void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public override IQueryable<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public override TEntity Insert(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public override TEntity Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
