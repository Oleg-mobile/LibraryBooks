using FluentValidation;
using LibraryBooks.Core.Repositories.Users;
using LibraryBooks.Dto;
using LibraryBooks.Interceptors;
using LibraryBooks.Utils;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace LibraryBooks.Forms
{
    public partial class FormAuthorization : Form //: FormLibrarryBooks
    {
        private readonly IUserRepository _userRepository;
        private readonly IValidator<FormAuthorization> _validator;

        public FormAuthorization()
        {
            InitializeComponent();

            //ActiveControl = textBoxLogin;
            //AcceptButton = buttonLogin;

            //_userRepository = Resolve<IUserRepository>();
            //_validator = Resolve<IValidator<FormAuthorization>>();
        }

        public virtual void buttonLogin_Click(object sender, EventArgs e)
        {
            _validator.ValidateAndThrow(this);

            var user = _userRepository.GetAll().First(u => u.Login == textBoxLogin.Text);
            //Session.CurrentUser = Mapper.Map<UserDto>(user);

            var formMain = ProxyGeneratorFactory.Create<FormMain>();
            formMain.Show();

            //Hide();
        }

        public virtual void AuthorizationForm_FormClosed(object sender, FormClosedEventArgs e) => Application.Exit();

        public virtual void buttonRegistration_Click(object sender, EventArgs e) => ProxyGeneratorFactory.Create<FormRegistration>(this).ShowDialog();  // this - the one from whom this form is opened
                                                                                                                                                        //to access an element of this form from another through the constructor
        public virtual void pictureBoxClose_Click(object sender, EventArgs e) => ToggleVisiblePassword(pictureBoxClose, textBoxPassword);

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