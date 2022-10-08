using AutoMapper;
using LibraryBooks.Core.Models;
using LibraryBooks.Core.Repositories;
using LibraryBooks.Dto.Authors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace LibraryBooks.Forms
{
    public partial class FormAuthors : LibrarryBooksForm
    {
        // LibraryBooksContext - database model
        // DataSource - data source binding (takes columns only of the entity to which it is attached)

        private readonly IRepository<Author, int> _authorRepository;  // Private - only in this class. Readonly - immutable database connection.

        public FormAuthors()
        {
            InitializeComponent(); // initializing all components

            _authorRepository = Resolve<IRepository<Author, int>>();
            var m = Resolve<IMapper>();
            //var b = m.Map<IEnumerable<AuthorDto>>(_authorRepository.GetAll().ToList());  // mapping an array of types AuthorDto

            RefrashTable();
            dataGridViewAuthors.Columns["Id"].Visible = false;
            dataGridViewAuthors.Columns["Name"].HeaderText = "Имя автора";
        }

        private void RefrashTable() => dataGridViewAuthors.DataSource = _authorRepository.GetAll().ToList();  

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var authForm = new AuthorForm();  // var - use when it is clear exactly what type of data
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
                _authorRepository.Delete(author);
            }

            RefrashTable();
        }

        private IEnumerable<Author> SelectedRowsMapToAuthors()
        {
            var authors = new List<Author>();  // to save references to objects (protection from the garbage collector)

            for (int i = 0; i < dataGridViewAuthors.SelectedRows.Count; i++)
            {
                var author = (Author)dataGridViewAuthors.SelectedRows[i].DataBoundItem;
                authors.Add(author);
            }

            return authors;
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewAuthors.SelectedRows.Count > 0)
            {
                var author = (Author)dataGridViewAuthors.SelectedRows[0].DataBoundItem;
                var authorForm = new AuthorForm(author);
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