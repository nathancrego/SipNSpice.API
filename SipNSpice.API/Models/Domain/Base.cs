using System.ComponentModel.DataAnnotations;

namespace SipNSpice.API.Models.Domain
{
    public class Base
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Drink> Drinks { get; set; }
    }
}
