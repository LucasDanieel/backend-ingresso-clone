namespace Ingresso.Application.DTOs.UserDTOs
{
    public class AuthenticatedUserDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string? Token { get; set; }
    }
}
