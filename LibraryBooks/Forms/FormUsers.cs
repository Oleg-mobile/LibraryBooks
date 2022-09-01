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
    public partial class FormUsers : Form
    {
        private readonly LibraryBooksContext _context;

        public FormUsers()
        {
            InitializeComponent();

            _context = new LibraryBooksContext();
            _context.Users.Load();

            dataGridViewUsers.DataSource = _context.Users.Local.ToBindingList();
            dataGridViewUsers.Columns["Id"].DisplayIndex = 0;
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
