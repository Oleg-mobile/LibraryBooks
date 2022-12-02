using LibraryBooks.Dto;
using System;
using System.Windows.Forms;

namespace LibraryBooks.Forms
{
    public partial class FormReader : FormLibrarryBooks
    {
        private OpenFileDialog ofd = new OpenFileDialog();

        public FormReader()
        {
            InitializeComponent();

            ofd.Title = "Выберите программу";
            ofd.Filter = "Программы|*.exe";

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

        private void pictureBoxPathToReader_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() != DialogResult.OK) return;
            textBoxPathToReader.Text = ofd.FileName;
        }
    }
}
