﻿using LibraryBooks.Core;
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
    public partial class BookForm : Form
    {
        private readonly LibraryBooksContext _context;

        public BookForm()
        {
            InitializeComponent();
            AcceptButton = buttonSave;

            _context = new LibraryBooksContext();
            _context.Authors.Load();
            _context.Genres.Load();
            _context.Users.Load();

            comboBoxAuthor.DataSource = _context.Authors;
            comboBoxAuthor.DisplayMember = "Name";

            comboBoxGenre.DataSource = _context.Genres;
            comboBoxGenre.DisplayMember = "Name";

            comboBoxUser.DataSource = _context.Users;
            comboBoxUser.DisplayMember = "Login";
        }

        public BookForm(Book book) : this()
        {
            textBoxName.Text = book.Name;
            comboBoxAuthor.Text = book.Author.Name;
            textBoxPublication.Text = book.Publication;
            textBoxYear.Text = book.Year.ToString();
            textBoxPageCount.Text = book.PageCount.ToString();
            comboBoxGenre.Text = book.Genre.Name;
            comboBoxUser.Text = book.User.Login;
            textBoxPathToBook.Text = book.PathToBook;
            textBoxMark.Text = book.Mark.ToString();
            checkBoxIsLiked.Checked = book.IsLiked;
            checkBoxIsFinished.Checked = book.IsFinished;
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            Close();
            DialogResult = DialogResult.OK;
        }

        private void textBoxIntegerMask_KeyPress(object sender, KeyPressEventArgs e)
        {
            char input = e.KeyChar;
            if (!char.IsDigit(input))
            {
                e.Handled = true;
            }
        }
    }
}
