using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Ingresso.Application.Authentication.Interfaces;
using Ingresso.Application.DTOs;
using Ingresso.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Ingresso.Application.Authentication
{
    public class TokenGenerator : ITokenGenerator
    {
        private readonly string secreteKey;
        public TokenGenerator(IConfiguration config)
        {
            secreteKey = config["MySettings:TokenSecretKey"];
        }

        public string GenerateConfirmationToken(User user)
        {
            var expires = DateTime.Now.AddDays(30);
            return GenerateToken(expires, user);
        }

        public string GenerateLoginToken(User user)
        {
            var expires = DateTime.Now.AddDays(10);
            return GenerateToken(expires, user);
        }

        public ClaimsDTO DecodToken(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var valiationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secreteKey))
            };

            try
            {
                var claims = handler.ValidateToken(token, valiationParameters, out SecurityToken validatedToken);
                var jwtToken = (JwtSecurityToken)validatedToken;

                Guid userId = Guid.Parse(jwtToken.Claims.First(x => x.Type == "Id").Value);
                string userName = jwtToken.Claims.First(x => x.Type == "Name").Value;

                var time = int.Parse(jwtToken.Claims.First(x => x.Type == "exp").Value);
                DateTimeOffset dt = DateTimeOffset.FromUnixTimeSeconds(time).ToLocalTime();

                if (dt.UtcDateTime > DateTime.Now)
                    return new ClaimsDTO { Id = userId, Name = userName };

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Token inválido: {ex.Message}");
            }

            return null;
        }

        private string GenerateToken(DateTime expires, User user)
        {
            var claims = new List<Claim>()
            {
                new Claim("Id", user.Id.ToString()),
                new Claim("Name", user.Name)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secreteKey));

            var token = new JwtSecurityToken(
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256),
                expires: expires,
                claims: claims);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
