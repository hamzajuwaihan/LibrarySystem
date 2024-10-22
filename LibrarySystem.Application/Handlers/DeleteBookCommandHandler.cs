using LibrarySystem.Application.Commands;
using LibrarySystem.Infrastructure.Repositories;
using MediatR;

namespace LibrarySystem.Application.Handlers;

public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, bool>
{
    private readonly IBookRepository _bookRepository;

    public DeleteBookCommandHandler(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;

    }

    public async Task<bool> Handle(DeleteBookCommand deleteBookCommand, CancellationToken cancellationToken)
    {

        try
        {
            await _bookRepository.DeleteAsync(deleteBookCommand.Id);
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error deleting book: {e.Message}");
            return false;
        }
    }

}
