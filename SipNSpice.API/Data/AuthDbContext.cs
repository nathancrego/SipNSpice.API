using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SipNSpice.API.Data
{
    public class AuthDbContext : IdentityDbContext<IdentityUser>
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var readerRoleId = "088926c1-9cee-4c88-aaf5-62bbed2269e8";
            var writerRoleId = "7b6df99e-946a-425a-b312-709296422852";

            //Create reader and writer roles
            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = readerRoleId,
                    Name = "Reader",
                    NormalizedName = "Reader".ToUpper(),
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                },
                new IdentityRole
                {
                    Id = writerRoleId,
                    Name = "Writer",
                    NormalizedName = "Writer".ToUpper(),
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                }
            };

            //Seed the roles
            builder.Entity<IdentityRole>().HasData(roles);

            //Create an admin user
            var adminUserId = "5d571cde-ba20-4e7b-92b0-b7a2b70e0e99";
            var admin = new IdentityUser
            {
                Id = adminUserId,
                UserName = "admin@sipnspice.com",
                Email = "admin@sipnspice.com",
                NormalizedEmail = "admin@sipnspice.com".ToUpper(),
                NormalizedUserName = "admin@sipnspice.com".ToUpper(),
                EmailConfirmed = true
            };

            var passwordHasher = new PasswordHasher<IdentityUser>();
            admin.PasswordHash = passwordHasher.HashPassword(admin, "Sipnspice*Admin@14$");

            //Seed the admin user
            builder.Entity<IdentityUser>().HasData(admin);

            //Assign roles to the Admin user
            var adminRoles = new List<IdentityUserRole<string>>
            {
                new IdentityUserRole<string>
                {
                    UserId = adminUserId,
                    RoleId = readerRoleId
                },
                new IdentityUserRole<string>
                {
                    UserId = adminUserId,
                    RoleId = writerRoleId
                }
            };

            //Seed Admin roles
            builder.Entity<IdentityUserRole<string>>().HasData(adminRoles);

        }
    }
}
