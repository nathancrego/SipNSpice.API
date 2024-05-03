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

        public async Task<IEnumerable<Drink>> GetAllAsync()
        {
            return await dbContext.Drinks.Include(x=>x.Bases).ToListAsync();
        }
    }
}
