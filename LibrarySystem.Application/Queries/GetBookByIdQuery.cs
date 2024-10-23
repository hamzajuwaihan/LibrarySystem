using MediatR;
using LibrarySystem.Domain.Entities;

namespace LibrarySystem.Application.Queries;
/// <summary>
/// GetBookByIdQuery class for MideatR
/// </summary>
/// <param name="bookId"></param>
public class GetBookByIdQuery(Guid bookId) : IRequest<Book>
{
    public Guid BookId { get; } = bookId;
}
