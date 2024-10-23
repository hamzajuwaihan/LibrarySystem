using LibrarySystem.Domain.Entities;


namespace LibrarySystem.infrastructure.Repositories;
/// <summary>
/// Contract for Book Repository
/// </summary>
public interface IBookRepository
{
    Task<Book?> GetByIdAsync(Guid id);
    Task<IEnumerable<Book>> GetAllAsync();
    Task AddAsync(Book book);
    Task<Book> UpdateAsync(Book book);
    Task<bool> DeleteAsync(Guid id);
}
