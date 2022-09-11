using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace LibraryBooks.Extentions
{
    public static class MessageBoxExtention
    {
        public static DialogResult Error(string text, string caption)
        {
            return MessageBox.Show(
                text,
                caption,
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
        }

        public static DialogResult ErrorInput(string text) => Error(text, "Ошибка ввода");


        public static DialogResult Warning(string text, string caption)
        {
            return MessageBox.Show(
                text,
                caption,
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            );
        }

        public static DialogResult WarningInput(string text) => Warning(text, "Внимание");

    }
}
