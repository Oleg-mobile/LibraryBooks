using FluentValidation;
using LibraryBooks.Common;
using LibraryBooks.Core.Repositories.Users;
using LibraryBooks.Forms;
using LibraryBooks.Utils;
using System.Linq;

namespace LibraryBooks.Validation
{
    public class AuthorizationValidator : AbstractValidator<FormAuthorization>
    {
        public AuthorizationValidator()
        {
            RuleFor(r => r.textBoxLogin.Text).NotNull().NotEmpty().WithMessage("Введите логин!");
            RuleFor(r => r.textBoxPassword.Text).NotNull().NotEmpty().WithMessage("Введите пароль!");
            RuleFor(r => r)
                .Must(u => CheckExistingUser(u.textBoxLogin.Text, u.textBoxPassword.Text))  // 2 характеристики
                .WithMessage("Не верный логин или пароль!");
        }

        private bool CheckExistingUser(string login, string password)
        {
            var userRepository = IocManager.Resolve<IUserRepository>();
            var user = userRepository.GetAll().FirstOrDefault(u => u.Login == login);
            if (user == null)
            {
                return false;
            }

            return userRepository.IsExist(login, EncryptionUtils.EncodePasword(password, user.Salt));
        }
    }
}
