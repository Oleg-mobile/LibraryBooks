using LibraryBooks.Core.Models;
using LibraryBooks.Core.Repositories.EntityFrameworkCore;

namespace LibraryBooks.Core.Repositories.Users
{
    public class UserRepository : EfCoreRepositoryBase<User, int>, IUserRepository
    {
        // base constructor
        public UserRepository(LibraryBooksContext context) : base(context)
        {
        }

        public bool IsExist(string login, string password)
        {
            var user = Table.FirstOrDefault(u => u.Login == login && u.Password == password);  // Table = Context.Users  (EfCoreRepositoryBase)
            return user != null;  // true or false
        }
    }
}
