using System;

namespace LibraryBooks.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]  // Ограничение (только характеристики)
    public class DgvColumnAttribute : Attribute  // Переименовать столбцы таблицы
    {
        public string DisplayName { get; set; }
        public bool IsVisible { get; set; } = true;
    }
}
