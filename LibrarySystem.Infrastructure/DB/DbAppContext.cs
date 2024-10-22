using Microsoft.EntityFrameworkCore;
using LibrarySystem.Domain.Entities;

namespace LibrarySystem.Infrastructure.DB
{
    public class DbAppContext : DbContext
    {
        public DbAppContext(DbContextOptions<DbAppContext> options)
            : base(options) { }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define your schema if needed
            modelBuilder.Entity<Book>().HasKey(b => b.Id);

             modelBuilder.Entity<Book>()
                .OwnsOne(b => b.ISBN, isbn =>
                {
                    isbn.Property(i => i.Value).HasColumnName("ISBN");
                });
        }
    }
}
