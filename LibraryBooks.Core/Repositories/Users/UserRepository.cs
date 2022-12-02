using LibraryBooks.Core.Extentions;
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

        public bool IsExist(string login, string password = null)
        {
            var user = Table   // Table = Context.Users  (EfCoreRepositoryBase)
                .Where(u => u.Login == login)
                .WhereIf(!string.IsNullOrWhiteSpace(password), u => u.Password == password)
                .FirstOrDefault();

            return user != null;  // true or false
        }
    }
}
