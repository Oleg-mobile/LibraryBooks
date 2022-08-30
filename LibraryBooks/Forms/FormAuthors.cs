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

namespace LibraryBooks.Forms
{
    public partial class FormAuthors : Form
    {
        private readonly LibraryBooksContext _context;

        public FormAuthors()
        {
            InitializeComponent();

            _context = new LibraryBooksContext();
            _context.Authors.Load();

            dataGridViewAuthors.DataSource = _context.Authors.Local.ToBindingList();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var authForm = new AuthorForm();
            DialogResult result = authForm.ShowDialog();

            if (result == DialogResult.Cancel)
            {
                return;
            }


            var author = new Author();
            author.Name = authForm.textBoxName.Text;

            _context.Authors.Add(author);
            _context.SaveChanges();
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridViewAuthors.SelectedRows.Count; i++)
            {
                var author = (Author)dataGridViewAuthors.SelectedRows[i].DataBoundItem;
                _context.Remove(author);
                _context.SaveChanges();
            }
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
