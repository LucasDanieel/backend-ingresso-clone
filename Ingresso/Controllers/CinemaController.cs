using Ingresso.Application.DTOs.CinemaDTOs;
using Ingresso.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ingresso.Api.Controllers
{
    [ApiController]
    [Route("cinema")]
    public class CinemaController : ControllerBase
    {
        private readonly ICinemaService _cinemaService;
        public CinemaController(ICinemaService cinemaService) => _cinemaService = cinemaService;

        [HttpGet]
        [Route("get")]
        public async Task<ActionResult> GetByCityId([FromQuery] int cityId)
        {
            var result = await _cinemaService.GetByCityIdAsync(cityId);
            if(result.IsSuccess) 
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet]
        [Route("get-slug")]
        public async Task<ActionResult> GetBySlug([FromQuery] string slug)
        {
            var result = await _cinemaService.GetBySlugAsync(slug);
            if(result.IsSuccess) 
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult> CreateAsync([FromBody] CinemaDTO cinemaDTO)
        {
            var result = await _cinemaService.CreateAsync(cinemaDTO);
            if(result.IsSuccess) 
                return Ok(result);

            return BadRequest(result);
        }
    }
}
