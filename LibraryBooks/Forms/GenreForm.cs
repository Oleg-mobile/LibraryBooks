using LibraryBooks.Core.Models;
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
    public partial class GenreForm : Form
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
