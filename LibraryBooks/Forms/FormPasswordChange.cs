using LibraryBooks.Core.Repositories.Users;
using LibraryBooks.Extentions;
using LibraryBooks.Utils;
using System;
using System.Linq;
using System.Windows.Forms;

namespace LibraryBooks.Forms
{
    public partial class FormPasswordChange : FormLibrarryBooks
    {
        private readonly IUserRepository _userRepository;
        public FormPasswordChange()
        {
            InitializeComponent();

            ActiveControl = textBoxOldPsswd;
            AcceptButton = buttonSave;

            _userRepository = Resolve<IUserRepository>();

            this.Text = "Изменить пароль: " + Session.CurrentUser.Login;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxOldPsswd.Text))
            {
                MessageBoxExtention.ErrorInput("Введите текущий пароль");
                return;
            }

            if (!_userRepository.IsExist(Session.CurrentUser.Login, textBoxOldPsswd.Text))
            {
                MessageBoxExtention.WarningInput("Текущий пароль введён не верно!");
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxNewPsswd.Text))
            {
                MessageBoxExtention.WarningInput("Пароль не может быть пустой!");
                return;
            }

            if (textBoxNewPsswd.Text != textBoxNewPsswdRep.Text)
            {
                MessageBoxExtention.WarningInput("Пароли не совпадают!");
                return;
            }

            if (textBoxOldPsswd.Text == textBoxNewPsswd.Text)
            {
                MessageBoxExtention.WarningInput("Новый пароль совпадает с текущим!");
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
            FormAuthorization.ToggleVisiblePassword(pictureBoxVis, textBoxOldPsswd, textBoxNewPsswd, textBoxNewPsswdRep);
        }
    }
}
