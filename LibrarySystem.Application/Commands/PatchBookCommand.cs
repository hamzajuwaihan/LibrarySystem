using LibrarySystem.Domain.Entities;
using LibrarySystem.Domain.ValueObjects;
using MediatR;

namespace LibrarySystem.Application.Commands;
/// <summary>
/// Patch Book Command Class
/// </summary>
public class PatchBookCommand : IRequest<Book>
{
    public Guid Id { get; set; }
    public string? Title { get; set; }
    public Guid? AuthorId { get; set; }
    public ISBN? ISBN { get; set; }
    public DateTime? PublishedDate { get; set; }
    public int? AvailableCopies { get; set; }
}
