using LibraryBooks.Dto;
using System.Windows.Forms;

namespace LibraryBooks.Forms
{
    public partial class AboutBookForm : LibrarryBooksForm
    {
        public AboutBookForm(BookDto bookDto)
        {
            InitializeComponent();

            labelName.Text = bookDto.Name;
            labelAuthor.Text = bookDto.AuthorName;
            labelGenre.Text = bookDto.GenreName;
            labelPublication.Text = bookDto.Publication;
            labelYaer.Text = bookDto.Year.ToString();
            labelMark.Text = bookDto.Mark.ToString();
            labelPageCount.Text = bookDto.PageCount.ToString();
            labelPath.Text = bookDto.PathToBook;

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
