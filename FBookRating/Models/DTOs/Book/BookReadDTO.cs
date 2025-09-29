namespace FBookRating.Models.DTOs.Book
{
    public class BookReadDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public string Description { get; set; }
        public DateTime PublishedDate { get; set; }
        public string CoverImageUrl { get; set; }
        
        // Display names for UI
        public string AuthorName { get; set; }
        public string PublisherName { get; set; }
        public string CategoryName { get; set; }
        
        // IDs for editing
        public Guid CategoryId { get; set; }
        public Guid? AuthorId { get; set; }
        public Guid? PublisherId { get; set; }
    }
}
