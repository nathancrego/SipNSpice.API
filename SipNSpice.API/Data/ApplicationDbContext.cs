using Microsoft.EntityFrameworkCore;
using SipNSpice.API.Models.Domain;

namespace SipNSpice.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Cuisine> Cuisines { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Base> Bases { get; set; }
        public DbSet<Drink> Drinks { get; set; }
        public DbSet<RecipeImage> RecipeImages { get; set; }
        public DbSet<DrinkImage> DrinkImages { get; set; }
    }
}
