using SipNSpice.API.Models.Domain;

namespace SipNSpice.API.Repositories.Interface
{
    public interface IRecipeImageRepository
    {
        Task<RecipeImage> Upload(IFormFile file, RecipeImage recipeImage);

        Task<IEnumerable<RecipeImage>> GetAll();
    }
}
