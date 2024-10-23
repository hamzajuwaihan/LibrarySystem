using MediatR;
using LibrarySystem.Domain.Entities;

namespace LibrarySystem.Application.Commands;
/// <summary>
/// Add book command to send for MideatR
/// </summary>
/// <param name="title"></param>
/// <param name="authorId"></param>
/// <param name="isbn"></param>
/// <param name="publishedDate"></param>
/// <param name="availableCopies"></param>
public class AddBookCommand(string title, Guid authorId, string isbn, DateTime publishedDate, int availableCopies) : IRequest<Book>
{
    public string Title { get; } = title;
    public Guid AuthorId { get; } = authorId;
    public string ISBN { get; } = isbn;
    public DateTime PublishedDate { get; } = publishedDate;
    public int AvailableCopies { get; } = availableCopies;
}
