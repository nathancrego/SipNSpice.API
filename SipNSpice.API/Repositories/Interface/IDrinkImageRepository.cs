using SipNSpice.API.Models.Domain;

namespace SipNSpice.API.Repositories.Interface
{
    public interface IDrinkImageRepository
    {
        Task<DrinkImage> Upload (IFormFile file,DrinkImage drinkImage);
        Task<IEnumerable<DrinkImage>> GetAll();
    }
}
