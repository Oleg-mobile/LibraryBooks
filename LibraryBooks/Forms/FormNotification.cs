using System;
using System.Drawing;

namespace LibraryBooks.Forms
{
    public partial class FormNotification : FormLibrarryBooks
    {
        public FormNotification(string pathToImage, string messageCaption, string messageText)
        {
            InitializeComponent();

            pictureBoxNotification.Image = Image.FromFile(pathToImage);
            labelNotificationCaption.Text = messageCaption;
            labelNotificationCaption.Left = (Width - labelNotificationCaption.Size.Width - labelNotificationCaption.Text.Length) / 2;
            labelNotificationText.Text = messageText;
            labelNotificationText.Left = (Width - labelNotificationText.Size.Width - labelNotificationText.Text.Length) / 2;
            buttonOk.Left = (Width - buttonOk.Size.Width - buttonOk.Text.Length) / 2;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
