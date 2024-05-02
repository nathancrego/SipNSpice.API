using SipNSpice.API.Models.Domain;

namespace SipNSpice.API.Repositories.Interface
{
    public interface IBaseRepository
    {
        Task<Base> CreateAsync(Base bases);
        Task<IEnumerable<Base>> GetAllAsync();
        Task<Base?> GetByIdAsync(Guid id);
        Task<Base?> UpdateAsync (Base bases);
        Task<Base?> DeleteAsync (Guid id);
    }
}
