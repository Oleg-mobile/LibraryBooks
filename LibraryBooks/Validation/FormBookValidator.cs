using FluentValidation;
using LibraryBooks.Forms;
using System.Text.RegularExpressions;

namespace LibraryBooks.Validation
{
    public class FormBookValidator : AbstractValidator<FormBook>
    {
        public FormBookValidator()
        {
            Transform(from: r => r.textBoxYear.Text, to: v => int.TryParse(v, out int year) ? (int?)year : null)  // !int.TryParse()
                .NotNull()
                .WithMessage("Не верный формат года");

            Transform(from: r => r.textBoxPageCount.Text, to: v => int.TryParse(v, out int pageCount) ? (int?)pageCount : null)
                .NotNull()
                .WithMessage("Не верный формат количества страниц");

            Transform(from: r => r.textBoxMark.Text, to: v => int.TryParse(v, out int mark) ? (int?)mark : null)
                .NotNull()
                .WithMessage("Не верный формат закладки");

            RuleFor(r => r.comboBoxGenre.SelectedItem).NotNull().WithMessage("Жанр не выбран");
            RuleFor(r => r.comboBoxAuthor.SelectedItem).NotNull().WithMessage("Автор не выбран");

            var regex = new Regex(@"(^"")|(\w*"")|(^')|(\w*')");  // regular expression
                                                                  // ^ - begin with ..., * - any sequence, \w - any character
            RuleFor(r => r.textBoxPathToBook.Text).Must(r => !regex.IsMatch(r)).WithMessage("Путь к книге не должен \n содержать ковычки!");
        }
    }
}
