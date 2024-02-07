using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApp.Infrastructure.Entities;

public class BorrowedBookEntity
{
    [Key]
    public int BorrowID { get; set; } 

    [Required]
    [ForeignKey("User")]
    public int UserID { get; set; } 
    public UserEntity User { get; set; } = null!;

    [Required]
    [ForeignKey("Book")]
    public int BookID { get; set; }
    public BookEntity Book { get; set; } = null!;

    [Required]
    public DateTime BorrowDate { get; set; } = DateTime.Now;

    [Required]
    public DateTime ReturnDate { get; set; } = DateTime.Now.AddDays(14);
}
