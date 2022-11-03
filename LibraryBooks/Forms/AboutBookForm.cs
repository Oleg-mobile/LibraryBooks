using LibraryBooks.Dto;
using System.Windows.Forms;

namespace LibraryBooks.Forms
{
    public partial class AboutBookForm : LibrarryBooksForm
    {
        private readonly BookDto _bookDto;
        public AboutBookForm(BookDto bookDto)
        {
            InitializeComponent();

            this._bookDto = bookDto;

            label1.Text = _bookDto.Name;
        }
    }
}
