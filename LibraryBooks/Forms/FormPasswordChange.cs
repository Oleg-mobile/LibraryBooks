using FluentValidation;
using LibraryBooks.Core.Repositories.Users;
using LibraryBooks.Utils;
using System;
using System.Linq;

namespace LibraryBooks.Forms
{
    public partial class FormPasswordChange : FormLibrarryBooks
    {
        private readonly IUserRepository _userRepository;
        private readonly IValidator<FormPasswordChange> _changePasswordValidator;
        private readonly string _formName;

        public FormPasswordChange()
        {
            InitializeComponent();

            ActiveControl = textBoxOldPassword;
            AcceptButton = buttonSave;

            _userRepository = Resolve<IUserRepository>();
            _changePasswordValidator = Resolve<IValidator<FormPasswordChange>>();
            _formName = nameof(FormPasswordChange) + " ";

            Text = "Библиотека  / Изменить пароль: " + Session.CurrentUser.Login;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            CallWithAllInterceptors(() =>
            {
                _changePasswordValidator.ValidateAndThrow(this);  // Немедленно выбросить исключение

                var user = _userRepository.GetAll().First(u => u.Login == Session.CurrentUser.Login);

                var salt = EncryptionUtils.GenerateSalt();
                user.Password = EncryptionUtils.EncodePasword(textBoxNewPassword.Text, salt);
                user.Salt = salt;

                _userRepository.Update(user);

                Notification.ShowSuccess("Пароль изменён!");
                Close();

            }, _formName + nameof(buttonSave_Click));
        }

        private void pictureBoxVis_Click(object sender, EventArgs e)
        {
            CallWithLoggerInterceptor(() =>
            {
                FormAuthorization.ToggleVisiblePassword(pictureBoxVis, textBoxOldPassword, textBoxNewPassword, textBoxNewPasswordRepeat);

            }, _formName + nameof(pictureBoxVis_Click));
        }
    }
}
