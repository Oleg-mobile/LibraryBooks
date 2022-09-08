using System.Windows.Forms;

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

        public static DialogResult ErrorInput(string text)
        {
            return Error(text, "Ошибка ввода");
        }
    }
}
