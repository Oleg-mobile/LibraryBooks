using FluentValidation;
using LibraryBooks.Dto;
using LibraryBooks.Utils;
using System;
using System.Linq;
using System.Windows.Forms;

namespace LibraryBooks.Forms
{
    public partial class FormReader : FormLibrarryBooks
    {
        private readonly IValidator<FormReader> _validator;
        private OpenFileDialog ofd = new OpenFileDialog();

        public FormReader()
        {
            InitializeComponent();

            ofd.Title = "Выберите программу";
            ofd.Filter = "Программы|*.exe";

            ActiveControl = textBoxName;
            AcceptButton = buttonSave;

            textBoxOpeningFormat.Text = "/A page={page} \"{path}\"";

            _validator = Resolve<IValidator<FormReader>>();
        }

        public FormReader(ReaderDto reader) : this()
        {
            textBoxName.Text = reader.Name;
            textBoxPathToReader.Text = reader.PathToReader;
            textBoxOpeningFormat.Text = reader.OpeningFormat;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                _validator.ValidateAndThrow(this);
                Close();
                DialogResult = DialogResult.OK;
            }
            catch (ValidationException ex)
            {
                var message = ex.Errors?.First().ErrorMessage ?? ex.Message;
                Notification.ShowWarning(message);
            }
        }

        private void pictureBoxPathToReader_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() != DialogResult.OK) return;
            textBoxPathToReader.Text = ofd.FileName;
        }
    }
}
