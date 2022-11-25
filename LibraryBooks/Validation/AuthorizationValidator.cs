using FluentValidation;
using LibraryBooks.Common;
using LibraryBooks.Core.Repositories.Users;
using LibraryBooks.Forms;

namespace LibraryBooks.Validation
{
    public class AuthorizationValidator : AbstractValidator<FormAuthorization>
    {
        public AuthorizationValidator()
        {
            RuleFor(r => r.textBoxLogin.Text).NotNull().NotEmpty().WithMessage("Введите логин!");
            RuleFor(r => r.textBoxPassword.Text).NotNull().NotEmpty().WithMessage("Введите пароль!");
            RuleFor(r => r)
                .Must(u => CheckExistingUser(u.textBoxLogin.Text, u.textBoxPassword.Text))  // 2 characteristics
                .WithMessage("Не верный логин или пароль!");
        }

        private bool CheckExistingUser(string user, string password)
        {
            var userRepository = IocManager.Resolve<IUserRepository>();
            return userRepository.IsExist(user, password);
        }
    }
}
