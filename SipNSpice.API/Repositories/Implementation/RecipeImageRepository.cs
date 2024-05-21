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

        public RecipeImageRepository(IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor, ApplicationDbContext dbContext)
        {
            this.webHostEnvironment = webHostEnvironment;
            this.httpContextAccessor = httpContextAccessor;
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<RecipeImage>> GetAll()
        {
            return await dbContext.RecipeImages.ToListAsync();
        }

        public async Task<RecipeImage> Upload(IFormFile file, RecipeImage recipeImage)
        {
            //1-Create a local images folder(images)
            var localPath = Path.Combine(webHostEnvironment.ContentRootPath, "Images/Recipes", $"{recipeImage.FileName}{recipeImage.FileExtension}");
            using var stream = new FileStream(localPath, FileMode.Create);
            await file.CopyToAsync(stream);


            //2- Update the databse
            //https://sipnspice.com/images/recipes/somefile.jpg
            var httpRequest = httpContextAccessor.HttpContext.Request;
            var urlPath = $"{httpRequest.Scheme}://{httpRequest.Host}{httpRequest.PathBase}/Images/Recipes/{recipeImage.FileName}{recipeImage.FileExtension}";
            
            recipeImage.Url = urlPath;
            await dbContext.RecipeImages.AddAsync(recipeImage);
            await dbContext.SaveChangesAsync();

            return recipeImage;
        }
    }
}
