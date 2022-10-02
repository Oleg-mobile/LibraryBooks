using LibraryBooks.Core.Models;
using LibraryBooks.Core.Repositories.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBooks.Core.Repositories.Users
{
    public class UserRepository : EfCoreRepositoryBase<User, int>, IUserRepository
    {
        public UserRepository(LibraryBooksContext context) : base(context)
        {

        }

        public bool IsExist(string login, string password)
        {
            var user = Table.FirstOrDefault(u => u.Login == login && u.Password == password);
            return user != null;
        }
    }
}
