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

namespace LibraryBooks.Forms
{
    public partial class FormAuthors : Form
    {
        private readonly LibraryBooksContext _context;  // Database model. Private - only in this class. Readonly - immutable database connection.

        public FormAuthors()
        {
            InitializeComponent(); // initializing all components

            _context = new LibraryBooksContext();
            _context.Authors.Load(); // loading data from a table into a variable (Entity Framework)

            dataGridViewAuthors.DataSource = _context.Authors.Local.ToBindingList();
            dataGridViewAuthors.Columns["Id"].DisplayIndex = 0;
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
                _context.SaveChanges();
            }
        }

        private IEnumerable<Author> SelectedRowsMapToAuthors()
        {
            var authors = new List<Author>();

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
