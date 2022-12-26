using Castle.Core.Internal;
using LibraryBooks.Core.Models;
using LibraryBooks.Core.Repositories;
using LibraryBooks.Dto;
using LibraryBooks.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace LibraryBooks.Forms
{
    public partial class FormGenres : FormLibrarryBooks
    {
        private readonly IRepository<Genre, int> _genreRepository;
        private readonly IRepository<Book, int> _bookRepository;
        private readonly string _formName;
        private BindingList<GenreDto> bindingList;

        public FormGenres()
        {
            InitializeComponent();

            _genreRepository = Resolve<IRepository<Genre, int>>();
            _bookRepository = Resolve<IRepository<Book, int>>();
            _formName = nameof(FormGenres) + " ";

            RefrashTable();
            InitDataGridViewColumns<GenreDto>(dataGridViewGenres);
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            CallWithLoggerInterceptor(() =>
            {
                var genreForm = new FormGenre();
                DialogResult result = genreForm.ShowDialog();

                if (result == DialogResult.Cancel)
                {
                    return;
                }

                var genre = new Genre(genreForm.textBoxName.Text);
                _genreRepository.Insert(genre);

                RefrashTable();

            }, _formName + nameof(buttonAdd_Click));
        }


        private void buttonDel_Click(object sender, EventArgs e)
        {
            CallWithLoggerInterceptor(() =>
            {
                var genres = SelectedRowsMapToGenres();

                foreach (var genre in genres)
                {
                    var books = _bookRepository.GetAll().AsNoTracking().Where(b => b.Genre.Id == genre.Id).ToList();
                    if (!books.IsNullOrEmpty())
                    {
                        Notification.ShowWarning("Жанр испорльзуется!");
                        return;
                    }

                    _genreRepository.Delete(genre);
                }

                RefrashTable();

            }, _formName + nameof(buttonDel_Click));
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
            CallWithLoggerInterceptor(() =>
            {
                if (dataGridViewGenres.SelectedRows.Count > 0)
                {
                    var genreDto = (GenreDto)dataGridViewGenres.SelectedRows[0].DataBoundItem;
                    var genre = Mapper.Map<Genre>(genreDto);
                    var genreForm = new FormGenre(genre);
                    DialogResult dialogResult = genreForm.ShowDialog();

                    if (dialogResult == DialogResult.Cancel)
                    {
                        return;
                    }

                    genre.Name = genreForm.textBoxName.Text;
                    _genreRepository.Update(genre);

                    RefrashTable();
                }
            }, _formName + nameof(buttonEdit_Click));
        }

        private void RefrashTable()
        {
            var genres = _genreRepository.GetAll().AsNoTracking().ToList();
            bindingList = new BindingList<GenreDto>(Mapper.Map<IList<GenreDto>>(genres));
            dataGridViewGenres.DataSource = bindingList;
        }
    }
}
