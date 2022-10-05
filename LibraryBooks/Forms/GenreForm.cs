using LibraryBooks.Core.Models;
using System;
using System.Windows.Forms;

namespace LibraryBooks.Forms
{
    public partial class GenreForm : LibrarryBooksForm
    {
        public GenreForm()
        {
            InitializeComponent();

            ActiveControl = textBoxName;
            AcceptButton = buttonSave;
        }

        public GenreForm(Genre genre) : this()
        {
            textBoxName.Text = genre.Name;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Close();
            DialogResult = DialogResult.OK;
        }
    }
}
