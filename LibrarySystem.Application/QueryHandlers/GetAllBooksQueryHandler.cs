using LibrarySystem.Application.Queries;
using LibrarySystem.Domain.Entities;
using LibrarySystem.infrastructure.Repositories;
using MediatR;
namespace LibrarySystem.Application.QueryHandlers;
/// <summary>
/// Handler class for MideatR to handle GetAllBooksQuery.
/// </summary>
/// <param name="bookRepository"></param>
public class GetAllBooksQueryHandler(IBookRepository bookRepository) : IRequestHandler<GetAllBooksQuery, List<Book>>
{

    private readonly IBookRepository _bookRepository = bookRepository;
    /// <summary>
    /// Query handler to get all books.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>List of all books</returns>
    public async Task<List<Book>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
    {

        try
        {
            List<Book> books = (await _bookRepository.GetAllAsync()).ToList();

            return books;

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);

            throw;
        }
    }
}
