using Microsoft.EntityFrameworkCore;
using SipNSpice.API.Data;
using SipNSpice.API.Models.Domain;
using SipNSpice.API.Repositories.Interface;

namespace SipNSpice.API.Repositories.Implementation
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly ApplicationDbContext dbContext;

        public RecipeRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Recipe> CreateAsync(Recipe recipe)
        {
            await dbContext.Recipes.AddAsync(recipe);
            await dbContext.SaveChangesAsync();
            return recipe;
        }

        public async Task<IEnumerable<Recipe>> GetAllAsync()
        {
            return await dbContext.Recipes.Include(x=>x.Cuisines).ToListAsync();
        }
    }
}
