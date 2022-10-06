using LibraryBooks.Core.Models;
using LibraryBooks.Core.Repositories;
using System;
using System.Linq;
using System.Windows.Forms;

namespace LibraryBooks.Forms
{
    public partial class BookForm : LibrarryBooksForm
    {
        private readonly IRepository<Author, int> _authorRepository;
        private readonly IRepository<Genre, int> _genreRepository;

        public BookForm()
        {
            InitializeComponent();

            _authorRepository = Resolve<IRepository<Author, int>>();
            _genreRepository = Resolve<IRepository<Genre, int>>();

            AcceptButton = buttonSave;

            comboBoxAuthor.DataSource = _authorRepository.GetAll().ToList();
            comboBoxAuthor.DisplayMember = "Name";

            comboBoxGenre.DataSource = _genreRepository.GetAll().ToList();
            comboBoxGenre.DisplayMember = "Name";

            // TODO временный
            label9.Text = Program.AuthForm.textBoxLogin.Text;
        }

        public BookForm(Book book) : this()
        {
            textBoxName.Text = book.Name;
            comboBoxAuthor.Text = book.Author.Name;
            textBoxPublication.Text = book.Publication;
            textBoxYear.Text = book.Year.ToString();
            textBoxPageCount.Text = book.PageCount.ToString();
            comboBoxGenre.Text = book.Genre.Name;
            label9.Text = book.User.Login;
            textBoxPathToBook.Text = book.PathToBook;
            textBoxMark.Text = book.Mark.ToString();
            checkBoxIsLiked.Checked = book.IsLiked;
            checkBoxIsFinished.Checked = book.IsFinished;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Close();
            DialogResult = DialogResult.OK;
        }

        private void textBoxIntegerMask_KeyPress(object sender, KeyPressEventArgs e)
        {
            char input = e.KeyChar;
            if (!char.IsDigit(input))
            {
                e.Handled = true;
            }
        }

        private void pictureBoxAuthor_Click(object sender, EventArgs e)
        {
            pictureBox_Click<AuthorForm, Author>
            (
                f => f.textBoxName.Text,
                _authorRepository,
                name => new Author(name),  // Generics cannot be manipulated by a constructor => need an empty (default) constructor and it can be called
                comboBoxAuthor
            );

            #region Как было
            //var authorForm = new AuthorForm();
            //DialogResult result = authorForm.ShowDialog();

            //if (result == DialogResult.Cancel)
            //{
            //    return;
            //}

            //var authorName = authorForm.textBoxName.Text;
            //var author = new Author(authorName);

            //_authorRepository.Insert(author);

            //comboBoxAuthor.DataSource = _authorRepository.GetAll().ToList();
            //comboBoxAuthor.DisplayMember = "Name";

            //int index = comboBoxAuthor.FindString(authorName);
            //comboBoxAuthor.SelectedIndex = index;
            #endregion
        }

        private void pictureBoxGenre_Click(object sender, EventArgs e)
        {
            pictureBox_Click<GenreForm, Genre>
            (
                f => f.textBoxName.Text,
                _genreRepository,
                name => new Genre(name),
                comboBoxGenre
            );
        }

        private void pictureBox_Click<TForm, TEntity>(Func<TForm, string> getName, IRepository<TEntity, int> repository, Func<string, TEntity> getEntity, ComboBox comboBox)
            // TODO есть конструктор?
            where TForm : LibrarryBooksForm, new()  // new() - there is an empty (default) constructor
            where TEntity : Entity<int>, new()      // new() - there is an empty (default) constructor
        {
            var form = new TForm();  // generics cannot use a constructor with parameters
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
    }
}
