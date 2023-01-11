using LibraryBooks.Attributes;

namespace LibraryBooks.Dto
{
    // Для редактирования имен и видимости столбцов таблицы

    /// <summary>
    /// Abstract entity with generic ID
    /// </summary>
    /// <typeparam name="TPrimaryKey"></typeparam>
    public abstract class EntityDto<TPrimaryKey>  // Абстрагирование от типа данных первичного ключа
    {
        [DgvColumn(DisplayName = "", IsVisible = false)]
        public TPrimaryKey Id { get; set; }
    }

    /// <summary>
    /// Abstract entity with int ID
    /// </summary>
    public abstract class EntityDto : EntityDto<int>  // Чаще всего ID типа int, чтобы не писать <int>
    {
    }
}
