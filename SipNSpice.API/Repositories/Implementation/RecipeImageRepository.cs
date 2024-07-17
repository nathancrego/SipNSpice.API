using Microsoft.EntityFrameworkCore;
using SipNSpice.API.Data;
using SipNSpice.API.Models.Domain;
using SipNSpice.API.Repositories.Interface;

namespace SipNSpice.API.Repositories.Implementation
{
    public class RecipeImageRepository : IRecipeImageRepository
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly ApplicationDbContext dbContext;
        private readonly BlobService blobService;

        public RecipeImageRepository(IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor, ApplicationDbContext dbContext, BlobService blobService)
        {
            this.webHostEnvironment = webHostEnvironment;
            this.httpContextAccessor = httpContextAccessor;
            this.dbContext = dbContext;
            this.blobService = blobService;
        }

        public async Task<IEnumerable<RecipeImage>> GetAll()
        {
            return await dbContext.RecipeImages.ToListAsync();
        }

        public async Task<RecipeImage> Upload(IFormFile file, RecipeImage recipeImage)
        {
            ////1-Create a local images folder(images)
            //var localPath = Path.Combine(webHostEnvironment.ContentRootPath, "wwwroot/Images/Recipes", $"{recipeImage.FileName}{recipeImage.FileExtension}");
            //using var stream = new FileStream(localPath, FileMode.Create);
            //await file.CopyToAsync(stream);


            ////2- Update the databse
            ////https://sipnspice.com/images/recipes/somefile.jpg
            //var httpRequest = httpContextAccessor.HttpContext.Request;
            //var urlPath = $"{httpRequest.Scheme}://{httpRequest.Host}{httpRequest.PathBase}wwwroot/Images/Recipes/{recipeImage.FileName}{recipeImage.FileExtension}";
            
            //recipeImage.Url = urlPath;
            //await dbContext.RecipeImages.AddAsync(recipeImage);
            //await dbContext.SaveChangesAsync();

            //return recipeImage;

            if(file == null || file.Length == 0)
            {
                throw new ArgumentException("Image not selected");
            }
            // Upload the file to Azure Blob Storage
            var fileName = $"{recipeImage.FileName}{recipeImage.FileExtension}";
            var fileUrl = await blobService.UploadRecipeFileAsync(file, fileName);

            // Update the database with the URL
            recipeImage.Url = fileUrl;
            await dbContext.RecipeImages.AddAsync(recipeImage);
            await dbContext.SaveChangesAsync();

            return recipeImage;
        }
    }
}
