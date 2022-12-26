using LibraryBooks.Core.Models;
using System;
using System.Windows.Forms;

namespace LibraryBooks.Forms
{
    public partial class FormAuthor : FormLibrarryBooks
    {
        public FormAuthor()
        {
            InitializeComponent();

            ActiveControl = textBoxName;
            AcceptButton = buttonSave;
        }

        public FormAuthor(Author author) : this()  // :this() - вызов конструктора по умолчанию
        {
            textBoxName.Text = author.Name;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            CallWithLoggerInterceptor(() =>
            {
                Close();
                DialogResult = DialogResult.OK;
            }, nameof(FormAuthor) + " " + nameof(buttonSave_Click));
        }
    }
}
