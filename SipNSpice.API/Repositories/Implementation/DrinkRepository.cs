using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SipNSpice.API.Data;
using SipNSpice.API.Models.Domain;
using SipNSpice.API.Repositories.Interface;

namespace SipNSpice.API.Repositories.Implementation
{
    public class DrinkRepository : IDrinkRepository
    {
        private readonly ApplicationDbContext dbContext;

        public DrinkRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Drink> CreateAsync(Drink drink)
        {
            await dbContext.Drinks.AddAsync(drink);
            await dbContext.SaveChangesAsync();
            return drink;
        }

        public async Task<Drink?> DeleteAsync(Guid id)
        {
            var existingDrink = await dbContext.Drinks.FirstOrDefaultAsync(x=> x.Id == id);
            if(existingDrink != null)
            {
                dbContext.Drinks.Remove(existingDrink);
                await dbContext.SaveChangesAsync();
                return existingDrink;
            }
            return null;
        }

        public async Task<IEnumerable<Drink>> GetAllAsync()
        {
            return await dbContext.Drinks.Include(x=>x.Bases).ToListAsync();
        }

        public async Task<Drink?> GetByIdAsync(Guid id)
        {
            return await dbContext.Drinks.Include(x=>x.Bases).FirstOrDefaultAsync(x=>x.Id == id);
        }

        public async Task<IEnumerable<Drink?>> GetCocktailsAsync()
        {
            return await dbContext.Drinks.Include(x => x.Bases).Where(x => x.Bases.Any(b => b.Name != "Non Alcoholic")).ToListAsync();
        }

        public async Task<Drink?> GetDrinkByBaseAsync(string basename)
        {
            return await dbContext.Drinks.Include(x => x.Bases).FirstOrDefaultAsync(x => x.Bases.Any(b => b.Name == basename));
            
        }

        public async Task<IEnumerable<Drink?>> GetMocktailsAsync()
        {
            return await dbContext.Drinks.Include(x => x.Bases).Where(x => x.Bases.Any(b => b.Name == "Non Alcoholic")).ToListAsync();
        }

        public async Task<Drink?> UpdateAsync(Drink drink)
        {
            var existingDrink = await dbContext.Drinks.Include(x=>x.Bases).FirstOrDefaultAsync(x=>x.Id==drink.Id);
            if(existingDrink == null)
            {
                return null;
            }
            dbContext.Entry(existingDrink).CurrentValues.SetValues(drink);
            existingDrink.Bases = drink.Bases;
            await dbContext.SaveChangesAsync();
            return drink;
        }
    }
}
