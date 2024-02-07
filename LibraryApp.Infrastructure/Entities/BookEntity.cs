using System.ComponentModel.DataAnnotations;

namespace LibraryApp.Infrastructure.Entities;

public class BookEntity
{
    [Key]
    public int BookID { get; set; }
    public string Title { get; set; } = null!;
    public string Author { get; set; } = null!;
    public int PublishedYear { get; set; }

    public virtual ICollection<BorrowedBookEntity> BorrowedBooks { get; set; } = new List<BorrowedBookEntity>();
    public virtual ICollection<BookCategoryEntity> BookCategories { get; set; } = new List<BookCategoryEntity>();

}
