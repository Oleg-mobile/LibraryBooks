using LibraryBooks.Core;
using LibraryBooks.Core.Repositories.Users;
using LibraryBooks.Extentions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace LibraryBooks.Forms
{
    public partial class AuthorizationForm : LibrarryBooksForm
    {
        private readonly IUserRepository _userRepository;
        public AuthorizationForm()
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

            if (string.IsNullOrEmpty(login))
            {
                MessageBoxExtention.ErrorInput("Введите логин");
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                MessageBoxExtention.ErrorInput("Введите пароль");
                return;
            }

            if (!_userRepository.IsExist(login, password))
            {
                MessageBoxExtention.Error("Не верный логин или пароль", "Ошибка авторизации!");
                return;
            }

            new FormMain().Show();
            Hide();
        }

        private void AuthorizationForm_FormClosed(object sender, FormClosedEventArgs e) => Application.Exit();

        private void buttonRegistration_Click(object sender, EventArgs e)
        {
            new RegistrationForm().Show();
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