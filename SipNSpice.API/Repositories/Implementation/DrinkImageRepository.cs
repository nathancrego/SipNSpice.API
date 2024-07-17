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
        private readonly BlobService blobService;

        public DrinkImageRepository(IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor, ApplicationDbContext dbContext, BlobService blobService)
        {
            this.webHostEnvironment = webHostEnvironment;
            this.httpContextAccessor = httpContextAccessor;
            this.dbContext = dbContext;
            this.blobService = blobService;
        }
        public async Task<IEnumerable<DrinkImage>> GetAll()
        {
            return await dbContext.DrinkImages.ToListAsync();
        }

        public async Task<DrinkImage> Upload(IFormFile file, DrinkImage drinkImage)
        {
            ////1-Create a local images folder(images)
            //var localPath = Path.Combine(webHostEnvironment.ContentRootPath, "wwwroot/Images/Drinks", $"{drinkImage.FileName}{drinkImage.FileExtension}");
            //using var stream = new FileStream(localPath, FileMode.Create);
            //await file.CopyToAsync(stream);

            ////2- Update the databse
            ////https://sipnspice.com/images/recipes/somefile.jpg
            //var httpRequest = httpContextAccessor.HttpContext.Request;
            //var urlPath = $"{httpRequest.Scheme}://{httpRequest.Host}{httpRequest.PathBase}wwwroot/Images/Drinks/{drinkImage.FileName}{drinkImage.FileExtension}";

            //drinkImage.Url = urlPath;
            //await dbContext.DrinkImages.AddAsync(drinkImage);
            //await dbContext.SaveChangesAsync();

            //return drinkImage;

            if (file == null || file.Length == 0)
            {
                throw new ArgumentException("Image not selected");
            }
            // Upload the file to Azure Blob Storage
            var fileName = $"{drinkImage.FileName}{drinkImage.FileExtension}";
            var fileUrl = await blobService.UploadDrinkFileAsync(file, fileName);

            // Update the database with the URL
            drinkImage.Url = fileUrl;
            await dbContext.DrinkImages.AddAsync(drinkImage);
            await dbContext.SaveChangesAsync();

            return drinkImage;

        }
    }
}
