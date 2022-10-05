namespace LibraryBooks.Core.Common
{
    public class EntityNotFounfException : Exception
    {
        public Type EntityType { get; set; }
        public object Id { get; set; }

        public EntityNotFounfException(Type entityType, object id) : base($"Сущность не найдена. Тип: {entityType.FullName}, Id: {id}")
        {
            EntityType = entityType;
            Id = id;
        }
    }
}
