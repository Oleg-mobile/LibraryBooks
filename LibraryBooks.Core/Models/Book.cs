using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryBooks.Core.Models
{
    /// <summary>
    /// Book
    /// </summary>
    public class Book : Entity
    {
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }  // Свойство навигации для JOIN

        public int AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public Author Author { get; set; }

        public int GenreId { get; set; }

        [ForeignKey("GenreId")]
        public Genre Genre { get; set; }

        public int? ReaderId { get; set; }  // Разрешить значение null

        [ForeignKey("ReaderId")]
        public Reader Reader { get; set; }

        public string Name { get; set; }
        public string Publication { get; set; }
        public int? Year { get; set; }
        public int Mark { get; set; }
        public int? PageCount { get; set; }
        public string PathToBook { get; set; }
        public string PathToCover { get; set; }
        public bool IsLiked { get; set; }
        public bool IsFinished { get; set; }
    }
}
