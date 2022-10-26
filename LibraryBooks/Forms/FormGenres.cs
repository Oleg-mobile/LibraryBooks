using LibraryBooks.Core.Models;
using LibraryBooks.Core.Repositories;
using LibraryBooks.Dto.Authors;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace LibraryBooks.Forms
{
    public partial class FormGenres : LibrarryBooksForm
    {
        private readonly IRepository<Genre, int> _genreRepository;
        private BindingList<GenreDto> bindingList;

        public FormGenres()
        {
            InitializeComponent();

            _genreRepository = Resolve<IRepository<Genre, int>>();

            RefrashTable();
            InitDataGridViewColumns<GenreDto>(dataGridViewGenres);
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

        // TODO ловлю ошибку с треккингом

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
            var genres = new List<GenreDto>();

            for (int i = 0; i < dataGridViewGenres.SelectedRows.Count; i++)
            {
                var genre = (GenreDto)dataGridViewGenres.SelectedRows[i].DataBoundItem;
                genres.Add(genre);
            }

            return Mapper.Map<IEnumerable<Genre>>(genres);
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewGenres.SelectedRows.Count > 0)
            {
                var genreDto = (GenreDto)dataGridViewGenres.SelectedRows[0].DataBoundItem;
                var genre = Mapper.Map<Genre>(genreDto);
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

        private void RefrashTable()
        {
            var genres = _genreRepository.GetAll().AsNoTracking().ToList();
            bindingList = new BindingList<GenreDto>(Mapper.Map<IList<GenreDto>>(genres));
            dataGridViewGenres.DataSource = bindingList;
        }
    }
}
