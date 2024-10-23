using LibrarySystem.Application.Commands;
using LibrarySystem.Domain.Entities;
using LibrarySystem.Infrastructure.Repositories;
using MediatR;

namespace LibrarySystem.Application.CommandHandlers;
/// <summary>
/// Update book command handler class, update the book from DB
/// </summary>
/// <param name="bookRepository"></param>
public class UpdateBookCommandHandler(IBookRepository bookRepository) : IRequestHandler<UpdateBookCommand, Book>
{
    private readonly IBookRepository _bookRepoistory = bookRepository;
    /// <summary>
    /// Converts the UpdateBookCommand to a Book object
    /// </summary>
    /// <param name="command"></param>
    /// <returns>Book object</returns>
    public static Book ToBook(UpdateBookCommand command)
    {
        return Book.Create(
            command.Id,
            command.Title,
            command.AuthorId,
            command.ISBN,
            command.PublishedDate,
            command.AvailableCopies
        );
    }
    /// <summary>
    /// Handle function execute Update Book Command
    /// </summary>
    /// <param name="updateBookCommand"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Updated book</returns>
    public async Task<Book> Handle(UpdateBookCommand updateBookCommand, CancellationToken cancellationToken)
    {

        try
        {
            Book bookToUpdate = ToBook(updateBookCommand);

            Book updatedBook = await _bookRepoistory.UpdateAsync(bookToUpdate);

            return updatedBook;
        }
        catch (Exception ex)
        {

            Console.WriteLine(ex.Message);
            throw;
        }

    }
}
