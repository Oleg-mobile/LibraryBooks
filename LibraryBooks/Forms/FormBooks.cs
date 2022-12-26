using FluentValidation;
using LibraryBooks.Core.Extentions;
using LibraryBooks.Core.Models;
using LibraryBooks.Core.Repositories;
using LibraryBooks.Dto;
using LibraryBooks.Extentions;
using LibraryBooks.Utils;
using Microsoft.EntityFrameworkCore;
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
        private readonly IRepository<Reader, int> _readerRepository;
        private BindingList<BookDto> bindingList;

        public FormBooks()
        {
            InitializeComponent();

            _bookRepository = Resolve<IRepository<Book, int>>();
            _genreRepository = Resolve<IRepository<Genre, int>>();
            _authorRepository = Resolve<IRepository<Author, int>>();
            _userRepository = Resolve<IRepository<User, int>>();
            _readerRepository = Resolve<IRepository<Reader, int>>();

            RefrashTable();
            InitDataGridViewColumns<BookDto>(dataGridViewBooks);
        }

        private void RefrashTable(BookFilterDto input = null)  // = null - not a prerequisite
        {
            // only what needs to be displayed in the table
            var books = _bookRepository
            .GetAll()
            .Include(b => b.Genre)   //  Join
            .Include(b => b.Author)  //  Join
            .Include(b => b.Reader)  //  Join
            .Where(b => b.UserId == Session.CurrentUser.Id)  //  Where - weed out something. Binding to user
            .WhereIf(!string.IsNullOrEmpty(input?.Keyword), b => b.Name.Contains(input.Keyword) || b.Genre.Name.Contains(input.Keyword) || b.Author.Name.Contains(input.Keyword))
            .WhereIf(input?.IsFinished != null, b => b.IsFinished == input.IsFinished)
            .WhereIf(input?.IsLiked != null, b => b.IsLiked == input.IsLiked)
            .AsNoTracking()
            .ToList();

            bindingList = new BindingList<BookDto>(Mapper.Map<IList<BookDto>>(books));  // mapping to DTO
            // INFO: Преобразование значения в таблице делается в DTO или в профиле маппера (в нашем случае)
            dataGridViewBooks.DataSource = bindingList;  // table filling
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var bookForm = new FormBook();
            DialogResult result = bookForm.ShowDialog();

            if (result == DialogResult.Cancel)
            {
                return;
            }

            Book book = GetBook(bookForm);
            _bookRepository.Insert(book);

            RefrashTable();
        }

        private Book GetBook(FormBook bookForm)
        {
            string mark = bookForm.textBoxMark.Text;

            return new Book
            {
                Name = bookForm.textBoxName.Text,
                Publication = bookForm.textBoxPublication.Text,
                Year = bookForm.textBoxYear.Text.ToInt(),  // int checked during validation, on line 72, so we parse without checks
                PageCount = bookForm.textBoxPageCount.Text.ToInt(),
                // INFO: Проверка на null:
                // ?. - если объект не равен null, то обращаемся к компоненту объекта после ".", иначе - не обращаемся
                // ?? - если операнд слева не равен null, то возвращает операнд слева, иначе - справа
                Mark = mark != "" ? mark.ToInt() : 1,
                GenreId = _genreRepository.GetAll().First(g => g.Name == bookForm.comboBoxGenre.Text).Id,
                UserId = _userRepository.GetAll().First(u => u.Login == Session.CurrentUser.Login).Id,
                AuthorId = _authorRepository.GetAll().First(a => a.Name == bookForm.comboBoxAuthor.Text).Id,
                PathToBook = bookForm.textBoxPathToBook.Text,
                PathToCover = bookForm.textBoxPathToCover.Text,
                IsLiked = bookForm.checkBoxIsLiked.Checked,
                IsFinished = bookForm.checkBoxIsFinished.Checked,
                ReaderId = _readerRepository.GetAll().First(r => r.Name == bookForm.comboBoxReader.Text).Id
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

                DialogResult result = bookForm.ShowDialog();

                if (result == DialogResult.Cancel)
                {
                    return;
                }

                var book = Mapper.Map<Book>(bookDto);
                EditBook(book, bookForm);
                _bookRepository.Update(book);

                RefrashTable();
            }
        }

        private void EditBook(Book book, FormBook bookForm)
        {
            book.Name = bookForm.textBoxName.Text;
            book.Publication = bookForm.textBoxPublication.Text;
            book.Year = bookForm.textBoxYear.Text.ToInt();
            book.PageCount = bookForm.textBoxPageCount.Text.ToInt();
            book.Mark = bookForm.textBoxMark.Text?.ToInt() ?? 1;
            book.GenreId = _genreRepository.GetAll().First(g => g.Name == bookForm.comboBoxGenre.Text).Id;
            book.UserId = _userRepository.GetAll().First(u => u.Login == Session.CurrentUser.Login).Id;
            book.AuthorId = _authorRepository.GetAll().First(a => a.Name == bookForm.comboBoxAuthor.Text).Id;
            book.PathToBook = bookForm.textBoxPathToBook.Text;
            book.PathToCover = bookForm.textBoxPathToCover.Text;
            book.IsLiked = bookForm.checkBoxIsLiked.Checked;
            book.IsFinished = bookForm.checkBoxIsFinished.Checked;
            book.ReaderId = _readerRepository.GetAll().First(r => r.Name == bookForm.comboBoxReader.Text).Id;  // TODO ошибка при удалении читалки с формы книги
        }

        private void buttonRead_Click(object sender, EventArgs e)
        {
            if (dataGridViewBooks.SelectedRows.Count > 0)
            {
                var book = (BookDto)dataGridViewBooks.SelectedRows[0].DataBoundItem;

                if (!File.Exists(book.PathToBook))
                {
                    Notification.ShowWarning("Файл отсутствует!");
                    return;
                }

                if (book.ReaderName is null)
                {
                    Notification.ShowWarning("Читалка не задана!");
                    return;
                }

                var reader = _readerRepository.GetAll().First(r => r.Name == book.ReaderName);

                string format = reader.OpeningFormat.Replace("{page}", book.Mark.ToString()).Replace("{path}", book.PathToBook);
                var openBookProcess = new ProcessStartInfo(reader.PathToReader, format);
                openBookProcess.WindowStyle = ProcessWindowStyle.Maximized;  // open full window
                Process.Start(openBookProcess);
            }
        }

        private void buttonBookInfo_Click(object sender, EventArgs e)
        {
            if (dataGridViewBooks.SelectedRows.Count > 0)
            {
                var bookDto = (BookDto)dataGridViewBooks.SelectedRows[0].DataBoundItem;
                new FormAboutBook(bookDto).ShowDialog();
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
                IsLiked = radioButtonIsLiked.Checked
            });
        }
    }
}
