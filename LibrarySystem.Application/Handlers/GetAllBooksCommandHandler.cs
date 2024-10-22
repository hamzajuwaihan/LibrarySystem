using LibrarySystem.Application.Queries;
using LibrarySystem.Domain.Entities;
using LibrarySystem.Infrastructure.Repositories;
using MediatR;
namespace LibrarySystem.Application.Handlers;

public class GetAllBooksCommandHandler : IRequestHandler<GetAllBooksQuery, List<Book>>
{

    private readonly IBookRepository _bookRepository;

    public GetAllBooksCommandHandler(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

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

            return null;
        }
    }
}
