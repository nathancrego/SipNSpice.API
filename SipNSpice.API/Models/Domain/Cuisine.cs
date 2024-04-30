using System.ComponentModel.DataAnnotations;

namespace SipNSpice.API.Models.Domain
{
    public class Cuisine
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string MainCuisine { get; set; }
        [Required]
        public string SubCuisine { get; set; }
        public ICollection<Recipe> Recipes { get; set; }
    }
}
