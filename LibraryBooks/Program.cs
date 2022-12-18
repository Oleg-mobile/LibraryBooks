using LibraryBooks.Forms;
using LibraryBooks.Interceptors;
using System;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]

namespace LibraryBooks
{
    internal static class Program
    {
        // to save form data
        public static FormAuthorization AuthForm = ProxyGeneratorFactory.Create<FormAuthorization>(new FormAuthorization());

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var a = ProxyGeneratorFactory.Create<FormAuthorization>(new FormAuthorization());
            // The form that runs when the application starts
            Application.Run(AuthForm);
        }
    }
}
