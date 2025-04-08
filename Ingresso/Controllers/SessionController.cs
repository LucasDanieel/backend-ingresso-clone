using Ingresso.Application.DTOs.SessionDTOs;
using Ingresso.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ingresso.Api.Controllers
{
    [ApiController]
    [Route("session")]
    public class SessionController : ControllerBase
    {
        private readonly ISessionService _sessionService;
        public SessionController(ISessionService sessionService) => _sessionService = sessionService;   

        [HttpGet]
        [Route("get")]
        public async Task<ActionResult> CreateAsync()
        {
            var result = await _sessionService.GetAsync();
            if(result.IsSuccess)
                return Ok(result);  

            return BadRequest(result);
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult> CreateAsync([FromBody] SessionDTO sessionDTO)
        {
            var result = await _sessionService.CreateAsync(sessionDTO);
            if(result.IsSuccess)
                return Ok(result);  

            return BadRequest(result);
        }
    }
}
