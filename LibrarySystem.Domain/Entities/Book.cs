using System;
using LibrarySystem.Domain.Primitives;
using LibrarySystem.Domain.ValueObjects;

namespace LibrarySystem.Domain.Entities
{
    public class Book : Entity
    {
        public string Title { get; private set; }
        public Guid AuthorId { get; private set; }
        public ISBN ISBN { get; private set; }
        public DateTime PublishedDate { get; private set; }
        public int AvailableCopies { get; private set; }

        // Private constructor for EF Core
        private Book() : base(Guid.NewGuid()) { }

        // Public constructor for your business logic
        public Book(Guid id, string title, Guid authorId, ISBN isbn, DateTime publishedDate, int availableCopies)
            : base(id)
        {
            Title = title;
            AuthorId = authorId;
            ISBN = isbn;
            PublishedDate = publishedDate;
            AvailableCopies = availableCopies;
        }
    }
}
