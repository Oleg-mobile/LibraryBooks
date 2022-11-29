using FluentValidation;
using LibraryBooks.Forms;

namespace LibraryBooks.Validation
{
    public class RegistrationValidator : BaseValidator<FormRegistration>
    {
        public RegistrationValidator()
        {
            RuleFor(r => r.textBoxName.Text).NotNull().NotEmpty().WithMessage("Введите логин!");
            RuleFor(r => r.textBoxPassword.Text).NotNull().NotEmpty().WithMessage("Введите пароль!");
            RuleFor(r => r.textBoxPassword.Text).Equal(r => r.textBoxPasswordRepeat.Text).WithMessage("Пароли не совпадают!");
        }
    }
}
