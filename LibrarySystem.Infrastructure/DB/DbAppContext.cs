using Microsoft.EntityFrameworkCore;
using LibrarySystem.Domain.Entities;

namespace LibrarySystem.Infrastructure.DB;

public class DbAppContext(DbContextOptions<DbAppContext> options) : DbContext(options)
{
    public DbSet<Book> Books { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>().HasKey(b => b.Id);

         modelBuilder.Entity<Book>()
            .OwnsOne(b => b.ISBN, isbn =>
            {
                isbn.Property(i => i.Value).HasColumnName("ISBN");
            });
    }
}
