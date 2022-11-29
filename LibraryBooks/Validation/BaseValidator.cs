using FluentValidation;

namespace LibraryBooks.Validation
{
    // Needed to create an instance, because with an abstract class this is not possible
    // (when registering dependencies)
    public class BaseValidator<T> : AbstractValidator<T>
    {
    }
}
