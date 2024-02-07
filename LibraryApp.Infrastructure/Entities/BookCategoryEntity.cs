using System.ComponentModel.DataAnnotations;

namespace LibraryApp.Infrastructure.Entities;

public class BookCategoryEntity
{
    [Key]
    public int BookCategoryID { get; set; } 
    public int BookID { get; set; }
    public BookEntity Book { get; set; } = null!;

    public int CategoryID { get; set; }
    public CategoryEntity Category { get; set; } = null!;
}
