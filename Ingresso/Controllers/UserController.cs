using Ingresso.Application.DTOs.UserDTOs;
using Ingresso.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ingresso.Api.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService) => _userService = userService;

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult> LoginUser(UserLoginDTO userLoginDTO)
        {
            var result = await _userService.LoginUserAsync(userLoginDTO);
            if (result.IsSuccess)
                return Ok(result.Data);

            return BadRequest(result);
        }
        
        [HttpGet]
        [Route("login-via-google")]
        public async Task<ActionResult> LoginViaGoole([FromQuery] string email)
        {
            var result = await _userService.LoginViaGoogleAsync(email);
            if (result.IsSuccess)
                return Ok(result.Data);

            return BadRequest(result);
        }

        [HttpGet]
        [Route("auth")]
        public async Task<ActionResult> AuthUser([FromQuery] string token)
        {
            var result = await _userService.AuthUserAsync(token);
            if (result.IsSuccess)
                return Ok(result.Data);

            return BadRequest(result);
        }
        
        [HttpGet]
        [Route("get-profile")]
        public async Task<ActionResult> GetUserProfile([FromQuery] string token)
        {
            var result = await _userService.GetUserProfileAsync(token);
            if (result.IsSuccess)
                return Ok(result.Data);

            return BadRequest(result);
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult> CreateUser(UserDTO userCreateDTO)
        {
            var result = await _userService.CreateUserAsync(userCreateDTO);
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPut]
        [Route("update-profile")]
        public async Task<ActionResult> UpdateProfile([FromBody] UserDTO userDTO)
        {
            var result = await _userService.UpdateProfileAsync(userDTO);
            if (result.IsSuccess)
                return Ok(result.IsSuccess);

            return BadRequest(result);
        }
        
        [HttpPut]
        [Route("change-password")]
        public async Task<ActionResult> ChangePassword([FromBody] ChangePasswordDTO changePasswordDTO)
        {
            var result = await _userService.ChangePasswordAsync(changePasswordDTO);
            if (result.IsSuccess)
                return Ok(result.IsSuccess);

            return BadRequest(result);
        }

        [HttpPost]
        [Route("confirm-email")]
        public async Task<ActionResult> ConfirmEmail([FromQuery] string token)
        {
            var result = await _userService.ConfirmEmailUserAsync(token);
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPost]
        [Route("verify-code")]
        public async Task<ActionResult> VerifyCode([FromBody] VerifyCodeDTO verifyCodeDTO)
        {
            var result = await _userService.VerifyCodeAsync(verifyCodeDTO);
            if(result.IsSuccess)
                return Ok(result.Data);

            return NotFound(result);
        }
        
        [HttpGet]
        [Route("resend-code")]
        public async Task<ActionResult> ResendCodeToEmail([FromQuery] string email)
        {
            var result = await _userService.ResendCodeToEmailAsync(email);
            if(result.IsSuccess)
                return Ok(result.IsSuccess);

            return NotFound(result);
        }

    }
}
