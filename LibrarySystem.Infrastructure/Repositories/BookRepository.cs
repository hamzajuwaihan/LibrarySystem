using LibrarySystem.Domain.Entities;
using LibrarySystem.Infrastructure.EFCore.DB;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.infrastructure.Repositories;
/// <summary>
/// Book Repository that handles Book operations on DB
/// </summary>
/// <param name="context"></param>
public class BookRepository(DbAppContext context) : IBookRepository
{
    private readonly DbAppContext _context = context;
    /// <summary>
    /// Gets the book by id from DB
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Book Object</returns>
    public async Task<Book?> GetByIdAsync(Guid id)
    {
        return await _context.Books.FindAsync(id);
    }

    /// <summary>
    /// Gets all books in DB
    /// </summary>
    /// <returns>List of Books</returns>
    public async Task<IEnumerable<Book>> GetAllAsync()
    {
        return await _context.Books.ToListAsync();
    }
    /// <summary>
    /// Takes a book and add it to DB
    /// </summary>
    /// <param name="book"></param>
    /// <returns></returns>
    public async Task AddAsync(Book book)
    {
        await _context.Books.AddAsync(book);
        await _context.SaveChangesAsync();
    }
    /// <summary>
    /// Updates a book in the DB
    /// </summary>
    /// <param name="book"></param>
    /// <returns></returns>
    public async Task<Book> UpdateAsync(Book book)
    {
        _context.Books.Update(book);
        await _context.SaveChangesAsync();
        return book;
    }
    /// <summary>
    /// Deletes a book in the DB if found
    /// </summary>
    /// <param name="id"></param>
    /// <returns>boolean value</returns>
    public async Task<bool> DeleteAsync(Guid id)
    {
        var book = await GetByIdAsync(id);

        if (book == null) return false;

        _context.Books.Remove(book);
        await _context.SaveChangesAsync();
        return true;
    }
}
