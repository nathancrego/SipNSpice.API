using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SipNSpice.API.Models.Domain;
using SipNSpice.API.Models.DTO;
using SipNSpice.API.Repositories.Implementation;
using SipNSpice.API.Repositories.Interface;

namespace SipNSpice.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrinkImagesController : ControllerBase
    {
        private readonly IDrinkImageRepository drinkImageRepository;

        public DrinkImagesController(IDrinkImageRepository drinkImageRepository)
        {
            this.drinkImageRepository = drinkImageRepository;
        }

        //POST:
        [HttpPost]
        public async Task<IActionResult> UploadDrinkImage([FromForm] IFormFile file,
            [FromForm] string fileName, [FromForm] string title)
        {
            ValidateFileUpload(file);
            if(ModelState.IsValid)
            {
                var drinkImage = new DrinkImage
                {
                    FileName = fileName,
                    FileExtension = Path.GetExtension(file.FileName).ToLower(),
                    Title = title,
                    DateCreated = DateTime.Now,
                };
                drinkImage = await drinkImageRepository.Upload(file, drinkImage);

                //convert to dto
                var response = new DrinkImageDto
                {
                    Id = drinkImage.Id,
                    Title = drinkImage.Title,
                    DateCreated = drinkImage.DateCreated,
                    FileExtension = drinkImage.FileExtension,
                    FileName = drinkImage.FileName,
                    Url = drinkImage.Url
                };
                return Ok(drinkImage);
            }
            return BadRequest(ModelState);
        }

        private void ValidateFileUpload(IFormFile file)
        {
            var allowedExtensions = new string[] { ".jpg", ".jpeg", ".png" };
            if (!allowedExtensions.Contains(Path.GetExtension(file.FileName).ToLower()))
            {
                ModelState.AddModelError("file", "Unsupported file format");
            }
            if (file.Length > 10485760)
            {
                ModelState.AddModelError("file", "File size cannot be greater than 10 mb");
            }
        }


        //GET:  
        [HttpGet]
        public async Task<IActionResult> GetAllRecipeImages()
        {
            //call recipeimage repository to get all recipe images
            var images = await drinkImageRepository.GetAll();

            //convert to dto
            var response = new List<DrinkImageDto>();
            foreach (var image in images)
            {
                response.Add(new DrinkImageDto
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
