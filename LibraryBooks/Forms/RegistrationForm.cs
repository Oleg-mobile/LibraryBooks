using LibraryBooks.Core.Models;
using LibraryBooks.Core.Repositories.Users;
using LibraryBooks.Extentions;
using System;
using System.Linq;
using System.Windows.Forms;

namespace LibraryBooks.Forms
{
    public partial class RegistrationForm : LibrarryBooksForm  // Not Form
    {
        private readonly IUserRepository _userRepository;

        public RegistrationForm()
        {
            InitializeComponent();

            ActiveControl = textBoxName;
            AcceptButton = buttonAdd;

            _userRepository = Resolve<IUserRepository>();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string login = textBoxName.Text;
            string password = textBoxPassword.Text;

            // TODO вынести валидацию в класс вадидатор

            if (string.IsNullOrEmpty(login))  // checking for empty and null
            {
                MessageBoxExtention.ErrorInput("Введите логин");
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                MessageBoxExtention.ErrorInput("Введите пароль");
                return;
            }

            if (textBoxPassword.Text != textBoxPasswordRepeat.Text)
            {
                MessageBoxExtention.ErrorInput("Пароли не совпадают");
                ResetPassword();
                return;
            }

            // TODO вынес в репозиторий
            var user = _userRepository.GetAll().FirstOrDefault(u => u.Login == login);
            if (user is not null)
            {
                MessageBoxExtention.ErrorInput("Существующий пользователь");
                ResetForm();
                return;
            }

            _userRepository.Insert(new User { Login = login, Password = password });

            MessageBox.Show("Пользователь добавлен");

            var authorizeForm = new AuthorizationForm();
            authorizeForm.Show();
            authorizeForm.textBoxLogin.Text = login;

            Close();
        }

        private void ResetForm()
        {
            textBoxName.Text = "";
            ResetPassword();
        }

        private void ResetPassword()
        {
            textBoxPassword.Text = "";
            textBoxPasswordRepeat.Text = "";
        }

        private void pictureBoxPassVis_Click(object sender, EventArgs e)
        {
            AuthorizationForm.ToggleVisiblePassword(pictureBoxPassVis, textBoxPassword, textBoxPasswordRepeat);
        }
    }
}
