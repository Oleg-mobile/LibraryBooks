using LibraryBooks.Core;
using LibraryBooks.Core.Models;
using LibraryBooks.Extentions;
using Microsoft.EntityFrameworkCore;
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
    public partial class FormBooks : Form
    {
        private readonly LibraryBooksContext _context;

        public FormBooks()
        {
            InitializeComponent();

            _context = new LibraryBooksContext();
            _context.Books.Load();
            _context.Genres.Load();
            _context.Authors.Load();
            _context.Users.Load();

            dataGridViewBooks.DataSource = _context.Books.Local.ToBindingList();
            // TODO ограничение отображения колонок
            dataGridViewBooks.Columns["Id"].Visible = false;
            dataGridViewBooks.Columns["UserId"].Visible = false;
            dataGridViewBooks.Columns["GenreId"].Visible = false;
            dataGridViewBooks.Columns["IsLiked"].Visible = false;
            dataGridViewBooks.Columns["IsFinished"].Visible = false;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var bookForm = new BookForm();
            lableShow:
            DialogResult result = bookForm.ShowDialog();

            if (result == DialogResult.Cancel)
            {
                return;
            }

            try
            {
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

                var book = new Book {
                    Name = bookForm.textBoxName.Text,
                    Publication = bookForm.textBoxPublication.Text,
                    Year = year,
                    PageCount = pageCount,
                    Mark = mark,

                    // TODO отображать не класс, а имя (Переопределить ToString?)
                    Genre = _context.Genres.First(g => g.Name == bookForm.comboBoxGenre.Text),
                    User = _context.Users.First(u => u.Login == bookForm.comboBoxUser.Text),
                    //User = _context.Users.First(u => u.Login == authorizeForm.textBoxLogin.Text),
                    Author = _context.Authors.First(a => a.Name == bookForm.comboBoxAuthor.Text),
                    PathToBook = bookForm.textBoxPathToBook.Text,
                    IsLiked = bookForm.checkBoxIsLiked.Checked,
                    IsFinished = bookForm.checkBoxIsFinished.Checked
                };

                _context.Books.Add(book);
                _context.SaveChanges();
            }
            catch (FormatException ex)
            {
                MessageBoxExtention.WarningInput(ex.Message);
                goto lableShow;
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            var books = SelectedRowsMapToBooks();

            foreach (var book in books)
            {
                _context.Remove(book);
            }

            _context.SaveChanges();
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

                // TODO ошибка при редактировании книги
                DialogResult result = bookForm.ShowDialog();

                if (result == DialogResult.Cancel)
                {
                    return;
                }

                try
                {
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

                    book.Name = bookForm.textBoxName.Text;
                    book.Publication = bookForm.textBoxPublication.Text;
                    book.Year = year;
                    book.PageCount = pageCount;
                    book.Mark = mark;

                    // TODO отображать не класс, а имя
                    book.Genre = _context.Genres.First(g => g.Name == bookForm.comboBoxGenre.Text);
                    book.User = _context.Users.First(u => u.Login == bookForm.comboBoxUser.Text);
                    book.Author = _context.Authors.First(a => a.Name == bookForm.comboBoxAuthor.Text);
                    book.PathToBook = bookForm.textBoxPathToBook.Text;
                    book.IsLiked = bookForm.checkBoxIsLiked.Checked;
                    book.IsFinished = bookForm.checkBoxIsFinished.Checked;

                    _context.SaveChanges();
                    dataGridViewBooks.Refresh();
                }
                catch (FormatException ex)
                {
                    MessageBoxExtention.WarningInput(ex.Message);
                    goto lableShow;
                }
            }
        }
    }
}
