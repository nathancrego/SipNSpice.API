namespace SipNSpice.API.Models.DTO
{
    public class CreateRecipeRequestDto
    {
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string ImageUrl { get; set; }
        public DateTime PublishedDate { get; set; }
        public Guid[] Cuisines { get; set; }
    }
}
