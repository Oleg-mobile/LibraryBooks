using FluentValidation;
using LibraryBooks.Core.Models;
using LibraryBooks.Core.Repositories.Users;
using LibraryBooks.Utils;
using LibraryBooks.Validation;
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

            try
            {
                // TODO вынес в вадидатор
                var validator = new RegistrationValidator();
                validator.ValidateAndThrow(this);

                // TODO вынес в репозиторий
                var user = _userRepository.GetAll().FirstOrDefault(u => u.Login == login);
                if (user is not null)
                {
                    Notification.ShowWarning("Существующий пользователь");
                    return;
                }

                _userRepository.Insert(new User { Login = login, Password = textBoxPassword.Text});

                Notification.ShowSuccess("Пользователь добавлен");

                var authorizeForm = new FormAuthorization();
                authorizeForm.Show();
                authorizeForm.textBoxLogin.Text = login;

                Close();
            }
            catch (ValidationException ex)
            {
                // TODO код повторяется
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
