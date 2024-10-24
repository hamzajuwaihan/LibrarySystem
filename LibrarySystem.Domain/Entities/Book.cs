using LibrarySystem.Domain.Primitives;
using LibrarySystem.Domain.ValueObjects;

namespace LibrarySystem.Domain.Entities;
/// <summary>
/// Book entity definiion (Domain Class)
/// </summary>
public class Book : Entity
{
    public required string Title { get; set; }
    public required Guid AuthorId { get; set; }
    public required ISBN ISBN { get; set; }
    public DateTime PublishedDate { get; private set; }
    public int AvailableCopies { get; private set; }

    // Private constructor for EF Core
    private Book() : base(Guid.Empty) { }

    public Book(Guid id, string title, Guid authorId, ISBN isbn, DateTime publishedDate, int availableCopies)
     : base(id)  // Pass id to the Entity base class
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            throw new ArgumentException("Title cannot be null or empty.", nameof(title));
        }

        Title = title;
        AuthorId = authorId;
        ISBN = isbn ?? throw new ArgumentNullException(nameof(isbn), "ISBN cannot be null.");
        PublishedDate = publishedDate;
        AvailableCopies = availableCopies;
    }

    /// <summary>
    /// Factory method to create new Book Object
    /// </summary>
    /// <param name="id"></param>
    /// <param name="title"></param>
    /// <param name="authorId"></param>
    /// <param name="isbn"></param>
    /// <param name="publishedDate"></param>
    /// <param name="availableCopies"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    /// <exception cref="ArgumentNullException"></exception>
    public static Book Create(Guid id, string title, Guid authorId, ISBN isbn, DateTime publishedDate, int availableCopies)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            throw new ArgumentException("Title cannot be null or empty.", nameof(title));
        }

        if (isbn == null)
        {
            throw new ArgumentNullException(nameof(isbn), "ISBN cannot be null.");
        }

        return new Book
        {
            Id = id,
            Title = title,
            AuthorId = authorId,
            ISBN = isbn,
            PublishedDate = publishedDate,
            AvailableCopies = availableCopies
        };
    }

    public void UpdateDetails(string? title, ISBN? isbn, DateTime? publishedDate, int? availableCopies)
    {
        if (!string.IsNullOrEmpty(title))
        {
            Title = title;
        }

        if (isbn != null)
        {
            ISBN = isbn;
        }

        if (publishedDate.HasValue && publishedDate.Value <= DateTime.Now)
        {
            PublishedDate = publishedDate.Value;
        }

        if (availableCopies.HasValue && availableCopies.Value >= 0)
        {
            AvailableCopies = availableCopies.Value;
        }
    }
}
