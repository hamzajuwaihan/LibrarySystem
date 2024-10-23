using FluentValidation;
using LibrarySystem.Application.Commands;

namespace LibrarySystem.Api.Abstractions;
/// <summary>
/// Validator for update book command value.
/// </summary>
public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
{
    /// <summary>
    /// Define business rules for updating book validation
    /// </summary>
    public UpdateBookCommandValidator()
    {
        RuleFor(command => command.Title).NotEmpty().WithMessage("Title is required");
    }
}
