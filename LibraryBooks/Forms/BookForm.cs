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
    public partial class BookForm : Form
    {
        private readonly LibraryBooksContext _context;

        public BookForm()
        {
            InitializeComponent();
            AcceptButton = buttonSave;

            // TODO разобраться с ComboBox
            _context = new LibraryBooksContext();
            _context.Authors.Load();
            _context.Genres.Load();
            _context.Users.Load();

            var authors = new List<Author>();
            var users = new List<User>();
            var genres = new List<Genre>();

            _context.Authors.Local.ToList().ForEach(a => authors.Add(a));
            comboBoxAuthor.DataSource = authors;
            comboBoxAuthor.DisplayMember = "Name";
            comboBoxAuthor.SelectedIndex = 0;

            _context.Genres.Local.ToList().ForEach(g => genres.Add(g));
            comboBoxGenre.DataSource = genres;
            comboBoxGenre.DisplayMember = "Name";
            comboBoxGenre.SelectedIndex = 0;

            _context.Users.Local.ToList().ForEach(u => users.Add(u));
            comboBoxUser.DataSource = users;
            comboBoxUser.DisplayMember = "Login";
            comboBoxUser.SelectedIndex = 0;
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
    }
}
