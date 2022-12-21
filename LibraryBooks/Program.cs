using LibraryBooks.Forms;
using System;
using System.Windows.Forms;

namespace LibraryBooks
{
    internal static class Program
    {
        // to save form data
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
            // The form that runs when the application starts
            Application.Run(AuthForm);
        }
    }
}
