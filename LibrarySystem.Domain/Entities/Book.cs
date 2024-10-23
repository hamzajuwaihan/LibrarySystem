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
    private Book() : base(Guid.NewGuid()) { }

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
            Title = title,
            AuthorId = authorId,
            ISBN = isbn,
            PublishedDate = publishedDate,
            AvailableCopies = availableCopies
        };
    }
}
