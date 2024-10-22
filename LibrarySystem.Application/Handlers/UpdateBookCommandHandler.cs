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

    public async Task<Book> Handle(UpdateBookCommand updateBookCommand, CancellationToken cancellationToken)
    {

        try
        {
            Book updatedBook = await _bookRepoistory.UpdateAsync(updateBookCommand.Book);

            return updatedBook;
        }
        catch (Exception ex)
        {

            Console.WriteLine(ex.Message);
            throw;
        }

    }
}
