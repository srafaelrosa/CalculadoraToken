using Calculadora.Models;
using Calculadora.Models.Responses;
using Calculadora.Services.AuthServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Calculadora.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ITokenService _tokenService;

        public AuthController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel model)
        {
            if (Validation(model.Username, model.Password))
            {
                var response = new TokenResponse
                {
                    AccessToken = _tokenService.GenerateAccessToken(model.Username),
                    ExpiresIn = (int)(_tokenService.GetAccessTokenExpiration() - DateTime.UtcNow).TotalSeconds
                };

                return Ok(response);


            }

            return Unauthorized(new { message = "Credenciais Invalidas" });

        }

        private bool Validation(string username, string password)
        {
            return (username == "Admin" && password == "1234");
        }




    }
}
