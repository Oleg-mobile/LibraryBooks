using FluentValidation;
using LibraryBooks.Dto;
using System;
using System.Windows.Forms;

namespace LibraryBooks.Forms
{
    public partial class FormReader : FormLibrarryBooks
    {
        private readonly IValidator<FormReader> _validator;
        private readonly string _formName;
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
            _formName = nameof(FormReader) + " ";
        }

        public FormReader(ReaderDto reader) : this()
        {
            textBoxName.Text = reader.Name;
            textBoxPathToReader.Text = reader.PathToReader;
            textBoxOpeningFormat.Text = reader.OpeningFormat;
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

        private void pictureBoxPathToReader_Click(object sender, EventArgs e)
        {
            CallWithLoggerInterceptor(() =>
            {
                if (ofd.ShowDialog() != DialogResult.OK) return;
                textBoxPathToReader.Text = ofd.FileName;

            }, _formName + nameof(pictureBoxPathToReader_Click));
        }
    }
}
