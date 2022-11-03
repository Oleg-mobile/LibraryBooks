﻿using System;
using System.Windows.Forms;

namespace LibraryBooks.Forms
{
    public partial class FormSettings : LibrarryBooksForm
    {
        private OpenFileDialog ofd = new OpenFileDialog();

        public FormSettings()
        {
            InitializeComponent();

            ofd.Title = "Выберите программу";
            ofd.Filter = "Exe файлы (.exe)|*.exe";
        }

        private void buttonGetPath_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() != DialogResult.OK) return;
            textBoxFilePath.Text = ofd.FileName;
        }
    }
}