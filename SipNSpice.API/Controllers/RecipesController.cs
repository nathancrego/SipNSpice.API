using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SipNSpice.API.Models.Domain;
using SipNSpice.API.Models.DTO;
using SipNSpice.API.Repositories.Interface;

namespace SipNSpice.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly IRecipeRepository recipeRepository;
        private readonly ICuisineRepository cuisineRepository;

        public RecipesController(IRecipeRepository recipeRepository, ICuisineRepository cuisineRepository)
        {
            this.recipeRepository = recipeRepository;
            this.cuisineRepository = cuisineRepository;
        }
        //POST:/api/recipes
        [HttpPost]
        public async Task<IActionResult> CreateRecipe([FromBody] CreateRecipeRequestDto createRecipeRequest)
        {
            //Convert DTO to Domain Model
            var recipe = new Recipe
            {
                Name = createRecipeRequest.Name,
                ShortDescription = createRecipeRequest.ShortDescription,
                Description = createRecipeRequest.Description,
                ImageUrl = createRecipeRequest.ImageUrl,
                Author = createRecipeRequest.Author,
                PublishedDate = createRecipeRequest.PublishedDate,
                Cuisines = new List<Cuisine>()
                
            };
            //loop through cuisines
            foreach(var cuisineGuid in createRecipeRequest.Cuisines)
            {
                var existingCuisine = await cuisineRepository.GetByIdAsync(cuisineGuid);
                if(existingCuisine != null)
                {
                    recipe.Cuisines.Add(existingCuisine);
                }
            }

            recipe = await recipeRepository.CreateAsync(recipe);

            //map Domain model back to DTO
            var response = new RecipeDto
            {
                Id = recipe.Id,
                Name = recipe.Name,
                ShortDescription = recipe.ShortDescription,
                Description = recipe.Description,
                ImageUrl = recipe.ImageUrl,
                Author = recipe.Author,
                PublishedDate = recipe.PublishedDate,
                Cuisines = recipe.Cuisines.Select(x => new CuisineDto
                {
                    Id = x.Id,
                    MainCuisine = x.MainCuisine,
                    SubCuisine = x.SubCuisine
                }).ToList()
            };
            return Ok (response);
        }

        //GET: /api/recipes
        [HttpGet]
        public async Task<IActionResult> GetAllRecipe()
        {
            var recipes = await recipeRepository.GetAllAsync();

            //Convert Domain Model to DTO
            var response = new List<RecipeDto>();
            foreach(var recipe in recipes)
            {
                response.Add(new RecipeDto
                {
                    Id = recipe.Id,
                    Name = recipe.Name,
                    ShortDescription = recipe.ShortDescription,
                    Description = recipe.Description,
                    ImageUrl = recipe.ImageUrl,
                    Author = recipe.Author,
                    PublishedDate = recipe.PublishedDate,
                    Cuisines = recipe.Cuisines.Select(x=> new CuisineDto
                    {
                        Id = x.Id,
                        MainCuisine = x.MainCuisine,
                        SubCuisine = x.SubCuisine
                    }).ToList()
                });
            }
            return Ok (response);
        }
    }
}
