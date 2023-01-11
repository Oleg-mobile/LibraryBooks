using LibraryBooks.Forms;
using System.Windows.Forms;

namespace LibraryBooks.Utils
{
    public static class Notification
    {
        public static DialogResult ShowError(string textMessage)
        {
            return new FormNotification(@"Images\error.png", "Ошибка!", textMessage).ShowDialog();  // ShowDialog() - открыть модально
        }

        public static DialogResult ShowWarning(string textMessage)
        {
            return new FormNotification(@"Images\danger.png", "Внимание!", textMessage).ShowDialog();
        }

        public static DialogResult ShowSuccess(string textMessage)
        {
            return new FormNotification(@"Images\trophy.png", "Ура!", textMessage).ShowDialog();
        }
    }
}
