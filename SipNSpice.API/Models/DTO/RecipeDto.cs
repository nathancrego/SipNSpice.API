using SipNSpice.API.Models.Domain;

namespace SipNSpice.API.Models.DTO
{
    public class RecipeDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string ImageUrl { get; set; }
        public DateTime PublishedDate { get; set; }
        public List<CuisineDto> Cuisines { get; set; } = new List<CuisineDto>();
    }
}
