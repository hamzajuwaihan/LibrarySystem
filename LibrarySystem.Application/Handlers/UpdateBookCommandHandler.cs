using LibrarySystem.Application.Commands;
using LibrarySystem.Domain.Entities;
using LibrarySystem.Infrastructure.Repositories;
using MediatR;

namespace LibrarySystem.Application.Handlers;

public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, Book>
{
    private readonly IBookRepository _bookRepoistory;

    public UpdateBookCommandHandler(IBookRepository bookRepository)
    {
        _bookRepoistory = bookRepository;
    }
    public static Book ToBook(UpdateBookCommand command)
    {
        return new Book(
            command.Id,
            command.Title,
            command.AuthorId,
            command.ISBN,
            command.PublishedDate,
            command.AvailableCopies
        );
    }

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
