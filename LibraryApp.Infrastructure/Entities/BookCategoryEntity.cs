using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApp.Infrastructure.Entities;

public class BookCategoryEntity
{
    [Key]
    public int BookCategoryID { get; set; }

    [Required]
    [ForeignKey("Book")]
    public int BookID { get; set; }
    public BookEntity Book { get; set; } = null!;

    [Required]
    [ForeignKey("Category")]
    public int CategoryID { get; set; }
    public CategoryEntity Category { get; set; } = null!;  
}
