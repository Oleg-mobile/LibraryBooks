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

        public FormAuthorization()
        {
            InitializeComponent();

            ActiveControl = textBoxLogin;
            AcceptButton = buttonLogin;

            _userRepository = Resolve<IUserRepository>();
            _validator = Resolve<IValidator<FormAuthorization>>();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            CallWithAllInterceptors(() =>
            {
                _validator.ValidateAndThrow(this);

                var user = _userRepository.GetAll().First(u => u.Login == textBoxLogin.Text);
                Session.CurrentUser = Mapper.Map<UserDto>(user);
                new FormMain().Show();  // stack variable is not needed
                Hide();
            }, nameof(FormAuthorization) + " " + nameof(buttonLogin_Click));
        }

        private void AuthorizationForm_FormClosed(object sender, FormClosedEventArgs e) => 
            CallWithLoggerInterceptor(() => Application.Exit(), nameof(FormAuthorization) + " " + nameof(AuthorizationForm_FormClosed));
        // this - the one from whom this form is opened
        //to access an element of this form from another through the constructor
        private void buttonRegistration_Click(object sender, EventArgs e) => 
            CallWithLoggerInterceptor(() => new FormRegistration(this).ShowDialog(), nameof(FormAuthorization) + " " + nameof(buttonRegistration_Click));
        private void pictureBoxClose_Click(object sender, EventArgs e) => 
            CallWithLoggerInterceptor(() => ToggleVisiblePassword(pictureBoxClose, textBoxPassword), nameof(FormAuthorization) + " " + nameof(pictureBoxClose_Click));
        public static void ToggleVisiblePassword(PictureBox pictureBox, params TextBox[] textBoxPasswords)
        {
            bool isVisiblePass = textBoxPasswords[0].UseSystemPasswordChar;
            // in case of multiple textBoxes
            foreach (TextBox textBoxPassword in textBoxPasswords)
            {
                textBoxPassword.UseSystemPasswordChar = !isVisiblePass;
            }
            pictureBox.Image = Image.FromFile(@$"Images\{(isVisiblePass ? "eyeOpen.png" : "eyeClose.png")}");
            // @ - take the string literally without escaping service characters
            // $ - string interpolation, you can use variables
        }
    }
}