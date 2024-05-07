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

        //GET:{apibaseurl}/api/recipes/{id}
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetRecipeById([FromRoute] Guid id)
        {
            var recipe = await recipeRepository.GetByIdAsync(id);
            if(recipe is null)
            {
                return NotFound();
            }
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
            return Ok(response);
        }

        //PUT: /{apibaseurl}/api/recipes/{id}
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateRecipe([FromRoute] Guid id, UpdateRecipeRequestDto updateRecipeRequest)
        {
            var recipe = new Recipe
            {
                Id = id,
                Name = updateRecipeRequest.Name,
                ShortDescription = updateRecipeRequest.ShortDescription,
                Description = updateRecipeRequest.Description,
                ImageUrl = updateRecipeRequest.ImageUrl,
                Author = updateRecipeRequest.Author,
                PublishedDate = updateRecipeRequest.PublishedDate,
                Cuisines = new List<Cuisine>()
            };
            foreach(var cuisineGuid in  updateRecipeRequest.Cuisines)
            {
                var existingCuisine = await cuisineRepository.GetByIdAsync(cuisineGuid);
                if(existingCuisine != null)
                {
                    recipe.Cuisines.Add(existingCuisine);
                }
            }
            var updatedRecipe = await recipeRepository.UpdateAsync(recipe);
            if(updatedRecipe == null)
            {
                return NotFound();
            }
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
            return Ok(response);
        }

        //DELETE: {baseurlapi}/api/recipes/{id}
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteRecipe([FromRoute] Guid id)
        {
            var deletedRecipe = await recipeRepository.DeleteAsync(id);
            if(deletedRecipe == null) 
            { 
                return NotFound(); 
            }
            var response = new RecipeDto
            {
                Id = deletedRecipe.Id,
                Name = deletedRecipe.Name,
                ShortDescription = deletedRecipe.ShortDescription,
                Description = deletedRecipe.Description,
                ImageUrl = deletedRecipe.ImageUrl,
                Author = deletedRecipe.Author,
                PublishedDate = deletedRecipe.PublishedDate
            };
            return Ok(response);
        }

    }
}
