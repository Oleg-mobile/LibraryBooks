using LibraryBooks.Core;
using LibraryBooks.Core.Models;
using LibraryBooks.Extentions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows.Forms;

namespace LibraryBooks.Forms
{
    public partial class RegistrationForm : Form
    {
        private readonly LibraryBooksContext _context;

        public RegistrationForm()
        {
            InitializeComponent();
            ActiveControl = textBoxName;
            AcceptButton = buttonAdd;

            _context = new LibraryBooksContext();
            _context.Users.Load();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string login = textBoxName.Text;
            string password = textBoxPassword.Text;

            // TODO вынести валидацию в класс вадидатор

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

            if (textBoxPassword.Text != textBoxPasswordRepeat.Text)
            {
                MessageBoxExtention.ErrorInput("Пароли не совпадают");
                ResetPassword();
                return;
            }

            var user = _context.Users.FirstOrDefault(u => u.Login == login);
            if (user is not null)
            {
                MessageBoxExtention.ErrorInput("Существующий пользователь");
                ResetForm();
                return;
            }

            // TODO вынести в репозиторий

            _context.Users.Add(new User { Login = login, Password = password});
            _context.SaveChanges();

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
    }
}
