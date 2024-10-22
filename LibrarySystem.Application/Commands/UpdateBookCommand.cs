using LibrarySystem.Domain.Entities;
using MediatR;

namespace LibrarySystem.Application.Commands;

public class UpdateBookCommand : IRequest<Book>
{
    public Book Book { get; private init; }

    public UpdateBookCommand(Book book)
    {
        Book = book;
    }
}
