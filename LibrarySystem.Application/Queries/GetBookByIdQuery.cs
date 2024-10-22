using MediatR;
using System;
using LibrarySystem.Domain.Entities;

namespace LibrarySystem.Application.Queries
{
    public class GetBookByIdQuery : IRequest<Book>
    {
        public Guid BookId { get; }

        public GetBookByIdQuery(Guid bookId)
        {
            BookId = bookId;
        }
    }
}
