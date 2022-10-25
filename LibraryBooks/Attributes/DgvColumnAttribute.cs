using System;

namespace LibraryBooks.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]  // limitation (only characteristics)
    public class DgvColumnAttribute : Attribute  // to rename table columns
    {
        public string DisplayName { get; set; }
        public bool IsVisible { get; set; } = true;
    }
}
