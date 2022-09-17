using LibraryBooks.Core;
using LibraryBooks.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using LibraryBooks.Core.Repositories;
using LibraryBooks.Core.Repositories.EntityFrameworkCore;

namespace LibraryBooks.Forms
{
    public partial class FormAuthors : Form
    {
        private readonly LibraryBooksContext _context;  // Database model. Private - only in this class. Readonly - immutable database connection.
        private readonly IRepository<Author, int> _authorRepository;

        public FormAuthors()
        {
            InitializeComponent(); // initializing all components

            _context = new LibraryBooksContext();
            _authorRepository = new EfCoreRepositoryBase<LibraryBooksContext, Author>(_context);
            var a = _authorRepository.GetAll().ToList();

            _context.Authors.Load(); // loading data from a table into a variable (Entity Framework)

            dataGridViewAuthors.DataSource = _context.Authors.Local.ToBindingList();
            dataGridViewAuthors.Columns["Id"].Visible = false;
            dataGridViewAuthors.Columns["Name"].HeaderText = "Имя автора";
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var authForm = new AuthorForm();  // var - use when it is clear exactly what type of data
            DialogResult result = authForm.ShowDialog();

            if (result == DialogResult.Cancel)
            {
                return;
            }

            var author = new Author(authForm.textBoxName.Text);

            _context.Authors.Add(author);
            _context.SaveChanges();
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            var authors = SelectedRowsMapToAuthors();

            foreach (var author in authors)
            {
                _context.Remove(author);
            }

            _context.SaveChanges();
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
                _context.SaveChanges();
                dataGridViewAuthors.Refresh();
            }
        }
    }
}
