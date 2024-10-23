using LibrarySystem.Application.Commands;
using LibrarySystem.Infrastructure.Repositories;
using MediatR;

namespace LibrarySystem.Application.CommandHandlers;

/// <summary>
/// Delete book command handler, will delete the book from DB if found
/// </summary>
/// <param name="bookRepository"></param>
public class DeleteBookCommandHandler(IBookRepository bookRepository) : IRequestHandler<DeleteBookCommand, bool>
{
    private readonly IBookRepository _bookRepository = bookRepository ?? throw new ArgumentNullException(nameof(bookRepository));
    /// <summary>
    /// Handler function that exectute delete book command
    /// </summary>
    /// <param name="deleteBookCommand"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
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
