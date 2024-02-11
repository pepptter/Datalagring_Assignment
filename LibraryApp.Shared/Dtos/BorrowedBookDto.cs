namespace LibraryApp.Business.Dtos
{
    public class BorrowedBookDto
    {
        private static DateTime _currentDateTime = DateTime.Now;
        public int BorrowID { get; set; }
        public int UserID { get; set; }
        public int BookID { get; set; }
        public DateTime BorrowDate { get; set; } = _currentDateTime;
        public DateTime ReturnDate { get; set; } = _currentDateTime.AddDays(14);
    }
}
