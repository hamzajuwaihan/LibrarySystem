using FluentValidation;
using LibrarySystem.Application.Commands;

namespace LibrarySystem.Api.Abstractions;
/// <summary>
/// Class to add validation for add book command
/// </summary>
public class AddBookCommandValidator : AbstractValidator<AddBookCommand>
{
    /// <summary>
    /// Define business validation for add book command
    /// </summary>
    public AddBookCommandValidator()
    {
        RuleFor(command => command.Title)
            .NotEmpty().WithMessage("Title is required")
            .MaximumLength(100).WithMessage("Title cannot be longer than 100 characters");

        RuleFor(command => command.AuthorId)
            .NotEmpty().WithMessage("AuthorId is required");

        RuleFor(command => command.ISBN)
            .NotEmpty().WithMessage("ISBN is required");

        RuleFor(command => command.PublishedDate)
            .LessThanOrEqualTo(DateTime.Now).WithMessage("Published date cannot be in the future");

        RuleFor(command => command.AvailableCopies)
            .GreaterThanOrEqualTo(0).WithMessage("Available copies must be a positive number");
    }
}
