using System.ComponentModel.DataAnnotations;

namespace SipNSpice.API.Models.Domain
{
    public class Cuisine
    {
        public Guid Id { get; set; }
        public string MainCuisine { get; set; }
        public string SubCuisine { get; set; }
        public ICollection<Recipe> Recipes { get; set; }
    }
}
