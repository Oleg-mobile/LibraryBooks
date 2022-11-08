using LibraryBooks.Dto;
using System.Drawing;
using System.Windows.Forms;

namespace LibraryBooks.Forms
{
    public partial class AboutBookForm : LibrarryBooksForm
    {
        public AboutBookForm(BookDto bookDto)
        {
            InitializeComponent();

            labelName.Text = "Название: " + bookDto.Name;
            labelAuthor.Text = "Автор: " + bookDto.AuthorName;
            labelGenre.Text = "Жанр: " + bookDto.GenreName;
            labelPublication.Text = "Издание: " + bookDto.Publication;
            labelYaer.Text = "Год выпуска: " + bookDto.Year.ToString();
            labelMark.Text = "Закладка на странице: " + bookDto.Mark.ToString();
            labelPageCount.Text = "Количество страниц: " + bookDto.PageCount.ToString();
            labelPath.Text = "Путь до книги: " + bookDto.PathToBook;
            pictureBoxCover.Image = Image.FromFile(bookDto.PathToCover);

            if (bookDto.IsLiked)
            {
                labelIsLiked.Text = "Книга понравилась";
            }
            else labelIsLiked.Text = "";

            if (bookDto.IsFinished)
            {
                labelIsFinished.Text = "Книга прочитана";
            }
            else labelIsFinished.Text = "";
        }
    }
}
