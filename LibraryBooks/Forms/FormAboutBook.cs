using LibraryBooks.Dto;
using System.Drawing;
using System.IO;

namespace LibraryBooks.Forms
{
    public partial class FormAboutBook : FormLibrarryBooks
    {
        public FormAboutBook(BookDto bookDto)
        {
            InitializeComponent();

            labelName.Text        += bookDto.Name;
            labelAuthor.Text      += bookDto.AuthorName;
            labelGenre.Text       += bookDto.GenreName;
            labelPublication.Text += bookDto.Publication;
            labelMark.Text        += bookDto.Mark.ToString();
            labelPageCount.Text   += bookDto.PageCount;
            labelPath.Text        += bookDto.PathToBook;

            if (bookDto.Year is not null)
            {
                labelYaer.Text = "Год выпуска: " + bookDto.Year;
            }

            if (File.Exists(bookDto.PathToCover))
            {
                pictureBoxCover.Image = Image.FromFile(bookDto.PathToCover);
            }

            if (bookDto.IsLiked)
            {
                labelIsLiked.Visible = true;
                labelIsLiked.Text += "Понравилась";
            }

            SetState(bookDto);

            if (bookDto.ReaderName is not null)
            {
                labelPathToReader.Text = $"Читалка: {bookDto.ReaderName}";
            }
        }

        private void SetState(BookDto bookDto)
        {
            CallWithLoggerInterceptor(() => 
            {
                if (bookDto.IsFinished)
                {
                    labelIsFinished.Text += "Прочитана";
                    return;
                }

                if (bookDto.Mark > 0)
                {
                    labelIsFinished.Text += $"Читаю на {bookDto.Mark} странице";
                    return;
                }

                labelIsFinished.Text += "Не читали";
            }, nameof(FormAboutBook) + " " + nameof(SetState));
        }
    }
}
