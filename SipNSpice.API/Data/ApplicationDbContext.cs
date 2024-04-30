using Microsoft.EntityFrameworkCore;
using SipNSpice.API.Models.Domain;

namespace SipNSpice.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Cuisine> tblsnscuisines { get; set; }
        public DbSet<Recipe> tblsnsrecipes { get; set; }
        public DbSet<Base> tblsnsbases { get; set; }
        public DbSet<Drink> tblsnsdrinks { get; set; }
    }
}
