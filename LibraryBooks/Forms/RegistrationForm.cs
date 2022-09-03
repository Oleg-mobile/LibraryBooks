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
            bool IsRegOk = true;
            var users = new List<User>();
            var user = new User();
            _context.Users.Local.ToList().ForEach(u => users.Add(u));

            if (textBoxName.Text != "")
            {
                if (textBoxPassword.Text != "")
                {
                    if (textBoxPassword.Text.Equals(textBoxPasswordRepeat.Text))
                    {
                        foreach (var usr in users)
                        {
                            if (textBoxName.Text.Equals(usr.Login))
                            {
                                DialogResult = MessageBox.Show(
                                    "Существующий пользователь",
                                    "Ошибка ввода",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error
                                    );

                                textBoxName.Text = "";
                                textBoxPassword.Text = "";
                                textBoxPasswordRepeat.Text = "";
                                IsRegOk = false;

                                break;
                            }
                        }

                        if (IsRegOk)
                        {
                            MessageBox.Show("Пользователь добавлен");

                            user.Login = textBoxName.Text;
                            user.Password = textBoxPassword.Text;

                            _context.Users.Add(user);
                            _context.SaveChanges();

                            var authorizeForm = new AuthorizationForm();
                            authorizeForm.Show();
                            authorizeForm.textBoxLogin.Text = this.textBoxName.Text;

                            Close();
                        }
                    }
                    else
                    {
                        DialogResult = MessageBox.Show(
                            "Пароли не совпадают",
                            "Ошибка ввода",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                            );

                        textBoxPassword.Text = "";
                        textBoxPasswordRepeat.Text = "";
                    }
                }
                else
                {
                    DialogResult = MessageBox.Show(
                        "Введите пароль",
                        "Ошибка ввода",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                        );
                }
            }
            else
            {
                DialogResult = MessageBox.Show(
                    "Введите логин",
                    "Ошибка ввода",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
            }
        }
    }
}
