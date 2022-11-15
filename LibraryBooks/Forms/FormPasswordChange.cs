using LibraryBooks.Core.Repositories.Users;
using LibraryBooks.Extentions;
using LibraryBooks.Utils;
using System;
using System.Linq;

namespace LibraryBooks.Forms
{
    public partial class FormPasswordChange : FormLibrarryBooks
    {
        private readonly IUserRepository _userRepository;
        public FormPasswordChange()
        {
            InitializeComponent();

            ActiveControl = textBoxOldPassword;
            AcceptButton = buttonSave;

            _userRepository = Resolve<IUserRepository>();

            this.Text = "Библиотека  / Изменить пароль: " + Session.CurrentUser.Login;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxOldPassword.Text))
            {
                //MessageBoxExtention.ErrorInput("Введите текущий пароль");
                Notification.ShowWarning("Введите текущий пароль!");
                return;
            }

            if (!_userRepository.IsExist(Session.CurrentUser.Login, textBoxOldPassword.Text))
            {
                MessageBoxExtention.WarningInput("Текущий пароль введён не верно!");
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxNewPassword.Text))
            {
                MessageBoxExtention.WarningInput("Пароль не может быть пустой!");
                return;
            }

            if (textBoxNewPassword.Text != textBoxNewPasswordRepeat.Text)
            {
                MessageBoxExtention.WarningInput("Пароли не совпадают!");
                return;
            }

            if (textBoxOldPassword.Text == textBoxNewPassword.Text)
            {
                MessageBoxExtention.WarningInput("Новый пароль совпадает с текущим!");
                return;
            }

            var user = _userRepository.GetAll().First(u => u.Login == Session.CurrentUser.Login && u.Password == textBoxOldPassword.Text);
            user.Password = textBoxNewPassword.Text;
            _userRepository.Update(user);

            MessageBoxExtention.SuccessInput("Пароль изменён");

            var formSettingsm = new FormSettings();
            formSettingsm.Show();

            Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FormAuthorization.ToggleVisiblePassword(pictureBoxVis, textBoxOldPassword, textBoxNewPassword, textBoxNewPasswordRepeat);
        }
    }
}
