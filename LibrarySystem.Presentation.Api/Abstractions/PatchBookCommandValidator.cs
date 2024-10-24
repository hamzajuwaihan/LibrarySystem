using LibrarySystem.Application.Commands;
using FluentValidation;

namespace LibrarySystem.Presentation.Api.Abstractions;

public class PatchBookCommandValidator : AbstractValidator<PatchBookCommand>
{
    /// <summary>
    /// Patch command validation logic
    /// </summary>
    public PatchBookCommandValidator()
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

        RuleFor(command => command.PublishedDate)
            .NotEmpty().WithMessage("Published date is required");
    }

}
