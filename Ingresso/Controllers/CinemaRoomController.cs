using Ingresso.Application.DTOs.CinemaRoomDTOs;
using Ingresso.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ingresso.Api.Controllers
{
    [ApiController]
    [Route("cinema-room")]
    public class CinemaRoomController : ControllerBase
    {
        private readonly ICinemaRoomService _cinemaRoomService;
        public CinemaRoomController(ICinemaRoomService cinemaRoomService) => _cinemaRoomService = cinemaRoomService;

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult> CreateAsync([FromBody] CinemaRoomDTO roomDTO)
        {
            var result = await _cinemaRoomService.CreateAsync(roomDTO);
            if(result.IsSuccess)
                return Ok(result);  

            return BadRequest(result);
        }
    }
}
