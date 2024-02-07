using System.ComponentModel.DataAnnotations;

namespace LibraryApp.Infrastructure.Entities;

public class CategoryEntity
{
    [Key]
    public int CategoryID { get; set; }
    public string CategoryName { get; set; } = null!;
}
