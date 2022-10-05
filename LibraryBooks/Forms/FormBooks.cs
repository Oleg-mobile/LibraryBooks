using LibraryBooks.Core;
using LibraryBooks.Core.Models;
using LibraryBooks.Core.Repositories;
using LibraryBooks.Extentions;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LibraryBooks.Forms
{
    public partial class FormBooks : LibrarryBooksForm
    {
        private readonly IRepository<Book, int> _bookRepository;
        private readonly IRepository<Genre, int> _genreRepository;
        private readonly IRepository<Author, int> _authorRepository;
        private readonly IRepository<Core.Models.User, int> _userRepository;

        public FormBooks()
        {
            InitializeComponent();

            _bookRepository = Resolve<IRepository<Book, int>>();
            _genreRepository = Resolve<IRepository<Genre, int>>();
            _authorRepository = Resolve<IRepository<Author, int>>();
            _userRepository = Resolve<IRepository<Core.Models.User, int>>();

            RefrashTable();
            // TODO ограничение отображения колонок
            dataGridViewBooks.Columns["Id"].Visible = false;
            dataGridViewBooks.Columns["UserId"].Visible = false;
            dataGridViewBooks.Columns["GenreId"].Visible = false;
            dataGridViewBooks.Columns["IsLiked"].Visible = false;
            dataGridViewBooks.Columns["IsFinished"].Visible = false;
        }

        private void RefrashTable() => dataGridViewBooks.DataSource = _bookRepository
            .GetAll()
            .Include(b => b.Genre)
            .Include(b => b.Author)
            .Include(b => b.User)
            .ToList();

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var bookForm = new BookForm();
            // a label so that the window does not close when an exception occurs
            lableShow:
            DialogResult result = bookForm.ShowDialog();

            if (result == DialogResult.Cancel)
            {
                return;
            }

            try
            {
                // TODO вынести в валидатор
                if (!int.TryParse(bookForm.textBoxYear.Text, out int year))
                {
                    throw new FormatException("Не верный формат года");
                }

                if (!int.TryParse(bookForm.textBoxPageCount.Text, out int pageCount))
                {
                    throw new FormatException("Не верный формат количества страниц");
                }

                if (!int.TryParse(bookForm.textBoxMark.Text, out int mark))
                {
                    throw new FormatException("Не верный формат закладки");
                }

                if (bookForm.comboBoxGenre.SelectedItem is null)
                {
                    throw new FormatException("Жанр не выбран");
                }

                if (bookForm.comboBoxAuthor.SelectedItem is null)
                {
                    throw new FormatException("Автор не выбран");
                }

                Book book = GetBook(bookForm, year, pageCount, mark);
                _bookRepository.Insert(book);

                RefrashTable();
            }
            catch (FormatException ex)
            {
                MessageBoxExtention.WarningInput(ex.Message);
                goto lableShow;
            }
        }

        private Book GetBook(BookForm bookForm, int year, int pageCount, int mark)
        {
            return new Book
            {
                Name = bookForm.textBoxName.Text,
                Publication = bookForm.textBoxPublication.Text,
                Year = year,
                PageCount = pageCount,
                Mark = mark,
                GenreId = _genreRepository.GetAll().First(g => g.Name == bookForm.comboBoxGenre.Text).Id,
                UserId = _userRepository.GetAll().First(u => u.Login == Program.AuthForm.textBoxLogin.Text).Id,
                AuthorId = _authorRepository.GetAll().First(a => a.Name == bookForm.comboBoxAuthor.Text).Id,
                PathToBook = bookForm.textBoxPathToBook.Text,
                IsLiked = bookForm.checkBoxIsLiked.Checked,
                IsFinished = bookForm.checkBoxIsFinished.Checked
            };
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            var books = SelectedRowsMapToBooks();

            foreach (var book in books)
            {
                _bookRepository.Delete(book);
            }

            RefrashTable();
        }

        private IEnumerable<Book> SelectedRowsMapToBooks()
        {
            var books = new List<Book>();

            for (int i = 0; i < dataGridViewBooks.SelectedRows.Count; i++)
            {
                var book = (Book)dataGridViewBooks.SelectedRows[i].DataBoundItem;
                books.Add(book);
            }

            return books;
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewBooks.SelectedRows.Count > 0)
            {
                var book = (Book)dataGridViewBooks.SelectedRows[0].DataBoundItem;
                var bookForm = new BookForm(book);
                lableShow:

                DialogResult result = bookForm.ShowDialog();

                if (result == DialogResult.Cancel)
                {
                    return;
                }

                try
                {
                    // TODO вынести в валидатор
                    if (!int.TryParse(bookForm.textBoxYear.Text, out int year))
                    {
                        throw new FormatException("Не верный формат года");
                    }

                    if (!int.TryParse(bookForm.textBoxPageCount.Text, out int pageCount))
                    {
                        throw new FormatException("Не верный формат количества страниц");
                    }

                    if (!int.TryParse(bookForm.textBoxMark.Text, out int mark))
                    {
                        throw new FormatException("Не верный формат закладки");
                    }

                    if (bookForm.comboBoxGenre.SelectedItem is null)
                    {
                        throw new FormatException("Жанр не выбран");
                    }

                    if (bookForm.comboBoxAuthor.SelectedItem is null)
                    {
                        throw new FormatException("Автор не выбран");
                    }

                    EditBook(book, bookForm, year, pageCount, mark);
                    _bookRepository.Update(book);

                    RefrashTable();
                }
                catch (FormatException ex)
                {
                    MessageBoxExtention.WarningInput(ex.Message);
                    goto lableShow;
                }
            }
        }

        private void EditBook(Book book, BookForm bookForm, int year, int pageCount, int mark)
        {
            book.Name = bookForm.textBoxName.Text;
            book.Publication = bookForm.textBoxPublication.Text;
            book.Year = year;
            book.PageCount = pageCount;
            book.Mark = mark;
            book.GenreId = _genreRepository.GetAll().First(g => g.Name == bookForm.comboBoxGenre.Text).Id;
            book.UserId = _userRepository.GetAll().First(u => u.Login == Program.AuthForm.textBoxLogin.Text).Id;
            book.AuthorId = _authorRepository.GetAll().First(a => a.Name == bookForm.comboBoxAuthor.Text).Id;
            book.PathToBook = bookForm.textBoxPathToBook.Text;
            book.IsLiked = bookForm.checkBoxIsLiked.Checked;
            book.IsFinished = bookForm.checkBoxIsFinished.Checked;
        }
    }
}
