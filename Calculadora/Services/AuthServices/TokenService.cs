using Calculadora.Services.AuthServices;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Calculadora.Services.AuthServices
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        private readonly double _accessTokenExpirationMinutes;


        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
            _accessTokenExpirationMinutes = double.Parse(_configuration["Jwt:AccessTokenExpirationMinutes"]);

        }

        public string GenerateAccessToken(string userId)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:AccessTokenKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, userId),
            new Claim("TokenType", "access-token")
        };

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_accessTokenExpirationMinutes),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


        public DateTime GetAccessTokenExpiration()
        {
            return DateTime.UtcNow.AddMinutes(_accessTokenExpirationMinutes);
        }
    }
}
