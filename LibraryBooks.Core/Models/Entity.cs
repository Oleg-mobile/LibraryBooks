namespace LibraryBooks.Core.Models
{
    /// <summary>
    /// Abstract entity with generic ID
    /// </summary>
    /// <typeparam name="TPrimaryKey"></typeparam>
    public abstract class Entity<TPrimaryKey>
    {
        public TPrimaryKey Id { get; set; }
    }

    /// <summary>
    /// Abstract entity with int ID
    /// </summary>
    public abstract class Entity : Entity<int>
    {
    }
}
