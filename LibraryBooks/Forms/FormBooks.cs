﻿using LibraryBooks.Core;
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
    public partial class FormBooks : Form
    {
        private readonly LibraryBooksContext _context;

        public FormBooks()
        {
            InitializeComponent();

            _context = new LibraryBooksContext();
            _context.Books.Load();

            dataGridViewBooks.DataSource = _context.Books.Local.ToBindingList();
            dataGridViewBooks.Columns["Id"].DisplayIndex = 0;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            //
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            //
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            //
        }
    }
}
