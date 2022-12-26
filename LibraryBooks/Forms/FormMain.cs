using System;
using System.Windows.Forms;

namespace LibraryBooks.Forms
{
    public partial class FormMain : FormLibrarryBooks
    {
        private readonly string _formName;
        private Form activeForm;

        public FormMain()
        {
            InitializeComponent();

            _formName = nameof(FormMain) + " ";
        }

        private void buttonBooks_Click(object sender, EventArgs e)
        {
            CallWithLoggerInterceptor(() => OpenChildForm(new FormBooks()), _formName + nameof(buttonBooks_Click));
        }

        private void buttonAuthors_Click(object sender, EventArgs e)
        {
            CallWithLoggerInterceptor(() => OpenChildForm(new FormAuthors()), _formName + nameof(buttonAuthors_Click));
        }

        private void buttonGenres_Click(object sender, EventArgs e)
        {
            CallWithLoggerInterceptor(() => OpenChildForm(new FormGenres()), _formName + nameof(buttonGenres_Click));
        }


        /// <summary>
        /// Open child form
        /// </summary>
        /// <param name="childForm"></param>
        private void OpenChildForm(Form childForm)  // private - существует внутри основной формы, Form - открыть любую форму (polymorphism)
        {
            if (activeForm != null)
                activeForm.Close();

            activeForm = childForm;
            activeForm.FormBorderStyle = FormBorderStyle.None; // Отключить заголовок окна
            activeForm.Dock = DockStyle.Fill;                  // Заполнить все пространство
            activeForm.TopLevel = false;                       // Форма не верхнего уровня (дочерняя)

            panelContent.Controls.Add(activeForm);             // Добавить на панель основной формы

            activeForm.Show();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            CallWithLoggerInterceptor(() => Exit(), _formName + nameof(buttonExit_Click));
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            CallWithLoggerInterceptor(() => Program.AuthForm.Show(), _formName + nameof(FormMain_FormClosed));
        }

        private void Exit()
        {
            Program.AuthForm.Show();
            Close();
        }

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            CallWithLoggerInterceptor(() => OpenChildForm(new FormSettings()), _formName + nameof(buttonSettings_Click));
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            // При открытии главной формы открыть форму книги
            CallWithLoggerInterceptor(() => buttonBooks.PerformClick(), _formName + nameof(FormMain_Load));
        }
    }
}
