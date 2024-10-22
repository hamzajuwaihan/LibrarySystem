using LibrarySystem.Domain.Entities;
using LibrarySystem.Domain.ValueObjects;
using MediatR;

namespace LibrarySystem.Application.Commands;

public class UpdateBookCommand : IRequest<Book>
{
    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public Guid AuthorId { get; private set; }
    public ISBN ISBN { get; private set; }
    public DateTime PublishedDate { get; private set; }
    public int AvailableCopies { get; private set; }

    public UpdateBookCommand(Guid id, string title, Guid authorId, ISBN isbn, DateTime publishedDate, int availableCopies)
    {
        Id = id;
        Title = title;
        AuthorId = authorId;
        ISBN = isbn;
        PublishedDate = publishedDate;
        AvailableCopies = availableCopies;
    }
}
