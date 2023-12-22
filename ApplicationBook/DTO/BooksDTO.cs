namespace ApplicationBook.DTO
{
    public class BooksDTO
    {
        public int BookId { get; set; }
        public string BookTitle { get; set; }
        public string BookDescription { get; set; }
        public string Author { get; set; }
        public DateTimeOffset PublishDate { get; set; }
        public string CoverBase64 { get; set; }
    }
}
