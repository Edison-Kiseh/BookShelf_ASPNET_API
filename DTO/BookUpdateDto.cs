namespace aspnet.DTO
{
    public class BookUpdateDto
    {
        public String CoverImageUrl { get; set; }      
        public String Title { get; set; }         
        public String Description { get; set; }
        public String Author { get; set; }
        public String Genre { get; set; }
        public String ISBN { get; set; }
        public DateTime PublicationDate { get; set; }
    }
}