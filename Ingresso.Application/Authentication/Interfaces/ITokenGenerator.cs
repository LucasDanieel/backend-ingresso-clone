using Ingresso.Application.DTOs;
using Ingresso.Domain.Entities;

namespace Ingresso.Application.Authentication.Interfaces
{
    public interface ITokenGenerator
    {
        public string GenerateConfirmationToken(User user);
        public string GenerateLoginToken(User user);
        public ClaimsDTO DecodToken(string token);
    }
}
