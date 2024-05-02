using Microsoft.EntityFrameworkCore;
using SipNSpice.API.Data;
using SipNSpice.API.Models.Domain;
using SipNSpice.API.Repositories.Interface;

namespace SipNSpice.API.Repositories.Implementation
{
    public class BaseRepository : IBaseRepository
    {
        private readonly ApplicationDbContext dbContext;

        public BaseRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Base> CreateAsync(Base bases)
        {
            await dbContext.Bases.AddAsync(bases);
            await dbContext.SaveChangesAsync();
            return bases;
        }

        public async Task<Base?> DeleteAsync(Guid id)
        {
            var existingBase = dbContext.Bases.FirstOrDefault(b => b.Id == id);
            if(existingBase is null)
            {
                return null;
            }
            dbContext.Bases.Remove(existingBase);
            await dbContext.SaveChangesAsync();
            return existingBase;
        }

        public async Task<IEnumerable<Base>> GetAllAsync()
        {
            return await dbContext.Bases.ToListAsync();
        }

        public async Task<Base?> GetByIdAsync(Guid id)
        {
            return await dbContext.Bases.FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<Base?> UpdateAsync(Base bases)
        {
            var existingBase = await dbContext.Bases.FirstOrDefaultAsync(a => a.Id == bases.Id);
            if(existingBase != null)
            {
                dbContext.Entry(existingBase).CurrentValues.SetValues(bases);
                await dbContext.SaveChangesAsync();
                return existingBase;
            }
            return null;
            
        }
    }
}
