using System;
using System.Windows.Forms;

namespace LibraryBooks.Forms
{
    public partial class FormSettings : FormLibrarryBooks
    {
        private OpenFileDialog ofd = new OpenFileDialog();

        public FormSettings()
        {
            InitializeComponent();

            ofd.Title = "Выберите программу";
            ofd.Filter = "Exe файлы (.exe)|*.exe";
            textBoxFilePath.Text = "C:\\Program Files\\Adobe\\Acrobat DC\\Acrobat\\Acrobat.exe";
        }

        private void buttonGetPath_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() != DialogResult.OK) return;
            textBoxFilePath.Text = ofd.FileName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new FormPasswordChange().Show();
        }
    }
}
