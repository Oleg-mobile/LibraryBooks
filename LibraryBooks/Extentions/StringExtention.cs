using System;

namespace LibraryBooks.Extentions
{
    public static class StringExtention
    {
        public static int ToInt(this string str)  // this - extension method
        {
            return Convert.ToInt32(str);
        }
    }
}
