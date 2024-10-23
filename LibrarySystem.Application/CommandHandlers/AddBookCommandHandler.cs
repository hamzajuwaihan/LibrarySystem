using LibrarySystem.Application.Commands;
using LibrarySystem.Domain.Entities;
using LibrarySystem.Domain.ValueObjects;
using LibrarySystem.Infrastructure.Repositories;
using MediatR;

namespace LibrarySystem.Application.CommandHandlers;
/// <summary>
/// Add book command handler, will create a new book in DB
/// </summary>
/// <param name="bookRepository"></param>
public class AddBookCommandHandler(IBookRepository bookRepository) : IRequestHandler<AddBookCommand, Book>
{
    private readonly IBookRepository _bookRepository = bookRepository;

    public async Task<Book> Handle(AddBookCommand request, CancellationToken cancellationToken)
    {
        ISBN isbnValueObject = new ISBN(request.ISBN);

        Book book = Book.Create(
            Guid.NewGuid(),
            request.Title,
            request.AuthorId,
            isbnValueObject,
            request.PublishedDate,
            request.AvailableCopies
        );

        await _bookRepository.AddAsync(book);
        return book;
    }
}
