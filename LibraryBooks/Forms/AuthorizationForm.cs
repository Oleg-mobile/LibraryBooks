﻿using LibraryBooks.Core;
using LibraryBooks.Extentions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
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

            pictureBoxClose.Visible = true;
            pictureBoxOpen.Visible = false;

            _context = new LibraryBooksContext();
            _context.Users.Load();
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

            var user = _context.Users.FirstOrDefault(u => u.Login == login && u.Password == password);
            if (user is null)
            {
                MessageBoxExtention.Error("Не верный логин или пароль", "Ошибка авторизации!");
                return;
            }

            new FormMain().Show();
            Hide();
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

        // TODO скрыть пароль
        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            textBoxPassword.UseSystemPasswordChar = false;
            pictureBoxOpen.Visible = true;
            pictureBoxClose.Visible = false;
        }

        private void pictureBoxOpen_Click(object sender, EventArgs e)
        {
            textBoxPassword.UseSystemPasswordChar = true;
            pictureBoxOpen.Visible = false;
            pictureBoxClose.Visible = true;
        }
    }
}