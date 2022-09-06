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
            dataGridViewBooks.Columns["Id"].DisplayIndex = 0;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var bookForm = new BookForm();
            DialogResult result = bookForm.ShowDialog();

            if (result == DialogResult.Cancel)
            {
                return;
            }

            var book = new Book();
            book.Name = bookForm.textBoxName.Text;
            book.Publication = bookForm.textBoxPublication.Text;

            // TODO try catch? nullable?

            //if (!Int32.TryParse(bookForm.textBoxYear.Text, out int year))
            //{
            //    //throw new InvalidOperationException("Не верный формат года");
            //    throw new FormatException("Не верный формат года");
            //}
            //book.Year = year;

            try
            {
                book.Year = Int32.Parse(bookForm.textBoxYear.Text);
            }
            catch (FormatException )
            {
                MessageBox.Show("Не верный формат года");
            }

            try
            {
                book.PageCount = Int32.Parse(bookForm.textBoxPageCount.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Не верный формат количества страниц");
            }

            try
            {
                book.Mark = Int32.Parse(bookForm.textBoxMark.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Не верный формат закладки");
            }

            // TODO нагородил
            book.Genre = _context.Genres.FirstOrDefault(g => g.Name.Equals(bookForm.comboBoxGenre.Text));  // FirstOrDefault - т.к. список может быть пуст
            book.User = _context.Users.FirstOrDefault(u => u.Login.Equals(bookForm.comboBoxUser.Text));
            book.Author = _context.Authors.FirstOrDefault(a => a.Name.Equals(bookForm.comboBoxAuthor.Text));
            book.PathToBook = bookForm.textBoxPathToBook.Text;
            book.IsLiked = bookForm.checkBoxIsLiked.Checked;
            book.IsFinished = bookForm.checkBoxIsFinished.Checked;

            _context.Books.Add(book);
            // TODO ошибка если нет жанров
            _context.SaveChanges();
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            var books = SelectedRowsMapToBooks();

            foreach (var book in books)
            {
                _context.Remove(book);
                _context.SaveChanges();
            }
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
                var book = (Book)dataGridViewBooks.SelectedRows [0].DataBoundItem;
                var bookForm = new BookForm(book);
                DialogResult result = bookForm.ShowDialog();

                if (result == DialogResult.Cancel)
                {
                    return;
                }

                book.Name = bookForm.textBoxName.Text;
                book.Publication = bookForm.textBoxPublication.Text;
                book.Year = Int32.Parse(bookForm.textBoxYear.Text);
                book.PageCount = Int32.Parse(bookForm.textBoxPageCount.Text);
                book.Mark = Int32.Parse(bookForm.textBoxMark.Text);
                book.Genre = _context.Genres.First(g => g.Name.Equals(bookForm.comboBoxGenre.Text));
                book.User = _context.Users.First(u => u.Login.Equals(bookForm.comboBoxUser.Text));
                book.Author = _context.Authors.First(a => a.Name.Equals(bookForm.comboBoxAuthor.Text));
                book.PathToBook = bookForm.textBoxPathToBook.Text;
                book.IsLiked = bookForm.checkBoxIsLiked.Checked;
                book.IsFinished = bookForm.checkBoxIsFinished.Checked;

                _context.SaveChanges();
                dataGridViewBooks.Refresh();
            }
        }
    }
}
