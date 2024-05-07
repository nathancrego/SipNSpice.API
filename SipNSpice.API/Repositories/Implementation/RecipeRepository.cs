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

        public async Task<Recipe?> DeleteAsync(Guid id)
        {
            var existingRecipe = await dbContext.Recipes.FirstOrDefaultAsync(x => x.Id == id);
            if(existingRecipe != null)
            {
                dbContext.Recipes.Remove(existingRecipe);
                await dbContext.SaveChangesAsync();
                return existingRecipe;
            }
            return null;
        }

        public async Task<IEnumerable<Recipe>> GetAllAsync()
        {
            return await dbContext.Recipes.Include(x=>x.Cuisines).ToListAsync();
        }

        public async Task<Recipe?> GetByIdAsync(Guid id)
        {
            return await dbContext.Recipes.Include(x=>x.Cuisines).FirstOrDefaultAsync(x=>x.Id == id);
        }

        public async Task<Recipe?> UpdateAsync(Recipe recipe)
        {
            var existingRecipe = await dbContext.Recipes.Include(x=>x.Cuisines).FirstOrDefaultAsync(x=>x.Id==recipe.Id);
            if(existingRecipe == null)
            {
                return null;
            }
            dbContext.Entry(existingRecipe).CurrentValues.SetValues(recipe);
            existingRecipe.Cuisines = recipe.Cuisines;
            await dbContext.SaveChangesAsync();
            return existingRecipe;
        }
    }
}
