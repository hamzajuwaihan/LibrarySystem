using LibrarySystem.Domain.Entities;


namespace LibrarySystem.Infrastructure.Repositories;

    public class AuthorRepository : IAuthorRepository
    {
        private readonly List<Author> authors = new List<Author>();

        public Task<Author> GetByIdAsync(Guid id)
        {
            Author? author = authors.SingleOrDefault(a => a.Id == id);
    
            return Task.FromResult(author);
        }

        public Task<IEnumerable<Author>> GetAllAsync()
        {
            return Task.FromResult(authors.AsEnumerable());
        }

        public Task AddAsync(Author author)
        {
            authors.Add(author);
            return Task.CompletedTask;
        }

        public Task UpdateAsync(Author author)
        {
        Author? existingAuthor = authors.SingleOrDefault(a => a.Id == author.Id);
            if (existingAuthor != null)
            {
                authors.Remove(existingAuthor);
                authors.Add(author);
            }
            return Task.CompletedTask;
        }

        public Task DeleteAsync(Guid id)
        {
        Author? author = authors.SingleOrDefault(a => a.Id == id);
            if (author != null)
            {
                authors.Remove(author);
            }
            return Task.CompletedTask;
        }
    }

