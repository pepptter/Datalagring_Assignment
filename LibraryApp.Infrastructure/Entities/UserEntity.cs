using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApp.Infrastructure.Entities;

public class UserEntity
{
    [Key]
    public int UserID { get; set; }
    [Required]
    [Column(TypeName = "nvarchar(30)")]
    public string Firstname { get; set; } = null!;
    [Required]
    [Column(TypeName = "nvarchar(30)")]
    public string Lastname { get; set; } = null!;
    [Required]
    [Column(TypeName = "nvarchar(100)")]
    public string Email { get; set; } = null!;
    [Column(TypeName = "nvarchar(12)")]
    public string? Phonenumber { get; set; }
    public virtual ICollection<BorrowedBookEntity> BorrowedBooks { get; set; } = new List<BorrowedBookEntity>();

}
