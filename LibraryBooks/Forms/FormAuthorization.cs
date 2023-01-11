using FluentValidation;
using LibraryBooks.Core.Repositories.Users;
using LibraryBooks.Dto;
using LibraryBooks.Utils;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace LibraryBooks.Forms
{
    public partial class FormAuthorization : FormLibrarryBooks
    {
        private readonly IUserRepository _userRepository;
        private readonly IValidator<FormAuthorization> _validator;
        private readonly string _formName;

        public FormAuthorization()
        {
            InitializeComponent();

            ActiveControl = textBoxLogin;
            AcceptButton = buttonLogin;

            _userRepository = Resolve<IUserRepository>();
            _validator = Resolve<IValidator<FormAuthorization>>();
            _formName = nameof(FormAuthorization) + " ";
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            CallWithAllInterceptors(() =>
            {
                _validator.ValidateAndThrow(this);

                var user = _userRepository.GetAll().First(u => u.Login == textBoxLogin.Text);
                Session.CurrentUser = Mapper.Map<UserDto>(user);
                new FormMain().Show();  // Переменная не нужна
                Hide();
            }, _formName + nameof(buttonLogin_Click));
        }

        private void AuthorizationForm_FormClosed(object sender, FormClosedEventArgs e) =>
            CallWithLoggerInterceptor(() => Application.Exit(), _formName + nameof(AuthorizationForm_FormClosed));
        // this - тот у кого открыта эта форма для доступа к её элементу из другой через конструктор
        private void buttonRegistration_Click(object sender, EventArgs e) =>
            CallWithLoggerInterceptor(() => new FormRegistration(this).ShowDialog(), _formName + nameof(buttonRegistration_Click));
        private void pictureBoxClose_Click(object sender, EventArgs e) =>
            CallWithLoggerInterceptor(() => ToggleVisiblePassword(pictureBoxClose, textBoxPassword), _formName + nameof(pictureBoxClose_Click));
        public static void ToggleVisiblePassword(PictureBox pictureBox, params TextBox[] textBoxPasswords)
        {
            bool isVisiblePass = textBoxPasswords[0].UseSystemPasswordChar;
            // На случай нескольких текстовых полей
            foreach (TextBox textBoxPassword in textBoxPasswords)
            {
                textBoxPassword.UseSystemPasswordChar = !isVisiblePass;
            }
            pictureBox.Image = Image.FromFile(@$"Images\{(isVisiblePass ? "eyeOpen.png" : "eyeClose.png")}");
            // @ - воспринимать строку буквально, не экранируя служебные символы
            // $ - интерполяция строк с возможностью использовать переменные
        }
    }
}