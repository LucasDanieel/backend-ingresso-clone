using Ingresso.Application.DTOs.CityDTOs;
using Ingresso.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ingresso.Api.Controllers
{
    [ApiController]
    [Route("city")]
    public class CityController : ControllerBase
    {
        private readonly ICityService _cityService;

        public CityController(ICityService cityService) => _cityService = cityService;

        [HttpGet]
        [Route("get")]
        public async Task<ActionResult> GetByName([FromQuery] string name)
        {
            var result = await _cityService.GetByNameAsync(name);
            if(result.IsSuccess)
                return Ok(result.Data);
            
            return BadRequest(result);
        }
        
        [HttpGet]
        [Route("get-by-slug")]
        public async Task<ActionResult> GetBySlug([FromQuery] string slug)
        {
            var result = await _cityService.GetBySlugAsync(slug);
            if(result.IsSuccess)
                return Ok(result.Data);
            
            return BadRequest(result);
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult> GetByName([FromBody] CityDTO cityDTO)
        {
            var result = await _cityService.CreateAsync(cityDTO);
            if(result.IsSuccess)
                return Ok(result);
            
            return BadRequest(result);
        }
    }
}
