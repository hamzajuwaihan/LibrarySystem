using MediatR;
using LibrarySystem.Domain.Entities;

namespace LibrarySystem.Application.Commands
{
    public class AddBookCommand : IRequest<Book>
    {
        public string Title { get; }
        public Guid AuthorId { get; }
        public string ISBN { get; }  // Keep it as string
        public DateTime PublishedDate { get; }
        public int AvailableCopies { get; }

        public AddBookCommand(string title, Guid authorId, string isbn, DateTime publishedDate, int availableCopies)
        {
            Title = title;
            AuthorId = authorId;
            ISBN = isbn;
            PublishedDate = publishedDate;
            AvailableCopies = availableCopies;
        }
    }
}
