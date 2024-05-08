using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = "Writer")]
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

        //GET: {apibaeurl}/api/drinks/{id}
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetDrinkById([FromRoute] Guid id)
        {
            var drink = await drinkRepository.GetByIdAsync(id);
            if(drink == null)
            {
                return NotFound();
            }
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
                }).ToList()
            };
            return Ok(response);
        }

        //PUT:{apibaseurl}/api/drinks/{id}
        [HttpPut]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> UpdateDrink([FromRoute] Guid id, UpdateDrinkRequestDto updateDrinkRequest)
        {
            var drink = new Drink
            {
                Id = id,
                Name = updateDrinkRequest.Name,
                ShortDescription = updateDrinkRequest.ShortDescription,
                Description = updateDrinkRequest.Description,
                Author = updateDrinkRequest.Author,
                ImageUrl = updateDrinkRequest.ImageUrl,
                PublishedDate = updateDrinkRequest.PublishedDate,
                Bases = new List<Base>()
            };
            foreach(var baseGuid in updateDrinkRequest.Bases)
            {
                var existingDrink = await baseRepository.GetByIdAsync(baseGuid);
                if(existingDrink != null)
                {
                    drink.Bases.Add(existingDrink);
                }
            }
            var updatedDrink = await drinkRepository.UpdateAsync(drink);
            if(updatedDrink == null) 
            {
                return NotFound();
            }
            var response = new DrinkDto
            {
                Id = id,
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
                }).ToList()
            };
            return Ok(response);
        }

        //DELETE: {baseapiurl}/api/drinks/{id}
        [HttpDelete]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> DeleteDrink([FromRoute] Guid id)
        {
            var deletedDrink = await drinkRepository.DeleteAsync(id);
            if(deletedDrink == null )
            {
                return NotFound();
            }
            var response = new DrinkDto
            {
                Id = deletedDrink.Id,
                Name = deletedDrink.Name,
                ShortDescription = deletedDrink.ShortDescription,
                Description = deletedDrink.Description,
                Author = deletedDrink.Author,
                ImageUrl = deletedDrink.ImageUrl,
                PublishedDate = deletedDrink.PublishedDate,
            };
            return Ok(response);
        }
    }
}
