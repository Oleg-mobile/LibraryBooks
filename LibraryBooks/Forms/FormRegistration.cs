﻿using FluentValidation;
using LibraryBooks.Core.Models;
using LibraryBooks.Core.Repositories.Users;
using LibraryBooks.Utils;
using System;
using System.Linq;

namespace LibraryBooks.Forms
{
    public partial class FormRegistration : FormLibrarryBooks  // Not Form
    {
        private readonly IUserRepository _userRepository;
        private readonly IValidator<FormRegistration> _validator;
        private readonly FormAuthorization _formAuthorization;

        public FormRegistration(FormAuthorization formAuthorization)
        {
            InitializeComponent();

            ActiveControl = textBoxName;
            AcceptButton = buttonAdd;

            _userRepository = Resolve<IUserRepository>();
            _validator = Resolve<IValidator<FormRegistration>>();
            _formAuthorization = formAuthorization;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string login = textBoxName.Text;

            try
            {
                _validator.ValidateAndThrow(this);

                if (_userRepository.IsExist(login))
                {
                    Notification.ShowWarning("Существующий пользователь");
                    return;
                }

                _userRepository.Insert(new User { Login = login, Password = textBoxPassword.Text });

                Notification.ShowSuccess("Пользователь добавлен");

                _formAuthorization.textBoxLogin.Text = login;

                Close();
            }
            catch (ValidationException ex)
            {
                // TODO код повторяется (inetceptor???)
                var message = ex.Errors?.First().ErrorMessage ?? ex.Message;
                Notification.ShowWarning(message);
            }
        }

        private void pictureBoxPassVis_Click(object sender, EventArgs e)
        {
            FormAuthorization.ToggleVisiblePassword(pictureBoxPassVis, textBoxPassword, textBoxPasswordRepeat);
        }
    }
}
