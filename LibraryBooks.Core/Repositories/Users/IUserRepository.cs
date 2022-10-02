using LibraryBooks.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBooks.Core.Repositories.Users
{
    public interface IUserRepository : IRepository<User>
    {
        bool IsExist(string login, string password);
    }
}
