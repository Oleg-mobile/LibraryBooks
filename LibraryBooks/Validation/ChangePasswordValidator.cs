using FluentValidation;
using LibraryBooks.Extentions;
using LibraryBooks.Forms;
using LibraryBooks.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBooks.Validation
{
    public class ChangePasswordValidator : AbstractValidator<FormPasswordChange>
    {
        public ChangePasswordValidator()
        {
            RuleFor(r => r.textBoxOldPassword.Text).NotNull().NotEmpty().WithMessage("Введите текущий пароль");
            RuleFor(r => r.textBoxNewPassword.Text).NotNull().NotEmpty().WithMessage("Пароль не может быть пустой!");
            RuleFor(r => r.textBoxNewPassword.Text).Equal(r => r.textBoxNewPasswordRepeat.Text).WithMessage("Пароли не совпадают!");
            RuleFor(r => r.textBoxOldPassword.Text).NotEqual(r => r.textBoxNewPasswordRepeat.Text).WithMessage("Новый пароль совпадает с текущим!");

            //if (!_userRepository.IsExist(Session.CurrentUser.Login, textBoxOldPsswd.Text))
            //{
            //    MessageBoxExtention.WarningInput("Текущий пароль введён не верно!");
            //    return;
            //}

        }
    }
}
