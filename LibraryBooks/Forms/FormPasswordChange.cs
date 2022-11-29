﻿using FluentValidation;
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

            Text = "Библиотека  / Изменить пароль: " + Session.CurrentUser.Login;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                _changePasswordValidator.ValidateAndThrow(this);  // immediately throw an exception

                var user = _userRepository.GetAll().First(u => u.Login == Session.CurrentUser.Login && u.Password == textBoxOldPassword.Text);
                user.Password = textBoxNewPassword.Text;
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
