using FluentValidation;
using LibraryBooks.Common;
using LibraryBooks.Core.Repositories.Users;
using LibraryBooks.Forms;
using LibraryBooks.Utils;

namespace LibraryBooks.Validation
{
    public class ChangePasswordValidator : AbstractValidator<FormPasswordChange>
    {
        public ChangePasswordValidator()
        {
            RuleFor(r => r.textBoxOldPassword.Text).NotNull().NotEmpty().WithMessage("Введите текущий пароль");
            RuleFor(r => r.textBoxOldPassword.Text).Must(CheckCurrentPassword).WithMessage("Текущий пароль введён не верно!");
            RuleFor(r => r.textBoxNewPassword.Text).NotNull().NotEmpty().WithMessage("Новый пароль не может быть пустой!");
            RuleFor(r => r.textBoxNewPassword.Text).Equal(r => r.textBoxNewPasswordRepeat.Text).WithMessage("Новые пароли не совпадают!");
            RuleFor(r => r.textBoxOldPassword.Text).NotEqual(r => r.textBoxNewPasswordRepeat.Text).WithMessage("Новый пароль совпадает с текущим!");
        }

        private bool CheckCurrentPassword(string currentPassword)
        {
            var userRepository = IocManager.Resolve<IUserRepository>();
            return userRepository.IsExist(Session.CurrentUser.Login, currentPassword);
        }
    }
}
