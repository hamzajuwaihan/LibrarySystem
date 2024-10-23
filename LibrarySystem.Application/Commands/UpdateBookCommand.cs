using LibrarySystem.Domain.Entities;
using LibrarySystem.Domain.ValueObjects;
using MediatR;

namespace LibrarySystem.Application.Commands;
/// <summary>
/// Update book command to send for MideatR
/// </summary>
/// <param name="id"></param>
/// <param name="title"></param>
/// <param name="authorId"></param>
/// <param name="isbn"></param>
/// <param name="publishedDate"></param>
/// <param name="availableCopies"></param>
public class UpdateBookCommand(Guid id, string title, Guid authorId, ISBN isbn, DateTime publishedDate, int availableCopies) : IRequest<Book>
{
    public Guid Id { get; private set; } = id;
    public string Title { get; private set; } = title;
    public Guid AuthorId { get; private set; } = authorId;
    public ISBN ISBN { get; private set; } = isbn;
    public DateTime PublishedDate { get; private set; } = publishedDate;
    public int AvailableCopies { get; private set; } = availableCopies;
}
