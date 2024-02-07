using System.ComponentModel.DataAnnotations;

namespace LibraryApp.Infrastructure.Entities;

public class BorrowedBookEntity
{
    [Key]
    public int BorrowedBookID { get; set; }
    public int UserID { get; set; } 
    public int BookID { get; set; }
    public DateTime BorrowDate { get; set; } = DateTime.Now;
    public DateTime ReturnDate { get; set;} = DateTime.Now.AddDays(14);
}
