﻿using LibraryBooks.Core;
using LibraryBooks.Core.Models;
using Microsoft.EntityFrameworkCore;
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
    public partial class FormGenres : Form
    {
        private readonly LibraryBooksContext _context;

        public FormGenres()
        {
            InitializeComponent();

            _context = new LibraryBooksContext();
            _context.Genres.Load();

            dataGridViewGenres.DataSource = _context.Genres.Local.ToBindingList();
            dataGridViewGenres.Columns["Id"].DisplayIndex = 0;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var genreForm = new GenreForm();
            DialogResult result = genreForm.ShowDialog();

            if (result == DialogResult.Cancel)
            {
                return;
            }

            var genre = new Genre();
            genre.Name = genreForm.textBoxName.Text;

            _context.Genres.Add(genre);
            _context.SaveChanges();
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            // TODO Исправить множественное удаление
            for (int i = 0; i < dataGridViewGenres.SelectedRows.Count; i++)
            {
                var genre = (Genre)dataGridViewGenres.SelectedRows[i].DataBoundItem;
                _context.Remove(genre);
                _context.SaveChanges();
            }
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
                _context.SaveChanges();
                dataGridViewGenres.Refresh();
            }
        }
    }
}
