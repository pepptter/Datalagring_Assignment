using System.ComponentModel.DataAnnotations;

namespace LibraryApp.Infrastructure.Entities;

public class BookEntity
{
    [Key]
    public int BookID { get; set; }

    [Required]
    [StringLength(200)]
    public string Title { get; set; } = null!;

    [Required]
    [StringLength(200)]
    public string Author { get; set; } = null!;

    [Required]
    public int Published_Year { get; set; }

    public ICollection<BorrowedBookEntity> BorrowedBooks { get; set; } = new List<BorrowedBookEntity>();

    public ICollection<BookCategoryEntity> BookCategories { get; set; } = new List<BookCategoryEntity>();

}
