using LibrarySystem.Application.Commands;
using LibrarySystem.Domain.Entities;
using LibrarySystem.infrastructure.Repositories;
using LibrarySystem.Domain.Exceptions;

using MediatR;

namespace LibrarySystem.Application.CommandHandlers;

public class PatchBookCommandHandler(IBookRepository bookRepository) : IRequestHandler<PatchBookCommand, Book?>
{
    private readonly IBookRepository _bookRepository = bookRepository;

    public async Task<Book?> Handle(PatchBookCommand request, CancellationToken cancellationToken)
    {
         if (request.Id == Guid.Empty)  throw new IdNullException();
    
        Book? book = await _bookRepository.GetByIdAsync(request.Id);

        if (book == null) return null;

        book.UpdateDetails(request.Title, request.ISBN, request.PublishedDate, request.AvailableCopies);
        
        await _bookRepository.UpdateAsync(book);

        return book;
    }
}
