using FluentValidation;
using LibrarySystem.Domain.Entities;

namespace LibrarySystem.Presentation.Api.Abstractions;


public class BookValidator : AbstractValidator<Book>
{
    public BookValidator()
    {

    }

}

