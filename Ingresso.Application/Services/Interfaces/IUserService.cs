using Ingresso.Application.DTOs.UserDTOs;

namespace Ingresso.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<ResultService<AuthenticatedUserDTO>> LoginUserAsync(UserLoginDTO userLoginDTO);
        Task<ResultService<AuthenticatedUserDTO>> LoginViaGoogleAsync(string email);
        Task<ResultService<AuthenticatedUserDTO>> AuthUserAsync(string token);
        Task<ResultService<UserDTO>> GetUserProfileAsync(string token);
        Task<ResultService> CreateUserAsync(UserDTO userDTO);
        Task<ResultService> UpdateProfileAsync(UserDTO userDTO);
        Task<ResultService> ChangePasswordAsync(ChangePasswordDTO changePasswordDTO);
        Task<ResultService<string>> VerifyCodeAsync(VerifyCodeDTO verifyCodeDTO);
        Task<ResultService> ConfirmEmailUserAsync(string token);
        Task<ResultService> ResendCodeToEmailAsync(string email);
    }
}
