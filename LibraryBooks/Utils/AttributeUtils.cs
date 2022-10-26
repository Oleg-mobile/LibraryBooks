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
            //  reflection
            PropertyInfo[] properties = typeof(T).GetProperties();  // PropertyInfo[] - information about properties
            foreach (var property in properties)
            {
                var attribute = property.GetCustomAttribute<DgvColumnAttribute>();  // read all custom attributes of a characteristic
                if (attribute is not null)
                {
                    result.Add(property.Name, attribute);
                }
            }
            return result;
        }
    }
}
