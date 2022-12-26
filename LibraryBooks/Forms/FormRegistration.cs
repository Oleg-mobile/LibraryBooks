using FluentValidation;
using LibraryBooks.Core.Models;
using LibraryBooks.Core.Repositories.Users;
using LibraryBooks.Utils;
using System;

namespace LibraryBooks.Forms
{
    public partial class FormRegistration : FormLibrarryBooks
    {
        private readonly IUserRepository _userRepository;
        private readonly IValidator<FormRegistration> _validator;
        private readonly FormAuthorization _formAuthorization;
        private readonly string _formName;

        public FormRegistration(FormAuthorization formAuthorization)
        {
            InitializeComponent();

            ActiveControl = textBoxName;
            AcceptButton = buttonAdd;

            _userRepository = Resolve<IUserRepository>();
            _validator = Resolve<IValidator<FormRegistration>>();
            _formAuthorization = formAuthorization;
            _formName = nameof(FormRegistration) + " ";
        }

        protected void buttonAdd_Click(object sender, EventArgs e)
        {
            CallWithAllInterceptors(() =>
            {
                _validator.ValidateAndThrow(this);

                string login = textBoxName.Text;
                if (_userRepository.IsExist(login))
                {
                    Notification.ShowWarning("Существующий пользователь");
                    return;
                }

                var salt = EncryptionUtils.GenerateSalt();
                var password = textBoxPassword.Text;

                _userRepository.Insert(new User
                {
                    Login = login,
                    Password = EncryptionUtils.EncodePasword(password, salt),
                    Salt = salt
                });

                Notification.ShowSuccess("Пользователь добавлен");
                _formAuthorization.textBoxLogin.Text = login;

                Close();
            }, _formName + nameof(buttonAdd_Click));
        }

        private void pictureBoxPassVis_Click(object sender, EventArgs e)
        {
            CallWithLoggerInterceptor(() =>
            {
                FormAuthorization.ToggleVisiblePassword(pictureBoxPassVis, textBoxPassword, textBoxPasswordRepeat);
            }, _formName + nameof(pictureBoxPassVis_Click));
        }
    }
}
