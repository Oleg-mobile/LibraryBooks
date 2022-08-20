using System;
using System.Windows.Forms;

namespace LibraryBooks.Forms
{
    public partial class FormMain : Form
    {
        private Form activeForm;

        public FormMain()
        {
            InitializeComponent();
        }

        private void buttonBooks_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormBooks());
        }

        private void buttonAuthors_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormAuthors());
        }

        /// <summary>
        /// Open child form
        /// </summary>
        /// <param name="childForm"></param>
        private void OpenChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();

            activeForm = childForm;
            activeForm.FormBorderStyle = FormBorderStyle.None;
            activeForm.Dock = DockStyle.Fill;
            activeForm.TopLevel = false;

            panelContent.Controls.Add(activeForm);

            activeForm.Show();
        }
    }
}
