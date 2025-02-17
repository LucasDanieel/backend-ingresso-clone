using Ingresso.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ingresso.Api.Controllers
{
    [Route("recaptcha")]
    public class RecaptchaController : ControllerBase
    {
        private readonly IRecaptchaService _recaptchaService;
        public RecaptchaController(IRecaptchaService recaptchaService) => _recaptchaService = recaptchaService;

        [HttpGet]
        [Route("validate")]
        public async Task<ActionResult> ValidateRecaptcha([FromQuery] string token_recaptcha)
        {
            var result = await _recaptchaService.ValidateRecaptchaAsync(token_recaptcha);
            if(result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }
    }
}
