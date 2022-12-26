using LibraryBooks.Forms;
using System;
using System.Windows.Forms;

namespace LibraryBooks
{
    internal static class Program
    {
        // Сохранить данные формы
        public static FormAuthorization AuthForm = new FormAuthorization();

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Форма, которая запускается при запуске приложения
            Application.Run(AuthForm);
        }
    }
}
