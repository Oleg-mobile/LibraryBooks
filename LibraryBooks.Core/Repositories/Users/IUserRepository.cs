using LibraryBooks.Core.Models;

namespace LibraryBooks.Core.Repositories.Users
{
    public interface IUserRepository : IRepository<User>
    {
        bool IsExist(string login, string password = null);  // password - не обязательное
    }
}
