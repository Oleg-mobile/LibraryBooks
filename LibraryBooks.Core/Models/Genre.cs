namespace LibraryBooks.Core.Models
{
    /// <summary>
    /// Genre
    /// </summary>
    public class Genre : Entity
    {
        public string Name { get; set; }

        public Genre()
        {
        }

        public Genre(string name)
        {
            Name = name;
        }

        public Genre(int id, string name) : this(name)
        {
            Id = id;
        }
    }
}
