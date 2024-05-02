using Microsoft.EntityFrameworkCore;
using SipNSpice.API.Data;
using SipNSpice.API.Models.Domain;
using SipNSpice.API.Repositories.Interface;

namespace SipNSpice.API.Repositories.Implementation
{
    public class CuisineRepository : ICuisineRepository
    {
        private readonly ApplicationDbContext dbContext;

        public CuisineRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Cuisine> CreateAsync(Cuisine cuisine)
        {
            await dbContext.Cuisines.AddAsync(cuisine);
            await dbContext.SaveChangesAsync();
            return cuisine;
        }

        public async Task<Cuisine?> DeleteAsync(Guid id)
        {
            var existingCuisine = await dbContext.Cuisines.FirstOrDefaultAsync(c => c.Id == id);
            if(existingCuisine is null)
            {
                return null;
            }
            dbContext.Cuisines.Remove(existingCuisine);
            await dbContext.SaveChangesAsync();
            return existingCuisine;
        }

        public async Task<IEnumerable<Cuisine>> GetAllAsync()
        {
            return await dbContext.Cuisines.ToListAsync();
        }

        public async Task<Cuisine?> GetByIdAsync(Guid id)
        {
            return await dbContext.Cuisines.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Cuisine?> UpdateAsync(Cuisine cuisine)
        {
            var existingCuisine = await dbContext.Cuisines.FirstOrDefaultAsync(x => x.Id == cuisine.Id);
            if(existingCuisine != null)
            {
                dbContext.Entry(existingCuisine).CurrentValues.SetValues(cuisine);
                await dbContext.SaveChangesAsync();
                return cuisine;
            }
            return null;
        }


    }
}
