using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SipNSpice.API.Models.Domain;
using SipNSpice.API.Models.DTO;
using SipNSpice.API.Repositories.Interface;

namespace SipNSpice.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeImagesController : ControllerBase
    {
        private readonly IRecipeImageRepository recipeImageRepository;

        public RecipeImagesController(IRecipeImageRepository recipeImageRepository)
        {
            this.recipeImageRepository = recipeImageRepository;
        }
        //POST:{apibaseurl}/api/RecipeImages
        [HttpPost]
        public async Task <IActionResult> UploadRecipeImage([FromForm] IFormFile file,
            [FromForm] string fileName, [FromForm] string title)
        {
            ValidateFileUpload(file);
            if(ModelState.IsValid)
            {
                var recipeImage = new RecipeImage
                {
                    FileName = fileName,
                    FileExtension = Path.GetExtension(file.FileName).ToLower(),
                    Title = title,
                    DateCreated = DateTime.Now,
                };
                recipeImage = await recipeImageRepository.Upload(file, recipeImage);

                //Convert Domain Model to DTO
                var response = new RecipeImageDto
                {
                    Id = recipeImage.Id,
                    Title = recipeImage.Title,
                    DateCreated = recipeImage.DateCreated,
                    FileExtension = recipeImage.FileExtension,
                    FileName = recipeImage.FileName,
                    Url = recipeImage.Url
                };
                return Ok (recipeImage);
            }
            return BadRequest(ModelState);
        }

        private void ValidateFileUpload(IFormFile file)
        {
            var allowedExtensions = new string[] { ".jpg", ".jpeg", ".png" };
            if(!allowedExtensions.Contains(Path.GetExtension(file.FileName).ToLower())) 
            {
                ModelState.AddModelError("file", "Unsupported file format");
            }
            if(file.Length > 10485760)
            {
                ModelState.AddModelError("file", "File size cannot be greater than 10 mb");
            }
        }

        //GET:  
        [HttpGet]
        public async Task<IActionResult> GetAllRecipeImages()
        {
            //call recipeimage repository to get all recipe images
            var images = await recipeImageRepository.GetAll();

            //convert to dto
            var response = new List<RecipeImageDto>();
            foreach (var image in images)
            {
                response.Add(new RecipeImageDto
                {
                    Id = image.Id,
                    Title = image.Title,
                    DateCreated = image.DateCreated,
                    FileExtension = image.FileExtension,
                    FileName = image.FileName,
                    Url = image.Url
                });
            }
            return Ok(response);
        }
    }
}
