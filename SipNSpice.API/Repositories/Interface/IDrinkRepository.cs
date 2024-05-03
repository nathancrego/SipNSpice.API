using SipNSpice.API.Models.Domain;

namespace SipNSpice.API.Repositories.Interface
{
    public interface IDrinkRepository
    {
        Task<Drink> CreateAsync(Drink drink);
        Task<IEnumerable<Drink>> GetAllAsync();
    }
}
