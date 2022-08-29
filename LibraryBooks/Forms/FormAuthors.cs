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



        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AuthorForm authForm = new AuthorForm();
            DialogResult result = authForm.ShowDialog();
            
            if (result == DialogResult.Cancel)
                return;

            Author author = new Author();
            author.Name = authForm.textBoxName.Text;

            _context.Authors.Add(author);
            _context.SaveChanges();
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridViewAuthors.SelectedRows.Count; i++)
            {
                Author author = (Author)dataGridViewAuthors.SelectedRows[i].DataBoundItem;
                _context.Remove(author);
            }
        }
    }
}
