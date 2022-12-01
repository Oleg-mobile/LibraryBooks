using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryBooks.Core.Models
{
    public class Reader : Entity
    {
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        public string Name { get; set; }
        public string PathToReader { get; set; }
        public string OpeningFormat { get; set; }

        public Reader()  //  for use in generics
        {
        }

        public Reader(string name)
        {
            Name = name;
        }

        public Reader(int id, string name) : this(name)
        {
            Id = id;
        }
    }
}
