namespace LibraryBooks.Core.Models
{
    /// <summary>
    /// Author
    /// </summary>
    public class Author : Entity
    {
        public string Name { get; set; }

        public Author()
        {
        }

        public Author(string name)
        {
            Name = name;
        }

        public Author(int id, string name) : this(name)
        {
            Id = id;
        }
    }
}
