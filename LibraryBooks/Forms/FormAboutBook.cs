using LibraryBooks.Dto;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace LibraryBooks.Forms
{
    public partial class FormAboutBook : FormLibrarryBooks
    {
        public FormAboutBook(BookDto bookDto)
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

            pictureBoxCover.SizeMode = PictureBoxSizeMode.Zoom;
            if (File.Exists(bookDto.PathToCover))
            {
                pictureBoxCover.Image = Image.FromFile(bookDto.PathToCover);
            }
            else 
                pictureBoxCover.Image = Image.FromFile(@"Images\no-paper.png");

            if (bookDto.IsLiked)
            {
                labelIsLiked.Text = "Книга понравилась";
            }
            else 
                labelIsLiked.Text = "";

            if (bookDto.IsFinished)
            {
                labelIsFinished.Text = "Книга прочитана";
            }
            else
                if (bookDto.Mark > 0)
                {
                    labelIsFinished.Text = $"Читаю на {bookDto.Mark} странице";
                }
                else
                    labelIsFinished.Text = "";
        }
    }
}
