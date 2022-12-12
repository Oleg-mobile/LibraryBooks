using System;
using System.Reflection;

namespace LibraryBooks.Extentions
{
    // TODO не используется?
    public static class ReflectionExtention
    {
        public static TCustomAttr GetCustomAttribute<TCustomAttr>(this PropertyInfo property) where TCustomAttr : Attribute  // this - who is this method for
        {
            var attribute = property.GetCustomAttribute(typeof(TCustomAttr));
            return attribute != null ? (TCustomAttr)attribute : null;  // TODO разобрать выражение
        }
    }
}
