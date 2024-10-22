using LibrarySystem.Application.Commands;
using LibrarySystem.Domain.Entities;
using LibrarySystem.Domain.ValueObjects;
using LibrarySystem.Infrastructure.Repositories;
using MediatR;

namespace LibrarySystem.Application.Handlers
{
    public class AddBookCommandHandler : IRequestHandler<AddBookCommand, Book>
    {
        private readonly IBookRepository _bookRepository;

        public AddBookCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<Book> Handle(AddBookCommand request, CancellationToken cancellationToken)
        {
            var isbnValueObject = new ISBN(request.ISBN); // Create the ISBN object from string

            var book = new Book(
                Guid.NewGuid(), // Generate a new ID
                request.Title,
                request.AuthorId,
                isbnValueObject, // Use the ISBN object
                request.PublishedDate,
                request.AvailableCopies
            );

            await _bookRepository.AddAsync(book);
            return book;
        }
    }
}