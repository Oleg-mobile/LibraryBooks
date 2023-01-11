using Castle.Core.Internal;
using LibraryBooks.Core.Models;
using LibraryBooks.Core.Repositories;
using LibraryBooks.Dto;
using LibraryBooks.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace LibraryBooks.Forms
{
    public partial class FormAuthors : FormLibrarryBooks
    {
        private readonly IRepository<Author, int> _authorRepository;
        private readonly IRepository<Book, int> _bookRepository;
        private readonly string _formName;
        private BindingList<AuthorDto> bindingList;

        public FormAuthors()
        {
            InitializeComponent();

            _authorRepository = Resolve<IRepository<Author, int>>();
            _bookRepository = Resolve<IRepository<Book, int>>();
            _formName = nameof(FormAuthors) + " ";

            RefrashTable();
            InitDataGridViewColumns<AuthorDto>(dataGridViewAuthors);
        }

        private void RefrashTable()
        {
            var authors = _authorRepository.GetAll().AsNoTracking().ToList();
            bindingList = new BindingList<AuthorDto>(Mapper.Map<IList<AuthorDto>>(authors));
            dataGridViewAuthors.DataSource = bindingList;  // DataSource - привязка источника данных (принимает столбцы только той сущности, к которой она прикреплена)
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            CallWithLoggerInterceptor(() =>
            {
                var authForm = new FormAuthor();
                DialogResult result = authForm.ShowDialog();

                if (result == DialogResult.Cancel)
                {
                    return;
                }

                var author = new Author(authForm.textBoxName.Text);
                _authorRepository.Insert(author);

                RefrashTable();

            }, _formName + nameof(buttonAdd_Click));
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            CallWithLoggerInterceptor(() =>
            {
                var authors = SelectedRowsMapToAuthors();

                foreach (var author in authors)
                {
                    var books = _bookRepository.GetAll().AsNoTracking().Where(b => b.Author.Id == author.Id).ToList();
                    if (!books.IsNullOrEmpty())
                    {
                        Notification.ShowWarning("Автор используется!");
                        return;
                    }

                    _authorRepository.Delete(author);
                }

                RefrashTable();

            }, _formName + nameof(buttonDel_Click));
        }

        private IEnumerable<Author> SelectedRowsMapToAuthors()
        {
            var authors = new List<AuthorDto>();  // Сохранить ссылки на объекты (защита от сборщика мусора)

            for (int i = 0; i < dataGridViewAuthors.SelectedRows.Count; i++)
            {
                var author = (AuthorDto)dataGridViewAuthors.SelectedRows[i].DataBoundItem;
                authors.Add(author);
            }

            return Mapper.Map<IEnumerable<Author>>(authors);
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            CallWithLoggerInterceptor(() =>
            {
                if (dataGridViewAuthors.SelectedRows.Count > 0)
                {
                    var authorDto = (AuthorDto)dataGridViewAuthors.SelectedRows[0].DataBoundItem;
                    var author = Mapper.Map<Author>(authorDto);  // <type - во что>(object - кого)
                    var authorForm = new FormAuthor(author);
                    DialogResult dialogResult = authorForm.ShowDialog();

                    if (dialogResult == DialogResult.Cancel)
                    {
                        return;
                    }

                    author.Name = authorForm.textBoxName.Text;
                    _authorRepository.Update(author);

                    RefrashTable();
                }
            }, _formName + nameof(buttonEdit_Click));
        }
    }
}