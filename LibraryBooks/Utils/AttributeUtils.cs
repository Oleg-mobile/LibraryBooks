using LibraryBooks.Attributes;
using System.Collections.Generic;
using System.Reflection;

namespace LibraryBooks.Utils
{
    public static class AttributeUtils
    {
        public static Dictionary<string, DgvColumnAttribute> GetDgvColumns<T>()
        {
            var result = new Dictionary<string, DgvColumnAttribute>();
            //  Рефлексия
            PropertyInfo[] properties = typeof(T).GetProperties();  // PropertyInfo[] - информация о свойствах
            foreach (var property in properties)
            {
                var attribute = property.GetCustomAttribute<DgvColumnAttribute>();  // Читать все настраиваемые атрибуты характеристик
                if (attribute is not null)
                {
                    result.Add(property.Name, attribute);
                }
            }
            return result;
        }
    }
}
