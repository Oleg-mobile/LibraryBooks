namespace LibraryBooks.Dto
{
    /// <summary>
    /// Abstract entity with generic ID
    /// </summary>
    /// <typeparam name="TPrimaryKey"></typeparam>
    public abstract class EntityDto<TPrimaryKey> // abstracting from the data type of the primary key
    {
        public TPrimaryKey Id { get; set; }
    }

    /// <summary>
    /// Abstract entity with int ID
    /// </summary>
    public abstract class EntityDto : EntityDto<int> // most often the type ID is int and not to write <int>
    {
    }
}
