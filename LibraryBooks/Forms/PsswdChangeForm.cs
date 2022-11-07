using LibraryBooks.Core.Repositories.Users;
using LibraryBooks.Extentions;
using LibraryBooks.Utils;
using System;
using System.Linq;
using System.Windows.Forms;

namespace LibraryBooks.Forms
{
    public partial class PsswdChangeForm : LibrarryBooksForm
    {
        private readonly IUserRepository _userRepository;
        public PsswdChangeForm()
        {
            InitializeComponent();

            ActiveControl = textBoxOldPsswd;
            AcceptButton = buttonSave;

            _userRepository = Resolve<IUserRepository>();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxOldPsswd.Text))
            {
                MessageBoxExtention.ErrorInput("Введите старый пароль");
                return;
            }

            if (!_userRepository.IsExist(Session.CurrentUser.Login, textBoxOldPsswd.Text))
            {
                MessageBoxExtention.Error("Не верный логин или пароль", "Ошибка авторизации!");
                textBoxOldPsswd.Clear();
                return;
            }

            if (string.IsNullOrEmpty(textBoxNewPsswd.Text))
            {
                MessageBoxExtention.ErrorInput("Пароль не может быть пустой!");
                return;
            }

            if (textBoxNewPsswd.Text != textBoxNewPsswdRep.Text)
            {
                MessageBoxExtention.ErrorInput("Пароли не совпадают");
                textBoxNewPsswd.Clear();
                textBoxNewPsswdRep.Clear();
                return;
            }

            var user = _userRepository.GetAll().First(u => u.Login == Session.CurrentUser.Login && u.Password == textBoxOldPsswd.Text);
            user.Password = textBoxNewPsswd.Text;
            _userRepository.Update(user);

            MessageBox.Show("Пароль изменён");

            var formSettingsm = new FormSettings();
            formSettingsm.Show();

            Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            AuthorizationForm.ToggleVisiblePassword(pictureBoxVis, textBoxOldPsswd, textBoxNewPsswd, textBoxNewPsswdRep);
        }
    }
}
