using System.ComponentModel.DataAnnotations;

namespace LibraryApp.Infrastructure.Entities;

public class CategoryEntity
{
    [Key]
    public int CategoryID { get; set; }

    [Required]
    [StringLength(200)]
    public string Name { get; set; } = null!;

    public ICollection<BookCategoryEntity> BookCategories { get; set; } = new List<BookCategoryEntity>();
}
