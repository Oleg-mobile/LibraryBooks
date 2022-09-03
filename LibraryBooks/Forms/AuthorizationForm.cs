using LibraryBooks.Core;
using LibraryBooks.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryBooks.Forms
{
    public partial class AuthorizationForm : Form
    {
        private readonly LibraryBooksContext _context;

        public AuthorizationForm()
        {
            InitializeComponent();
            ActiveControl = textBoxLogin;
            AcceptButton = buttonLogin;

            _context = new LibraryBooksContext();
            _context.Users.Load();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            bool IsRegOk = false;
            var users = new List<User>();
            _context.Users.Local.ToList().ForEach(u => users.Add(u));

            foreach (var user in users)
            {
                if (user.Login.Equals(textBoxLogin.Text) && user.Password.Equals(textBoxPassword.Text))
                {
                    IsRegOk = true;
                    var formMain = new FormMain();
                    formMain.Show();
                    Hide();
                    break;
                }
            }

            if (IsRegOk == false)
            {
                DialogResult result = MessageBox.Show(
                    "Не верный логин или пароль",
                    "Ошибка авторизации!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error

                    );
            }
        }

        private void AuthorizationForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void buttonRegistration_Click(object sender, EventArgs e)
        {
            var regForm = new RegistrationForm();
            regForm.Show();
            Hide();
        }
    }
}
