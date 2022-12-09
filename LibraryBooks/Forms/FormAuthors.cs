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
        // LibraryBooksContext - database model
        // DataSource - data source binding (takes columns only of the entity to which it is attached)

        private readonly IRepository<Author, int> _authorRepository;  // Private - only in this class. Readonly - immutable database connection.
        private readonly IRepository<Book, int> _bookRepository;
        private BindingList<AuthorDto> bindingList;

        public FormAuthors()
        {
            InitializeComponent(); // initializing all components

            _authorRepository = Resolve<IRepository<Author, int>>();
            _bookRepository = Resolve<IRepository<Book, int>>();

            RefrashTable();
            InitDataGridViewColumns<AuthorDto>(dataGridViewAuthors);
        }

        private void RefrashTable()
        {
            var authors = _authorRepository.GetAll().AsNoTracking().ToList();
            bindingList = new BindingList<AuthorDto>(Mapper.Map<IList<AuthorDto>>(authors));
            dataGridViewAuthors.DataSource = bindingList;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var authForm = new FormAuthor();  // var - use when it is clear exactly what type of data
            DialogResult result = authForm.ShowDialog();

            if (result == DialogResult.Cancel)
            {
                return;
            }

            var author = new Author(authForm.textBoxName.Text);
            _authorRepository.Insert(author);

            RefrashTable();
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            var authors = SelectedRowsMapToAuthors();

            foreach (var author in authors)
            {
                // TODO проверка при удалении автора
                // Здесь же без привязки к юзеру?
                var books = _bookRepository.GetAll().AsNoTracking().Where(b => b.Author.Id == author.Id).ToList();
                if (!books.IsNullOrEmpty())
                {
                    Notification.ShowWarning("Автор используется!");
                    return;
                }

                _authorRepository.Delete(author);
            }

            RefrashTable();
        }

        private IEnumerable<Author> SelectedRowsMapToAuthors()
        {
            var authors = new List<AuthorDto>();  // to save references to objects (protection from the garbage collector)

            for (int i = 0; i < dataGridViewAuthors.SelectedRows.Count; i++)
            {
                var author = (AuthorDto)dataGridViewAuthors.SelectedRows[i].DataBoundItem;
                authors.Add(author);
            }

            return Mapper.Map<IEnumerable<Author>>(authors);
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewAuthors.SelectedRows.Count > 0)
            {
                var authorDto = (AuthorDto)dataGridViewAuthors.SelectedRows[0].DataBoundItem;
                var author = Mapper.Map<Author>(authorDto);  // <type - what>(object - Of what)
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
        }
    }
}