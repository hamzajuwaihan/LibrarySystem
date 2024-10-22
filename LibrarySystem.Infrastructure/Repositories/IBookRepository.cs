using LibrarySystem.Domain.Entities;


namespace LibrarySystem.Infrastructure.Repositories;

    public interface IBookRepository
    {
        Task<Book> GetByIdAsync(Guid id);
        Task<IEnumerable<Book>> GetAllAsync();
        Task AddAsync(Book book);
        Task<Book> UpdateAsync(Book book);
        Task DeleteAsync(Guid id);
    }
