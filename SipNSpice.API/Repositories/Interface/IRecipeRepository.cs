using SipNSpice.API.Models.Domain;

namespace SipNSpice.API.Repositories.Interface
{
    public interface IRecipeRepository
    {
        Task<Recipe> CreateAsync(Recipe recipe);
        Task<IEnumerable<Recipe>> GetAllAsync();
    }
}
