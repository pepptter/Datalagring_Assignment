namespace LibraryApp.Shared.Dtos
{
    public class BorrowedBookDto
    {
        public int BorrowID { get; set; }
        public int UserID { get; set; }
        public int BookID { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
