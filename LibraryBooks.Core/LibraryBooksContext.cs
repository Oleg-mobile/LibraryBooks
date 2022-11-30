using LibraryBooks.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryBooks.Core
{
    /// <summary>
    /// Database model
    /// </summary>
    public class LibraryBooksContext : DbContext  // a class symbolizing the database
    {
        // tables
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Reader> Readers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // database connection string
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=LibraryBooks;Trusted_Connection=True;");
        }
    }
}
