using LibrarySystem.Application.Queries;
using LibrarySystem.Domain.Entities;
using LibrarySystem.Infrastructure.Repositories;
using MediatR;


namespace LibrarySystem.Application.Handlers
{
    public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, Book>
    {
        private readonly IBookRepository _bookRepository;

        public GetBookByIdQueryHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<Book> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            return await _bookRepository.GetByIdAsync(request.BookId);
        }
    }
}
