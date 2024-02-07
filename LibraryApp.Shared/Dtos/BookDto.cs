namespace LibraryApp.Shared.Dtos
{
    public class BookDto
    {
        public string Author { get; set; } = null!;
        public int BookID { get; set; }
        public int Published_Year { get; set; }
        public string Title { get; set; } = null!;
    }
}