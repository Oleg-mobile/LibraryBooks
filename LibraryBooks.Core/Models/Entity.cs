using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBooks.Core.Models
{
    /// <summary>
    /// Abstract entity with generic ID
    /// </summary>
    /// <typeparam name="TPrimaryKey"></typeparam>
    public abstract class Entity<TPrimaryKey> // abstracting from the data type of the primary key
    {
        public TPrimaryKey Id { get; set; }
    }

    /// <summary>
    /// Abstract entity with int ID
    /// </summary>
    public abstract class Entity : Entity<int> // most often the type ID is int and not to write <int>
    {
    }
}
