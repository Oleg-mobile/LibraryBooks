using FluentValidation;
using LibraryBooks.Forms;
using System.Text.RegularExpressions;

namespace LibraryBooks.Validation
{
    public class FormReaderValidator : BaseValidator<FormReader>
    {
        public FormReaderValidator()
        {
            var regex = new Regex(@"(^"")|(\w*"")|(^')|(\w*')");
            RuleFor(r => r.textBoxPathToReader.Text).Must(r => !regex.IsMatch(r)).WithMessage("Путь к читалке не должен \n содержать ковычки!");
        }
    }
}
