using System.Windows.Forms;

namespace LibraryBooks.Extentions
{
    // TODO уже не нужен?

    /// <summary>
    /// Expanding the functionality of methods
    /// </summary>
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

        public static DialogResult Success(string text, string caption)
        {
            return MessageBox.Show(
                text,
                caption,
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        public static DialogResult SuccessInput(string text) => Success(text, "Успех");

    }
}
