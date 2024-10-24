using LibrarySystem.Application.Queries;
using LibrarySystem.Domain.Entities;
using LibrarySystem.infrastructure.Repositories;
using MediatR;


namespace LibrarySystem.Application.QueryHandlers;
/// <summary>
/// GetBookByIdQueryHandler class that contains the handle method
/// </summary>
/// <param name="bookRepository"></param>
public class GetBookByIdQueryHandler(IBookRepository bookRepository) : IRequestHandler<GetBookByIdQuery, Book?>
{
    private readonly IBookRepository _bookRepository = bookRepository;
    /// <summary>
    /// Handle method to execute GetBookByIdQuery
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Signle book object if found</returns>
    public async Task<Book?> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
    {
        var book = await _bookRepository.GetByIdAsync(request.BookId);

        if (book == null) return null;

        return book;
    }
}
