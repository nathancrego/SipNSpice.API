using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SipNSpice.API.Models.Domain;
using SipNSpice.API.Models.DTO;
using SipNSpice.API.Repositories.Interface;

namespace SipNSpice.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrinksController : ControllerBase
    {
        private readonly IDrinkRepository drinkRepository;
        private readonly IBaseRepository baseRepository;

        public DrinksController(IDrinkRepository drinkRepository, IBaseRepository baseRepository)
        {
            this.drinkRepository = drinkRepository;
            this.baseRepository = baseRepository;
        }

        //POST: api/drinks
        [HttpPost]
        public async Task<IActionResult> CreateDrink([FromBody] CreateDrinkRequestDto createDrinkRequest)
        {
            //Convert DTO to Domain model
            var drink = new Drink
            {
                Name = createDrinkRequest.Name,
                ShortDescription = createDrinkRequest.ShortDescription,
                Description = createDrinkRequest.Description,
                Author = createDrinkRequest.Author,
                ImageUrl = createDrinkRequest.ImageUrl,
                PublishedDate = createDrinkRequest.PublishedDate,
                Bases = new List<Base>()
            };
            //loop through base
            foreach(var baseGuid in createDrinkRequest.Bases)
            {
                var existingBase = await baseRepository.GetByIdAsync(baseGuid);
                if (existingBase != null)
                {
                    drink.Bases.Add(existingBase);
                }
            }

            drink = await drinkRepository.CreateAsync(drink);

            //convert domain model back to dto
            var response = new DrinkDto
            {
                Id = drink.Id,
                Name = drink.Name,
                ShortDescription = drink.ShortDescription,
                Description = drink.Description,
                Author = drink.Author,
                ImageUrl = drink.ImageUrl,
                PublishedDate = drink.PublishedDate,
                Bases = drink.Bases.Select(x => new BaseDto
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToList(),
            };
            return Ok(response);
        }

        //GET:api/drinks
        [HttpGet]
        public async Task<IActionResult> GetAllDrink()
        {
            var drinks = await drinkRepository.GetAllAsync();
            //Convert Domain model to dto
            var response = new List<DrinkDto>();
            foreach(var drink in drinks)
            {
                response.Add(new DrinkDto
                {
                    Id = drink.Id,
                    Name = drink.Name,
                    ShortDescription = drink.ShortDescription,
                    Description = drink.Description,
                    Author = drink.Author,
                    ImageUrl = drink.ImageUrl,
                    PublishedDate = drink.PublishedDate,
                    Bases = drink.Bases.Select(x => new BaseDto
                    {
                        Id = x.Id,
                        Name = x.Name
                    }).ToList(),
                });
            }
            return Ok(response);
        }
    }
}
