using SipNSpice.API.Models.Domain;

namespace SipNSpice.API.Repositories.Interface
{
    public interface ICuisineRepository
    {
        Task<Cuisine> CreateAsync (Cuisine cuisine);
        Task<IEnumerable<Cuisine>> GetAllAsync ();
        Task<Cuisine?> GetByIdAsync(Guid id);
        Task<Cuisine?> UpdateAsync (Cuisine cuisine);
        Task<Cuisine?> DeleteAsync (Guid id);
    }
}
