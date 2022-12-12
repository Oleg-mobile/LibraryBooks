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

        public FormPasswordChange()
        {
            InitializeComponent();

            ActiveControl = textBoxOldPassword;
            AcceptButton = buttonSave;

            _userRepository = Resolve<IUserRepository>();
            _changePasswordValidator = Resolve<IValidator<FormPasswordChange>>();

            Text = "Библиотека  / Изменить пароль: " + Session.CurrentUser.Login;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                _changePasswordValidator.ValidateAndThrow(this);  // immediately throw an exception

                var user = _userRepository.GetAll().First(u => u.Login == Session.CurrentUser.Login);

                var salt = EncryptionUtils.GenerateSalt();
                user.Password = EncryptionUtils.EncodePasword(textBoxNewPassword.Text, salt);
                user.Salt = salt;

                _userRepository.Update(user);

                Notification.ShowSuccess("Пароль изменён!");
                Close();
            }
            catch (ValidationException ex)
            {
                var message = ex.Errors?.First().ErrorMessage ?? ex.Message;  // ? - defence from NullReferenceException
                Notification.ShowWarning(message);                            // if ex.Errors not null, method First() will be called
            }                                                                 // ?? - if left is not null, use left
        }                                                                     // otherwise, use ex.Message

        private void pictureBoxVis_Click(object sender, EventArgs e)
        {
            FormAuthorization.ToggleVisiblePassword(pictureBoxVis, textBoxOldPassword, textBoxNewPassword, textBoxNewPasswordRepeat);
        }
    }
}
