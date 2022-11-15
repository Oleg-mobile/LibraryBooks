using LibraryBooks.Core.Models;
using System;
using System.Windows.Forms;

namespace LibraryBooks.Forms
{
    public partial class FormGenre : FormLibrarryBooks
    {
        public FormGenre()
        {
            InitializeComponent();

            ActiveControl = textBoxName;
            AcceptButton = buttonSave;
        }

        public FormGenre(Genre genre) : this()
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
