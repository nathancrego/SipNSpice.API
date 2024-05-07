using SipNSpice.API.Models.Domain;

namespace SipNSpice.API.Repositories.Interface
{
    public interface IDrinkRepository
    {
        Task<Drink> CreateAsync(Drink drink);
        Task<IEnumerable<Drink>> GetAllAsync();
        Task<Drink?> GetByIdAsync(Guid id);
        Task<Drink?> UpdateAsync(Drink drink);
        Task<Drink?> DeleteAsync(Guid id);
    }
}
