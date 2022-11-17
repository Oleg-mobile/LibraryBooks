using FluentValidation;
using LibraryBooks.Core.Repositories.Users;
using LibraryBooks.Utils;
using LibraryBooks.Validation;
using System;
using System.Linq;
using ValidationException = FluentValidation.ValidationException;

namespace LibraryBooks.Forms
{
    public partial class FormPasswordChange : FormLibrarryBooks
    {
        private readonly IUserRepository _userRepository;
        private readonly ChangePasswordValidator _changePasswordValidator;
        public FormPasswordChange()
        {
            InitializeComponent();

            ActiveControl = textBoxOldPassword;
            AcceptButton = buttonSave;

            _userRepository = Resolve<IUserRepository>();
            //TODO заменить на автоматическую валидацию
            _changePasswordValidator = new ChangePasswordValidator();

            this.Text = "Библиотека  / Изменить пароль: " + Session.CurrentUser.Login;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                _changePasswordValidator.ValidateAndThrow(this);  // immediately throw an exception
            }
            catch (ValidationException ex)
            {
                Notification.ShowError(ex.Message);
            }

            if (string.IsNullOrWhiteSpace(textBoxOldPassword.Text))
            {
                //MessageBoxExtention.ErrorInput("Введите текущий пароль!");
                Notification.ShowWarning("Введите текущий пароль!");
                return;
            }

            if (!_userRepository.IsExist(Session.CurrentUser.Login, textBoxOldPassword.Text))
            {
                //MessageBoxExtention.WarningInput("Текущий пароль введён не верно!");
                Notification.ShowWarning("Текущий пароль введён не верно!");
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxNewPassword.Text))
            {
                //MessageBoxExtention.WarningInput("Пароль не может быть пустой!");
                Notification.ShowWarning("Пароль не может быть пустой!");
                return;
            }

            if (textBoxNewPassword.Text != textBoxNewPasswordRepeat.Text)
            {
                //MessageBoxExtention.WarningInput("Пароли не совпадают!");
                Notification.ShowWarning("Пароли не совпадают!");
                return;
            }

            if (textBoxOldPassword.Text == textBoxNewPassword.Text)
            {
                //MessageBoxExtention.WarningInput("Новый пароль совпадает с текущим!");
                Notification.ShowWarning("Новый пароль совпадает с текущим!");
                return;
            }

            var user = _userRepository.GetAll().First(u => u.Login == Session.CurrentUser.Login && u.Password == textBoxOldPassword.Text);
            user.Password = textBoxNewPassword.Text;
            _userRepository.Update(user);

            //MessageBoxExtention.SuccessInput("Пароль изменён!");
            Notification.ShowSuccess("Пароль изменён!");

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
