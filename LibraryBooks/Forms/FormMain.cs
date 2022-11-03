using System;
using System.Windows.Forms;

namespace LibraryBooks.Forms
{
    public partial class FormMain : LibrarryBooksForm
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

        private void buttonGenres_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormGenres());
        }


        /// <summary>
        /// Open child form
        /// </summary>
        /// <param name="childForm"></param>
        private void OpenChildForm(Form childForm)  // private - exists within the main form, Form - open any form (polymorphism)
        {
            if (activeForm != null)
                activeForm.Close();

            activeForm = childForm;
            activeForm.FormBorderStyle = FormBorderStyle.None; // disable window title
            activeForm.Dock = DockStyle.Fill;                  // fill all the space
            activeForm.TopLevel = false;                       // non-top-level form (child)

            panelContent.Controls.Add(activeForm);             // add to the main form panel

            activeForm.Show();
        }

        private void buttonExit_Click(object sender, EventArgs e) => Exit();

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e) => Program.AuthForm.Show();

        private void Exit()
        {
            Program.AuthForm.Show();
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormSettings());
        }
    }
}
