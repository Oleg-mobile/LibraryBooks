using LibraryBooks.Core.Models;
using System;
using System.Windows.Forms;

namespace LibraryBooks.Forms
{
    public partial class FormAuthor : FormLibrarryBooks
    {
        public FormAuthor()
        {
            InitializeComponent();

            ActiveControl = textBoxName;
            AcceptButton = buttonSave;
        }

        // to fill in all the input fields on the form
        public FormAuthor(Author author) : this()  // :this() - calling the default constructor
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
