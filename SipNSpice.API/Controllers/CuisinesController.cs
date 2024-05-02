using Microsoft.AspNetCore.Mvc;
using SipNSpice.API.Models.Domain;
using SipNSpice.API.Models.DTO;
using SipNSpice.API.Repositories.Interface;

namespace SipNSpice.API.Controllers
{
    //https://localhost:xxxx/api/cuisines
    [Route("api/[controller]")]
    [ApiController]
    public class CuisinesController : ControllerBase
    {
        private readonly ICuisineRepository cuisineRepository;

        public CuisinesController(ICuisineRepository cuisineRepository)
        {
            this.cuisineRepository = cuisineRepository;
        }

        //POST: Function to create Cuisine
        [HttpPost]
        public async Task<IActionResult> CreateCuisine([FromBody] CreateCuisineRequestDto createCuisineRequest)
        {
            //Map DTO to Domain Model
            var cuisine = new Cuisine
            {
                MainCuisine = createCuisineRequest.MainCuisine,
                SubCuisine = createCuisineRequest.SubCuisine
            };

            //Fetches the tasks in the Cuisine Repository <Createasync> function
            await cuisineRepository.CreateAsync(cuisine);

            //Map Domain model back to DTO
            var response = new CuisineDto
            {
                Id = cuisine.Id,
                MainCuisine = cuisine.MainCuisine,
                SubCuisine = cuisine.SubCuisine
            };

            return Ok (response);
        }

        //GET: /api/cuisines
        [HttpGet]
        public async Task<IActionResult> GetAllCuisine()
        {
            var cuisines = await cuisineRepository.GetAllAsync();
            //Map Domain model to DTO
            var response = new List<CuisineDto>();
            foreach(var cuisine in cuisines)
            {
                response.Add(new CuisineDto
                {
                    Id = cuisine.Id,
                    MainCuisine = cuisine.MainCuisine,
                    SubCuisine = cuisine.SubCuisine
                });
            }

            return Ok (response);
        }

        //GET: /api/cuisines/{id}
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetCuisineId([FromRoute] Guid id)
        {
            var existingCuisine = await cuisineRepository.GetByIdAsync(id);
            if (existingCuisine == null)
            {
                return NotFound();
            }
            //Map Domain model to Dto
            var response = new CuisineDto
            {
                Id = existingCuisine.Id,
                MainCuisine = existingCuisine.MainCuisine,
                SubCuisine = existingCuisine.SubCuisine
            };

            return Ok (response);
        }

        //PUT: /api/cuisines/{id}
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> EditCuisine([FromRoute] Guid id, UpdateCuisineRequestDto updateCuisineRequest)
        {
            //Convert DTO to Domain Model
            var cuisine = new Cuisine
            {
                Id = id,
                MainCuisine = updateCuisineRequest.MainCuisine,
                SubCuisine = updateCuisineRequest.SubCuisine
            };

            cuisine = await cuisineRepository.UpdateAsync(cuisine);

            if(cuisine == null)
            {
                return NotFound();
            }

            //Convert Domain model back to DTO
            var response = new CuisineDto
            {
                Id = cuisine.Id,
                MainCuisine = cuisine.MainCuisine,
                SubCuisine = cuisine.SubCuisine
            };
            return Ok (response);
        }

        //DELETE: /api/cuisines/{id}
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteCuisine([FromRoute] Guid id)
        {
            var cuisine = await cuisineRepository.DeleteAsync(id);
            if(cuisine is null)
            {
                return NotFound();
            }
            //Convert Domain model to Dto
            var response = new CuisineDto
            {
                Id = cuisine.Id,
                MainCuisine = cuisine.MainCuisine,
                SubCuisine = cuisine.SubCuisine
            };
            return Ok (response);
        }

    }
}
