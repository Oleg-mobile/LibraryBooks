using LibraryBooks.Core.Models;
using LibraryBooks.Core.Repositories;
using LibraryBooks.Dto;
using LibraryBooks.Extentions;
using LibraryBooks.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace LibraryBooks.Forms
{
    public partial class FormBooks : FormLibrarryBooks
    {
        private readonly IRepository<Book, int> _bookRepository;
        private readonly IRepository<Genre, int> _genreRepository;
        private readonly IRepository<Author, int> _authorRepository;
        private readonly IRepository<User, int> _userRepository;
        private BindingList<BookDto> bindingList;

        public FormBooks()
        {
            InitializeComponent();

            _bookRepository = Resolve<IRepository<Book, int>>();
            _genreRepository = Resolve<IRepository<Genre, int>>();
            _authorRepository = Resolve<IRepository<Author, int>>();
            _userRepository = Resolve<IRepository<User, int>>();

            RefrashTable();
            InitDataGridViewColumns<BookDto>(dataGridViewBooks);
        }

        private void RefrashTable(BookFilterDto input = null)  // = null - not a prerequisite
        {
            var books = _bookRepository
            .GetAll()
            .Include(b => b.Genre)   //  Join
            .Include(b => b.Author)  //  Join
            .Include(b => b.User)    //  Join
            .WhereIf(!string.IsNullOrEmpty(input?.Keyword), b => b.Name.Contains(input.Keyword) || b.Genre.Name.Contains(input.Keyword) || b.Author.Name.Contains(input.Keyword))
            .WhereIf(input?.IsFinished != null, b => b.IsFinished == input.IsFinished)
            .WhereIf(input?.IsLiked != null, b => b.IsLiked == input.IsLiked)
            .AsNoTracking()
            .ToList();

            bindingList = new BindingList<BookDto>(Mapper.Map<IList<BookDto>>(books));  // mapping to DTO
            dataGridViewBooks.DataSource = bindingList;  // table filling
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var bookForm = new FormBook();
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

                if (bookForm.textBoxPathToBook.Text.Contains('"') || bookForm.textBoxPathToBook.Text.Contains('\''))
                {
                    throw new FormatException("Путь к книге не должен содержать ковычки!");
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

        private Book GetBook(FormBook bookForm, int year, int pageCount, int mark)
        {
            return new Book
            {
                Name = bookForm.textBoxName.Text,
                Publication = bookForm.textBoxPublication.Text,
                Year = year,
                PageCount = pageCount,
                Mark = mark,
                GenreId = _genreRepository.GetAll().First(g => g.Name == bookForm.comboBoxGenre.Text).Id,
                UserId = _userRepository.GetAll().First(u => u.Login == Session.CurrentUser.Login).Id,
                AuthorId = _authorRepository.GetAll().First(a => a.Name == bookForm.comboBoxAuthor.Text).Id,
                PathToBook = bookForm.textBoxPathToBook.Text,
                PathToCover = bookForm.textBoxPathToCover.Text,
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
            var books = new List<BookDto>();

            for (int i = 0; i < dataGridViewBooks.SelectedRows.Count; i++)
            {
                var book = (BookDto)dataGridViewBooks.SelectedRows[i].DataBoundItem;
                books.Add(book);
            }

            return Mapper.Map<IEnumerable<Book>>(books);
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewBooks.SelectedRows.Count > 0)
            {
                var bookDto = (BookDto)dataGridViewBooks.SelectedRows[0].DataBoundItem;
                var bookForm = new FormBook(bookDto);

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

                    if (bookForm.textBoxPathToBook.Text.Contains('"') || bookForm.textBoxPathToBook.Text.Contains('\''))
                    {
                        throw new FormatException("Путь к книге не должен содержать ковычки!");
                    }

                    var book = Mapper.Map<Book>(bookDto);
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

        private void EditBook(Book book, FormBook bookForm, int year, int pageCount, int mark)
        {
            book.Name = bookForm.textBoxName.Text;
            book.Publication = bookForm.textBoxPublication.Text;
            book.Year = year;
            book.PageCount = pageCount;
            book.Mark = mark;
            book.GenreId = _genreRepository.GetAll().First(g => g.Name == bookForm.comboBoxGenre.Text).Id;
            book.UserId = _userRepository.GetAll().First(u => u.Login == Session.CurrentUser.Login).Id;
            book.AuthorId = _authorRepository.GetAll().First(a => a.Name == bookForm.comboBoxAuthor.Text).Id;
            book.PathToBook = bookForm.textBoxPathToBook.Text;
            book.PathToCover = bookForm.textBoxPathToCover.Text;
            book.IsLiked = bookForm.checkBoxIsLiked.Checked;
            book.IsFinished = bookForm.checkBoxIsFinished.Checked;
        }

        private void buttonRead_Click(object sender, EventArgs e)
        {
            if (dataGridViewBooks.SelectedRows.Count > 0)
            {
                var book = (BookDto)dataGridViewBooks.SelectedRows[0].DataBoundItem;

                if (!File.Exists(book.PathToBook))
                {
                    MessageBoxExtention.WarningInput("Файл отсутствует!");
                    return;
                }

                var openBookProcess = new ProcessStartInfo($"C:\\Program Files\\Adobe\\Acrobat DC\\Acrobat\\Acrobat.exe", $@"/A page={book.Mark} ""{book.PathToBook}""");

                openBookProcess.WindowStyle = ProcessWindowStyle.Maximized;  // open full window
                Process.Start(openBookProcess);
            }
        }

        private void buttonBookInfo_Click(object sender, EventArgs e)
        {
            if (dataGridViewBooks.SelectedRows.Count > 0)
            {
                var bookDto = (BookDto)dataGridViewBooks.SelectedRows[0].DataBoundItem;

                new FormAboutBook(bookDto).Show();
            }
        }

        private void pictureBoxSearch_Click(object sender, EventArgs e)
        {
            var keyword = textBoxKeyword.Text.Trim();
            RefrashTable(new BookFilterDto
            {
                Keyword = keyword
            });
        }

        private void textBoxKeyword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                pictureBoxSearch_Click(sender, e);
            }
        }

        private void radioButtonClearFilter_Click(object sender, EventArgs e)
        {
            radioButtonIsFinished.Checked = false;
            radioButtonIsLiked.Checked = false;
            textBoxKeyword.Clear();

            RefrashTable();
        }

        private void radioButtonIsFinished_Click(object sender, EventArgs e)
        {
            RefrashTable(new BookFilterDto
            {
                IsFinished = radioButtonIsFinished.Checked
            });
        }

        private void radioButtonIsLiked_Click(object sender, EventArgs e)
        {
            RefrashTable(new BookFilterDto
            {
                IsLiked = radioButtonIsFinished.Checked
            });
        }
    }
}
