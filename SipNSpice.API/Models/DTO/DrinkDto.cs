using SipNSpice.API.Models.Domain;

namespace SipNSpice.API.Models.DTO
{
    public class DrinkDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string ImageUrl { get; set; }
        public DateTime PublishedDate { get; set; }
        public ICollection<BaseDto> Bases { get; set; } = new List<BaseDto>();
    }
}
