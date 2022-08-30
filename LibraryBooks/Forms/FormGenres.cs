using LibraryBooks.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryBooks.Forms
{
    public partial class FormGenres : Form
    {
        private readonly LibraryBooksContext _context;

        public FormGenres()
        {
            InitializeComponent();

            _context = new LibraryBooksContext();
            _context.Genres.Load();

            dataGridViewGenres.DataSource = _context.Genres.Local.ToBindingList();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {

        }
    }
}
