using LibraryApp.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Infrastructure.Contexts;

public class LibraryContext(DbContextOptions<LibraryContext> options) : DbContext(options)
{
    public virtual DbSet<UserEntity> Users { get; set; } = null!;
    public virtual DbSet<BookEntity> Books { get; set; } = null!;
    public virtual DbSet<CategoryEntity> Categories { get; set; } = null!;
    public virtual DbSet<BookCategoryEntity> BookCategories { get; set; } = null!;
    public virtual DbSet<BorrowedBookEntity> BorrowedBooks { get; set; } = null!;

}
