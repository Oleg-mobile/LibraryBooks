using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBooks.Core.Models
{
    /// <summary>
    /// Book
    /// </summary>
    public class Book : Entity
    {
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }     // navigation property for JOIN

        public int AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public Author Author { get; set; }

        public int GenreId { get; set; }

        [ForeignKey("GenreId")]
        public Genre Genre { get; set; }

        public string Name { get; set; }
        public string Publication { get; set; }
        public int Year { get; set; }
        public int Mark { get; set; }
        public int PageCount { get; set; }
        public string PathToBook { get; set; }
        public bool IsLiked { get; set; }
        public bool IsFinished { get; set; }
    }
}
