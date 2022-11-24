﻿using FluentValidation;
using LibraryBooks.Core.Repositories.Users;
using LibraryBooks.Dto;
using LibraryBooks.Utils;
using LibraryBooks.Validation;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace LibraryBooks.Forms
{
    public partial class FormAuthorization : FormLibrarryBooks
    {
        private readonly IUserRepository _userRepository;
        public FormAuthorization()
        {
            InitializeComponent();

            ActiveControl = textBoxLogin;
            AcceptButton = buttonLogin;

            _userRepository = Resolve<IUserRepository>();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string login = textBoxLogin.Text;
            string password = textBoxPassword.Text;

            // TODO в валидацию
            //if (string.IsNullOrEmpty(login))
            //{
            //    Notification.ShowWarning("Введите логин");
            //    return;
            //}

            //if (string.IsNullOrEmpty(password))
            //{
            //    Notification.ShowWarning("Введите пароль");
            //    return;
            //}

            //if (!_userRepository.IsExist(login, password))
            //{
            //    Notification.ShowWarning("Не верный логин или пароль");
            //    return;
            //}

            try
            {
                var validator = new AuthorizationValidator();
                validator.ValidateAndThrow(this);

                var user = _userRepository.GetAll().First(u => u.Login == login && u.Password == password);
                Session.CurrentUser = Mapper.Map<UserDto>(user);
                new FormMain().Show();  // stack variable is not needed
                Hide();
            }
            catch (ValidationException ex)
            {
                var message = ex.Errors?.First().ErrorMessage ?? ex.Message;
                Notification.ShowWarning(message);
            }
        }

        private void AuthorizationForm_FormClosed(object sender, FormClosedEventArgs e) => Application.Exit();

        private void buttonRegistration_Click(object sender, EventArgs e)
        {
            new FormRegistration().Show();
            Hide();
        }

        private void pictureBoxClose_Click(object sender, EventArgs e) => ToggleVisiblePassword(pictureBoxClose, textBoxPassword);

        public static void ToggleVisiblePassword(PictureBox pictureBox, params TextBox[] textBoxPasswords)
        {
            bool isVisiblePass = textBoxPasswords[0].UseSystemPasswordChar;
            // in case of multiple textBoxes
            foreach (TextBox textBoxPassword in textBoxPasswords)
            {
                textBoxPassword.UseSystemPasswordChar = !isVisiblePass;
            }
            pictureBox.Image = Image.FromFile(@$"Images\{(isVisiblePass ? "eyeOpen.png" : "eyeClose.png")}");
            // @ - take the string literally without escaping service characters
            // $ - string interpolation, you can use variables
        }
    }
}