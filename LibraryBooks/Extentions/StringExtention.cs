using System;

namespace LibraryBooks.Extentions
{
    public static class StringExtention
    {
        public static int ToInt(this string str)  // this - метод расширения
        {
            return Convert.ToInt32(str);
        }
    }
}
