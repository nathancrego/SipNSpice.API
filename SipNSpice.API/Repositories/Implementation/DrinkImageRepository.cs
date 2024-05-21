using Microsoft.EntityFrameworkCore;
using SipNSpice.API.Data;
using SipNSpice.API.Models.Domain;
using SipNSpice.API.Repositories.Interface;

namespace SipNSpice.API.Repositories.Implementation
{
    public class DrinkImageRepository : IDrinkImageRepository
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly ApplicationDbContext dbContext;

        public DrinkImageRepository(IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor, ApplicationDbContext dbContext)
        {
            this.webHostEnvironment = webHostEnvironment;
            this.httpContextAccessor = httpContextAccessor;
            this.dbContext = dbContext;
        }
        public async Task<IEnumerable<DrinkImage>> GetAll()
        {
            return await dbContext.DrinkImages.ToListAsync();
        }

        public async Task<DrinkImage> Upload(IFormFile file, DrinkImage drinkImage)
        {
            //1-Create a local images folder(images)
            var localPath = Path.Combine(webHostEnvironment.ContentRootPath, "Images/Drinks", $"{drinkImage.FileName}{drinkImage.FileExtension}");
            using var stream = new FileStream(localPath, FileMode.Create);
            await file.CopyToAsync(stream);

            //2- Update the databse
            //https://sipnspice.com/images/recipes/somefile.jpg
            var httpRequest = httpContextAccessor.HttpContext.Request;
            var urlPath = $"{httpRequest.Scheme}://{httpRequest.Host}{httpRequest.PathBase}/Images/Drinks/{drinkImage.FileName}{drinkImage.FileExtension}";

            drinkImage.Url = urlPath;
            await dbContext.DrinkImages.AddAsync(drinkImage);
            await dbContext.SaveChangesAsync();

            return drinkImage;

        }
    }
}
