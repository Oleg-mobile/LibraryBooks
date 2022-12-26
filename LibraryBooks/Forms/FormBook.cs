﻿using FluentValidation;
using LibraryBooks.Core.Models;
using LibraryBooks.Core.Repositories;
using LibraryBooks.Dto;
using System;
using System.Linq;
using System.Windows.Forms;

namespace LibraryBooks.Forms
{
    public partial class FormBook : FormLibrarryBooks
    {
        private readonly IRepository<Author, int> _authorRepository;
        private readonly IRepository<Genre, int> _genreRepository;
        private readonly IRepository<Reader, int> _readerRepository;
        private readonly IValidator<FormBook> _validator;
        private readonly string _formName;
        private OpenFileDialog ofd = new();

        public FormBook()
        {
            InitializeComponent();

            _authorRepository = Resolve<IRepository<Author, int>>();
            _genreRepository = Resolve<IRepository<Genre, int>>();
            _readerRepository = Resolve<IRepository<Reader, int>>();
            _validator = Resolve<IValidator<FormBook>>();
            _formName = nameof(FormBook) + " ";

            AcceptButton = buttonSave;

            comboBoxAuthor.DataSource = _authorRepository.GetAll().ToList();
            comboBoxAuthor.DisplayMember = "Name";

            comboBoxGenre.DataSource = _genreRepository.GetAll().ToList();
            comboBoxGenre.DisplayMember = "Name";

            comboBoxReader.DataSource = _readerRepository.GetAll().ToList();
            comboBoxReader.DisplayMember = "Name";
        }

        public FormBook(BookDto book) : this()
        {
            textBoxName.Text = book.Name;
            comboBoxAuthor.Text = book.AuthorName;
            textBoxPublication.Text = book.Publication;
            textBoxYear.Text = book.Year.ToString();
            textBoxPageCount.Text = book.PageCount.ToString();
            comboBoxGenre.Text = book.GenreName;
            textBoxPathToBook.Text = book.PathToBook;
            textBoxPathToCover.Text = book.PathToCover;
            textBoxMark.Text = book.Mark.ToString();
            checkBoxIsLiked.Checked = book.IsLiked;
            checkBoxIsFinished.Checked = book.IsFinished;
            comboBoxReader.Text = book.ReaderName;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            CallWithAllInterceptors(() =>
            {
                _validator.ValidateAndThrow(this);
                Close();
                DialogResult = DialogResult.OK;
            }, _formName + nameof(buttonSave_Click));
        }

        private void textBoxIntegerMask_KeyPress(object sender, KeyPressEventArgs e)
        {
            char input = e.KeyChar;
            if ((!char.IsDigit(input)) && (!char.IsControl(input)))
            {
                e.Handled = true;
            }
        }

        private void pictureBoxAuthor_Click(object sender, EventArgs e)
        {
            CallWithLoggerInterceptor(() =>
            {
                pictureBox_Click<FormAuthor, Author>
                (
                    f => f.textBoxName.Text,
                    _authorRepository,
                    name => new Author(name),  // Generics не может управляться конструктором => нужен пустой (по умолчанию) конструктор, и его можно вызвать
                    comboBoxAuthor
                );
            }, _formName + nameof(pictureBoxAuthor_Click));
        }

        private void pictureBoxGenre_Click(object sender, EventArgs e)
        {
            CallWithLoggerInterceptor(() =>
            {
                pictureBox_Click<FormGenre, Genre>
                (
                    f => f.textBoxName.Text,
                    _genreRepository,
                    name => new Genre(name),
                    comboBoxGenre
                );
            }, _formName + nameof(pictureBoxGenre_Click));
        }

        private void pictureBox_Click<TForm, TEntity>(Func<TForm, string> getName, IRepository<TEntity, int> repository, Func<string, TEntity> getEntity, ComboBox comboBox)
            where TForm : FormLibrarryBooks, new()  // new() - есть пустой (по умолчанию) конструктор
            where TEntity : Entity<int>, new()
        {
            var form = new TForm();  // Generics не могут иметь конструктор с параметрами
            DialogResult result = form.ShowDialog();

            if (result == DialogResult.Cancel)
            {
                return;
            }

            repository.Insert(getEntity(getName(form)));

            comboBox.DataSource = repository.GetAll().ToList();
            comboBox.DisplayMember = "Name";

            int index = comboBox.FindString(getName(form));
            comboBox.SelectedIndex = index;
        }

        private void pictureBoxPathToBook_Click(object sender, EventArgs e)
        {
            CallWithLoggerInterceptor(() =>
            {
                ofd.Title = "Выберите путь до книги";
                ofd.Filter = "Книги|*.doc;*.docx;*.pdf;*.txt";

                if (ofd.ShowDialog() != DialogResult.OK) return;
                textBoxPathToBook.Text = ofd.FileName;
            }, _formName + nameof(pictureBoxPathToBook_Click));
        }

        private void pictureBoxPathToCover_Click(object sender, EventArgs e)
        {
            CallWithLoggerInterceptor(() =>
            {
                ofd.Title = "Выберите путь до обложки";
                ofd.Filter = "Картинки|*.jpg;*.jpeg;*.png;*.gif;*.tif;...";

                if (ofd.ShowDialog() != DialogResult.OK) return;
                textBoxPathToCover.Text = ofd.FileName;
            }, _formName + nameof(pictureBoxPathToCover_Click));
        }
    }
}
