using LibraryBooks.Core.Models;
using LibraryBooks.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace LibraryBooks.Forms
{
    public partial class FormGenres : LibrarryBooksForm
    {
        private readonly IRepository<Genre, int> _genreRepository;

        public FormGenres()
        {
            InitializeComponent();

            _genreRepository = Resolve<IRepository<Genre, int>>();

            RefrashTable();

            dataGridViewGenres.Columns["Id"].Visible = false;
            dataGridViewGenres.Columns["Name"].HeaderText = "Жанр";
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var genreForm = new GenreForm();
            DialogResult result = genreForm.ShowDialog();

            if (result == DialogResult.Cancel)
            {
                return;
            }

            var genre = new Genre(genreForm.textBoxName.Text);
            _genreRepository.Insert(genre);

            RefrashTable();
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            var genres = SelectedRowsMapToGenres();

            foreach (var genre in genres)
            {
                _genreRepository.Delete(genre);
            }

            RefrashTable();
        }

        private IEnumerable<Genre> SelectedRowsMapToGenres()
        {
            var genres = new List<Genre>();

            for (int i = 0; i < dataGridViewGenres.SelectedRows.Count; i++)
            {
                var genre = (Genre)dataGridViewGenres.SelectedRows[i].DataBoundItem;
                genres.Add(genre);
            }

            return genres;
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewGenres.SelectedRows.Count > 0)
            {
                var genre = (Genre)dataGridViewGenres.SelectedRows[0].DataBoundItem;
                var genreForm = new GenreForm(genre);
                DialogResult dialogResult = genreForm.ShowDialog();

                if (dialogResult == DialogResult.Cancel)
                {
                    return;
                }

                genre.Name = genreForm.textBoxName.Text;
                _genreRepository.Update(genre);

                RefrashTable();
            }
        }

        private void RefrashTable() => dataGridViewGenres.DataSource = _genreRepository.GetAll().ToList();
    }
}
