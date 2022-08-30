using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBooks.Core.Models
{
    public abstract class Entity<TPrimaryKey> // abstracting from the data type of the primary key
    {
        public TPrimaryKey Id { get; set; }
    }

    // TODO: do something
    public abstract class Entity : Entity<int> // most often the type ID is int and not to write <int>
    {
    }
}
