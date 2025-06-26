// Archivo: api-rest/Controllers/AuthController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using api_rest.Models;

namespace api_rest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _config;

        public AuthController(IConfiguration config)
        {
            _config = config;
        }

        // Registro (simplificado)
        [HttpPost("register")]
        public IActionResult Register([FromBody] UserDto request)
        {
            // Guardar usuario en la base de datos (simulado)
            return Ok(new { message = "Usuario registrado (simulado)" });
        }

        // Login con JWT
        [HttpPost("login")]
        public IActionResult Login([FromBody] UserDto request)
        {
            if (request.Username != "admin" || request.Password != "1234")
                return Unauthorized("Credenciales inválidas");

            var claims = new[] {
                new Claim(ClaimTypes.Name, request.Username),
                new Claim(ClaimTypes.Role, "usuario")
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds
            );

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });
        }
    }
}