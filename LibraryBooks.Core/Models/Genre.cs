using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBooks.Core.Models
{
    /// <summary>
    /// Genre
    /// </summary>
    public class Genre : Entity
    {
        public string Name { get; set; }

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
