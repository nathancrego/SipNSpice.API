using SipNSpice.API.Models.Domain;

namespace SipNSpice.API.Repositories.Interface
{
    public interface IRecipeRepository
    {
        Task<Recipe> CreateAsync(Recipe recipe);
        Task<IEnumerable<Recipe>> GetAllAsync();
        Task<Recipe?> GetByIdAsync(Guid id);
        Task<Recipe?> UpdateAsync(Recipe recipe);
        Task<Recipe?> DeleteAsync(Guid id);
    }
}
