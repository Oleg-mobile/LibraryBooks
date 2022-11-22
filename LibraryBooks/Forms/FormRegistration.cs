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

        public FormRegistration()
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
                Notification.ShowWarning("Введите логин");
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                Notification.ShowWarning("Введите пароль");
                return;
            }

            if (textBoxPassword.Text != textBoxPasswordRepeat.Text)
            {
                Notification.ShowWarning("Пароли не совпадают");
                return;
            }

            // TODO вынес в репозиторий
            var user = _userRepository.GetAll().FirstOrDefault(u => u.Login == login);
            if (user is not null)
            {
                Notification.ShowWarning("Существующий пользователь");
                return;
            }

            _userRepository.Insert(new User { Login = login, Password = password });

            Notification.ShowSuccess("Пользователь добавлен");

            var authorizeForm = new FormAuthorization();
            authorizeForm.Show();
            authorizeForm.textBoxLogin.Text = login;

            Close();
        }

        private void pictureBoxPassVis_Click(object sender, EventArgs e)
        {
            FormAuthorization.ToggleVisiblePassword(pictureBoxPassVis, textBoxPassword, textBoxPasswordRepeat);
        }
    }
}
