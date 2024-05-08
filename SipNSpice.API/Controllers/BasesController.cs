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
    public class BasesController : ControllerBase
    {
        private readonly IBaseRepository baseRepository;

        public BasesController(IBaseRepository baseRepository)
        {
            this.baseRepository = baseRepository;
        }

        //POST:/api/bases
        [HttpPost]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> CreateBase(CreateBaseRequestDto createBaseRequest)
        {
            //Convert DTO to Domain model
            var bas = new Base
            {
                Name = createBaseRequest.Name
            };

            await baseRepository.CreateAsync(bas);

            //Convert DomainModel to DTO
            var response = new BaseDto
            {
                Id = bas.Id,
                Name = bas.Name
            };
            return Ok(response);
        }

        //GET:/api/bases
        [HttpGet]
        public async Task<IActionResult> GetAllBase()
        {
            var bases = await baseRepository.GetAllAsync();
            //Map dto to domain model
            var response = new List<BaseDto>();
            foreach(var bas in bases)
            {
                response.Add(new BaseDto
                {
                    Id = bas.Id,
                    Name = bas.Name
                });
            }
            return Ok(response);
        }

        //GETByID: /api/bases/{id}
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetBaseId([FromRoute] Guid id)
        {
            var existingBase = await baseRepository.GetByIdAsync(id);
            if(existingBase == null)
            {
                return NotFound();
            }
            //map domain model to dto
            var response = new BaseDto
            {
                Id = existingBase.Id,
                Name = existingBase.Name
            };
            return Ok(response);
        }

        //PUT: api/bases/{id}
        [HttpPut]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> EditBase([FromRoute] Guid id, UpdateBaseRequestDto updateBaseRequest)
        {
            //Convert DTO to domain model
            var bas = new Base
            {
                Id = id,
                Name = updateBaseRequest.Name,
            };
            bas = await baseRepository.UpdateAsync(bas);
            if(bas == null)
            {
                return null;
            }
            //Map Domain model to DTO
            var response = new BaseDto
            {
                Id = bas.Id,
                Name = bas.Name
            };
            return Ok(response);
        }

        //DELETE: api/bases/{id}
        [HttpDelete]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> DeleteBase([FromRoute] Guid id)
        {
            var bas = await baseRepository.DeleteAsync(id);
            if(bas is null)
            {
                return NotFound();
            }
            //Map Domainmodel to DTO
            var response = new BaseDto
            {
                Id = bas.Id,
                Name = bas.Name
            };
            return Ok(response);
        }
    }
}
