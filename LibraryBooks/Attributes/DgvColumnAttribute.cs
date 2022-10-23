using System;

namespace LibraryBooks.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class DgvColumnAttribute : Attribute
    {
        public string DisplayName { get; set; }
        public bool IsVisible { get; set; } = true;
    }
}
