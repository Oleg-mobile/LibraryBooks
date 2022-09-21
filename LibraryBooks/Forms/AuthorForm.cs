using Castle.Windsor;
using LibraryBooks.Core.Models;
using LibraryBooks.Core.Repositories;
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
    public partial class AuthorForm : LibrarryBooksForm
    {
        public AuthorForm()
        {
            InitializeComponent();
            ActiveControl = textBoxName;
            AcceptButton = buttonSave;

            // for test
            IRepository<Author, int> a = Resolve<IRepository<Author, int>>();
            var b = a.GetAll().ToList();
        }

        // to fill in all the input fields on the form
        public AuthorForm(Author author) : this()  // :this() - calling the default constructor
        {
            textBoxName.Text = author.Name;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Close();
            DialogResult = DialogResult.OK;
        }
    }
}
