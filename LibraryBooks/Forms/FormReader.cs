using LibraryBooks.Dto;
using System;
using System.Windows.Forms;

namespace LibraryBooks.Forms
{
    public partial class FormReader : FormLibrarryBooks
    {
        public FormReader()
        {
            InitializeComponent();

            ActiveControl = textBoxName;
            AcceptButton = buttonSave;
        }

        public FormReader(ReaderDto reader) : this()
        {
            textBoxName.Text = reader.Name;
            textBoxPathToReader.Text = reader.PathToReader;
            textBoxOpeningFormat.Text = reader.OpeningFormat;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Close();
            DialogResult = DialogResult.OK;
        }
    }
}
